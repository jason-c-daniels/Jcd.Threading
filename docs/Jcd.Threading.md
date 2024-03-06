#### [Jcd.Threading](index.md 'index')

## Jcd.Threading Namespace

Provides types and extension methods to assist with the creation, execution, and  
management of unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances.

| Classes | |
| :--- | :--- |
| [ItemProcessor&lt;TItem&gt;](ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>') | An item processor that calls a delegate on each item enqueued with it. |
| [ReaderWriterLockSlimExtensions](ReaderWriterLockSlimExtensions.md 'Jcd.Threading.ReaderWriterLockSlimExtensions') | A set of extension methods to simplify using a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')<br/>to ensure the correct pair of EnterRead+ExitRead, EnterUpgradeableRead+ExitUpgradeableRead,<br/>and EnterWrite+ExitWrite are called. |
| [SemaphoreSlimExtensions](SemaphoreSlimExtensions.md 'Jcd.Threading.SemaphoreSlimExtensions') | A set of extension methods to simplify using a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')<br/>to ensure that Release is called for every Wait or WaitAsync. Useful for<br/>ensuring synchronized access to data for short lived operations. |
| [SpinLockExtensions](SpinLockExtensions.md 'Jcd.Threading.SpinLockExtensions') | Provides extension methods to aid in working with SpinLocks |
| [ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper') | Provides basic thread management facilities such as Pause, Resume, Stop, Start and<br/>entering and exiting the idle state. |
| [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock') | Provides a naiive implementation of a [Ticket lock (wikipedia)](https://en.wikipedia.org/wiki/Ticket_lock 'https://en.wikipedia.org/wiki/Ticket_lock') with cancellation support. |

| Interfaces | |
| :--- | :--- |
| [ITicket](ITicket.md 'Jcd.Threading.ITicket') | The supported interface guaranteed to be returned from<br/>the appropriate methods of [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock') |

| Enums | |
| :--- | :--- |
| [ReaderWriterLockSlimIntent](ReaderWriterLockSlimIntent.md 'Jcd.Threading.ReaderWriterLockSlimIntent') | Indicates the intent of a call to ReaderWriterLockSLimExtensions.Lock. |
