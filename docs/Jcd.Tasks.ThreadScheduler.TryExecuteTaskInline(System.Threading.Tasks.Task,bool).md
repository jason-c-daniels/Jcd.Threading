### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[ThreadScheduler](Jcd.Tasks.ThreadScheduler.md 'Jcd.Tasks.ThreadScheduler')

## ThreadScheduler.TryExecuteTaskInline(Task, bool) Method

This the default implementation for this scheduler guarantees only its threads are processing tasks, so we cannot  
inline operations as inlining executes the task on the ThreadPool, which may not meet the same requirements as our  
dedicated threads.

```csharp
protected override bool TryExecuteTaskInline(System.Threading.Tasks.Task task, bool taskWasPreviouslyQueued);
```
#### Parameters

<a name='Jcd.Tasks.ThreadScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the task to try inlining

<a name='Jcd.Tasks.ThreadScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).taskWasPreviouslyQueued'></a>

`taskWasPreviouslyQueued` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

indicates if it was previously queued with this scheduler

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if it was executed inline.