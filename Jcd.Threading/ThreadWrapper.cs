using System;
using System.Diagnostics;
using System.Threading;

using Jcd.Threading.SynchronizedValues;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable VirtualMemberNeverOverridden.Global
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global

namespace Jcd.Threading;

/// <summary>
/// Provides basic thread management facilities such as Pause, Resume, Stop, Start and
/// entering and exiting the idle state. 
/// </summary>
/// <remarks>
/// `Stop` will shutdown the underlying thread completely, and a subsequent call to Start will
/// create a brand new thread (with associated cancellation token), while Pause and
/// Resume will suspend the thread operations at the appropriate time in the main loop.
/// </remarks>
public abstract class ThreadWrapper : IDisposable
{
   /// <summary>
   /// Constructs a <see cref="ThreadWrapper"/>
   /// </summary>
   /// <param name="name">The name of this <see cref="ThreadWrapper"/>, propagated to the underlying thread as "{name}.Thread".</param>
   /// <param name="useBackgroundThread">Indicates if the processing thread is a background thread.</param>
   /// <param name="autoStart">Indicates if the thread should be automatically started in the constructor.</param>
   /// <param name="timeToYieldInMs">The amount of CPU time to yield per cycle through the main loop</param>
   /// <param name="idleAfterEmptyQueueCount">the number of iterations with no work before transitioning to the idle state. Set to -1 to disable idle state detection and transition.</param>
   /// <param name="priority">The priority to start the processing thread at.</param>
   /// <param name="apartmentState">The apartment state for the underlying thread.</param>
   /// <param name="yieldEachCycle">A flag indicating if CPU time is yielded each pass through the main loop.</param>
   /// <remarks>
   /// <para>
   /// NOTE: The underlying thread is not created until the first call to `Start` and will change when calling `Stop`
   /// followed by `Start`. This is because the thread ends completely with a call to `Stop`.
   /// </para>
   /// <para>
   /// If resuming  the same thread is the desired behavior, call `Pause` and `Resume` instead.
   /// </para> 
   /// </remarks>
   protected ThreadWrapper(
      bool           autoStart                = true
    , string?        name                     = null
    , bool           useBackgroundThread      = true
    , bool           yieldEachCycle           = true
    , int            timeToYieldInMs          = 15
    , int            idleAfterEmptyQueueCount = 15
    , ThreadPriority priority                 = ThreadPriority.Normal
    , ApartmentState apartmentState           = ApartmentState.Unknown
   )
   {
      if (yieldEachCycle && timeToYieldInMs < 1)
         throw new ArgumentException("must be greater than or equal to 1", nameof(timeToYieldInMs));

      Name                          = name ?? $"{GetType().Name}";
      isIdleDetectionDisabled       = idleAfterEmptyQueueCount < 0;
      this.useBackgroundThread      = useBackgroundThread;
      this.yieldEachCycle           = yieldEachCycle;
      this.timeToYieldInMs          = timeToYieldInMs;
      this.idleAfterEmptyQueueCount = idleAfterEmptyQueueCount;
      this.priority                 = priority;
      this.apartmentState           = apartmentState;
      if (autoStart) Start();
   }

   #region Thread Creation and Related

   private readonly ApartmentState                     apartmentState;
   private readonly ThreadPriority                     priority;
   private readonly bool                               useBackgroundThread;
   private readonly bool                               yieldEachCycle;
   private readonly int                                timeToYieldInMs;
   private readonly int                                idleAfterEmptyQueueCount;
   private readonly ReaderWriterLockSlimValue<Thread?> thread = new();

   /// <summary>
   /// The name of this instance of the <see cref="ThreadWrapper"/>.
   /// By default the underlying thread will be named as follows:
   /// `$"{Name}.Thread"`
   /// </summary>
   public string Name { get; }

   /// <summary>
   /// Provides direct access to the underlying thread.
   /// </summary>
   public Thread? Thread => thread.Value;

   private Thread CreateThread()
   {
      var newThread = new Thread(ThreadProc)
                      {
                         Name = $"{Name}.Thread", IsBackground = useBackgroundThread, Priority = priority
                      };

      if (apartmentState != ApartmentState.Unknown)
         newThread.TrySetApartmentState(apartmentState);

      if (cancellationSource.IsCancellationRequested)
         cancellationSource = new CancellationTokenSource();

      return newThread;
   }

