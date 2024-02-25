### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## CustomSchedulerTaskRunner<TScheduler> Class

A [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') bound task runner. It ensures all tasks it creates are registered  
with either its own, or a user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler').

```csharp
public static class CustomSchedulerTaskRunner<TScheduler>
    where TScheduler : System.Threading.Tasks.TaskScheduler, new()
```
#### Type parameters

<a name='Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.TScheduler'></a>

`TScheduler`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CustomSchedulerTaskRunner<TScheduler>

| Properties | |
| :--- | :--- |
| [Scheduler](Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.Scheduler.md 'Jcd.Tasks.CustomSchedulerTaskRunner<TScheduler>.Scheduler') | The [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') used to schedule and execute tasks. |

| Methods | |
| :--- | :--- |
| [Run(Action, TaskScheduler)](Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.Run(System.Action,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run(System.Action, System.Threading.Tasks.TaskScheduler)') | |
