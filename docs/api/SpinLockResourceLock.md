#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## SpinLockResourceLock Struct

Provides a single-use mechanism for establishing and releasing locks on a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock').

```csharp
public ref struct SpinLockResourceLock
```

### Remarks
  
This struct exists to be used in conjunction with the .Lock extension method for  
[System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') and advanced use cases.

| Constructors | |
| :--- | :--- |
| [SpinLockResourceLock(SpinLock)](SpinLockResourceLock..ctor.G2/3SZStevwzoNnrYsxPog.md 'Jcd.Threading.SpinLockResourceLock.SpinLockResourceLock(System.Threading.SpinLock)') | Creates an instance of [SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock') bound to a specific [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') |

| Properties | |
| :--- | :--- |
| [IsLocked](SpinLockResourceLock.IsLocked.md 'Jcd.Threading.SpinLockResourceLock.IsLocked') | Indicates if the lock was acquired by this [SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock') |
| [IsReleased](SpinLockResourceLock.IsReleased.md 'Jcd.Threading.SpinLockResourceLock.IsReleased') | Indicates if the lock was released. |
| [IsWaiting](SpinLockResourceLock.IsWaiting.md 'Jcd.Threading.SpinLockResourceLock.IsWaiting') | Indicates if the lock is currently waiting to acquire the resource. |

| Methods | |
| :--- | :--- |
| [BeginWait()](SpinLockResourceLock.BeginWait().md 'Jcd.Threading.SpinLockResourceLock.BeginWait()') | Removes the lock from the IsWaiting state. |
| [Dispose()](SpinLockResourceLock.Dispose().md 'Jcd.Threading.SpinLockResourceLock.Dispose()') | Releases the lock on the resource. |
| [EndWait()](SpinLockResourceLock.EndWait().md 'Jcd.Threading.SpinLockResourceLock.EndWait()') | Removes the lock from the IsWaiting state. Call at the end of your Release method. |
| [LockAcquired()](SpinLockResourceLock.LockAcquired().md 'Jcd.Threading.SpinLockResourceLock.LockAcquired()') | Sets IsLocked to true and returns true. |
| [Release()](SpinLockResourceLock.Release().md 'Jcd.Threading.SpinLockResourceLock.Release()') | Releases the lock on the resource. |
| [ReleaseLock()](SpinLockResourceLock.ReleaseLock().md 'Jcd.Threading.SpinLockResourceLock.ReleaseLock()') | Sets flags indicated the lock has been released. |
| [Wait()](SpinLockResourceLock.Wait().md 'Jcd.Threading.SpinLockResourceLock.Wait()') | Locks the resource. Blocks other calls to Lock until Release is called. |
| [Wait(CancellationToken)](SpinLockResourceLock.Wait.AZ8J8ILbBy6iF29lmsgtmg.md 'Jcd.Threading.SpinLockResourceLock.Wait(System.Threading.CancellationToken)') | Locks the resource. Blocks other calls to Lock until Release is called. |
| [WaitAsync()](SpinLockResourceLock.WaitAsync().md 'Jcd.Threading.SpinLockResourceLock.WaitAsync()') | Asynchronously Locks the resource. Blocks other calls to Lock until Release is called. |
| [WaitAsync(CancellationToken)](SpinLockResourceLock.WaitAsync.OQ7VHo8OAcrVL90ArJiEQw.md 'Jcd.Threading.SpinLockResourceLock.WaitAsync(System.Threading.CancellationToken)') | Asynchronously Locks the resource. Blocks other calls to Lock until Release is called. |
