#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## SpinLockExtensions Class

Provides extension methods to aid in working with SpinLocks

```csharp
internal static class SpinLockExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SpinLockExtensions

| Methods | |
| :--- | :--- |
| [GetResourceLock(this SpinLock)](SpinLockExtensions.GetResourceLock.rs2Ilo8YxHfWlGR5VIvsQA.md 'Jcd.Threading.SpinLockExtensions.GetResourceLock(this System.Threading.SpinLock)') | Gets a resource lock bound to the instance of a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') |
| [Lock(this SpinLock, Action, bool)](SpinLockExtensions.Lock.YudqElM2Ax0Q1IO1sJXVjw.md 'Jcd.Threading.SpinLockExtensions.Lock(this System.Threading.SpinLock, System.Action, bool)') | Acquires exclusive access to the spinLock and executes the provided action. |
| [Lock(this SpinLock, CancellationToken)](SpinLockExtensions.Lock.ErVYP5eiLdt7kRvEmF6mUg.md 'Jcd.Threading.SpinLockExtensions.Lock(this System.Threading.SpinLock, System.Threading.CancellationToken)') | Waits on the semaphore, and returns an [SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock') that calls Release. |
| [Lock(this SpinLock)](SpinLockExtensions.Lock.Rww9odAvmcqVyXsNUXgHFQ.md 'Jcd.Threading.SpinLockExtensions.Lock(this System.Threading.SpinLock)') | Waits on the semaphore, and returns an [SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock') that calls Release. |
| [LockAsync(this SpinLock, Action, bool)](SpinLockExtensions.LockAsync.jcrUFEL09TmPpGEu6MPqQg.md 'Jcd.Threading.SpinLockExtensions.LockAsync(this System.Threading.SpinLock, System.Action, bool)') | Acquires exclusive access to the spinLock and executes the provided action. |
