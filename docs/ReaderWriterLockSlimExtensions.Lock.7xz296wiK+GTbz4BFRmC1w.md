#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ReaderWriterLockSlimExtensions](ReaderWriterLockSlimExtensions.md 'Jcd.Threading.ReaderWriterLockSlimExtensions')

## ReaderWriterLockSlimExtensions.Lock(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent, CancellationToken) Method

Waits on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and returns an IDisposable that  
calls the appropriate exit method on the lock during disposal.

```csharp
public static System.IDisposable Lock(this System.Threading.ReaderWriterLockSlim rwls, Jcd.Threading.ReaderWriterLockSlimIntent intent, System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.Lock(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent,System.Threading.CancellationToken).rwls'></a>

`rwls` [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')

The lock to acquire and release.

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.Lock(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent,System.Threading.CancellationToken).intent'></a>

`intent` [ReaderWriterLockSlimIntent](ReaderWriterLockSlimIntent.md 'Jcd.Threading.ReaderWriterLockSlimIntent')

The type of lock being acquired. By default this is a Read

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.Lock(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') to inspect for cancellation requests

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
the IDisposable to release the resources.

### Remarks
  
This method is intended to be used with a using block.  
There is little value in using it otherwise.  
  
```csharp  
// example usage.  
var rwls = new ReaderWriterLockSlim();  
var cts = new CancellationTokenSource();  
  
using (rwls.Lock(ReaderWriterLockSlimIntent.Write, cts.Token))  
{  
   // write to a critical set of values here.  
   // ..  
}  
```