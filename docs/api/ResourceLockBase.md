#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## ResourceLockBase Class

Provides a base mechanism for managing the state of [IResourceLock](IResourceLock.md 'Jcd.Threading.IResourceLock') implementations.

```csharp
public abstract class ResourceLockBase :
Jcd.Threading.IResourceLock,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ResourceLockBase

Derived  
&#8627; [ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock')  
&#8627; [SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock')  
&#8627; [TicketLockResourceLock](TicketLockResourceLock.md 'Jcd.Threading.TicketLockResourceLock')

Implements [IResourceLock](IResourceLock.md 'Jcd.Threading.IResourceLock'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [IsLocked](ResourceLockBase.IsLocked.md 'Jcd.Threading.ResourceLockBase.IsLocked') | Indicates if the lock was acquired by this [IResourceLock](IResourceLock.md 'Jcd.Threading.IResourceLock') |
| [IsReleased](ResourceLockBase.IsReleased.md 'Jcd.Threading.ResourceLockBase.IsReleased') | Indicates if the lock was released. |
| [IsWaiting](ResourceLockBase.IsWaiting.md 'Jcd.Threading.ResourceLockBase.IsWaiting') | Indicates if the lock is currently waiting to be acquired. |

| Methods | |
| :--- | :--- |
| [BeginWait()](ResourceLockBase.BeginWait().md 'Jcd.Threading.ResourceLockBase.BeginWait()') | Removes the lock from the IsWaiting state. |
| [EndWait()](ResourceLockBase.EndWait().md 'Jcd.Threading.ResourceLockBase.EndWait()') | Removes the lock from the IsWaiting state. Call at the end of your Release method. |
| [LockAcquired()](ResourceLockBase.LockAcquired().md 'Jcd.Threading.ResourceLockBase.LockAcquired()') | Sets IsLocked to true and returns true. |
| [Release()](ResourceLockBase.Release().md 'Jcd.Threading.ResourceLockBase.Release()') | Releases the lock on the resource. |
| [ReleaseLock()](ResourceLockBase.ReleaseLock().md 'Jcd.Threading.ResourceLockBase.ReleaseLock()') | Sets flags indicated the lock has been released. |
| [Wait()](ResourceLockBase.Wait().md 'Jcd.Threading.ResourceLockBase.Wait()') | Locks the resource. Blocks other calls to Lock until Release is called. |
| [Wait(CancellationToken)](ResourceLockBase.Wait.3pA+b0N5T0DMk7gxC+L2xw.md 'Jcd.Threading.ResourceLockBase.Wait(System.Threading.CancellationToken)') | Locks the resource. Blocks other calls to Lock until Release is called. |
| [WaitAsync()](ResourceLockBase.WaitAsync().md 'Jcd.Threading.ResourceLockBase.WaitAsync()') | Asynchronously Locks the resource. Blocks other calls to Lock until Release is called. |
| [WaitAsync(CancellationToken)](ResourceLockBase.WaitAsync.77Z9VUYnWVrBCzvzlRk0BQ.md 'Jcd.Threading.ResourceLockBase.WaitAsync(System.Threading.CancellationToken)') | Asynchronously Locks the resource. Blocks other calls to Lock until Release is called. |
