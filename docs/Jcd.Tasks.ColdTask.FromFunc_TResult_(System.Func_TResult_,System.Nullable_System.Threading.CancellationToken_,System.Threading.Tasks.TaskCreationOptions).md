### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[ColdTask](Jcd.Tasks.ColdTask.md 'Jcd.Tasks.ColdTask')

## ColdTask.FromFunc<TResult>(Func<TResult>, Nullable<CancellationToken>, TaskCreationOptions) Method

Creates an unstarted [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') from a function. Once started the task will execute the function.

```csharp
public static System.Threading.Tasks.Task<TResult> FromFunc<TResult>(System.Func<TResult> function, System.Nullable<System.Threading.CancellationToken> cancellationToken=null, System.Threading.Tasks.TaskCreationOptions options=System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously);
```
#### Type parameters

<a name='Jcd.Tasks.ColdTask.FromFunc_TResult_(System.Func_TResult_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).TResult'></a>

`TResult`

The type of the data returned.
#### Parameters

<a name='Jcd.Tasks.ColdTask.FromFunc_TResult_(System.Func_TResult_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).function'></a>

`function` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TResult](Jcd.Tasks.ColdTask.FromFunc_TResult_(System.Func_TResult_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md#Jcd.Tasks.ColdTask.FromFunc_TResult_(System.Func_TResult_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).TResult 'Jcd.Tasks.ColdTask.FromFunc<TResult>(System.Func<TResult>, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The function to execute.

<a name='Jcd.Tasks.ColdTask.FromFunc_TResult_(System.Func_TResult_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).cancellationToken'></a>

`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The optional cancellation token for the task. The default is null/not provided.

<a name='Jcd.Tasks.ColdTask.FromFunc_TResult_(System.Func_TResult_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).options'></a>

`options` [System.Threading.Tasks.TaskCreationOptions](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions 'System.Threading.Tasks.TaskCreationOptions')

Task [System.Threading.Tasks.TaskCreationOptions](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions 'System.Threading.Tasks.TaskCreationOptions') for the task. The default is [System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously 'System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.ColdTask.FromFunc_TResult_(System.Func_TResult_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md#Jcd.Tasks.ColdTask.FromFunc_TResult_(System.Func_TResult_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).TResult 'Jcd.Tasks.ColdTask.FromFunc<TResult>(System.Func<TResult>, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The created task.