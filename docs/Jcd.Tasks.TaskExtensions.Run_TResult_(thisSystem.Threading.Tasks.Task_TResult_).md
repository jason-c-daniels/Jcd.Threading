### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.Run<TResult>(this Task<TResult>) Method

Calls [TryStart(this Task, Exception)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception)') on a task then returns the task, discarding exceptions.

```csharp
public static System.Threading.Tasks.Task<TResult> Run<TResult>(this System.Threading.Tasks.Task<TResult> task);
```
#### Type parameters

<a name='Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_).TResult'></a>

`TResult`

The type of data returned from the task.
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_).task'></a>

`task` [System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_).md#Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_).TResult 'Jcd.Tasks.TaskExtensions.Run<TResult>(this System.Threading.Tasks.Task<TResult>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

the task to start

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_).md#Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_).TResult 'Jcd.Tasks.TaskExtensions.Run<TResult>(this System.Threading.Tasks.Task<TResult>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
the original task

### Remarks
While this returns the original task, it doesn't guarantee it's awaitable. Only call  
this method if you've got 100% control over the lifecycle of the task. Otherwise call  
[TryStart(this Task, Exception)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception)') instead and inspect the results before calling await.