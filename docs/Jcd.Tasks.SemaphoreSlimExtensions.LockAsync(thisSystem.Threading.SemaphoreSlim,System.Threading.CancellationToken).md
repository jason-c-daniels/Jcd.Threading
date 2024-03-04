### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SemaphoreSlimExtensions](Jcd.Tasks.SemaphoreSlimExtensions.md 'Jcd.Tasks.SemaphoreSlimExtensions')

## SemaphoreSlimExtensions.LockAsync(this SemaphoreSlim, CancellationToken) Method

Asynchronously waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release.

```csharp
public static System.Threading.Tasks.Task<System.IDisposable> LockAsync(this System.Threading.SemaphoreSlim sem, System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Tasks.SemaphoreSlimExtensions.LockAsync(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).sem'></a>

`sem` [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

the semaphore to use.

<a name='Jcd.Tasks.SemaphoreSlimExtensions.LockAsync(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token to use during the wait.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') for an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release in its Dispose method.