### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## CurrentSchedulerTaskRunner Class

A static class that schedules tasks on the current [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') or  
a user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') if null is passed in or none is specified.

```csharp
public static class CurrentSchedulerTaskRunner
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CurrentSchedulerTaskRunner

| Properties | |
| :--- | :--- |
| [Scheduler](Jcd.Tasks.CurrentSchedulerTaskRunner.Scheduler.md 'Jcd.Tasks.CurrentSchedulerTaskRunner.Scheduler') | The current [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |

| Methods | |
| :--- | :--- |
| [Run(Action, TaskScheduler)](Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Action,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Action, System.Threading.Tasks.TaskScheduler)') | Runs an action on the current or provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
