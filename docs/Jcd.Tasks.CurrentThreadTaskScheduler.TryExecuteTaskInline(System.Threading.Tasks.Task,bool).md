### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[CurrentThreadTaskScheduler](Jcd.Tasks.CurrentThreadTaskScheduler.md 'Jcd.Tasks.CurrentThreadTaskScheduler')

## CurrentThreadTaskScheduler.TryExecuteTaskInline(Task, bool) Method

Runs the provided Task synchronously on the current thread.

```csharp
protected override bool TryExecuteTaskInline(System.Threading.Tasks.Task task, bool taskWasPreviouslyQueued);
```
#### Parameters

<a name='Jcd.Tasks.CurrentThreadTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

The task to be executed.

<a name='Jcd.Tasks.CurrentThreadTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).taskWasPreviouslyQueued'></a>

`taskWasPreviouslyQueued` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the Task was previously queued to the scheduler.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the Task was successfully executed; otherwise, false.