### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[CustomSchedulerTaskRunner&lt;TScheduler&gt;](Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.md 'Jcd.Tasks.CustomSchedulerTaskRunner<TScheduler>')

## CustomSchedulerTaskRunner<TScheduler>.Run(Func<Task>, CancellationToken, TaskScheduler) Method

Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one.

```csharp
public static System.Threading.Tasks.Task Run(System.Func<System.Threading.Tasks.Task?> asyncAction, System.Threading.CancellationToken cancellationToken, System.Threading.Tasks.TaskScheduler? scheduler=null);
```
#### Parameters

<a name='Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run(System.Func_System.Threading.Tasks.Task_,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).asyncAction'></a>

`asyncAction` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

the action to execute.

<a name='Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run(System.Func_System.Threading.Tasks.Task_,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The token to check for cancellation.

<a name='Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run(System.Func_System.Threading.Tasks.Task_,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The optional scheduler to execute the action with.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.