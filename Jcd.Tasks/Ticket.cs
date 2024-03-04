using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

internal class Ticket : ITicket
{
   private readonly TicketLock ticketLock;
   private readonly long       ticketId;
   private          SpinWait   spinWait;
   public           long       TicketId =>ticketId;
   private          bool       isReleased;

   internal Ticket(TicketLock ticketLock, long ticketId)
   {
      this.ticketLock = ticketLock;
      this.ticketId   = ticketId;
   }
   public bool IsCanceled { get; private set; }
   
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public bool Wait() => Wait(CancellationToken.None);
   
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public bool Wait(CancellationToken token)
   {
      while (ticketLock.nowServing < ticketId)
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
   public Task<bool> WaitAsync() => WaitAsync(CancellationToken.None);

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<bool> WaitAsync(CancellationToken token )
   {
      while (ticketLock.nowServing < ticketId)
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
   }
   
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public void Release()
   {
      isReleased = true;
      //if (!IsCanceled) 
         ticketLock.Release();
      //else
      // ticketLock.Cancel(ticketId); 
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public void Dispose()
   {
      if (!isReleased)
         Release();
   }
}