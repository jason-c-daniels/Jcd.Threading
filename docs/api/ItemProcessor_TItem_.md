#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## ItemProcessor<TItem> Class

Provides the ability to call a delegate on each item in an internally managed queue
from its own background thread.

```csharp
public sealed class ItemProcessor<TItem> : Jcd.Threading.ThreadWrapper
```
#### Type parameters

<a name='Jcd.Threading.ItemProcessor_TItem_.TItem'></a>

`TItem`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper') &#129106; ItemProcessor<TItem>

### Remarks
You must ensure all shared resources owned by the enqueued items have their access
synchronized appropriately. This type only synchronizes access to internal data.

| Constructors | |
| :--- | :--- |
| [ItemProcessor(Action&lt;TItem&gt;, bool, string, bool, int, int, ThreadPriority, ApartmentState)](ItemProcessor_TItem_..ctor.Dy3hP/j6mEGF9KY6x9i2GA.md 'Jcd.Threading.ItemProcessor<TItem>.ItemProcessor(System.Action<TItem>, bool, string, bool, int, int, System.Threading.ThreadPriority, System.Threading.ApartmentState)') | Constructs a [ItemProcessor&lt;TItem&gt;](ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>') |

| Properties | |
| :--- | :--- |
| [Count](ItemProcessor_TItem_.Count.md 'Jcd.Threading.ItemProcessor<TItem>.Count') | The number of items in the internal queue. |
| [HasItems](ItemProcessor_TItem_.HasItems.md 'Jcd.Threading.ItemProcessor<TItem>.HasItems') | Gets a flag indicating if there are any pending items. |
| [Items](ItemProcessor_TItem_.Items.md 'Jcd.Threading.ItemProcessor<TItem>.Items') | |

| Methods | |
| :--- | :--- |
| [Clear()](ItemProcessor_TItem_.Clear().md 'Jcd.Threading.ItemProcessor<TItem>.Clear()') | Clears all items out of the queue. USE AT YOUR OWN RISK! |
| [ClearAsync()](ItemProcessor_TItem_.ClearAsync().md 'Jcd.Threading.ItemProcessor<TItem>.ClearAsync()') | Asynchronously clears all items out of the queue. USE AT YOUR OWN RISK! |
| [Dispose(bool)](ItemProcessor_TItem_.Dispose.R9oK3S7Odlhv6x2YZ2IuYQ.md 'Jcd.Threading.ItemProcessor<TItem>.Dispose(bool)') | Cleans up other disposables. |
| [Enqueue(TItem)](ItemProcessor_TItem_.Enqueue.N3GhfJcbwhpIzx+5apE2ZQ.md 'Jcd.Threading.ItemProcessor<TItem>.Enqueue(TItem)') | Enqueues an item. Control is immediately returned to the caller. |
| [EnqueueAsync(TItem)](ItemProcessor_TItem_.EnqueueAsync.mVMQ00UOgrbxulMCDWdHGw.md 'Jcd.Threading.ItemProcessor<TItem>.EnqueueAsync(TItem)') | Enqueues an item asynchronously. Control is immediately returned to the caller. |
| [PerformWork(CancellationToken)](ItemProcessor_TItem_.PerformWork.+Mbrb8EbUB5C59WBBSfo+A.md 'Jcd.Threading.ItemProcessor<TItem>.PerformWork(System.Threading.CancellationToken)') | Grabs the first item in the queue and performs the user provided action on it. |
