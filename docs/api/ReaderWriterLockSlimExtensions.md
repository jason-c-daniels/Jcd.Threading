#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## ReaderWriterLockSlimExtensions Class

Provides extension methods to simplify using a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')
to ensure the correct pair of EnterRead plus ExitRead, EnterUpgradeableRead plus ExitUpgradeableRead,
and EnterWrite plus ExitWrite are called.

```csharp
public static class ReaderWriterLockSlimExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ReaderWriterLockSlimExtensions

### Remarks

These methods are intended to be used with a using block as illustrated below.
This will ensure the lock is held for no more time than necessary.

Contrast this with a using declaration where an method may grow in length over time,
and and execution time. Usually most of the lines in those methods shouldn't hold
the lock. The reason is the longer a lock is held, the more contention there will be.
And large scale contention for resources adversely impacts performance application
performance.

```csharp
// problem illustration:
void DoNotDoThis()
{
   using _ = rwls.Lock(ReaderWriterLockSlimIntent.Write); // acquire the lock. But don't use the value. Just dispose it.
   AShortActionRequiringSynchronization();   // very fast: done in 10 microseconds.
   AShortActionRequiringSynchronization();   // fast: done in 75 microseconds.
   AShortActionRequiringNoSynchronization(); // reasonable but unwanted: done in 5 milliseconds.
   ALongActionRequiringNoSynchronization();  // slow: done in 500 milliseconds.
} // the lock is disposed (and released) here.
```

The reason the above code is problematic is the lock is held until disposal.
The result of Lock is an [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') bound to the [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')
which exits the lock when `Dispose` is called. `Dispose` won't be called until
the method is exited, the very nature of a using declaration.

Instead, use a traditional using block. Below is the corrected code.


```csharp
// problem resolution:
void DefinitelyDoThis()
{
   using (rwls.Lock(ReaderWriterLockSlimIntent.Write)) // acquire the lock. But don't use the value.
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
| [GetResourceLock(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent)](ReaderWriterLockSlimExtensions.GetResourceLock.AzNe84awJcDDQTeRS6hyNg.md 'Jcd.Threading.ReaderWriterLockSlimExtensions.GetResourceLock(this System.Threading.ReaderWriterLockSlim, Jcd.Threading.ReaderWriterLockSlimIntent)') | Gets a resource lock bound to the instance of a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') |
| [Lock(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent, CancellationToken)](ReaderWriterLockSlimExtensions.Lock.7xz296wiK+GTbz4BFRmC1w.md 'Jcd.Threading.ReaderWriterLockSlimExtensions.Lock(this System.Threading.ReaderWriterLockSlim, Jcd.Threading.ReaderWriterLockSlimIntent, System.Threading.CancellationToken)') | Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns a [ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock') that calls the appropriate exit method on the lock during disposal. |
| [Lock(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent)](ReaderWriterLockSlimExtensions.Lock.PbfeDuxIOKnp2wHKGkWu4g.md 'Jcd.Threading.ReaderWriterLockSlimExtensions.Lock(this System.Threading.ReaderWriterLockSlim, Jcd.Threading.ReaderWriterLockSlimIntent)') | Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns a [ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock') that calls the appropriate exit method on the lock during disposal. |
| [LockAsync(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent, CancellationToken)](ReaderWriterLockSlimExtensions.LockAsync.xY3dp8fIlGJtpbHt/hy7GA.md 'Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(this System.Threading.ReaderWriterLockSlim, Jcd.Threading.ReaderWriterLockSlimIntent, System.Threading.CancellationToken)') | Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns a [ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock') that calls the appropriate exit method on the lock during disposal. |
| [LockAsync(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent)](ReaderWriterLockSlimExtensions.LockAsync.jN9Mr6okIrexTbtUMJPQgQ.md 'Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(this System.Threading.ReaderWriterLockSlim, Jcd.Threading.ReaderWriterLockSlimIntent)') | Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns a [ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock') that calls the appropriate exit method on the lock during disposal. |
