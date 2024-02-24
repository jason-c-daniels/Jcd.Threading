### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[CurrentThreadTaskScheduler](Jcd.Tasks.CurrentThreadTaskScheduler.md 'Jcd.Tasks.CurrentThreadTaskScheduler')

## CurrentThreadTaskScheduler.GetScheduledTasks() Method

Gets the Tasks currently scheduled to this scheduler.

```csharp
protected override System.Collections.Generic.IEnumerable<System.Threading.Tasks.Task> GetScheduledTasks();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
An empty enumerable, as Tasks are never queued, only executed.