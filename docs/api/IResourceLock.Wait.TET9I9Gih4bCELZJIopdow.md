#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[IResourceLock](IResourceLock.md 'Jcd.Threading.IResourceLock')

## IResourceLock.Wait(CancellationToken) Method

Locks the resource. Blocks other calls to Lock until Release is called.

```csharp
bool Wait(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.IResourceLock.Wait(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to inspect for cancellation.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')