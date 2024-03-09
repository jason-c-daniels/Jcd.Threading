using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace Jcd.Threading;

/// <summary>
/// Provides a naiive implementation of a <see href="https://en.wikipedia.org/wiki/Ticket_lock">Ticket lock (wikipedia)</see> with cancellation support.
/// </summary>
/// <remarks>
/// <para>
/// For a technical reference on Ticket Locks see: <see href="https://medium.com/@shivajiofficial5088/ticket-locking-algorithm-fair-lock-delivery-mechanism-fdfe04b0b94b">Ticket Locking Algorithm : Fair Lock Delivery Mechanism</see>
/// </para> 
/// <para>
/// For further reading see the <see href="https://en.wikipedia.org/wiki/Ticket_lock">Wikipedia Article on Ticket locks</see>.
/// </para> 
/// </remarks>
public class TicketLock : IResourceLockFactory<TicketLockResourceLock>
{
   private long ticketCounter;
   private long nowServing;

   /// <summary>
   /// The maximum number of possible tickets. (At 1 per 20ms this should last 350 years of continuous run time.)
   /// </summary>
   public static long MaxTicketCount => long.MaxValue;

   /// <summary>
   /// The ticket currently holding the lock.
   /// </summary>
   public long NowServing => nowServing;

   /// <summary>
   /// The total number of pending tickets.
   /// </summary>
   public long CurrentCount => ticketCounter - nowServing;

   /// <summary>
   /// Increment's NowServing so that the next thread
   /// can begin processing.
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   internal void Release() { Interlocked.Increment(ref nowServing); }

   /// <summary>
   /// Creates an <see cref="TicketLockResourceLock"/>.
   /// </summary>
   /// <remarks>
   /// WARNING: This is for advanced use cases only. Failing to release the lock
   /// will deadlock all other tickets with a larger TicketId. However, calling release
   /// on the ticket before this <see cref="TicketLock"/> has NowServing set to the
   /// new ticket's ID will cause a race condition between the code locked by
   /// this specific ticket and the next immediately higher lock.  
   /// </remarks>
   /// <returns>The new ticket.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public TicketLockResourceLock GetResourceLock()
   {
      return new TicketLockResourceLock(this, Interlocked.Increment(ref ticketCounter) - 1);
   }

   /// <summary>
   /// Creates an <see cref="TicketLockResourceLock"/> and waits on it.
   /// </summary>
   /// <returns>The ticket once the lock is acquired.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public TicketLockResourceLock Lock()
   {
      var ticket = GetResourceLock();
      ticket.Wait();

      return ticket;
   }

   /// <summary>
   /// Creates an <see cref="TicketLockResourceLock"/> and waits on it.
   /// </summary>
   /// <param name="token">The token to listen for cancellation on.</param>
   /// <returns>The ticket once the lock is acquired.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public TicketLockResourceLock Lock(CancellationToken token)
   {
      var ticket = GetResourceLock();
      ticket.Wait(token);

      return ticket;
   }

   /// <summary>
   /// Asynchronously creates an <see cref="TicketLockResourceLock"/> and waits on it.
   /// </summary>
   /// <returns>The ticket once the lock is acquired.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<TicketLockResourceLock> LockAsync()
   {
      var ticket = GetResourceLock();
      await ticket.WaitAsync();

      return ticket;
   }

   /// <summary>
   /// Asynchronously creates an <see cref="TicketLockResourceLock"/> and waits on it.
   /// </summary>
   /// <param name="token">The token to listen for cancellation on.</param>
   /// <returns>The ticket once the lock is acquired.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<TicketLockResourceLock> LockAsync(CancellationToken token)
   {
      var ticket = GetResourceLock();
      await ticket.WaitAsync(token);

      return ticket;
   }
}