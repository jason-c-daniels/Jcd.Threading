#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ReaderWriterLockSlimResourceLock](ReaderWriterLockSlimResourceLock.md 'Jcd.Threading.ReaderWriterLockSlimResourceLock')

## ReaderWriterLockSlimResourceLock.Wait(CancellationToken) Method

Locks the resource. Blocks other calls to Lock until Release is called.

```csharp
public override bool Wait(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.ReaderWriterLockSlimResourceLock.Wait(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to inspect for cancellation.

Implements [Wait(CancellationToken)](IResourceLock.Wait.TET9I9Gih4bCELZJIopdow.md 'Jcd.Threading.IResourceLock.Wait(System.Threading.CancellationToken)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')