#### [Jcd.Tasks](index.md 'index')
### [Jcd.Tasks.TaskSchedulers](Jcd.Tasks.TaskSchedulers.md 'Jcd.Tasks.TaskSchedulers').[TaskSchedulerExtensions](Jcd.Tasks.TaskSchedulers.TaskSchedulerExtensions.md 'Jcd.Tasks.TaskSchedulers.TaskSchedulerExtensions')

## TaskSchedulerExtensions.Run(this TaskScheduler, Func<Task>) Method

Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

```csharp
public static System.Threading.Tasks.Task Run(this System.Threading.Tasks.TaskScheduler scheduler, System.Func<System.Threading.Tasks.Task?> function);
```
#### Parameters

<a name='Jcd.Tasks.TaskSchedulers.TaskSchedulerExtensions.Run(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The scheduler to execute the function with.

<a name='Jcd.Tasks.TaskSchedulers.TaskSchedulerExtensions.Run(thisSystem.Threading.Tasks.TaskScheduler,System.Func_System.Threading.Tasks.Task_).function'></a>

`function` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

the function to execute.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.