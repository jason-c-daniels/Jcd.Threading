#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks')

## TaskSchedulerExtensions Class

Adds various `Run` extension for any [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') derived type.  
This allows tasks to be scheduled with the desired [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')  
in a manner similar to `Task.Run`

```csharp
public static class TaskSchedulerExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TaskSchedulerExtensions

| Methods | |
| :--- | :--- |
| [Run(this TaskScheduler, Action, CancellationToken)](TaskSchedulerExtensions.Run.QK9afJRwHH7UMkezvulWWw.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run(this System.Threading.Tasks.TaskScheduler, System.Action, System.Threading.CancellationToken)') | Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run(this TaskScheduler, Action)](TaskSchedulerExtensions.Run.I+OtM7hPGRm1StRmaTzRZA.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run(this System.Threading.Tasks.TaskScheduler, System.Action)') | Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run(this TaskScheduler, Func&lt;Task&gt;, CancellationToken)](TaskSchedulerExtensions.Run.8IbTVr/W7yN9W+eqXxjrEA.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run(this System.Threading.Tasks.TaskScheduler, System.Func<System.Threading.Tasks.Task>, System.Threading.CancellationToken)') | Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run(this TaskScheduler, Func&lt;Task&gt;)](TaskSchedulerExtensions.Run.wvuzk/eGOOP/Q0de2a98FQ.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run(this System.Threading.Tasks.TaskScheduler, System.Func<System.Threading.Tasks.Task>)') | Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(this TaskScheduler, Func&lt;Task&lt;TResult&gt;&gt;, CancellationToken)](TaskSchedulerExtensions.Run.N+KJ2Wiy2rq5EmHkz6iH8g.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<System.Threading.Tasks.Task<TResult>>, System.Threading.CancellationToken)') | Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(this TaskScheduler, Func&lt;Task&lt;TResult&gt;&gt;)](TaskSchedulerExtensions.Run.CJdQoUck8hgbC4mMBYfeyQ.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<System.Threading.Tasks.Task<TResult>>)') | Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(this TaskScheduler, Func&lt;TResult&gt;, CancellationToken)](TaskSchedulerExtensions.Run.aklWfwujqT4hgoQe55H55g.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<TResult>, System.Threading.CancellationToken)') | Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
| [Run&lt;TResult&gt;(this TaskScheduler, Func&lt;TResult&gt;)](TaskSchedulerExtensions.Run.AJgAW8t20F8bV46fRBP0/Q.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions.Run<TResult>(this System.Threading.Tasks.TaskScheduler, System.Func<TResult>)') | Schedules work with the provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') |
