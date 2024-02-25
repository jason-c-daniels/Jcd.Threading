### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskSchedulerExtensions](Jcd.Tasks.TaskSchedulerExtensions.md 'Jcd.Tasks.TaskSchedulerExtensions')

## TaskSchedulerExtensions.Run<TResult>(this TaskScheduler, Func<TResult>, CancellationToken) Method

Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

```csharp
public static System.Threading.Tasks.Task<TResult> Run<TResult>(this System.Threading.Tasks.TaskScheduler scheduler, System.Func<TResult> function, System.Threading.CancellationToken cancellationToken);
```
#### Type parameters

<a name='Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_,System.Threading.CancellationToken).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_,System.Threading.CancellationToken).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The scheduler to execute the function with.

<a name='Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_,System.Threading.CancellationToken).function'></a>

`function` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TResult](Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_,System.Threading.CancellationToken).md#Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_,System.Threading.CancellationToken).TResult 'Jcd.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<TResult>, System.Threading.CancellationToken).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

the function to execute.

<a name='Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

the token to check for cancellation

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_,System.Threading.CancellationToken).md#Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_,System.Threading.CancellationToken).TResult 'Jcd.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<TResult>, System.Threading.CancellationToken).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.