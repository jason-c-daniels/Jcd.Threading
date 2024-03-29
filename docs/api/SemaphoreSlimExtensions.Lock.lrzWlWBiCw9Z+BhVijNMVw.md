#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SemaphoreSlimExtensions](SemaphoreSlimExtensions.md 'Jcd.Threading.SemaphoreSlimExtensions')

## SemaphoreSlimExtensions.Lock(this SemaphoreSlim, CancellationToken) Method

Waits on the semaphore, and returns an [SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock') that calls Release.

```csharp
public static Jcd.Threading.SemaphoreSlimResourceLock Lock(this System.Threading.SemaphoreSlim sem, System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.SemaphoreSlimExtensions.Lock(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).sem'></a>

`sem` [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

the semaphore to use.

<a name='Jcd.Threading.SemaphoreSlimExtensions.Lock(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token to use during the wait.

#### Returns
[SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock')
an [SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock') that calls Release in its Dispose method.