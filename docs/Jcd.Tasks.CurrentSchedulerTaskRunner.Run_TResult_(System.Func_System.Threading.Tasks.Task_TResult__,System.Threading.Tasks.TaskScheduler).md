#### [Jcd.Tasks](index.md 'index')
### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[CurrentSchedulerTaskRunner](Jcd.Tasks.CurrentSchedulerTaskRunner.md 'Jcd.Tasks.CurrentSchedulerTaskRunner')

## CurrentSchedulerTaskRunner.Run<TResult>(Func<Task<TResult>>, TaskScheduler) Method

Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

```csharp
public static System.Threading.Tasks.Task<TResult> Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>?> function, System.Threading.Tasks.TaskScheduler? scheduler=null);
```
#### Type parameters

<a name='Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.Tasks.TaskScheduler).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.Tasks.TaskScheduler).function'></a>

`function` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.Tasks.TaskScheduler).md#Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.Tasks.TaskScheduler).TResult 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.Tasks.TaskScheduler).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

the function to execute.

<a name='Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.Tasks.TaskScheduler).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The optional scheduler to execute the function with.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.Tasks.TaskScheduler).md#Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.Tasks.TaskScheduler).TResult 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.Tasks.TaskScheduler).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.