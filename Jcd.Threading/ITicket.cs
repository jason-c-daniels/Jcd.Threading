using System;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMemberInSuper.Global

namespace Jcd.Threading;

/// <summary>
/// The supported interface guaranteed to be returned from
/// the appropriate methods of <see cref="TicketLock"/>
/// </summary>
public interface ITicket
   : IDisposable
{
   /// <summary>
   /// The ID for the ticket. These are issued out sequentially.
   /// </summary>
   long TicketId { get; }

   /// <summary>
   /// Indicates if the ticket was cancelled.
   /// </summary>
   bool IsCanceled { get; }

   /// <summary>
   /// Waits for the `NowServing` on the owning <see cref="TicketLock"/>
   /// to match its own `TicketId`
   /// </summary>
   /// <returns>true if the lock was acquired, false otherwise (usually a cancellation)</returns>
   bool Wait();

   /// <summary>
   /// Waits for the `NowServing` on the owning <see cref="TicketLock"/>
   /// to match its own `TicketId`
   /// </summary>
   /// <param name="token">the token to observe for cancellation.</param>
   /// <returns>true if the lock was acquired, false otherwise (usually a cancellation)</returns>
   bool Wait(CancellationToken token);

   /// <summary>
   /// Asynchronously Waits for the `NowServing` on the owning <see cref="TicketLock"/>
   /// to match its own `TicketId`
   /// </summary>
   /// <returns>true if the lock was acquired, false otherwise (usually a cancellation)</returns>
   Task<bool> WaitAsync();

   /// <summary>
   /// Waits for the `NowServing` on the owning <see cref="TicketLock"/>
   /// to match its own `TicketId`
   /// </summary>
   /// <param name="token">the token to observe for cancellation.</param>
   /// <returns>true if the lock was acquired, false otherwise (usually a cancellation)</returns>
   Task<bool> WaitAsync(CancellationToken token);

   /// <summary>
   /// Cancels the ticket. This will register a background thread to do cleanup.
   /// </summary>
   void Cancel();

   /// <summary>
   /// Releases the lock, if acquired.
   /// </summary>
   void Release();
}