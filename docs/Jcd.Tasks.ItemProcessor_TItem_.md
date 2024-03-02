### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## ItemProcessor<TItem> Class

An item processor that calls a delegate on each item enqueued with it.

```csharp
public sealed class ItemProcessor<TItem> :
System.IDisposable
```
#### Type parameters

<a name='Jcd.Tasks.ItemProcessor_TItem_.TItem'></a>

`TItem`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ItemProcessor<TItem>

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

### Remarks
You must ensure all shared resources owned by the enqueued items have their access  
synchronized appropriately. This type only synchronizes access to internal data.

| Constructors | |
| :--- | :--- |
| [ItemProcessor(Action&lt;TItem&gt;, bool, string, bool, ThreadPriority, ApartmentState)](Jcd.Tasks.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState).md 'Jcd.Tasks.ItemProcessor<TItem>.ItemProcessor(System.Action<TItem>, bool, string, bool, System.Threading.ThreadPriority, System.Threading.ApartmentState)') | Constructs a [ItemProcessor&lt;TItem&gt;](Jcd.Tasks.ItemProcessor_TItem_.md 'Jcd.Tasks.ItemProcessor<TItem>') |

| Properties | |
| :--- | :--- |
| [Count](Jcd.Tasks.ItemProcessor_TItem_.Count.md 'Jcd.Tasks.ItemProcessor<TItem>.Count') | The number of items in the internal queue. |
| [HasItems](Jcd.Tasks.ItemProcessor_TItem_.HasItems.md 'Jcd.Tasks.ItemProcessor<TItem>.HasItems') | Gets a flag indicating if there are any pending items. |
| [IsIdle](Jcd.Tasks.ItemProcessor_TItem_.IsIdle.md 'Jcd.Tasks.ItemProcessor<TItem>.IsIdle') | Gets a flag indicating if the item processing is currently paused. |
| [IsPaused](Jcd.Tasks.ItemProcessor_TItem_.IsPaused.md 'Jcd.Tasks.ItemProcessor<TItem>.IsPaused') | Gets a flag indicating if the item processing is currently paused. |
| [IsStarted](Jcd.Tasks.ItemProcessor_TItem_.IsStarted.md 'Jcd.Tasks.ItemProcessor<TItem>.IsStarted') | Gets a flag indicating if the item processing loop has started. |
| [Items](Jcd.Tasks.ItemProcessor_TItem_.Items.md 'Jcd.Tasks.ItemProcessor<TItem>.Items') | |
| [Thread](Jcd.Tasks.ItemProcessor_TItem_.Thread.md 'Jcd.Tasks.ItemProcessor<TItem>.Thread') | Provides direct access to the underlying thread. |

| Methods | |
| :--- | :--- |
| [Enqueue(TItem)](Jcd.Tasks.ItemProcessor_TItem_.Enqueue(TItem).md 'Jcd.Tasks.ItemProcessor<TItem>.Enqueue(TItem)') | Enqueues a [TItem](https://docs.microsoft.com/en-us/dotnet/api/TItem 'TItem'). This is a "fire and forget" method. Control is immediately<br/>returned to the caller. |
| [Pause()](Jcd.Tasks.ItemProcessor_TItem_.Pause().md 'Jcd.Tasks.ItemProcessor<TItem>.Pause()') | Pauses the retrieval and processing of queued items. |
| [PauseAsync()](Jcd.Tasks.ItemProcessor_TItem_.PauseAsync().md 'Jcd.Tasks.ItemProcessor<TItem>.PauseAsync()') | Pauses the retrieval and execution of queued items. |
| [Resume()](Jcd.Tasks.ItemProcessor_TItem_.Resume().md 'Jcd.Tasks.ItemProcessor<TItem>.Resume()') | Resumes item processing. |
| [ResumeAsync()](Jcd.Tasks.ItemProcessor_TItem_.ResumeAsync().md 'Jcd.Tasks.ItemProcessor<TItem>.ResumeAsync()') | Resumes item processing. |
| [Start()](Jcd.Tasks.ItemProcessor_TItem_.Start().md 'Jcd.Tasks.ItemProcessor<TItem>.Start()') | Starts the processing of queued items. |
