### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## SchedulerBoundTaskRunner<TScheduler> Class

A TaskScheduler bound task runner. It ensures all tasks it creates are registered with either its own,  
or a user provided TaskScheduler.

```csharp
public static class SchedulerBoundTaskRunner<TScheduler>
    where TScheduler : System.Threading.Tasks.TaskScheduler, new()
```
#### Type parameters

<a name='Jcd.Tasks.SchedulerBoundTaskRunner_TScheduler_.TScheduler'></a>

`TScheduler`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SchedulerBoundTaskRunner<TScheduler>

| Methods | |
| :--- | :--- |
| [Run(Action, TaskScheduler)](Jcd.Tasks.SchedulerBoundTaskRunner_TScheduler_.Run(System.Action,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.SchedulerBoundTaskRunner<TScheduler>.Run(System.Action, System.Threading.Tasks.TaskScheduler)') | |
