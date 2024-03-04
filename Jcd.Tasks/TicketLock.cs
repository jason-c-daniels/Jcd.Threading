using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

public class TicketLock
{
   //private           SpinWait      spinWait;
   private          long           ticketCounter;
   internal          long           nowServing;

   public           long           MaxTicketCount => long.MaxValue;

   public long NowServing => nowServing;
   
   public long CurrentCount => ticketCounter - nowServing;
   
   internal void Release()
   {
      Interlocked.Increment(ref nowServing);
   }
   
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public ITicket GetTicket()
   {
      return new Ticket(this, Interlocked.Increment(ref ticketCounter) - 1);
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public ITicket Lock() => Lock(CancellationToken.None);
   
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public ITicket Lock(CancellationToken token)
   {
      var ticket = GetTicket();
      ticket.Wait(token);
      return ticket;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public Task<ITicket> LockAsync() => LockAsync(CancellationToken.None);
   
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<ITicket> LockAsync(CancellationToken token)
   {
      var ticket = GetTicket();
      await ticket.WaitAsync(token);
      return ticket;
   }
}