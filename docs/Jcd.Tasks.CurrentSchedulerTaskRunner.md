#### [Jcd.Tasks](index.md 'index')
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
| [Run(Action, CancellationToken, TaskScheduler)](Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Action,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Action, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run(Action, TaskScheduler)](Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Action,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Action, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run(Func&lt;Task&gt;, CancellationToken, TaskScheduler)](Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Func_System.Threading.Tasks.Task_,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Func<System.Threading.Tasks.Task>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run(Func&lt;Task&gt;, TaskScheduler)](Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Func_System.Threading.Tasks.Task_,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run(System.Func<System.Threading.Tasks.Task>, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;, CancellationToken, TaskScheduler)](Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;, TaskScheduler)](Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(Func&lt;TResult&gt;, CancellationToken, TaskScheduler)](Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_TResult_,System.Threading.CancellationToken,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run<TResult>(System.Func<TResult>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(Func&lt;TResult&gt;, TaskScheduler)](Jcd.Tasks.CurrentSchedulerTaskRunner.Run_TResult_(System.Func_TResult_,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.CurrentSchedulerTaskRunner.Run<TResult>(System.Func<TResult>, System.Threading.Tasks.TaskScheduler)') | Schedules work with the current or user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
