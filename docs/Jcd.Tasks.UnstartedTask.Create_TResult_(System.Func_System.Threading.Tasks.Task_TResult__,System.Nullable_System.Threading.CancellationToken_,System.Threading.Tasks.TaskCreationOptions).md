### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[UnstartedTask](Jcd.Tasks.UnstartedTask.md 'Jcd.Tasks.UnstartedTask')

## UnstartedTask.Create<TResult>(Func<Task<TResult>>, Nullable<CancellationToken>, TaskCreationOptions) Method

Creates an unstarted [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') as a proxy for an asynchronous function. Once started the task will execute the function.

```csharp
public static System.Threading.Tasks.Task<TResult> Create<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> function, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, System.Threading.Tasks.TaskCreationOptions options=System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously);
```
#### Type parameters

<a name='Jcd.Tasks.UnstartedTask.Create_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).TResult'></a>

`TResult`

The type of the data returned.
#### Parameters

<a name='Jcd.Tasks.UnstartedTask.Create_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).function'></a>

`function` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.UnstartedTask.Create_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md#Jcd.Tasks.UnstartedTask.Create_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).TResult 'Jcd.Tasks.UnstartedTask.Create<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

<a name='Jcd.Tasks.UnstartedTask.Create_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).cancellationToken'></a>

`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The optional cancellation token for the task. The default is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null').

<a name='Jcd.Tasks.UnstartedTask.Create_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).options'></a>

`options` [System.Threading.Tasks.TaskCreationOptions](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions 'System.Threading.Tasks.TaskCreationOptions')

Task [System.Threading.Tasks.TaskCreationOptions](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions 'System.Threading.Tasks.TaskCreationOptions') for the task. The default is [System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously 'System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.UnstartedTask.Create_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md#Jcd.Tasks.UnstartedTask.Create_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).TResult 'Jcd.Tasks.UnstartedTask.Create<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An unstarted [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') proxy for the asynchronous function.