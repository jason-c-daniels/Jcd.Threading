### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler._queueGroups Field

A sorted list of round-robin queue lists.  Tasks with the smallest priority value  
are preferred.  Priority groups are round-robin'd through in order of priority.

```csharp
private readonly SortedList<int,QueueGroup> _queueGroups;
```

#### Field Value
[System.Collections.Generic.SortedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedList-2 'System.Collections.Generic.SortedList`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedList-2 'System.Collections.Generic.SortedList`2')[QueueGroup](Jcd.Tasks.QueuedTaskScheduler.QueueGroup.md 'Jcd.Tasks.QueuedTaskScheduler.QueueGroup')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.SortedList-2 'System.Collections.Generic.SortedList`2')