#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock')

## TicketLock.Lock(CancellationToken) Method

Creates an [ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket') and waits on it.

```csharp
public Jcd.Threading.ITicket Lock(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.TicketLock.Lock(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to listen for cancellation on.

#### Returns
[ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket')  
The ticket once the lock is acquired.