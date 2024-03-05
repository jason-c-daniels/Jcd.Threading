#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock')

## TicketLock.Lock() Method

Creates an [ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket') and waits on it.

```csharp
public Jcd.Threading.ITicket Lock();
```

#### Returns
[ITicket](Jcd.Threading.ITicket.md 'Jcd.Threading.ITicket')  
The ticket once the lock is acquired.