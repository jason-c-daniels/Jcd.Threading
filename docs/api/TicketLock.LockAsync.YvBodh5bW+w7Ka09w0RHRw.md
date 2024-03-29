#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')

## TicketLock.LockAsync(CancellationToken) Method

Asynchronously creates an [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock') and waits on it.

```csharp
public System.Threading.Tasks.Task<Jcd.Threading.TicketLockResourceLock> LockAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.TicketLock.LockAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to listen for cancellation on.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')
The ticket once the lock is acquired.