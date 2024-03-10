#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks').[TaskSchedulerExtensions](TaskSchedulerExtensions.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions')

## TaskSchedulerExtensions.Run(this TaskScheduler, Action) Method

Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

```csharp
public static System.Threading.Tasks.Task Run(this System.Threading.Tasks.TaskScheduler scheduler, System.Action action);
```
#### Parameters

<a name='Jcd.Threading.Tasks.TaskSchedulerExtensions.Run(thisSystem.Threading.Tasks.TaskScheduler,System.Action).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The scheduler to execute the action with.

<a name='Jcd.Threading.Tasks.TaskSchedulerExtensions.Run(thisSystem.Threading.Tasks.TaskScheduler,System.Action).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

the action to execute.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') representing the result of the execution.