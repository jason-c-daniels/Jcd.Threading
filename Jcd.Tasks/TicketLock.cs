using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

public class TicketLock(long maxTicketCount = long.MaxValue / 2) : IDisposable
{
   private readonly AutoResetEvent waiter   = new(false);
   private           SpinWait      spinWait;
   private          long           ticketCounter;
   private          long           nowServing;
   private readonly SemaphoreSlim  ticketLock  = new(1, 1);
   private readonly SemaphoreSlim  servingLock = new(1, 1);
   public           long           MaxTicketCount => maxTicketCount;

   public  long NowServing => nowServing;
   
   public  long TicketCount => ticketCounter - nowServing;
   
   private long GetNextTicket()
   {
      // spin-wait on ticketing numbers being updated.
      while (ticketLock.CurrentCount == 0) waiter.WaitOne(1);
      //using (ticketLock.Lock())
      {
         var ticket = Interlocked.Increment(ref ticketCounter) - 1;

         if (ticket < MaxTicketCount) return ticket;
         ticket %= MaxTicketCount;
         AdjustCounter(ticketLock
                     , ticketCounter
                     , (currentCount) => Interlocked.Exchange(ref ticketCounter, currentCount) % MaxTicketCount
                      );

         return ticket;
      }
   }
   
   private async Task<long> GetNextTicketAsync()
   {
      // spin-wait on ticketing numbers being updated.
      while (ticketLock.CurrentCount == 0) await Task.Yield();
      //using (await ticketLock.LockAsync())
      {

         var ticket = Interlocked.Increment(ref ticketCounter) - 1;

         if (ticket < MaxTicketCount) return ticket;
         ticket %= MaxTicketCount;
         await AdjustCounterAsync(ticketLock
                                , ticketCounter
                                , (currentCount) =>
                                     Interlocked.Exchange(ref ticketCounter, currentCount) % MaxTicketCount
                                 );

         return ticket;
      }
   }
   
   private void AdjustCounter(SemaphoreSlim sem, long currentCount, Func<long,long> getInterchangedValue)
   {
      if (currentCount        < MaxTicketCount) return;
      //while (sem.CurrentCount == 0) waiter.WaitOne(1);
      using (sem.Lock())
      {
         currentCount %= MaxTicketCount;
         
         var priorCount = getInterchangedValue(currentCount);

         while (priorCount > currentCount)
         {
            currentCount = priorCount;
            priorCount   = getInterchangedValue(currentCount);
            waiter.WaitOne(1);
         }
         // TODO: rewrite the value
      }
   }

   private async Task AdjustCounterAsync(SemaphoreSlim sem, long currentCount, Func<long,long> getInterchangedValue)
   {
      if (currentCount < MaxTicketCount) return;
      //while (sem.CurrentCount == 0) Task.Yield();
      using (await sem.LockAsync())
      {
         currentCount %= MaxTicketCount;
         
         var priorCount = getInterchangedValue(currentCount);

         while (priorCount > currentCount)
         {
            currentCount = priorCount;
            priorCount   = getInterchangedValue(currentCount);
            await Task.Yield();
         }
         // TODO: rewrite the value
      }
   }

   private long AcquireTicket(long ticket)
   {
      while (nowServing != ticket)
      {
         spinWait.SpinOnce();
      }

      return ticket;
   }
   
   private async Task<long> AcquireTicketAsync(long ticket)
   {
      while (nowServing != ticket)
      {
         await Task.Yield();
      }

      return ticket;
   }
   
   private void Release()
   {
      // spin-wait on ticketing numbers being updated.
      while (servingLock.CurrentCount == 0)
         waiter.WaitOne(1);

      var servingCount = Interlocked.Increment(ref nowServing);

      if (servingCount < MaxTicketCount) return;
      AdjustCounter(servingLock, nowServing, (currentCount)=>Interlocked.Exchange(ref nowServing, currentCount) % MaxTicketCount);
   }

   public void Dispose()
   {
      ticketLock.Dispose();
      servingLock.Dispose();
   }

   public Ticket Lock()
   {
      return new Ticket(this, AcquireTicket(GetNextTicket()));
   }

   public async Task<Ticket> LockAsync()
   {
      return new Ticket(this, await AcquireTicketAsync(await GetNextTicketAsync()));
   }

   public class Ticket(TicketLock ticketLock, long ticketId) : IDisposable
   {
      public long TicketId=>ticketId;
      public void Dispose() => ticketLock.Release();
   }
}