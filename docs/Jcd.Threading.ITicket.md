#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## ITicket Interface

The supported interface guaranteed to be returned from  
the appropriate methods of [TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock')

```csharp
public interface ITicket :
System.IDisposable
```

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [IsCanceled](Jcd.Threading.ITicket.IsCanceled.md 'Jcd.Threading.ITicket.IsCanceled') | Indicates if the ticket was cancelled. |
| [TicketId](Jcd.Threading.ITicket.TicketId.md 'Jcd.Threading.ITicket.TicketId') | The ID for the ticket. These are issued out sequentially. |

| Methods | |
| :--- | :--- |
| [Cancel()](Jcd.Threading.ITicket.Cancel().md 'Jcd.Threading.ITicket.Cancel()') | Cancels the ticket. This will register a background thread to do cleanup. |
| [Release()](Jcd.Threading.ITicket.Release().md 'Jcd.Threading.ITicket.Release()') | Releases the lock, if acquired. |
| [Wait()](Jcd.Threading.ITicket.Wait().md 'Jcd.Threading.ITicket.Wait()') | Waits for the `NowServing` on the owning [TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock')<br/>to match its own `TicketId` |
| [Wait(CancellationToken)](Jcd.Threading.ITicket.Wait(System.Threading.CancellationToken).md 'Jcd.Threading.ITicket.Wait(System.Threading.CancellationToken)') | Waits for the `NowServing` on the owning [TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock')<br/>to match its own `TicketId` |
| [WaitAsync()](Jcd.Threading.ITicket.WaitAsync().md 'Jcd.Threading.ITicket.WaitAsync()') | Asynchronously Waits for the `NowServing` on the owning [TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock')<br/>to match its own `TicketId` |
| [WaitAsync(CancellationToken)](Jcd.Threading.ITicket.WaitAsync(System.Threading.CancellationToken).md 'Jcd.Threading.ITicket.WaitAsync(System.Threading.CancellationToken)') | Waits for the `NowServing` on the owning [TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock')<br/>to match its own `TicketId` |
