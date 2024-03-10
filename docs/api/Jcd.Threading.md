#### [Jcd.Threading](index.md 'index')

## Jcd.Threading Namespace

Provides types and extension methods to assist with the management
of resource synchronization primitives.

| Classes | |
| :--- | :--- |
| [ItemProcessor&lt;TItem&gt;](ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>') | Provides the ability to call a delegate on each item in an internally managed queue from its own background thread. |
| [ReaderWriterLockSlimExtensions](ReaderWriterLockSlimExtensions.md 'Jcd.Threading.ReaderWriterLockSlimExtensions') | Provides extension methods to simplify using a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') to ensure the correct pair of EnterRead plus ExitRead, EnterUpgradeableRead plus ExitUpgradeableRead, and EnterWrite plus ExitWrite are called. |
| [ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock') | Provides a single-use mechanism for establishing and releasing locks on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim'). |
| [ResourceLockBase](ResourceLockBase.md 'Jcd.Threading.ResourceLockBase') | Provides a base mechanism for managing the state of [IResourceLock](IResourceLock.md 'Jcd.Threading.IResourceLock') implementations. |
| [SemaphoreSlimExtensions](SemaphoreSlimExtensions.md 'Jcd.Threading.SemaphoreSlimExtensions') | Provides extension methods to simplify using a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') to ensure the correct pairing of calls to of Enter and Exit. |
| [SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock') | Provides a single-use mechanism for establishing and releasing locks on a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim'). |
| [SpinLockExtensions](SpinLockExtensions.md 'Jcd.Threading.SpinLockExtensions') | Provides extension methods to simplify using a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') to ensure the correct pairing of calls to of Wait and Release. |
| [ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper') | Provides basic thread management facilities such as Pause, Resume, Stop, Start and entering and exiting the idle state. |
| [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock') | Provides a naïve implementation of a [Ticket lock (wikipedia)](https://en.wikipedia.org/wiki/Ticket_lock 'https://en.wikipedia.org/wiki/Ticket_lock') with cancellation support. |
| [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock') | Provides a mechanism for establishing and releasing locks on a [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock'). |

| Structs | |
| :--- | :--- |
| [SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock') | Provides a single-use mechanism for establishing and releasing locks on a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock'). |

| Interfaces | |
| :--- | :--- |
| [IResourceLock](IResourceLock.md 'Jcd.Threading.IResourceLock') | Provides a mechanism for establishing and releasing locks on a resource. |
| [IResourceLockProvider&lt;T&gt;](IResourceLockProvider_T_.md 'Jcd.Threading.IResourceLockProvider<T>') | Provides a mechanism for acquiring resource locks bound to a specific instance of a synchronization primitive. |

| Enums | |
| :--- | :--- |
| [ReaderWriterLockSlimIntent](ReaderWriterLockSlimIntent.md 'Jcd.Threading.ReaderWriterLockSlimIntent') | Indicates the intent of a call to [ReaderWriterLockSlimExtensions](ReaderWriterLockSlimExtensions.md 'Jcd.Threading.ReaderWriterLockSlimExtensions')`Lock`. |
