#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## SpinLockExtensions Class

Provides extension methods to simplify using a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock')
to ensure the correct pairing of calls to of Wait and Release.

```csharp
internal static class SpinLockExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SpinLockExtensions

### Remarks

These methods are intended to be used with a using block as illustrated below.
This will ensure the lock is held for no more time than necessary.

Contrast this with a using declaration where an method may grow in length over time,
and and execution time. Usually most of the lines in those methods shouldn't hold
the lock. The reason is the longer a lock is held, the more contention there will be.
And large scale contention for resources adversely impacts performance application
performance.

NB: The following examples are for .net7.0 and up. This is because `ref struct`s
were released with .net7.0. Since [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') is a struct, the only
way to track a reference to it is to use a `ref struct`.

```csharp
// problem illustration:
void DoNotDoThis()
{
   using _ = sl.Lock();                     // acquire the lock. But don't use the value. Just dispose it.
   AShortActionRequiringSynchronization();   // very fast: done in 10 microseconds.
   AShortActionRequiringSynchronization();   // fast: done in 75 microseconds.
   AShortActionRequiringNoSynchronization(); // reasonable but unwanted: done in 5 milliseconds.
   ALongActionRequiringNoSynchronization();  // slow: done in 500 milliseconds.
} // the lock is disposed (and released) here.
```

The reason the above code is problematic is the lock is held until disposal.
The result of Lock is an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') bound to the [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock')
which exits the lock when `Dispose` is called. `Dispose` won't be called until
the method is exited, which is the very nature of a using declaration.

Instead, use a traditional using block. Below is the corrected code.


```csharp
// problem resolution:
void DefinitelyDoThis()
{
   using (sl.Lock()) // acquire the lock. But don't use the value.
   {
      AShortActionRequiringSynchronization();   // very fast: done in 10 microseconds.
      AShortActionRequiringSynchronization();   // fast: done in 75 microseconds.
   }
   AShortActionRequiringNoSynchronization();    // the lock is no longer held. This won't cause contention.
   ALongActionRequiringNoSynchronization();     // the lock is no longer held. This won't cause contention.
}
```

As you can see, a using block clearly describes the scope for which
the lock needs to be held.

| Methods | |
| :--- | :--- |
| [GetResourceLock(this SpinLock)](SpinLockExtensions.GetResourceLock.rs2Ilo8YxHfWlGR5VIvsQA.md 'Jcd.Threading.SpinLockExtensions.GetResourceLock(this System.Threading.SpinLock)') | Gets a resource lock bound to the instance of a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') |
| [Lock(this SpinLock, Action, bool)](SpinLockExtensions.Lock.YudqElM2Ax0Q1IO1sJXVjw.md 'Jcd.Threading.SpinLockExtensions.Lock(this System.Threading.SpinLock, System.Action, bool)') | Acquires exclusive access to the spinLock and executes the provided action. |
| [Lock(this SpinLock, CancellationToken)](SpinLockExtensions.Lock.ErVYP5eiLdt7kRvEmF6mUg.md 'Jcd.Threading.SpinLockExtensions.Lock(this System.Threading.SpinLock, System.Threading.CancellationToken)') | Waits on the semaphore, and returns an [SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock') that calls Release. |
| [Lock(this SpinLock)](SpinLockExtensions.Lock.Rww9odAvmcqVyXsNUXgHFQ.md 'Jcd.Threading.SpinLockExtensions.Lock(this System.Threading.SpinLock)') | Waits on the semaphore, and returns an [SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock') that calls Release. |
| [LockAsync(this SpinLock, Action, bool)](SpinLockExtensions.LockAsync.jcrUFEL09TmPpGEu6MPqQg.md 'Jcd.Threading.SpinLockExtensions.LockAsync(this System.Threading.SpinLock, System.Action, bool)') | Acquires exclusive access to the spinLock and executes the provided action. |
