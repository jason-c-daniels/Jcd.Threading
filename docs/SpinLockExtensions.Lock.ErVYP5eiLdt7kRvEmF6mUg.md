#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SpinLockExtensions](SpinLockExtensions.md 'Jcd.Threading.SpinLockExtensions')

## SpinLockExtensions.Lock(this SpinLock, CancellationToken) Method

Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release.

```csharp
public static Jcd.Threading.SpinLockResourceLock Lock(this ref System.Threading.SpinLock sem, System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.SpinLockExtensions.Lock(thisSystem.Threading.SpinLock,System.Threading.CancellationToken).sem'></a>

`sem` [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock')

the semaphore to use.

<a name='Jcd.Threading.SpinLockExtensions.Lock(thisSystem.Threading.SpinLock,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token to use during the wait.

#### Returns
[SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock')  
an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release in its Dispose method.