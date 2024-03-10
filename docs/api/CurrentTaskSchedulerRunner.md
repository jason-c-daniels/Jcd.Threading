#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks')

## CurrentTaskSchedulerRunner Class

A static class that schedules tasks on the current [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') or
a user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') if null is passed in or none is specified.

```csharp
public static class CurrentTaskSchedulerRunner
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CurrentTaskSchedulerRunner

| Properties | |
| :--- | :--- |
| [Scheduler](CurrentTaskSchedulerRunner.Scheduler.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Scheduler') | The current [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |

| Methods | |
| :--- | :--- |
| [Run(Action, CancellationToken, TaskScheduler)](CurrentTaskSchedulerRunner.Run.rvqdTOTnEBTdoC+UYzOXDQ.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run(System.Action, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run(Action, TaskScheduler)](CurrentTaskSchedulerRunner.Run.9k7QfHIsWEGHPPjYLNsPPA.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run(System.Action, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run(Func&lt;Task&gt;, CancellationToken, TaskScheduler)](CurrentTaskSchedulerRunner.Run.rdk+c2Tkx+G0j67VYHssjA.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run(System.Func<System.Threading.Tasks.Task>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run(Func&lt;Task&gt;, TaskScheduler)](CurrentTaskSchedulerRunner.Run.eQgIyxLbYScnxah9M3O53g.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run(System.Func<System.Threading.Tasks.Task>, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;, CancellationToken, TaskScheduler)](CurrentTaskSchedulerRunner.Run.bQCcSNTEbL1ElxWoZQ6kJQ.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;, TaskScheduler)](CurrentTaskSchedulerRunner.Run.Qf65LPZdULwi14jJ+TAveg.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(Func&lt;TResult&gt;, CancellationToken, TaskScheduler)](CurrentTaskSchedulerRunner.Run.5dMunf7nOR1IzO2buAgQeg.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run<TResult>(System.Func<TResult>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(Func&lt;TResult&gt;, TaskScheduler)](CurrentTaskSchedulerRunner.Run.dnCXDvYM3ED7tJp0UiZpcw.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner.Run<TResult>(System.Func<TResult>, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
