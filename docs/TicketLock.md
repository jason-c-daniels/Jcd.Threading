#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## TicketLock Class

Provides a naiive implementation of a [Ticket lock (wikipedia)](https://en.wikipedia.org/wiki/Ticket_lock 'https://en.wikipedia.org/wiki/Ticket_lock') with cancellation support.

```csharp
public class TicketLock :
Jcd.Threading.IResourceLockFactory<Jcd.Threading.TicketLockResourceLock>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TicketLock

Implements [Jcd.Threading.IResourceLockFactory&lt;](IResourceLockFactory_T_.md 'Jcd.Threading.IResourceLockFactory<T>')[TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock')[&gt;](IResourceLockFactory_T_.md 'Jcd.Threading.IResourceLockFactory<T>')

### Remarks
  
For a technical reference on Ticket Locks see: [Ticket Locking Algorithm : Fair Lock Delivery Mechanism](https://medium.com/@shivajiofficial5088/ticket-locking-algorithm-fair-lock-delivery-mechanism-fdfe04b0b94b 'https://medium.com/@shivajiofficial5088/ticket-locking-algorithm-fair-lock-delivery-mechanism-fdfe04b0b94b')  
  
For further reading see the [Wikipedia Article on Ticket locks](https://en.wikipedia.org/wiki/Ticket_lock 'https://en.wikipedia.org/wiki/Ticket_lock').

| Properties | |
| :--- | :--- |
| [CurrentCount](TicketLock.CurrentCount.md 'Jcd.Threading.TicketLock.CurrentCount') | The total number of pending tickets. |
| [MaxTicketCount](TicketLock.MaxTicketCount.md 'Jcd.Threading.TicketLock.MaxTicketCount') | The maximum number of possible tickets. (At 1 per 20ms this should last 350 years of continuous run time.) |
| [NowServing](TicketLock.NowServing.md 'Jcd.Threading.TicketLock.NowServing') | The ticket currently holding the lock. |

| Methods | |
| :--- | :--- |
| [GetResourceLock()](TicketLock.GetResourceLock().md 'Jcd.Threading.TicketLock.GetResourceLock()') | Creates an [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock'). |
| [Lock()](TicketLock.Lock().md 'Jcd.Threading.TicketLock.Lock()') | Creates an [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock') and waits on it. |
| [Lock(CancellationToken)](TicketLock.Lock.fYrPViITPBg53GsQFBRyJw.md 'Jcd.Threading.TicketLock.Lock(System.Threading.CancellationToken)') | Creates an [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock') and waits on it. |
| [LockAsync()](TicketLock.LockAsync().md 'Jcd.Threading.TicketLock.LockAsync()') | Asynchronously creates an [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock') and waits on it. |
| [LockAsync(CancellationToken)](TicketLock.LockAsync.YvBodh5bW+w7Ka09w0RHRw.md 'Jcd.Threading.TicketLock.LockAsync(System.Threading.CancellationToken)') | Asynchronously creates an [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock') and waits on it. |
| [Release()](TicketLock.Release().md 'Jcd.Threading.TicketLock.Release()') | Increment's NowServing so that the next thread<br/>can begin processing. |
