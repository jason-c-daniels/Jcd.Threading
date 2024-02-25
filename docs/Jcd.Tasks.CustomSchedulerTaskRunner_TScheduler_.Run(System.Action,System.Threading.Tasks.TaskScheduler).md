### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[CustomSchedulerTaskRunner&lt;TScheduler&gt;](Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.md 'Jcd.Tasks.CustomSchedulerTaskRunner<TScheduler>')

## CustomSchedulerTaskRunner<TScheduler>.Run(Action, TaskScheduler) Method

Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one.

```csharp
public static System.Threading.Tasks.Task Run(System.Action action, System.Threading.Tasks.TaskScheduler? scheduler=null);
```
#### Parameters

<a name='Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run(System.Action,System.Threading.Tasks.TaskScheduler).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

the action to execute.

<a name='Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run(System.Action,System.Threading.Tasks.TaskScheduler).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The optional scheduler to execute the action with.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.