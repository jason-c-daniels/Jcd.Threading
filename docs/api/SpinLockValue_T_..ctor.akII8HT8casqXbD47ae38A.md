#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>')

## SpinLockValue(T, bool, bool) Constructor

Creates an instance of a [SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>')

```csharp
public SpinLockValue(T initialVal=default(T), bool useMemoryBarrier=false, bool useThreadTracking=false);
```
#### Parameters

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.SpinLockValue(T,bool,bool).initialVal'></a>

`initialVal` [T](SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')

The initial value

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.SpinLockValue(T,bool,bool).useMemoryBarrier'></a>

`useMemoryBarrier` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the call to Exit should use a memory barrier to notify other threads the lock has been freed(much slower!).

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.SpinLockValue(T,bool,bool).useThreadTracking'></a>

`useThreadTracking` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') uses thread tracking.