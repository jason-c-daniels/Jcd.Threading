### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.Run<TResult>(this Task<TResult>, TaskScheduler) Method

Calls [TryStart(this Task, Exception, TaskScheduler)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception, System.Threading.Tasks.TaskScheduler)') on a task then returns the task, discarding exceptions.

```csharp
public static System.Threading.Tasks.Task<TResult> Run<TResult>(this System.Threading.Tasks.Task<TResult> task, System.Threading.Tasks.TaskScheduler taskScheduler=null);
```
#### Type parameters

<a name='Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Threading.Tasks.TaskScheduler).TResult'></a>

`TResult`

The type of data returned from the task.
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Threading.Tasks.TaskScheduler).task'></a>

`task` [System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Threading.Tasks.TaskScheduler).md#Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Threading.Tasks.TaskScheduler).TResult 'Jcd.Tasks.TaskExtensions.Run<TResult>(this System.Threading.Tasks.Task<TResult>, System.Threading.Tasks.TaskScheduler).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

the task to start

<a name='Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Threading.Tasks.TaskScheduler).taskScheduler'></a>

`taskScheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') to use for executing the task. If not provided the  
current [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') is used.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Threading.Tasks.TaskScheduler).md#Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Threading.Tasks.TaskScheduler).TResult 'Jcd.Tasks.TaskExtensions.Run<TResult>(this System.Threading.Tasks.Task<TResult>, System.Threading.Tasks.TaskScheduler).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
the original task

### Remarks
While this returns the original task, it doesn't guarantee it's awaitable. Only call  
this method if you've got 100% control over the lifecycle of the task. Otherwise call  
[TryStart(this Task, Exception, TaskScheduler)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception, System.Threading.Tasks.TaskScheduler)') instead and inspect the results before calling await.