#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## SemaphoreSlimResourceLock Class

Provides a mechanism for establishing and releasing locks on a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim').

```csharp
public class SemaphoreSlimResourceLock : Jcd.Threading.ResourceLockBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ResourceLockBase](ResourceLockBase.md 'Jcd.Threading.ResourceLockBase') &#129106; SemaphoreSlimResourceLock

### Remarks
  
Do not share instances of this type across threads or synchronization contexts.  
Behavior can be unpredictable. These are provided and meant to be used in conjunction  
with the extension classes to create a more consistent experience when using  
synchronization primitives.

| Constructors | |
| :--- | :--- |
| [SemaphoreSlimResourceLock(SemaphoreSlim)](SemaphoreSlimResourceLock..ctor.IChqjw3fYT+2pNVk0peOGw.md 'Jcd.Threading.SemaphoreSlimResourceLock.SemaphoreSlimResourceLock(System.Threading.SemaphoreSlim)') | Provides a mechanism for establishing and releasing locks on a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim'). |

| Methods | |
| :--- | :--- |
| [Dispose()](SemaphoreSlimResourceLock.Dispose().md 'Jcd.Threading.SemaphoreSlimResourceLock.Dispose()') | Releases any locks held. |
| [Release()](SemaphoreSlimResourceLock.Release().md 'Jcd.Threading.SemaphoreSlimResourceLock.Release()') | Releases the lock on the resource. |
| [Wait()](SemaphoreSlimResourceLock.Wait().md 'Jcd.Threading.SemaphoreSlimResourceLock.Wait()') | Locks the resource. Blocks other calls to Lock until Release is called. |
| [Wait(CancellationToken)](SemaphoreSlimResourceLock.Wait.JAeVK594xSGa0d3twTWh+w.md 'Jcd.Threading.SemaphoreSlimResourceLock.Wait(System.Threading.CancellationToken)') | Locks the resource. Blocks other calls to Lock until Release is called. |
| [WaitAsync()](SemaphoreSlimResourceLock.WaitAsync().md 'Jcd.Threading.SemaphoreSlimResourceLock.WaitAsync()') | Asynchronously Locks the resource. Blocks other calls to Lock until Release is called. |
| [WaitAsync(CancellationToken)](SemaphoreSlimResourceLock.WaitAsync.ZQaziGW4glLqHQbYoy3tzw.md 'Jcd.Threading.SemaphoreSlimResourceLock.WaitAsync(System.Threading.CancellationToken)') | Asynchronously Locks the resource. Blocks other calls to Lock until Release is called. |
