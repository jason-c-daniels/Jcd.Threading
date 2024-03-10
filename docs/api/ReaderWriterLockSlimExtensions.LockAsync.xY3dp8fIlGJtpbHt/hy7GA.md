#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ReaderWriterLockSlimExtensions](ReaderWriterLockSlimExtensions.md 'Jcd.Threading.ReaderWriterLockSlimExtensions')

## ReaderWriterLockSlimExtensions.LockAsync(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent, CancellationToken) Method

Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns a [ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock') that  
calls the appropriate exit method on the lock during disposal.

```csharp
public static System.Threading.Tasks.Task<Jcd.Threading.ReaderWriterLockSlimResourceLock> LockAsync(this System.Threading.ReaderWriterLockSlim rwls, Jcd.Threading.ReaderWriterLockSlimIntent intent, System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent,System.Threading.CancellationToken).rwls'></a>

`rwls` [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')

The lock to acquire and release.

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent,System.Threading.CancellationToken).intent'></a>

`intent` [ReaderWriterLockSlimIntent](ReaderWriterLockSlimIntent.md 'Jcd.Threading.ReaderWriterLockSlimIntent')

The type of lock being acquired. By default this is a Read

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

the [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') to inspect for cancellation requests.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
the [ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock') to release the resources.