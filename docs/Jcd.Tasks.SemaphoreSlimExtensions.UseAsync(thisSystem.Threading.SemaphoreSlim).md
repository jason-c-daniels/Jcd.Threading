### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SemaphoreSlimExtensions](Jcd.Tasks.SemaphoreSlimExtensions.md 'Jcd.Tasks.SemaphoreSlimExtensions')

## SemaphoreSlimExtensions.UseAsync(this SemaphoreSlim) Method

Asynchronously waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release.

```csharp
public static System.Threading.Tasks.Task<System.IDisposable> UseAsync(this System.Threading.SemaphoreSlim sem);
```
#### Parameters

<a name='Jcd.Tasks.SemaphoreSlimExtensions.UseAsync(thisSystem.Threading.SemaphoreSlim).sem'></a>

`sem` [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

the semaphore to use.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') for an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release in its Dispose method.