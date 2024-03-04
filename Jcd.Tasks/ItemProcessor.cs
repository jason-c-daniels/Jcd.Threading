using System;
using System.Collections.Generic;
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
public sealed class ItemProcessor<TItem> : IDisposable
{
   private readonly CancellationTokenSource itemProcessingCancellation = new();
   
   private readonly Queue<TItem> itemQueue = new();

   private readonly SemaphoreSlim queueSem = new(1, 1);
   private readonly SemaphoreSlim pauseSem = new(1, 1);
   private readonly SemaphoreSlim idleSem  = new(1, 1);

   private readonly MutexValue<bool>   isStarted  = new();
   private readonly MutexValue<Thread> threadSync = new();
   
   private readonly Action<TItem?>            action;
   private readonly ApartmentState            apartmentState;
   private readonly ThreadPriority            priority;
   private readonly bool                      useBackgroundThread;
   private readonly string                    name;

   /// <summary>
   /// Provides direct access to the underlying thread.
   /// </summary>
   public Thread Thread => threadSync.Value;

   /// <summary>
   /// 
   /// </summary>
   public IReadOnlyCollection<TItem> Items
   {
      get
      {
         using (GetQueueLock())
            return itemQueue.ToArray();
      }
   }

   /// <summary>
   /// The number of items in the internal queue.
   /// </summary>
   public int Count
   {
      get
      {
         using (GetQueueLock())
            return itemQueue.Count;
      }
   }

   private IDisposable GetQueueLock()
   {
      return queueSem.Lock(itemProcessingCancellation.Token);
   }

   private Task<IDisposable> GetQueueLockAsync()
   {
      return queueSem.LockAsync(itemProcessingCancellation.Token);
   }

   /// <summary>
   /// Gets a flag indicating if there are any pending items.
   /// </summary>
   public bool HasItems => Count > 0;

   /// <summary>
   /// Gets a flag indicating if the item processing loop has started.
   /// </summary>
   public bool IsStarted => isStarted.Value;

   /// <summary>
   /// Gets a flag indicating if the item processing is currently paused.
   /// </summary>
   public bool IsPaused => pauseSem.CurrentCount == 0;

   /// <summary>
   /// Gets a flag indicating if the item processing is currently paused.
   /// </summary>
   public bool IsIdle => Count == 0;

   /// <summary>
   /// Constructs a <see cref="ItemProcessor{TItem}"/>
   /// </summary>
   /// <param name="action">The action to execute on each item.</param>
   /// <param name="name">The name of this ItemProcessor, propagated to the underlying thread.</param>
   /// <param name="useBackgroundThread">Indicates if the processing thread is a background thread.</param>
   /// <param name="autoStart">Indicates if the thread should be automatically started.</param>
   /// <param name="priority">The priority to start the processing thread at.</param>
   /// <param name="apartmentState">The apartment state for the underlying thread.</param>
   public ItemProcessor(
      Action<TItem?> action
    , bool           autoStart           = true
    , string?        name                = null
    , bool           useBackgroundThread = true
    , ThreadPriority priority            = ThreadPriority.Normal
    , ApartmentState apartmentState      = ApartmentState.Unknown
   )
   {
      this.action              = action ?? throw new ArgumentNullException(nameof(action));
      this.name                = name   ?? $"{GetType().Name}";
      this.useBackgroundThread = useBackgroundThread;
      this.priority            = priority;
      this.apartmentState      = apartmentState;
      if (autoStart) Start();
   }

   #region Queue Management and Processing Loop

   /// <summary>
   /// Enqueues a <see cref="TItem"/>. This is a "fire and forget" method. Control is immediately
   /// returned to the caller.
   /// </summary>
   /// <param name="item">The action to enqueue.</param>
   public void Enqueue(TItem item)
   {
      using (GetQueueLock())
         itemQueue.Enqueue(item);
      ExitIdleState();
   }

   private void InternalClear()
   {
      Debug.WriteLine(nameof(InternalClear));
      itemQueue.Clear();
   }

