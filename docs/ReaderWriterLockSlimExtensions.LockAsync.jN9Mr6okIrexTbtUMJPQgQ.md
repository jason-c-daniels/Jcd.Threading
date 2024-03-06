#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ReaderWriterLockSlimExtensions](ReaderWriterLockSlimExtensions.md 'Jcd.Threading.ReaderWriterLockSlimExtensions')

## ReaderWriterLockSlimExtensions.LockAsync(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent) Method

Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns an IDisposable that  
calls the appropriate exit method on the lock during disposal.

```csharp
public static System.Threading.Tasks.Task<System.IDisposable> LockAsync(this System.Threading.ReaderWriterLockSlim @lock, Jcd.Threading.ReaderWriterLockSlimIntent intent=Jcd.Threading.ReaderWriterLockSlimIntent.Read);
```
#### Parameters

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent).lock'></a>

`lock` [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')

The lock to acquire and release.

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.LockAsync(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent).intent'></a>

`intent` [ReaderWriterLockSlimIntent](ReaderWriterLockSlimIntent.md 'Jcd.Threading.ReaderWriterLockSlimIntent')

The type of lock being acquired. By default this is a Read

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
the IDisposable to release the resources.

### Remarks
  
This method is intended to be used with a using block.  
There is little value in using it otherwise.  
  
```csharp  
// example usage.  
var rwls = new ReaderWriterLockSlim();  
  
using (await rwls.LockAsync(ReaderWriterLockSlimIntent.Write))  
{  
   // write to a critical set of values here.  
   // ..  
}  
```