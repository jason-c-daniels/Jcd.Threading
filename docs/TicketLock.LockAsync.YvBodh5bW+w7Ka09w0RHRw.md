#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')

## TicketLock.LockAsync(CancellationToken) Method

Asynchronously creates an [ITicket](ITicket.md 'Jcd.Threading.ITicket') and waits on it.

```csharp
public System.Threading.Tasks.Task<Jcd.Threading.ITicket> LockAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.TicketLock.LockAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to listen for cancellation on.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ITicket](ITicket.md 'Jcd.Threading.ITicket')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The ticket once the lock is acquired.