### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[CurrentSchedulerTaskRunner](Jcd.Tasks.CurrentSchedulerTaskRunner.md 'Jcd.Tasks.CurrentSchedulerTaskRunner')

## CurrentSchedulerTaskRunner.Run(Action, TaskScheduler) Method

Runs an action on the current or provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

```csharp
public static System.Threading.Tasks.Task Run(System.Action action, System.Threading.Tasks.TaskScheduler scheduler=null);
```
#### Parameters

<a name='Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Action,System.Threading.Tasks.TaskScheduler).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

the action to run

<a name='Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Action,System.Threading.Tasks.TaskScheduler).scheduler'></a>

`scheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The scheduler to use, pass null to use the the current one.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')