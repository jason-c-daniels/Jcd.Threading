#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ItemProcessor&lt;TItem&gt;](ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>')

## ItemProcessor<TItem>.EnqueueAsync(TItem) Method

Enqueues an item asynchronously. Control is immediately  
returned to the caller.

```csharp
public System.Threading.Tasks.Task EnqueueAsync(TItem item);
```
#### Parameters

<a name='Jcd.Threading.ItemProcessor_TItem_.EnqueueAsync(TItem).item'></a>

`item` [TItem](ItemProcessor_TItem_.md#Jcd.Threading.ItemProcessor_TItem_.TItem 'Jcd.Threading.ItemProcessor<TItem>.TItem')

The action to enqueue.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')