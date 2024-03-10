#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock')

## ReaderWriterLockSlimResourceLock(ReaderWriterLockSlim, ReaderWriterLockSlimIntent) Constructor

Provides a single-use mechanism for establishing and releasing locks on a [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim').

```csharp
public ReaderWriterLockSlimResourceLock(System.Threading.ReaderWriterLockSlim internalLock, Jcd.Threading.ReaderWriterLockSlimIntent intent);
```
#### Parameters

<a name='Jcd.Threading.ReaderWriterLockSlimResourceLock.ReaderWriterLockSlimResourceLock(System.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent).internalLock'></a>

`internalLock` [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim')

The [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') to lock and release.

<a name='Jcd.Threading.ReaderWriterLockSlimResourceLock.ReaderWriterLockSlimResourceLock(System.Threading.ReaderWriterLockSlim,Jcd.Threading.ReaderWriterLockSlimIntent).intent'></a>

`intent` [ReaderWriterLockSlimIntent](ReaderWriterLockSlimIntent.md 'Jcd.Threading.ReaderWriterLockSlimIntent')

The intent of the lock (Read, UpgradeableRead, Write)

### Remarks
  
Do not share instances of this type across threads or synchronization contexts.  
Behavior can be unpredictable. This exists to be used in conjunction  
with the .Lock extension method for [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and  
advanced use cases.