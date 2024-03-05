#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket')

## ITicket.Wait(CancellationToken) Method

Waits for the `NowServing` on the owning [TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock')  
to match its own `TicketId`

```csharp
bool Wait(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.ITicket.Wait(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

the token to observe for cancellation.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the lock was acquired, false otherwise (usually a cancellation)