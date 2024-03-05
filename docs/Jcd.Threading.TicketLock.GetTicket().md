#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock')

## TicketLock.GetTicket() Method

Creates an [ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket').

```csharp
public Jcd.Threading.ITicket GetTicket();
```

#### Returns
[ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket')  
The new ticket.

### Remarks
WARNING: This is for advanced use cases only. Failing to release the lock  
will deadlock all other tickets with a larger TicketId. However, calling release  
on the ticket before this [TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock') has NowServing set to the  
new ticket's ID will cause a race condition between the code locked by  
this specific ticket and the next immediately higher lock.