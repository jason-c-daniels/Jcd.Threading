#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## ReaderWriterLockSlimResourceLock Class

Provides a single-use mechanism for establishing and releasing locks on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim').

```csharp
public class ReaderWriterLockSlimResourceLock : Jcd.Threading.ResourceLockBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ResourceLockBase](ResourceLockBase.md 'Jcd.Threading.ResourceLockBase') &#129106; ReaderWriterLockSlimResourceLock

### Remarks

Do not share instances of this type across threads or synchronization contexts.
Behavior can be unpredictable. This exists to be used in conjunction
with the .Lock extension method for [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and
advanced use cases.

| Constructors | |
| :--- | :--- |
| [ReaderWriterLockSlimResourceLock(ReaderWriterLockSlim, ReaderWriterLockSlimIntent)](ReaderWriterLockSlimResourceLock..ctor.labO7flm4XklW9ggmUKjQA.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock.ReaderWriterLockSlimResourceLock(System.Threading.ReaderWriterLockSlim, Jcd.Threading.ReaderWriterLockSlimIntent)') | Provides a single-use mechanism for establishing and releasing locks on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim'). |

| Methods | |
| :--- | :--- |
| [Dispose()](ReaderWriterLockSlimResourceLock.Dispose().md 'Jcd.Threading.ReaderWriterLockSlimResourceLock.Dispose()') | Releases any locks held. |
| [Release()](ReaderWriterLockSlimResourceLock.Release().md 'Jcd.Threading.ReaderWriterLockSlimResourceLock.Release()') | Releases the lock on the resource. |
| [Wait()](ReaderWriterLockSlimResourceLock.Wait().md 'Jcd.Threading.ReaderWriterLockSlimResourceLock.Wait()') | Acquires a lock on the ReaderWriterLockSlim according to the intent it was created with. |
| [Wait(CancellationToken)](ReaderWriterLockSlimResourceLock.Wait.sglM4IAgnfOHPcaFKegWNQ.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock.Wait(System.Threading.CancellationToken)') | Locks the resource. Blocks other calls to Lock until Release is called. |
| [WaitAsync()](ReaderWriterLockSlimResourceLock.WaitAsync().md 'Jcd.Threading.ReaderWriterLockSlimResourceLock.WaitAsync()') | Asynchronously Locks the resource. Blocks other calls to Lock until Release is called. |
| [WaitAsync(CancellationToken)](ReaderWriterLockSlimResourceLock.WaitAsync.hiK0ZsFXex0OTUUzbLLBxA.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock.WaitAsync(System.Threading.CancellationToken)') | Asynchronously Locks the resource. Blocks other calls to Lock until Release is called. |
