### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[ItemProcessor&lt;TItem&gt;](Jcd.Tasks.ItemProcessor_TItem_.md 'Jcd.Tasks.ItemProcessor<TItem>')

## ItemProcessor<TItem>.Enqueue(TItem) Method

Enqueues a [TItem](https://docs.microsoft.com/en-us/dotnet/api/TItem 'TItem'). This is a "fire and forget" method. Control is immediately  
returned to the caller.

```csharp
public void Enqueue(TItem item);
```
#### Parameters

<a name='Jcd.Tasks.ItemProcessor_TItem_.Enqueue(TItem).item'></a>

`item` [TItem](Jcd.Tasks.ItemProcessor_TItem_.md#Jcd.Tasks.ItemProcessor_TItem_.TItem 'Jcd.Tasks.ItemProcessor<TItem>.TItem')

The action to enqueue.