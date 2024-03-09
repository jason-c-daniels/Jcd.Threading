#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## IResourceLock Interface

Provides a mechanism for establishing and releasing locks on a resource.

```csharp
public interface IResourceLock :
System.IDisposable
```

Derived  
&#8627; [ResourceLockBase](ResourceLockBase.md 'Jcd.Threading.ResourceLockBase')

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [IsLocked](IResourceLock.IsLocked.md 'Jcd.Threading.IResourceLock.IsLocked') | Indicates if the lock was acquired by this [IResourceLock](IResourceLock.md 'Jcd.Threading.IResourceLock') |
| [IsReleased](IResourceLock.IsReleased.md 'Jcd.Threading.IResourceLock.IsReleased') | Indicates if the lock was released. |
| [IsWaiting](IResourceLock.IsWaiting.md 'Jcd.Threading.IResourceLock.IsWaiting') | Indicates if the lock is currently waiting to be acquired. |

| Methods | |
| :--- | :--- |
| [Release()](IResourceLock.Release().md 'Jcd.Threading.IResourceLock.Release()') | Releases the lock on the resource. |
| [Wait()](IResourceLock.Wait().md 'Jcd.Threading.IResourceLock.Wait()') | Locks the resource. Blocks other calls to Lock until Release is called. |
| [Wait(CancellationToken)](IResourceLock.Wait.TET9I9Gih4bCELZJIopdow.md 'Jcd.Threading.IResourceLock.Wait(System.Threading.CancellationToken)') | Locks the resource. Blocks other calls to Lock until Release is called. |
| [WaitAsync()](IResourceLock.WaitAsync().md 'Jcd.Threading.IResourceLock.WaitAsync()') | Asynchronously Locks the resource. Blocks other calls to Lock until Release is called. |
| [WaitAsync(CancellationToken)](IResourceLock.WaitAsync.nmWfqBUe9gzKavYfWfB1wQ.md 'Jcd.Threading.IResourceLock.WaitAsync(System.Threading.CancellationToken)') | Asynchronously Locks the resource. Blocks other calls to Lock until Release is called. |
