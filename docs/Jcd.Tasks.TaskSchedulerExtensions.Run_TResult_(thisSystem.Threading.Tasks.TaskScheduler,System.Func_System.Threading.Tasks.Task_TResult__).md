#### [Jcd.Tasks](index.md 'index')
### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskSchedulerExtensions](Jcd.Tasks.TaskSchedulerExtensions.md 'Jcd.Tasks.TaskSchedulerExtensions')

## TaskSchedulerExtensions.Run<TResult>(this TaskScheduler, Func<Task<TResult>>) Method

Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

```csharp
public static System.Threading.Tasks.Task<TResult> Run<TResult>(this System.Threading.Tasks.TaskScheduler scheduler, System.Func<System.Threading.Tasks.Task<TResult>?> function);
```
#### Type parameters

<a name='Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The scheduler to execute the function with.

<a name='Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__).function'></a>

`function` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__).md#Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__).TResult 'Jcd.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<System.Threading.Tasks.Task<TResult>>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

the function to execute.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__).md#Jcd.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_TResult__).TResult 'Jcd.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<System.Threading.Tasks.Task<TResult>>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.