   /// <summary>
   /// The main thread control loop. 
   /// </summary>
   /// <remarks>
   /// <para>
   /// You should only override this for advanced use cases.
   /// Override `GetShouldContinue` for determining when the thread ends.
   /// Override `PerformWork` to do a single unit of work on each pass through the loop.
   /// </para>
   /// <para>
   /// If you choose to override this and supply your own main loop for the thread,
   /// You will need to check for cancellation, Call `IdleWait` and `PauseWait`
   /// at the appropriate time in your loop, as well as `YieldCpuTime` to ensure
   /// your thread doesn't monopolize the CPU.
   /// use cases. 
   /// </para>
   /// </remarks>
   protected virtual void ThreadProc()
   {
      try
      {
         var token = CancellationToken;

         do
         {
            DoWorkAndIdleDetection(token);

            if (token.IsCancellationRequested)
               return;

            DoIdleOrYield(token);

            if (token.IsCancellationRequested)
               return;

            PauseWait(token);

            if (token.IsCancellationRequested)
               return;
         }
         while (GetShouldContinue(token));
      }
      catch (Exception ex)
      {
         Debug.WriteLine($"Thread ending exception: {ex.Message}");
         Debug.Flush();
      }
      finally
      {
         PerformThreadStateCleanup();
         Debug.WriteLine($"Exiting {nameof(ThreadProc)}");
         Debug.Flush();
      }
   }

   private int noWorkCounter;

   private void DoWorkAndIdleDetection(CancellationToken token)
   {
      var meaningfulWorkPerformed = PerformWork(token);

      if (isIdleDetectionDisabled) return;

      if (meaningfulWorkPerformed)
      {
         noWorkCounter = 0;
      }
      else
      {
         noWorkCounter++;
         if (idleAfterEmptyQueueCount < noWorkCounter)
            EnterIdleState();
      }
   }

   private void DoIdleOrYield(CancellationToken token)
   {
      if (!IdleWait(token) && yieldEachCycle)
         YieldCpuTime(timeToYieldInMs);
   }

   /// <summary>
   /// Performs a single unit of work. Implement in derived types not overriding ThreadProc.
   /// </summary>
   /// <param name="token">the token cancellation token to use</param>
   /// <returns>
   /// True if meaningful work was done. False if the it should transition to idle
   /// after this call.
   /// </returns>
   protected virtual bool PerformWork(CancellationToken token) { return false; }

   private readonly AutoResetEvent waitEvent = new(false);

   // ReSharper disable once MemberCanBePrivate.Global -- intended to be called by derived types.
   /// <summary>
   /// Yields very small amounts of CPU time. This can approach 1ms.
   /// Thread.Sleep and Task.Delay will wait at least 15ms.
   /// </summary>
   /// <param name="timeToYieldInMilliseconds">The amount of time to wait, in milliseconds.</param>
   protected void YieldCpuTime(int timeToYieldInMilliseconds) { waitEvent.WaitOne(timeToYieldInMilliseconds); }

   #endregion

   #region Protected Thread Management

   private          CancellationTokenSource cancellationSource = new();
   private readonly SemaphoreSlim           pauseSem           = new(1, 1);
   private readonly SemaphoreSlim           idleSem            = new(1, 1);

   private readonly ReaderWriterLockSlimValue<bool> isPaused = new();
   private readonly ReaderWriterLockSlimValue<bool> isIdle   = new(true);
   private readonly bool                            isIdleDetectionDisabled;

   /// <summary>
   /// Gives derived types access to the <see cref="CancellationToken"/>
   /// </summary>
   protected CancellationToken CancellationToken => cancellationSource.Token;

   /// <summary>
   /// Gets a flag indicating if the item processing loop has started.
   /// </summary>
   public bool IsStarted { get; private set; }

   /// <summary>
   /// Gets a flag indicating if the item processing is currently paused.
   /// </summary>
   public bool IsPaused => isPaused.Value;

