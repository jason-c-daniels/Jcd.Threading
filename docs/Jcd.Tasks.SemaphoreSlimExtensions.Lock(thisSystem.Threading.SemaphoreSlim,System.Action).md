### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SemaphoreSlimExtensions](Jcd.Tasks.SemaphoreSlimExtensions.md 'Jcd.Tasks.SemaphoreSlimExtensions')

## SemaphoreSlimExtensions.Lock(this SemaphoreSlim, Action) Method

Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release.

```csharp
public static void Lock(this System.Threading.SemaphoreSlim sem, System.Action action);
```
#### Parameters

<a name='Jcd.Tasks.SemaphoreSlimExtensions.Lock(thisSystem.Threading.SemaphoreSlim,System.Action).sem'></a>

`sem` [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

the semaphore to use.

<a name='Jcd.Tasks.SemaphoreSlimExtensions.Lock(thisSystem.Threading.SemaphoreSlim,System.Action).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')