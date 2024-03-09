#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SemaphoreSlimExtensions](SemaphoreSlimExtensions.md 'Jcd.Threading.SemaphoreSlimExtensions')

## SemaphoreSlimExtensions.Lock(this SemaphoreSlim) Method

Waits on the semaphore, and returns an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release.

```csharp
public static Jcd.Threading.SemaphoreSlimResourceLock Lock(this System.Threading.SemaphoreSlim sem);
```
#### Parameters

<a name='Jcd.Threading.SemaphoreSlimExtensions.Lock(thisSystem.Threading.SemaphoreSlim).sem'></a>

`sem` [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

the semaphore to use.

#### Returns
[SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock')  
an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') that calls Release in its Dispose method.