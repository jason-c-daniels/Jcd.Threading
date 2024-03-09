#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[IResourceLock](IResourceLock.md 'Jcd.Threading.IResourceLock')

## IResourceLock.WaitAsync(CancellationToken) Method

Asynchronously Locks the resource. Blocks other calls to Lock until Release is called.

```csharp
System.Threading.Tasks.Task<bool> WaitAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.IResourceLock.WaitAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to inspect for cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')