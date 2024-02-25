#### [Jcd.Tasks](index.md 'index')
### [Jcd.Tasks.TaskSchedulers](Jcd.Tasks.TaskSchedulers.md 'Jcd.Tasks.TaskSchedulers').[ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler')

## ThreadTaskScheduler.TryExecuteTaskInline(Task, bool) Method

The method to attempt executing a Task in the calling thread's context.  
This is disabled by default. See remarks for discussion.

```csharp
protected override bool TryExecuteTaskInline(System.Threading.Tasks.Task task, bool taskWasPreviouslyQueued);
```
#### Parameters

<a name='Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the task to try inlining

<a name='Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).taskWasPreviouslyQueued'></a>

`taskWasPreviouslyQueued` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

indicates if it was previously queued with this scheduler

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
false, by default, may be overridden in a derived type.

### Remarks
The default implementation for this scheduler guarantees only its threads are processing tasks, so we cannot  
inline operations as inlining executes the task on the ThreadPool, which may not meet the same requirements as our  
dedicated threads.