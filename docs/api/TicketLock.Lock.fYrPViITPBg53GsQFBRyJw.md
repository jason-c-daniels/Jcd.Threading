#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')

## TicketLock.Lock(CancellationToken) Method

Creates an [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock') and waits on it.

```csharp
public Jcd.Threading.TicketLockResourceLock Lock(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.TicketLock.Lock(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to listen for cancellation on.

#### Returns
[TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock')  
The ticket once the lock is acquired.