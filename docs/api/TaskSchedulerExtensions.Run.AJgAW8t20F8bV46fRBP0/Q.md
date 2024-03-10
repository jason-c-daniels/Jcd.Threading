#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks').[TaskSchedulerExtensions](TaskSchedulerExtensions.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions')

## TaskSchedulerExtensions.Run<TResult>(this TaskScheduler, Func<TResult>) Method

Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

```csharp
public static System.Threading.Tasks.Task<TResult> Run<TResult>(this System.Threading.Tasks.TaskScheduler scheduler, System.Func<TResult> function);
```
#### Type parameters

<a name='Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The scheduler to execute the function with.

<a name='Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_).function'></a>

`function` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TResult](TaskSchedulerExtensions.Run.AJgAW8t20F8bV46fRBP0/Q.md#Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_).TResult 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<TResult>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

the function to execute.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](TaskSchedulerExtensions.Run.AJgAW8t20F8bV46fRBP0/Q.md#Jcd.Threading.Tasks.TaskSchedulerExtensions.Run_TResult_(thisSystem.Threading.Tasks.TaskScheduler,System.Func_TResult_).TResult 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<TResult>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.