#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')

## TicketLock.LockAsync() Method

Asynchronously creates an [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock') and waits on it.

```csharp
public System.Threading.Tasks.Task<Jcd.Threading.TicketLockResourceLock> LockAsync();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The ticket once the lock is acquired.