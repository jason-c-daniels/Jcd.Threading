#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock')

## TicketLockResourceLock.Wait() Method

Waits for the `NowServing` on the owning [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')
to match its own `TicketId`

```csharp
public override bool Wait();
```

Implements [Wait()](IResourceLock.Wait().md 'Jcd.Threading.IResourceLock.Wait()')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
true if the lock was acquired, false otherwise (usually a cancellation)