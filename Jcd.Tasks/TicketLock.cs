using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

public class TicketLock
{
   private long ticketCounter;
   private long nowServing;
   public  long MaxTicketCount => long.MaxValue;

   public long NowServing => nowServing;

   public long CurrentCount => ticketCounter - nowServing;
   
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
   public ITicket Lock()
   {
      var ticket = GetTicket();
      ticket.Wait();

      return ticket;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public ITicket Lock(CancellationToken token)
   {
      var ticket = GetTicket();
      ticket.Wait(token);

      return ticket;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<ITicket> LockAsync()
   {
      var ticket = GetTicket();
      await ticket.WaitAsync();

      return ticket;
   }
   
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<ITicket> LockAsync(CancellationToken token)
   {
      var ticket = GetTicket();
      await ticket.WaitAsync(token);

      return ticket;
   }
}