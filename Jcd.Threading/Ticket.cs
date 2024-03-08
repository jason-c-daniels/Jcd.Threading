using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Jcd.Threading.Tasks;

namespace Jcd.Threading;

internal class Ticket : ITicket
{
   private readonly TicketLock ticketLock;
   private          SpinWait   spinWait;
   public           long       TicketId { get; }

   public  bool IsReleased { get; private set; }
   public  bool IsCanceled { get; private set; }

   internal Ticket(TicketLock ticketLock, long ticketId)
   {
      this.ticketLock = ticketLock;
      TicketId        = ticketId;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public bool Wait()
   {
      while (ticketLock.NowServing < TicketId && !IsCanceled) 
         spinWait.SpinOnce();

      return true;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public bool Wait(CancellationToken token)
   {
      while (ticketLock.NowServing < TicketId && !token.IsCancellationRequested)
         spinWait.SpinOnce();

      if (token.IsCancellationRequested)
         Cancel();

      return !IsCanceled;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<bool> WaitAsync()
   {
      while (ticketLock.NowServing < TicketId && !IsCanceled) 
         await Task.Yield();

      return true;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<bool> WaitAsync(CancellationToken token)
   {
      while (ticketLock.NowServing < TicketId && !token.IsCancellationRequested)
         await Task.Yield();

      if (token.IsCancellationRequested)
         Cancel();

      return !IsCanceled;
   }

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

                                      IsReleased = true;
                                      ticketLock.Release();
                                   }
                                  )
                      .ConfigureAwait(false);
      #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public void Release()
   {
      IsReleased = true;
      ticketLock.Release();
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public void Dispose()
   {
      if (!IsReleased || (IsCanceled && ticketLock.NowServing < TicketId))
         Release();
   }
}