   /// <summary>
   /// Gets a flag indicating if the item processing is currently paused.
   /// </summary>
   public bool IsIdle => isIdle.Value;

   /// <summary>
   /// Determines if the main thread loop should continue looping.
   /// </summary>
   /// <param name="token">the token to check for cancellation</param>
   /// <returns>True if the main thread loop should continue.</returns>
   protected virtual bool GetShouldContinue(CancellationToken token) { return !token.IsCancellationRequested; }

   /// <summary>
   /// Ensures thread state is reset to final, including cancellation.
   /// This is called as a thread is exiting..
   /// </summary>
   protected void PerformThreadStateCleanup()
   {
      #if CANCEL_STATES
      if (!cancellationSource.IsCancellationRequested)
         cancellationSource.Cancel();
      if (IsIdle) ExitIdleState();
      if (IsPaused) ExitPausedState();
      #endif
      IsStarted = false;
   }

   /// <summary>
   /// Wait in idle state, if the IsIdle flag is set.
   /// </summary>
   /// <param name="token">the token to observe for cancellation.</param>
   /// <returns>true if we waited in the idle state.</returns>
   protected bool IdleWait(CancellationToken token)
   {
      if (!IsIdle || token.IsCancellationRequested) return false;
      idleSem.Wait(token);

      return true;
   }

   /// <summary>
   /// Wait in the paused state if the IsPaused flag is set.
   /// </summary>
   /// <param name="token">the token to observe for cancellation.</param>
   protected void PauseWait(CancellationToken token)
   {
      if (token.IsCancellationRequested) return;
      if (IsPaused)
         pauseSem.Wait(token);
   }

   /// <summary>
   /// Sets the thread into the idle state.
   /// </summary>
   protected void EnterIdleState() { isIdle.Value = true; }

   /// <summary>
   /// Causes the owning thread to resume. This must be called by an external thread.
   /// </summary>
   protected void ExitIdleState()
   {
      if (idleSem.CurrentCount > 0) return;
      Debug.WriteLine($"{Name} is no longer idle.");
      isIdle.Value = false;
      idleSem.Release();
   }

   /// <summary>
   /// Puts the thread into the Paused state.
   /// </summary>
   protected void EnterPausedState() { isPaused.Value = true; }

   /// <summary>
   /// Causes the thread to exit the paused state. This must be called by
   /// an external thread.
   /// </summary>
   protected void ExitPausedState()
   {
      if (pauseSem.CurrentCount == 0) pauseSem.Release();
      isPaused.Value = false;
   }

   #endregion

   #region Public Thread Management

   /// <summary>
   /// Pauses the retrieval and processing of queued items. 
   /// </summary>
   public void Pause() { EnterPausedState(); }

   /// <summary>
   /// Resumes item processing.
   /// </summary>
   public void Resume() { ExitPausedState(); }

   // ReSharper disable once MemberCanBeProtected.Global -- intended to be called by other classes.
   /// <summary>
   /// Starts the processing of queued items.
   /// </summary>
   public void Start()
   {
      if (IsStarted) return;
      IsStarted    = true;
      thread.Value = CreateThread();
      thread.Value.Start();
   }

   /// <summary>
   /// Shuts down the thread through the CancellationToken
   /// </summary>
   public void Stop()
   {
      if (!IsStarted) return;
      if (!cancellationSource.IsCancellationRequested)
         cancellationSource.Cancel();
   }

   #endregion

   #region Dispose Pattern

   /// <summary>
   /// Disposes of resources.
   /// </summary>
   /// <param name="disposing">indicates if it's actually being disposed vs garbage collected</param>
   protected virtual void Dispose(bool disposing)
   {
      if (!disposing) return;

      try
      {
         Stop();
      }
      catch
      {
         // intentionally ignored
      }

      isPaused.Dispose();
      isIdle.Dispose();
      waitEvent.Dispose();
      pauseSem.Dispose();
      idleSem.Dispose();
      cancellationSource.Dispose();
   }

   /// <inheritdoc />
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   /// <summary>
   /// finalizes the object.
   /// </summary>
   ~ThreadWrapper() { Dispose(false); }

   #endregion
}