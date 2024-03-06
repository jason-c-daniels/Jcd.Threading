#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks').[CustomSchedulerTaskRunner&lt;TScheduler&gt;](CustomSchedulerTaskRunner_TScheduler_.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>')

## CustomSchedulerTaskRunner<TScheduler>.Run<TResult>(Func<Task<TResult>>, CancellationToken, TaskScheduler) Method

Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one.

```csharp
public static System.Threading.Tasks.Task<TResult> Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>?> function, System.Threading.CancellationToken cancellationToken, System.Threading.Tasks.TaskScheduler? scheduler=null);
```
#### Type parameters

<a name='Jcd.Threading.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Threading.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).function'></a>

`function` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](CustomSchedulerTaskRunner_TScheduler_.Run.Z0tTyuzf0A37FBRPDuL2UA.md#Jcd.Threading.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).TResult 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

the function to execute.

<a name='Jcd.Threading.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to check for cancellation.

<a name='Jcd.Threading.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The optional scheduler to execute the function with.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](CustomSchedulerTaskRunner_TScheduler_.Run.Z0tTyuzf0A37FBRPDuL2UA.md#Jcd.Threading.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).TResult 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.