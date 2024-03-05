using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global

namespace Jcd.Tasks;

/// <summary>
/// An item processor that calls a delegate on each item enqueued with it. 
/// </summary>
/// <remarks>
/// You must ensure all shared resources owned by the enqueued items have their access
/// synchronized appropriately. This type only synchronizes access to internal data.
/// </remarks>
public abstract class PauseableThreadWrapper  : IDisposable
{

   private readonly ApartmentState apartmentState;
   private readonly ThreadPriority priority;
   private readonly bool           useBackgroundThread;
   private readonly string         name;
   private readonly SemaphoreSlim  pauseSem = new(1, 1);
   private readonly SemaphoreSlim  idleSem  = new(1, 1);

   private bool                     isStarted;
   private SynchronizedValue<bool>  isIdle=new(true);
   private Thread                   thread;

   protected readonly CancellationTokenSource ThreadProcCancellationSource = new();

   /// <summary>
   /// Provides direct access to the underlying thread.
   /// </summary>
   public Thread Thread => thread;

   /// <summary>
   /// Gets a flag indicating if the item processing loop has started.
   /// </summary>
   public bool IsStarted => isStarted;

   /// <summary>
   /// Gets a flag indicating if the item processing is currently paused.
   /// </summary>
   public bool IsPaused => pauseSem.CurrentCount == 0;

   /// <summary>
   /// Gets a flag indicating if the item processing is currently paused.
   /// </summary>
   public bool IsIdle => isIdle.Value;

   /// <summary>
   /// Constructs a <see cref="PauseableThreadWrapper"/>
   /// </summary>
   /// <param name="name">The name of this PauseableThreadWrapper, propagated to the underlying thread.</param>
   /// <param name="useBackgroundThread">Indicates if the processing thread is a background thread.</param>
   /// <param name="autoStart">Indicates if the thread should be automatically started.</param>
   /// <param name="priority">The priority to start the processing thread at.</param>
   /// <param name="apartmentState">The apartment state for the underlying thread.</param>
   public PauseableThreadWrapper(
      bool           autoStart           = true
    , string?        name                = null
    , bool           useBackgroundThread = true
    , ThreadPriority priority            = ThreadPriority.Normal
    , ApartmentState apartmentState      = ApartmentState.Unknown
   )
   {
      this.name                = name ?? $"{GetType().Name}";
      this.useBackgroundThread = useBackgroundThread;
      this.priority            = priority;
      this.apartmentState      = apartmentState;
      if (autoStart) Start();
   }

   #region Queue Management and Processing Loop

   private AutoResetEvent waitEvent = new(false);

   void Wait(int milliseconds) { waitEvent.WaitOne(milliseconds); }

   protected virtual void ThreadProc()
   {
      try
      {
         isStarted = true;

         do
         {
            // wait if the IsPaused flag is set.
            PauseWait(ThreadProcCancellationSource);

            if (!PerformWork(ThreadProcCancellationSource))
               IdleWait(ThreadProcCancellationSource);
            
            if (ThreadProcCancellationSource.IsCancellationRequested)
               return;
         }
         while (GetShouldContinue(ThreadProcCancellationSource));

      }
      catch (Exception ex)
      {
         Debug.WriteLine($"Thread ending exception: {ex.Message}");
         Debug.Flush();
      }
      finally
      {
         isStarted = false;
         Resume();
         Debug.WriteLine($"Exiting {nameof(ThreadProc)}");
         Debug.Flush();
      }
   }

   /// <summary>
   /// Performs a single unit of work. Implement in derived types.
   /// </summary>
   /// <param name="cts">the token cancellation source to use</param>
   /// <returns>True if work thread is still active. False if should transition to idle.</returns>
   protected abstract bool PerformWork(CancellationTokenSource cts);

   /// <summary>
   /// Determines if the main thread loop should continue looping.
   /// </summary>
   /// <param name="threadProcCancellationSource">the source of cancellations</param>
   /// <returns>True if looping should continue. </returns>
   protected virtual bool GetShouldContinue(CancellationTokenSource threadProcCancellationSource) { return true; }

   protected virtual void IdleWait(CancellationTokenSource cancellationSource) => EnterIdleState(cancellationSource);

   protected virtual void PauseWait(CancellationTokenSource cancellationSource)
   {
      if (IsPaused)
         pauseSem.Wait(cancellationSource.Token);
   }
   
   protected virtual void EnterIdleState(CancellationTokenSource cancellationSource)
   {
      Debug.WriteLine($"{name} has become idle.");
      isIdle.Value = true;
      idleSem.Wait(cancellationSource.Token);
   }

   protected virtual void ExitIdleState()
   {
      if (idleSem.CurrentCount != 0) return;
      Debug.WriteLine($"{name} is no longer idle.");
      idleSem.Release();
      isIdle.Value = false;
   }

   protected void InternalStop(int joinTimeout = 0)
   {
      if (!ThreadProcCancellationSource.IsCancellationRequested)
         ThreadProcCancellationSource.Cancel();

      if (IsStarted && joinTimeout > 0)
         Thread.Join(joinTimeout); // wait 100ms for the thread to die.
   }

   #endregion

   #region Thread Management

   /// <summary>
   /// Pauses the retrieval and processing of queued items. 
   /// </summary>
   public void Pause()
   {
      if (IsPaused) return;
      pauseSem.Wait(ThreadProcCancellationSource.Token);
   }

   /// <summary>
   /// Resumes item processing.
   /// </summary>
   public void Resume()
   {
      if (!IsPaused) return;
      pauseSem.Release();
   }

   /// <summary>
   /// Pauses the retrieval and execution of queued items.
   /// </summary>
   public async Task PauseAsync()
   {
      if (IsPaused) return;
      await pauseSem.WaitAsync(ThreadProcCancellationSource.Token);
   }

   /// <summary>
   /// Resumes item processing.
   /// </summary>
   public Task ResumeAsync()
   {
      if (!IsPaused) return Task.CompletedTask;
      pauseSem.Release();

      return Task.CompletedTask;
   }

   /// <summary>
   /// Starts the processing of queued items.
   /// </summary>
   public void Start()
   {
      if (IsStarted) return;
      thread=CreateThread();
      thread.Start();
   }

   /// <summary>
   /// Starts the processing of queued items.
   /// </summary>
   public Task StartAsync()
   {
      if (IsStarted) return Task.CompletedTask;
      thread = CreateThread();
      thread.Start();
      return Task.CompletedTask;
   }
   public void Stop() { InternalStop(); }

   public Task StopAsync()
   {
      InternalStop();

      return Task.CompletedTask;
   }

   protected virtual Thread CreateThread()
   {
      var newThread = new Thread(ThreadProc)
                      {
                         Name = $"{name}.Thread", IsBackground = useBackgroundThread, Priority = priority
                      };

      if (apartmentState != ApartmentState.Unknown)
         newThread.TrySetApartmentState(apartmentState);

      return newThread;
   }

   #endregion

   #region Dispose Pattern

   private void Dispose(bool disposing)
   {
      if (!disposing) return;

      try
      {
         InternalStop();
      }
      catch
      {
         // intentionally ignored
      }

      if (!ThreadProcCancellationSource.IsCancellationRequested)
         ThreadProcCancellationSource.Cancel();

      ThreadProcCancellationSource.Dispose();
      pauseSem.Dispose();
      idleSem.Dispose();
   }

   /// <inheritdoc />
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   ~PauseableThreadWrapper() { Dispose(false); }

   #endregion

}