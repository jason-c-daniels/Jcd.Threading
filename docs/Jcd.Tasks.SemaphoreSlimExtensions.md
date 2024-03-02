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
| [Use(this SemaphoreSlim, CancellationToken)](Jcd.Tasks.SemaphoreSlimExtensions.Use(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).md 'Jcd.Tasks.SemaphoreSlimExtensions.Use(this System.Threading.SemaphoreSlim, System.Threading.CancellationToken)') | Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [Use(this SemaphoreSlim)](Jcd.Tasks.SemaphoreSlimExtensions.Use(thisSystem.Threading.SemaphoreSlim).md 'Jcd.Tasks.SemaphoreSlimExtensions.Use(this System.Threading.SemaphoreSlim)') | Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [UseAsync(this SemaphoreSlim, CancellationToken)](Jcd.Tasks.SemaphoreSlimExtensions.UseAsync(thisSystem.Threading.SemaphoreSlim,System.Threading.CancellationToken).md 'Jcd.Tasks.SemaphoreSlimExtensions.UseAsync(this System.Threading.SemaphoreSlim, System.Threading.CancellationToken)') | Asynchronously waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [UseAsync(this SemaphoreSlim)](Jcd.Tasks.SemaphoreSlimExtensions.UseAsync(thisSystem.Threading.SemaphoreSlim).md 'Jcd.Tasks.SemaphoreSlimExtensions.UseAsync(this System.Threading.SemaphoreSlim)') | Asynchronously waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
