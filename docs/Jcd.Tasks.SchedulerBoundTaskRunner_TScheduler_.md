### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## SchedulerBoundTaskRunner<TScheduler> Class

A TaskScheduler bound task runner. It ensures all tasks it creates are registered  
with either its own, or a user provided TaskScheduler.

```csharp
public static class SchedulerBoundTaskRunner<TScheduler>
    where TScheduler : System.Threading.Tasks.TaskScheduler, new()
```
#### Type parameters

<a name='Jcd.Tasks.SchedulerBoundTaskRunner_TScheduler_.TScheduler'></a>

`TScheduler`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SchedulerBoundTaskRunner<TScheduler>

| Properties | |
| :--- | :--- |
| [Scheduler](Jcd.Tasks.SchedulerBoundTaskRunner_TScheduler_.Scheduler.md 'Jcd.Tasks.SchedulerBoundTaskRunner<TScheduler>.Scheduler') | The [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') used to schedule and execute tasks. |

| Methods | |
| :--- | :--- |
| [Run(Action, TaskScheduler)](Jcd.Tasks.SchedulerBoundTaskRunner_TScheduler_.Run(System.Action,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.SchedulerBoundTaskRunner<TScheduler>.Run(System.Action, System.Threading.Tasks.TaskScheduler)') | |
