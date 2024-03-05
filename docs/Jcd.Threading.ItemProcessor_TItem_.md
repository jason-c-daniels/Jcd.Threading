#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## ItemProcessor<TItem> Class

An item processor that calls a delegate on each item enqueued with it.

```csharp
public sealed class ItemProcessor<TItem> : Jcd.Threading.ThreadWrapper
```
#### Type parameters

<a name='Jcd.Threading.ItemProcessor_TItem_.TItem'></a>

`TItem`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ThreadWrapper](Jcd.Threading.ThreadWrapper.md 'Jcd.Threading.ThreadWrapper') &#129106; ItemProcessor<TItem>

### Remarks
You must ensure all shared resources owned by the enqueued items have their access  
synchronized appropriately. This type only synchronizes access to internal data.

| Constructors | |
| :--- | :--- |
| [ItemProcessor(Action&lt;TItem&gt;, bool, string, bool, bool, int, ThreadPriority, ApartmentState)](Jcd.Threading.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,bool,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).md 'Jcd.Threading.ItemProcessor<TItem>.ItemProcessor(System.Action<TItem>, bool, string, bool, bool, int, System.Threading.ThreadPriority, System.Threading.ApartmentState)') | Constructs a [ItemProcessor&lt;TItem&gt;](Jcd.Threading.ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>') |

| Properties | |
| :--- | :--- |
| [Count](Jcd.Threading.ItemProcessor_TItem_.Count.md 'Jcd.Threading.ItemProcessor<TItem>.Count') | The number of items in the internal queue. |
| [HasItems](Jcd.Threading.ItemProcessor_TItem_.HasItems.md 'Jcd.Threading.ItemProcessor<TItem>.HasItems') | Gets a flag indicating if there are any pending items. |
| [Items](Jcd.Threading.ItemProcessor_TItem_.Items.md 'Jcd.Threading.ItemProcessor<TItem>.Items') | |

| Methods | |
| :--- | :--- |
| [Clear()](Jcd.Threading.ItemProcessor_TItem_.Clear().md 'Jcd.Threading.ItemProcessor<TItem>.Clear()') | Clears all items out of the queue. USE AT YOUR OWN RISK! |
| [ClearAsync()](Jcd.Threading.ItemProcessor_TItem_.ClearAsync().md 'Jcd.Threading.ItemProcessor<TItem>.ClearAsync()') | Asynchronously clears all items out of the queue. USE AT YOUR OWN RISK! |
| [Dispose(bool)](Jcd.Threading.ItemProcessor_TItem_.Dispose(bool).md 'Jcd.Threading.ItemProcessor<TItem>.Dispose(bool)') | Cleans up other disposables. |
| [Enqueue(TItem)](Jcd.Threading.ItemProcessor_TItem_.Enqueue(TItem).md 'Jcd.Threading.ItemProcessor<TItem>.Enqueue(TItem)') | Enqueues an item. Control is immediately<br/>returned to the caller. |
| [EnqueueAsync(TItem)](Jcd.Threading.ItemProcessor_TItem_.EnqueueAsync(TItem).md 'Jcd.Threading.ItemProcessor<TItem>.EnqueueAsync(TItem)') | Enqueues an item asynchronously. Control is immediately<br/>returned to the caller. |
| [PerformWork(CancellationToken)](Jcd.Threading.ItemProcessor_TItem_.PerformWork(System.Threading.CancellationToken).md 'Jcd.Threading.ItemProcessor<TItem>.PerformWork(System.Threading.CancellationToken)') | Grabs the first item in the queue and performs the user provided action on it. |
