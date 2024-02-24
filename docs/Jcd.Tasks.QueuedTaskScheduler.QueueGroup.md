### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler.QueueGroup Class

A group of queues a the same priority level.

```csharp
private class QueuedTaskScheduler.QueueGroup : System.Collections.Generic.List<Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[QueuedTaskSchedulerQueue](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1') &#129106; QueueGroup

| Fields | |
| :--- | :--- |
| [NextQueueIndex](Jcd.Tasks.QueuedTaskScheduler.QueueGroup.NextQueueIndex.md 'Jcd.Tasks.QueuedTaskScheduler.QueueGroup.NextQueueIndex') | The starting index for the next round-robin traversal. |

| Methods | |
| :--- | :--- |
| [CreateSearchOrder()](Jcd.Tasks.QueuedTaskScheduler.QueueGroup.CreateSearchOrder().md 'Jcd.Tasks.QueuedTaskScheduler.QueueGroup.CreateSearchOrder()') | Creates a search order through this group. |
