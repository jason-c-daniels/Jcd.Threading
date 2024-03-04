using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

public interface ITicket
   : IDisposable
{
   long       TicketId   { get; }
   bool       IsCanceled { get; }
   bool       Wait();
   bool       Wait(CancellationToken token);
   Task<bool> WaitAsync();
   Task<bool> WaitAsync(CancellationToken token );
   void       Cancel();
   void       Release();
}