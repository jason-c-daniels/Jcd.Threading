#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

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
| [Lock(this SemaphoreSlim, Action)](SemaphoreSlimExtensions.Lock.gtTtwYHLcU9e2zyqiG5NSA.md 'Jcd.Threading.SemaphoreSlimExtensions.Lock(this System.Threading.SemaphoreSlim, System.Action)') | Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [Lock(this SemaphoreSlim, CancellationToken)](SemaphoreSlimExtensions.Lock.lrzWlWBiCw9Z+BhVijNMVw.md 'Jcd.Threading.SemaphoreSlimExtensions.Lock(this System.Threading.SemaphoreSlim, System.Threading.CancellationToken)') | Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [Lock(this SemaphoreSlim)](SemaphoreSlimExtensions.Lock.TfibVEOq4/VaWrHC7tH/rg.md 'Jcd.Threading.SemaphoreSlimExtensions.Lock(this System.Threading.SemaphoreSlim)') | Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [LockAsync(this SemaphoreSlim, CancellationToken)](SemaphoreSlimExtensions.LockAsync.w5Z5NNlB0OW05M7hDmlT0w.md 'Jcd.Threading.SemaphoreSlimExtensions.LockAsync(this System.Threading.SemaphoreSlim, System.Threading.CancellationToken)') | Asynchronously waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
| [LockAsync(this SemaphoreSlim)](SemaphoreSlimExtensions.LockAsync.thM6pz8QjtVLgPqK6jAgIA.md 'Jcd.Threading.SemaphoreSlimExtensions.LockAsync(this System.Threading.SemaphoreSlim)') | Asynchronously waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release. |
