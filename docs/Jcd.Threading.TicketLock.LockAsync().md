#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock')

## TicketLock.LockAsync() Method

Asynchronously creates an [ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket') and waits on it.

```csharp
public System.Threading.Tasks.Task<Jcd.Threading.ITicket> LockAsync();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The ticket once the lock is acquired.