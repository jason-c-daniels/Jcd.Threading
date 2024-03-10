#### [Jcd.Threading](index.md 'index')

## Jcd.Threading.SynchronizedValues Namespace

  
Provides generic types that encapsulate a value and a specific synchronization  
primitive.

### Remarks
  
The synchronization primitive is used to govern access to the underlying value.  
These are useful for exchanging independent and atomic pieces of information  
across threads.  
  
NB: If using a reference type for the underlying value, ensure your reference  
type is appropriately synchronized. In this case these types only restrict  
access to the reference, not the data contained within the reference type.

| Classes | |
| :--- | :--- |
| [ReaderWriterLockSlimValue&lt;T&gt;](ReaderWriterLockSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>') | Provides a generic mechanism for setting, getting, acting on, and altering values<br/>shared among tasks and threads, utilizing a [System.Threading.ReaderWriterLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLock 'System.Threading.ReaderWriterLock') for synchronization. |
| [SemaphoreSlimValue&lt;T&gt;](SemaphoreSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>') | Provides a generic mechanism for setting, getting, acting on, and altering values<br/>shared among tasks and threads, utilizing a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') for synchronization. |
| [SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>') | Provides a generic mechanism for setting, getting, acting on, and altering values<br/>shared among tasks and threads, utilizing a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') for synchronization. |
| [TicketLockValue&lt;T&gt;](TicketLockValue_T_.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>') | Provides a generic mechanism for setting, getting, acting on, and altering values<br/>shared among tasks and threads, utilizing a [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock') for synchronization. |
