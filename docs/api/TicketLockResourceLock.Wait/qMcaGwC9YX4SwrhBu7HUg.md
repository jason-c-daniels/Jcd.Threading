#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock')

## TicketLockResourceLock.Wait(CancellationToken) Method

Waits for the `NowServing` on the owning [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')
to match its own `TicketId`

```csharp
public override bool Wait(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.TicketLockResourceLock.Wait(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

the token to observe for cancellation.

Implements [Wait(CancellationToken)](IResourceLock.Wait.TET9I9Gih4bCELZJIopdow.md 'Jcd.Threading.IResourceLock.Wait(System.Threading.CancellationToken)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
true if the lock was acquired, false otherwise (usually a cancellation)