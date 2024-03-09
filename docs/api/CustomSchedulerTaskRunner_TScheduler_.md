#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks')

## CustomSchedulerTaskRunner<TScheduler> Class

A singleton [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') bound task runner. It ensures all tasks it creates
are registered with either its own, or a user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler').

```csharp
public static class CustomSchedulerTaskRunner<TScheduler>
    where TScheduler : System.Threading.Tasks.TaskScheduler, new()
```
#### Type parameters

<a name='Jcd.Threading.Tasks.CustomSchedulerTaskRunner_TScheduler_.TScheduler'></a>

`TScheduler`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CustomSchedulerTaskRunner<TScheduler>

| Properties | |
| :--- | :--- |
| [Scheduler](CustomSchedulerTaskRunner_TScheduler_.Scheduler.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Scheduler') | The [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') used to schedule and execute tasks. |

| Methods | |
| :--- | :--- |
| [Run(Action, CancellationToken, TaskScheduler)](CustomSchedulerTaskRunner_TScheduler_.Run.l0YpgTPH56lrZkAEL/hbRQ.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run(System.Action, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one. |
| [Run(Action, TaskScheduler)](CustomSchedulerTaskRunner_TScheduler_.Run.vYqAG9UN+9KE9KQcgigQ/Q.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run(System.Action, System.Threading.Tasks.TaskScheduler)') | Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one. |
| [Run(Func&lt;Task&gt;, CancellationToken, TaskScheduler)](CustomSchedulerTaskRunner_TScheduler_.Run.TuaZS6guewD86TVtLdtDew.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run(System.Func<System.Threading.Tasks.Task>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one. |
| [Run(Func&lt;Task&gt;, TaskScheduler)](CustomSchedulerTaskRunner_TScheduler_.Run.4U2EikBJaMvszTb8uACbfw.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run(System.Func<System.Threading.Tasks.Task>, System.Threading.Tasks.TaskScheduler)') | Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one. |
| [Run&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;, CancellationToken, TaskScheduler)](CustomSchedulerTaskRunner_TScheduler_.Run.Z0tTyuzf0A37FBRPDuL2UA.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one. |
| [Run&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;, TaskScheduler)](CustomSchedulerTaskRunner_TScheduler_.Run.5Y7DAAxzSCKGAiqaHbiDyg.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.Tasks.TaskScheduler)') | Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one. |
| [Run&lt;TResult&gt;(Func&lt;TResult&gt;, CancellationToken, TaskScheduler)](CustomSchedulerTaskRunner_TScheduler_.Run.OsCSEXEKwu5sVsmlykutRQ.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run<TResult>(System.Func<TResult>, System.Threading.CancellationToken, System.Threading.Tasks.TaskScheduler)') | Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one. |
| [Run&lt;TResult&gt;(Func&lt;TResult&gt;, TaskScheduler)](CustomSchedulerTaskRunner_TScheduler_.Run.NFYTf9qZcmbpzctoziu0Gw.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>.Run<TResult>(System.Func<TResult>, System.Threading.Tasks.TaskScheduler)') | Schedules work on either the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') this type owns or the user provided one. |
