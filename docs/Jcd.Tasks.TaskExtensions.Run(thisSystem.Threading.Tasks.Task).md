### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.Run(this Task) Method

Calls [TryStart(this Task, Exception, TaskScheduler)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception, System.Threading.Tasks.TaskScheduler)') on a task then returns the task, discarding exceptions.

```csharp
public static System.Threading.Tasks.Task Run(this System.Threading.Tasks.Task task);
```
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.Run(thisSystem.Threading.Tasks.Task).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the task to start

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
the original task

### Remarks
While this returns the original task, it doesn't guarantee it's awaitable. Only call  
this method if you've got 100% control over the lifecycle of the task. Otherwise call  
[TryStart(this Task, Exception, TaskScheduler)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception, System.Threading.Tasks.TaskScheduler)') instead and inspect the results before calling await.