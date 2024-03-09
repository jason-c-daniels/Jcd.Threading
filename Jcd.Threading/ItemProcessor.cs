using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global

namespace Jcd.Threading;

/// <summary>
/// Provides the ability to call a delegate on each item in an internally managed queue
/// from its own background thread.
/// </summary>
/// <remarks>
/// You must ensure all shared resources owned by the enqueued items have their access
/// synchronized appropriately. This type only synchronizes access to internal data.
/// </remarks>
public sealed class ItemProcessor<TItem> : ThreadWrapper
{
   private readonly Action<TItem?> action;

   /// <summary>
   /// Constructs a <see cref="ItemProcessor{TItem}"/>
   /// </summary>
   /// <param name="action">The action to execute on each item.</param>
   /// <param name="name">The name of this ItemProcessor, propagated to the underlying thread.</param>
   /// <param name="useBackgroundThread">Indicates if the processing thread is a background thread.</param>
   /// <param name="autoStart">Indicates if the thread should be automatically started.</param>
   /// <param name="timeToYieldInMs">Indicates the amount of time to yield pass through the main loop. Only positive values will cause a yield.</param>
   /// <param name="idleAfterEmptyQueueCount">the number of iterations with no items in the queue before transitioning to the idle state. Set to -1 to disable idle state detection and transition.</param>
   /// <param name="priority">The priority to start the processing thread at.</param>
   /// <param name="apartmentState">The apartment state for the underlying thread.</param>
   public ItemProcessor(
      Action<TItem?> action
    , bool           autoStart                = true
    , string?        name                     = null
    , bool           useBackgroundThread      = true
    , int            timeToYieldInMs          = 15
    , int            idleAfterEmptyQueueCount = 15
    , ThreadPriority priority                 = ThreadPriority.Normal
    , ApartmentState apartmentState           = ApartmentState.Unknown
   ) : base(false
          , name
          , useBackgroundThread
          , timeToYieldInMs
          , idleAfterEmptyQueueCount
          , priority
          , apartmentState
           )
   {
      this.action = action ?? throw new ArgumentNullException(nameof(action));
      if (autoStart) Start();
   }

   /// <summary>
   /// Grabs the first item in the queue and performs the user provided action on it.
   /// </summary>
   /// <param name="token">The token to inspect for cancellation.</param>
   /// <returns>True if there are pending items after the work is performed.</returns>
   protected override bool PerformWork(CancellationToken token)
   {
      if (token.IsCancellationRequested)
         return false;

      switch (HasItems)
      {
         case true when TryPeek(token, out var item):
            action(item);
            Dequeue(token);

            break;
      }

      return HasItems;
   }

   #region Queue Management

   private readonly SemaphoreSlim queueSem = new(1, 1);

   private readonly Queue<TItem> itemQueue = new();

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

   /// <summary>
   /// Gets a flag indicating if there are any pending items.
   /// </summary>
   public bool HasItems => Count > 0;

   /// <summary>
   /// Clears all items out of the queue. USE AT YOUR OWN RISK!
   /// </summary>
   public void Clear()
   {
      using (GetQueueLock())
         itemQueue.Clear();
   }

   /// <summary>
   /// Asynchronously clears all items out of the queue. USE AT YOUR OWN RISK!
   /// </summary>
   public async Task ClearAsync()
   {
      using (await GetQueueLockAsync())
         itemQueue.Clear();
   }

   /// <summary>
   /// Enqueues an item. Control is immediately
   /// returned to the caller.
   /// </summary>
   /// <param name="item">The action to enqueue.</param>
   public void Enqueue(TItem item)
   {
      using (GetQueueLock())
         itemQueue.Enqueue(item);
      ExitIdleState();
   }

   /// <summary>
   /// Enqueues an item asynchronously. Control is immediately
   /// returned to the caller.
   /// </summary>
   /// <param name="item">The action to enqueue.</param>
   public async Task EnqueueAsync(TItem item)
   {
      using (await GetQueueLockAsync())
         itemQueue.Enqueue(item);
      ExitIdleState();
   }

   private void Dequeue(CancellationToken cancellationSource)
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

   private IResourceLock GetQueueLock() { return queueSem.Lock(CancellationToken); }

   private async Task<IResourceLock> GetQueueLockAsync() { return await queueSem.LockAsync(CancellationToken); }

   private bool TryPeek(CancellationToken cancellationSource, out TItem? item)
   {
      item = default;

      if (cancellationSource.IsCancellationRequested)
         return false;

      using (GetQueueLock())
      {
         if (itemQueue.Count == 0)
            return false;

         item = itemQueue.Peek();

         return true;
      }
   }

   #endregion

   #region Dispose Pattern

   /// <summary>
   /// Cleans up other disposables.
   /// </summary>
   /// <param name="disposing"></param>
   protected override void Dispose(bool disposing)
   {
      if (!disposing) return;

      try
      {
         using (GetQueueLock())
         {
            Stop();
            Clear();
         }
      }
      catch
      {
         // intentionally ignored
      }

      base.Dispose(disposing);
      queueSem.Dispose();
   }

   #endregion
}