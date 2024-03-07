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

   private bool isReleased;
   public  bool IsCanceled { get; private set; }

   internal Ticket(TicketLock ticketLock, long ticketId)
   {
      this.ticketLock = ticketLock;
      TicketId        = ticketId;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public bool Wait()
   {
      while (ticketLock.NowServing < TicketId && !IsCanceled) spinWait.SpinOnce();

      return true;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public bool Wait(CancellationToken token)
   {
      while (ticketLock.NowServing < TicketId && !IsCanceled)
      {
         if (token.IsCancellationRequested)
         {
            Cancel();

            break;
         }

         spinWait.SpinOnce();
      }

      return !IsCanceled;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<bool> WaitAsync()
   {
      while (ticketLock.NowServing < TicketId && !IsCanceled) await Task.Yield();

      return true;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<bool> WaitAsync(CancellationToken token)
   {
      while (ticketLock.NowServing < TicketId && !IsCanceled)
      {
         if (token.IsCancellationRequested)
         {
            Cancel();

            break;
         }

         await Task.Yield();
      }

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

                                      isReleased = true;
                                      ticketLock.Release();
                                   }
                                  )
                      .ConfigureAwait(false);
      #pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public void Release()
   {
      isReleased = true;
      ticketLock.Release();
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public void Dispose()
   {
      if (!isReleased || (IsCanceled && ticketLock.NowServing < TicketId))
         Release();
   }
}