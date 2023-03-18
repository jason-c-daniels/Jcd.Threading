### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[ColdTask](Jcd.Tasks.ColdTask.md 'Jcd.Tasks.ColdTask')

## ColdTask.FromAsyncAction(Func<Task>, Nullable<CancellationToken>, TaskCreationOptions) Method

Creates an unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') from an async action. Once started the task will execute the action.

```csharp
public static System.Threading.Tasks.Task FromAsyncAction(System.Func<System.Threading.Tasks.Task> action, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, System.Threading.Tasks.TaskCreationOptions options=System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously);
```
#### Parameters

<a name='Jcd.Tasks.ColdTask.FromAsyncAction(System.Func_System.Threading.Tasks.Task_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).action'></a>

`action` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

<a name='Jcd.Tasks.ColdTask.FromAsyncAction(System.Func_System.Threading.Tasks.Task_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).cancellationToken'></a>

`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The optional cancellation token for the task. The default is null/not provided.

<a name='Jcd.Tasks.ColdTask.FromAsyncAction(System.Func_System.Threading.Tasks.Task_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).options'></a>

`options` [System.Threading.Tasks.TaskCreationOptions](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions 'System.Threading.Tasks.TaskCreationOptions')

Task [System.Threading.Tasks.TaskCreationOptions](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions 'System.Threading.Tasks.TaskCreationOptions') for the task. The default is [System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously 'System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
The created task.