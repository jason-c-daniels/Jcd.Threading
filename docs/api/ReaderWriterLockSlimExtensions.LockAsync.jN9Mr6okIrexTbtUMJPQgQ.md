#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ReaderWriterLockSlimExtensions](ReaderWriterLockSlimExtensions.md 'Jcd.Threading.ReaderWriterLockSlimExtensions')

## ReaderWriterLockSlimExtensions.LockAsync(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent) Method

Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns a [ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock') that  
calls the appropriate exit method on the lock during disposal.

```csharp
public static System.Threading.Tasks.Task<Jcd.Threading.ReaderWriterLockSlimResourceLock> LockAsync(this System.Threading.ReaderWriterLockSlim rwls, Jcd.Threading.ReaderWriterLockSlimIntent intent=Jcd.Threading.ReaderWriterLockSlimIntent.Read);
```
#### Parameters

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent).rwls'></a>

`rwls` [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')

The lock to acquire and release.

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent).intent'></a>

`intent` [ReaderWriterLockSlimIntent](ReaderWriterLockSlimIntent.md 'Jcd.Threading.ReaderWriterLockSlimIntent')

The type of lock being acquired. By default this is a Read

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
the [ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock') to release the resources.