#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## ReaderWriterLockSlimExtensions Class

A set of extension methods to simplify using a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')  
to ensure the correct pair of EnterRead+ExitRead, EnterUpgradeableRead+ExitUpgradeableRead,  
and EnterWrite+ExitWrite are called.

```csharp
public static class ReaderWriterLockSlimExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ReaderWriterLockSlimExtensions

| Methods | |
| :--- | :--- |
| [GetResourceLock(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent)](ReaderWriterLockSlimExtensions.GetResourceLock.AzNe84awJcDDQTeRS6hyNg.md 'Jcd.Threading.ReaderWriterLockSlimExtensions.GetResourceLock(this System.Threading.ReaderWriterLockSlim, Jcd.Threading.ReaderWriterLockSlimIntent)') | Gets a resource lock bound to the instance of a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') |
| [Lock(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent)](ReaderWriterLockSlimExtensions.Lock.PbfeDuxIOKnp2wHKGkWu4g.md 'Jcd.Threading.ReaderWriterLockSlimExtensions.Lock(this System.Threading.ReaderWriterLockSlim, Jcd.Threading.ReaderWriterLockSlimIntent)') | Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns an IDisposable that<br/>calls the appropriate exit method on the lock during disposal. |
| [Lock(this ReaderWriterLockSlim, CancellationToken, ReaderWriterLockSlimIntent)](ReaderWriterLockSlimExtensions.Lock.QD9diZQYIPNSYkJBbCxQWA.md 'Jcd.Threading.ReaderWriterLockSlimExtensions.Lock(this System.Threading.ReaderWriterLockSlim, System.Threading.CancellationToken, Jcd.Threading.ReaderWriterLockSlimIntent)') | Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns an IDisposable that<br/>calls the appropriate exit method on the lock during disposal. |
| [LockAsync(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent)](ReaderWriterLockSlimExtensions.LockAsync.jN9Mr6okIrexTbtUMJPQgQ.md 'Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(this System.Threading.ReaderWriterLockSlim, Jcd.Threading.ReaderWriterLockSlimIntent)') | Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns an IDisposable that<br/>calls the appropriate exit method on the lock during disposal. |
| [LockAsync(this ReaderWriterLockSlim, CancellationToken, ReaderWriterLockSlimIntent)](ReaderWriterLockSlimExtensions.LockAsync.DkGTvz91hXHO5DzrZ9HecQ.md 'Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(this System.Threading.ReaderWriterLockSlim, System.Threading.CancellationToken, Jcd.Threading.ReaderWriterLockSlimIntent)') | Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns an IDisposable that<br/>calls the appropriate exit method on the lock during disposal. |
