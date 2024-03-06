#### [Jcd.Threading](index.md 'index')

## Jcd.Threading.SynchronizedValues Namespace

| Classes | |
| :--- | :--- |
| [ReaderWriterLockSlimValue&lt;T&gt;](ReaderWriterLockSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>') | Provides a simple async-safe and thread-safe method of setting, getting, acting on,<br/>and altering values shared among tasks and threads. |
| [SemaphoreSlimValue&lt;T&gt;](SemaphoreSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>') | A value wrapper with a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') to block access during reads and writes.<br/>This results in single writer or single reader access to the data. |
| [SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>') | Provides synchronization to an underlying value through a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock'). |
| [TicketLockValue&lt;T&gt;](TicketLockValue_T_.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>') | A value wrapper for a [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock') to block access during reads<br/>and writes. It guarantees in order execution of locks. |
