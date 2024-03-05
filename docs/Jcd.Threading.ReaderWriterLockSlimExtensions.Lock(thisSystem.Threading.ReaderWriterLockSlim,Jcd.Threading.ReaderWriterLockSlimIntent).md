#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ReaderWriterLockSlimExtensions](Jcd.Threading.ReaderWriterLockSlimExtensions.md 'Jcd.Threading.ReaderWriterLockSlimExtensions')

## ReaderWriterLockSlimExtensions.Lock(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent) Method

Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns an IDisposable that  
calls the appropriate exit method on the lock during disposal.

```csharp
public static System.IDisposable Lock(this System.Threading.ReaderWriterLockSlim @lock, Jcd.Threading.ReaderWriterLockSlimIntent intent=Jcd.Threading.ReaderWriterLockSlimIntent.Read);
```
#### Parameters

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.Lock(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent).lock'></a>

`lock` [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')

The lock to acquire and release.

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.Lock(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent).intent'></a>

`intent` [ReaderWriterLockSlimIntent](Jcd.Threading.ReaderWriterLockSlimIntent.md 'Jcd.Threading.ReaderWriterLockSlimIntent')

The type of lock being acquired. By default this is a Read

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
the IDisposable to release the resources.

### Remarks
  
This method is intended to be used with a using block.  
There is little value in using it otherwise.  
  
```csharp  
// example usage.  
var rwls = new ReaderWriterLockSlim();  
  
using (rwls.Lock(ReaderWriterLockSlimIntent.Write))  
{  
   // write to a critical set of values here.  
   // ..  
}  
```