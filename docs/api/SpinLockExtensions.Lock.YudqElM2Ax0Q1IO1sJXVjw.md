#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SpinLockExtensions](SpinLockExtensions.md 'Jcd.Threading.SpinLockExtensions')

## SpinLockExtensions.Lock(this SpinLock, Action, bool) Method

Acquires exclusive access to the spinLock and executes the provided action.

```csharp
public static void Lock(this ref System.Threading.SpinLock spinLock, System.Action action, bool useMemoryBarrierOnExit=false);
```
#### Parameters

<a name='Jcd.Threading.SpinLockExtensions.Lock(thisSystem.Threading.SpinLock,System.Action,bool).spinLock'></a>

`spinLock` [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock')

The [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') to use for locking.

<a name='Jcd.Threading.SpinLockExtensions.Lock(thisSystem.Threading.SpinLock,System.Action,bool).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The action to perform

<a name='Jcd.Threading.SpinLockExtensions.Lock(thisSystem.Threading.SpinLock,System.Action,bool).useMemoryBarrierOnExit'></a>

`useMemoryBarrierOnExit` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Passed to `Exit` when releasing the lock.