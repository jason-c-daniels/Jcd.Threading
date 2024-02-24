### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler._taskProcessingThread Field

Whether we're processing tasks on the current thread.

```csharp
private static ThreadLocal<bool> _taskProcessingThread;
```

#### Field Value
[System.Threading.ThreadLocal&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ThreadLocal-1 'System.Threading.ThreadLocal`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ThreadLocal-1 'System.Threading.ThreadLocal`1')