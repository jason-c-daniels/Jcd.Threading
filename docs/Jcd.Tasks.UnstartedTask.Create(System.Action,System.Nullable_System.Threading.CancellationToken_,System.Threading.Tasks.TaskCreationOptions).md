### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[UnstartedTask](Jcd.Tasks.UnstartedTask.md 'Jcd.Tasks.UnstartedTask')

## UnstartedTask.Create(Action, Nullable<CancellationToken>, TaskCreationOptions) Method

Creates an unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') as a proxy for an action. Once started the task will execute the action.

```csharp
public static System.Threading.Tasks.Task Create(System.Action action, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, System.Threading.Tasks.TaskCreationOptions options=System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously);
```
#### Parameters

<a name='Jcd.Tasks.UnstartedTask.Create(System.Action,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The work to execute.

<a name='Jcd.Tasks.UnstartedTask.Create(System.Action,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).cancellationToken'></a>

`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The optional cancellation token for the task. The default is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null').

<a name='Jcd.Tasks.UnstartedTask.Create(System.Action,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).options'></a>

`options` [System.Threading.Tasks.TaskCreationOptions](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions 'System.Threading.Tasks.TaskCreationOptions')

Task [System.Threading.Tasks.TaskCreationOptions](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions 'System.Threading.Tasks.TaskCreationOptions') for the task. The default is [System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously 'System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
An unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') proxy for the action.