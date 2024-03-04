### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SemaphoreSlimExtensions](Jcd.Tasks.SemaphoreSlimExtensions.md 'Jcd.Tasks.SemaphoreSlimExtensions')

## SemaphoreSlimExtensions.Lock(this SemaphoreSlim, CancellationToken) Method

Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release.

```csharp
public static System.IDisposable Lock(this System.Threading.SemaphoreSlim sem, System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Tasks.SemaphoreSlimExtensions.Lock(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).sem'></a>

`sem` [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

the semaphore to use.

<a name='Jcd.Tasks.SemaphoreSlimExtensions.Lock(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token to use during the wait.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release in its Dispose method.