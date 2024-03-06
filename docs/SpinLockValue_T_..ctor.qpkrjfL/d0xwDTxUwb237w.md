#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>')

## SpinLockValue(T, bool) Constructor

Creates an instance of a [SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>')

```csharp
public SpinLockValue(T initialValue=default(T), bool useMemoryBarrier=false);
```
#### Parameters

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.SpinLockValue(T,bool).initialValue'></a>

`initialValue` [T](SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')

The initial value

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.SpinLockValue(T,bool).useMemoryBarrier'></a>

`useMemoryBarrier` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the call to Exit should use a memory barrier to notify other threads the lock has been freed(much slower!).