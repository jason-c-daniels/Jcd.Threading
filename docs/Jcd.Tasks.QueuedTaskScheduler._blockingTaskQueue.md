### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler._blockingTaskQueue Field

The collection of tasks to be executed on our custom threads.

```csharp
private readonly BlockingCollection<Task> _blockingTaskQueue;
```

#### Field Value
[System.Collections.Concurrent.BlockingCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Concurrent.BlockingCollection-1 'System.Collections.Concurrent.BlockingCollection`1')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Concurrent.BlockingCollection-1 'System.Collections.Concurrent.BlockingCollection`1')