#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ReaderWriterLockSlimExtensions](ReaderWriterLockSlimExtensions.md 'Jcd.Threading.ReaderWriterLockSlimExtensions')

## ReaderWriterLockSlimExtensions.GetResourceLock(this ReaderWriterLockSlim, ReaderWriterLockSlimIntent) Method

Gets a resource lock bound to the instance of a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')

```csharp
public static Jcd.Threading.ReaderWriterLockSlimResourceLock GetResourceLock(this System.Threading.ReaderWriterLockSlim rwls, Jcd.Threading.ReaderWriterLockSlimIntent intent);
```
#### Parameters

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.GetResourceLock(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent).rwls'></a>

`rwls` [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')

The [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') to create the resource lock for.

<a name='Jcd.Threading.ReaderWriterLockSlimExtensions.GetResourceLock(thisSystem.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent).intent'></a>

`intent` [ReaderWriterLockSlimIntent](ReaderWriterLockSlimIntent.md 'Jcd.Threading.ReaderWriterLockSlimIntent')

The intended purpose of the lock.

#### Returns
[ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock')  
A resource lock bound to the instance of a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')

### Remarks
  
This method is intended for advanced use cases. While the return type is [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
immediate disposal is effectively a very expensive no-op. This method merely creates the binding  
which provides the uniform Wait/Release calls.