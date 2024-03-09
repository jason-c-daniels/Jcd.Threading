#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock')

## SemaphoreSlimResourceLock.WaitAsync() Method

Asynchronously Locks the resource. Blocks other calls to Lock until Release is called.

```csharp
public override System.Threading.Tasks.Task<bool> WaitAsync();
```

Implements [WaitAsync()](IResourceLock.WaitAsync().md 'Jcd.Threading.IResourceLock.WaitAsync()')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')