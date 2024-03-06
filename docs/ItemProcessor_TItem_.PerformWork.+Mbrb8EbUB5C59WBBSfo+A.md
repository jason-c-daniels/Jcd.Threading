#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ItemProcessor&lt;TItem&gt;](ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>')

## ItemProcessor<TItem>.PerformWork(CancellationToken) Method

Grabs the first item in the queue and performs the user provided action on it.

```csharp
protected override bool PerformWork(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.ItemProcessor_TItem_.PerformWork(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to inspect for cancellation.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if there are pending items after the work is performed.