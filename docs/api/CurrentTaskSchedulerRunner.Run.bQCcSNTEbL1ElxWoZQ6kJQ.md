#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks').[CurrentTaskSchedulerRunner](CurrentTaskSchedulerRunner.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner')

## CurrentTaskSchedulerRunner.Run<TResult>(Func<Task<TResult>>, CancellationToken, TaskScheduler) Method

Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

```csharp
public static System.Threading.Tasks.Task<TResult> Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> function, System.Threading.CancellationToken cancellationToken, System.Threading.Tasks.TaskScheduler? scheduler=null);
```
#### Type parameters

<a name='Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).function'></a>

`function` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](CurrentTaskSchedulerRunner.Run.bQCcSNTEbL1ElxWoZQ6kJQ.md#Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).TResult 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

the function to execute.

<a name='Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

the token to check for cancellation.

<a name='Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The optional scheduler to execute the function with.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](CurrentTaskSchedulerRunner.Run.bQCcSNTEbL1ElxWoZQ6kJQ.md#Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).TResult 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.