   private void ItemProcessingLoop()
   {
      try
      {
         isStarted.Value=true;

         using var waitEvent = new AutoResetEvent(false);
         var       counter   = 0;

         do
         {
            counter++;
            counter %= 10;
            if (counter == 0) waitEvent.WaitOne(15); // yield a little bit of time.

            if (itemProcessingCancellation.IsCancellationRequested)
               return;
         }
         while (ProcessNextItem(itemProcessingCancellation));

      }
      catch (Exception ex)
      {
         Debug.WriteLine($"Thread ending exception: {ex.Message}");
         Debug.Flush();
      }
      finally
      {
         isStarted.SetValue(false);
         Resume();
         Debug.WriteLine($"Exiting {nameof(ItemProcessingLoop)}");
         Debug.Flush();
      }
   }

   private bool ProcessNextItem(CancellationTokenSource cancellationSource)
   {
      // wait if the IsPaused flag is set.
      PauseWait(cancellationSource);

      switch (HasItems)
      {
         case true when TryPeek(cancellationSource, out var item):
            action(item);
            Dequeue(cancellationSource);
            break;
      }

      // wait if the IsIdle flag is set. 
      IdleWait(cancellationSource);

      return !cancellationSource.IsCancellationRequested;
   }

   private void PauseWait(CancellationTokenSource cancellationSource)
   {
      if (IsPaused)
         pauseSem.Wait(cancellationSource.Token);
   }

   private void IdleWait(CancellationTokenSource cancellationSource)
   {
      if (HasItems) return;
      EnterIdleState(cancellationSource);
   }

   private void EnterIdleState(CancellationTokenSource cancellationSource)
   {
      Debug.WriteLine($"{name} has become idle.");
      if (IsIdle) idleSem.Wait(cancellationSource.Token);
   }

   private void ExitIdleState()
   {
      if (idleSem.CurrentCount != 0) return;
      Debug.WriteLine($"{name} is no longer idle.");
      idleSem.Release();
   }

   private bool TryPeek(CancellationTokenSource cancellationSource, out TItem? item)
   {
      item = default;

      using (GetQueueLock())
      {
         if (cancellationSource.IsCancellationRequested)
            return false;

         if (itemQueue.Count == 0)
            return false;

         item = itemQueue.Peek();

         return true;
      }
   }

   private void Dequeue(CancellationTokenSource cancellationSource)
   {
      using (GetQueueLock())
      {
         if (cancellationSource.IsCancellationRequested)
            return;

         if (itemQueue.Count == 0)
            return;

         itemQueue.Dequeue();
      }
   }

   private void InternalStop()
   {
      if (!itemProcessingCancellation.IsCancellationRequested)
         itemProcessingCancellation.Cancel();

      if (IsStarted)
         Thread.Join(100); // wait 100ms for the thread to die.
   }

   #endregion

   #region Thread Management

   /// <summary>
   /// Pauses the retrieval and processing of queued items. 
   /// </summary>
   public void Pause()
   {
          if (IsPaused) return;
          pauseSem.Wait(itemProcessingCancellation.Token);
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
      await pauseSem.WaitAsync(itemProcessingCancellation.Token);
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
      threadSync.SetValue(CreateThread()).Start();
   }

   public void Stop()
   {
      using (GetQueueLock())
         InternalStop();
   }
   
   public async Task StopAsync()
   {
      using (await GetQueueLockAsync())
         InternalStop();
   }
   
   public void Clear()
   {
      using (GetQueueLock())
         InternalStop();
   }
   
   public async Task ClearAsync()
   {
      using (await GetQueueLockAsync())
         InternalStop();
   }
   
   private Thread CreateThread()
   {
      var newThread = new Thread(ItemProcessingLoop)
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
      using (GetQueueLock())
      {
         try
         {
            InternalStop();
            InternalClear();
         }
         catch
         {
            // intentionally ignored
         }
      }

      itemProcessingCancellation.Cancel();
      itemProcessingCancellation.Dispose();
      pauseSem.Dispose();
      idleSem.Dispose();
      queueSem.Dispose();
      threadSync.Dispose();
   }

   /// <inheritdoc />
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   ~ItemProcessor() { Dispose(false); }

   #endregion

}