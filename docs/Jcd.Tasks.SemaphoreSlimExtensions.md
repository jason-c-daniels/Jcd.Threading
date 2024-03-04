### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## SemaphoreSlimExtensions Class

A set of extension methods to simplify using a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')  
to ensure that Release is called for every Wait or WaitAsync. Useful for  
ensuring synchronized access to data for short lived operations.

```csharp
public static class SemaphoreSlimExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SemaphoreSlimExtensions

| Methods | |
| :--- | :--- |
| [Lock(this SemaphoreSlim, Action)](Jcd.Tasks.SemaphoreSlimExtensions.Lock(thisSystem.Threading.SemaphoreSlim,System.Action).md 'Jcd.Tasks.SemaphoreSlimExtensions.Lock(this System.Threading.SemaphoreSlim, System.Action)') | Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [Lock(this SemaphoreSlim, CancellationToken)](Jcd.Tasks.SemaphoreSlimExtensions.Lock(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).md 'Jcd.Tasks.SemaphoreSlimExtensions.Lock(this System.Threading.SemaphoreSlim, System.Threading.CancellationToken)') | Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [Lock(this SemaphoreSlim)](Jcd.Tasks.SemaphoreSlimExtensions.Lock(thisSystem.Threading.SemaphoreSlim).md 'Jcd.Tasks.SemaphoreSlimExtensions.Lock(this System.Threading.SemaphoreSlim)') | Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [LockAsync(this SemaphoreSlim, CancellationToken)](Jcd.Tasks.SemaphoreSlimExtensions.LockAsync(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).md 'Jcd.Tasks.SemaphoreSlimExtensions.LockAsync(this System.Threading.SemaphoreSlim, System.Threading.CancellationToken)') | Asynchronously waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [LockAsync(this SemaphoreSlim)](Jcd.Tasks.SemaphoreSlimExtensions.LockAsync(thisSystem.Threading.SemaphoreSlim).md 'Jcd.Tasks.SemaphoreSlimExtensions.LockAsync(this System.Threading.SemaphoreSlim)') | Asynchronously waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
