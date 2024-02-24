### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler.TryExecuteTaskInline(Task, bool) Method

Tries to execute a task synchronously on the current thread.

```csharp
protected override bool TryExecuteTaskInline(System.Threading.Tasks.Task task, bool taskWasPreviouslyQueued);
```
#### Parameters

<a name='Jcd.Tasks.QueuedTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

The task to execute.

<a name='Jcd.Tasks.QueuedTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).taskWasPreviouslyQueued'></a>

`taskWasPreviouslyQueued` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the task was previously queued.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the task was executed; otherwise, false.