#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')

## TicketLock.GetResourceLock() Method

Creates an [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock').

```csharp
public Jcd.Threading.TicketLockResourceLock GetResourceLock();
```

Implements [GetResourceLock()](IResourceLockFactory_T_.GetResourceLock().md 'Jcd.Threading.IResourceLockFactory<T>.GetResourceLock()')

#### Returns
[TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock')  
The new ticket.

### Remarks
WARNING: This is for advanced use cases only. Failing to release the lock  
will deadlock all other tickets with a larger TicketId. However, calling release  
on the ticket before this [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock') has NowServing set to the  
new ticket's ID will cause a race condition between the code locked by  
this specific ticket and the next immediately higher lock.