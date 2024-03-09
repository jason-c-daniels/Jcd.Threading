#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks').[TaskSchedulerExtensions](TaskSchedulerExtensions.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions')

## TaskSchedulerExtensions.Run<TResult>(this TaskScheduler, Func<Task<TResult>>, CancellationToken) Method

Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

```csharp
public static System.Threading.Tasks.Task<TResult> Run<TResult>(this System.Threading.Tasks.TaskScheduler? scheduler, System.Func<System.Threading.Tasks.Task<TResult>>? function, System.Threading.CancellationToken cancellationToken);
```
#### Type parameters

<a name='Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The scheduler to execute the function with.

<a name='Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).function'></a>

`function` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](TaskSchedulerExtensions.Run.N+KJ2Wiy2rq5EmHkz6iH8g.md#Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).TResult 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.CancellationToken).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

the function to execute.

<a name='Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

the token to check for cancellation

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](TaskSchedulerExtensions.Run.N+KJ2Wiy2rq5EmHkz6iH8g.md#Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).TResult 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.CancellationToken).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.