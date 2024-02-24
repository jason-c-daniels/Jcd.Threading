### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler._nonthreadsafeTaskQueue Field

The queue of tasks to process when using an underlying target scheduler.

```csharp
private readonly Queue<Task> _nonthreadsafeTaskQueue;
```

#### Field Value
[System.Collections.Generic.Queue&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Queue-1 'System.Collections.Generic.Queue`1')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Queue-1 'System.Collections.Generic.Queue`1')