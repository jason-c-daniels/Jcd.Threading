#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## TicketLock Class

Provides a naiive implementation of a [Ticket lock (wikipedia)](https://en.wikipedia.org/wiki/Ticket_lock 'https://en.wikipedia.org/wiki/Ticket_lock') with cancellation support.

```csharp
public class TicketLock
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TicketLock

### Remarks
See also: [Ticket Locking Algorithm : Fair Lock Delivery Mechanism](https://medium.com/@shivajiofficial5088/ticket-locking-algorithm-fair-lock-delivery-mechanism-fdfe04b0b94b 'https://medium.com/@shivajiofficial5088/ticket-locking-algorithm-fair-lock-delivery-mechanism-fdfe04b0b94b')  
For other details see the [Wikipedia Article on Ticket locks](https://en.wikipedia.org/wiki/Ticket_lock 'https://en.wikipedia.org/wiki/Ticket_lock').

| Properties | |
| :--- | :--- |
| [CurrentCount](Jcd.Threading.TicketLock.CurrentCount.md 'Jcd.Threading.TicketLock.CurrentCount') | The total number of pending tickets. |
| [MaxTicketCount](Jcd.Threading.TicketLock.MaxTicketCount.md 'Jcd.Threading.TicketLock.MaxTicketCount') | The maximum number of possible tickets. (At 1 per 20ms this should last 350 years of continuous run time.) |
| [NowServing](Jcd.Threading.TicketLock.NowServing.md 'Jcd.Threading.TicketLock.NowServing') | The ticket currently holding the lock. |

| Methods | |
| :--- | :--- |
| [GetTicket()](Jcd.Threading.TicketLock.GetTicket().md 'Jcd.Threading.TicketLock.GetTicket()') | Creates an [ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket'). |
| [Lock()](Jcd.Threading.TicketLock.Lock().md 'Jcd.Threading.TicketLock.Lock()') | Creates an [ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket') and waits on it. |
| [Lock(CancellationToken)](Jcd.Threading.TicketLock.Lock(System.Threading.CancellationToken).md 'Jcd.Threading.TicketLock.Lock(System.Threading.CancellationToken)') | Creates an [ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket') and waits on it. |
| [LockAsync()](Jcd.Threading.TicketLock.LockAsync().md 'Jcd.Threading.TicketLock.LockAsync()') | Asynchronously creates an [ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket') and waits on it. |
| [LockAsync(CancellationToken)](Jcd.Threading.TicketLock.LockAsync(System.Threading.CancellationToken).md 'Jcd.Threading.TicketLock.LockAsync(System.Threading.CancellationToken)') | Asynchronously creates an [ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket') and waits on it. |
| [Release()](Jcd.Threading.TicketLock.Release().md 'Jcd.Threading.TicketLock.Release()') | Increment's NowServing so that the next thread<br/>can begin processing. |
