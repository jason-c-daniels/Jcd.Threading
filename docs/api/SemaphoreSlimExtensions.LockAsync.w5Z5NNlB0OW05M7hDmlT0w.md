#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SemaphoreSlimExtensions](SemaphoreSlimExtensions.md 'Jcd.Threading.SemaphoreSlimExtensions')

## SemaphoreSlimExtensions.LockAsync(this SemaphoreSlim, CancellationToken) Method

Asynchronously waits on the semaphore, and returns an [SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock') that calls Release.

```csharp
public static System.Threading.Tasks.Task<Jcd.Threading.SemaphoreSlimResourceLock> LockAsync(this System.Threading.SemaphoreSlim sem, System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.SemaphoreSlimExtensions.LockAsync(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).sem'></a>

`sem` [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

the semaphore to use.

<a name='Jcd.Threading.SemaphoreSlimExtensions.LockAsync(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token to use during the wait.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') for an [SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock') that calls Release in its Dispose method.