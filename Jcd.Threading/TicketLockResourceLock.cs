using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Jcd.Threading.Tasks;

namespace Jcd.Threading;

/// <summary>
/// Provides a mechanism for establishing and releasing locks on a <see cref="TicketLock"/>.
/// </summary>
/// <para>
/// Do not share instances of this type across threads. Behavior can be unpredictable.
/// Instances of this type are created by <see cref="TicketLock"/> to create a more
/// consistent experience when using synchronization primitives with other
/// <see cref="IResourceLock"/> types.
/// </para> 
public sealed class TicketLockResourceLock : ResourceLockBase
{
   private readonly TicketLock ticketLock;
   private          SpinWait   spinWait;

   /// <summary>
   /// The ticked Id for this instance.
   /// </summary>
   public long TicketId { get; }

   /// <summary>
   /// Indicates if the ticket has been canceled.
   /// </summary>
   public bool IsCanceled { get; private set; }

   internal TicketLockResourceLock(TicketLock ticketLock, long ticketId)
   {
      this.ticketLock = ticketLock;
      TicketId        = ticketId;
   }

   /// <summary>
   /// Waits for the `NowServing` on the owning <see cref="TicketLock"/>
   /// to match its own `TicketId`
   /// </summary>
   /// <returns>true if the lock was acquired, false otherwise (usually a cancellation)</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override bool Wait()
   {
      BeginWait();

      try
      {
         while (ticketLock.NowServing < TicketId && !IsCanceled)
            spinWait.SpinOnce();

         return LockAcquired();
      }
      finally
      {
         EndWait();
      }
   }

   /// <summary>
   /// Waits for the `NowServing` on the owning <see cref="TicketLock"/>
   /// to match its own `TicketId`
   /// </summary>
   /// <param name="token">the token to observe for cancellation.</param>
   /// <returns>true if the lock was acquired, false otherwise (usually a cancellation)</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override bool Wait(CancellationToken token)
   {
      BeginWait();

      try
      {
         while (ticketLock.NowServing < TicketId && !token.IsCancellationRequested)
            spinWait.SpinOnce();

         if (token.IsCancellationRequested)
            Cancel();

         return LockAcquired();
      }
      finally
      {
         EndWait();
      }
   }

   /// <summary>
   /// Asynchronously Waits for the `NowServing` on the owning <see cref="TicketLock"/>
   /// to match its own `TicketId`
   /// </summary>
   /// <returns>true if the lock was acquired, false otherwise (usually a cancellation)</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override async Task<bool> WaitAsync()
   {
      BeginWait();

      try
      {
         while (ticketLock.NowServing < TicketId && !IsCanceled)
            await Task.Yield();

         return LockAcquired();
      }
      finally
      {
         EndWait();
      }
   }

   /// <summary>
   /// Waits for the `NowServing` on the owning <see cref="TicketLock"/>
   /// to match its own `TicketId`
   /// </summary>
   /// <param name="token">the token to observe for cancellation.</param>
   /// <returns>true if the lock was acquired, false otherwise (usually a cancellation)</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override async Task<bool> WaitAsync(CancellationToken token)
   {
      BeginWait();

      try
      {
         while (ticketLock.NowServing < TicketId && !token.IsCancellationRequested)
            await Task.Yield();

         if (!token.IsCancellationRequested) return LockAcquired();
         Cancel();

         return false;
      }
      finally
      {
         EndWait();
      }
   }

   /// <summary>
   /// Cancels the ticket. This will register a background thread to do cleanup.
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public void Cancel()
   {
      IsCanceled = true;

      // intentionally non-awaited.
      #pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
      if (ticketLock.NowServing < TicketId)

         // ReSharper disable once HeapView.DelegateAllocation -- there is no other way to do this...
         TaskScheduler.Current.Run(async () =>
                                   {
                                      while (ticketLock.NowServing < TicketId) await Task.Yield();
                                      ticketLock.Release();
                                      ReleaseLock();
                                   }
                                  )
                      .ConfigureAwait(false);
      #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
   }

   /// <inheritdoc />
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override void Release()
   {
      if (!IsReleased || (IsCanceled && ticketLock.NowServing < TicketId))
         ticketLock.Release();
      ReleaseLock();
   }

   /// <summary>
   /// Releases any locks held.
   /// </summary>
   public override void Dispose() { Release(); }
}