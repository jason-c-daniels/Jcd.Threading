### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## TaskExtensions Class

A set of helpers for [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') objects.

```csharp
public static class TaskExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TaskExtensions

| Methods | |
| :--- | :--- |
| [IsUnstarted(this Task)](Jcd.Tasks.TaskExtensions.IsUnstarted(thisSystem.Threading.Tasks.Task).md 'Jcd.Tasks.TaskExtensions.IsUnstarted(this System.Threading.Tasks.Task)') | Checks if a task is unstarted and startable. (Status==Created) |
| [Run(this Task)](Jcd.Tasks.TaskExtensions.Run(thisSystem.Threading.Tasks.Task).md 'Jcd.Tasks.TaskExtensions.Run(this System.Threading.Tasks.Task)') | Calls [TryStart(this Task, Exception, TaskScheduler)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception, System.Threading.Tasks.TaskScheduler)') on a task then returns the task, discarding exceptions. |
| [Run&lt;TResult&gt;(this Task&lt;TResult&gt;, TaskScheduler)](Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.TaskExtensions.Run<TResult>(this System.Threading.Tasks.Task<TResult>, System.Threading.Tasks.TaskScheduler)') | Calls [TryStart(this Task, Exception, TaskScheduler)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception, System.Threading.Tasks.TaskScheduler)') on a task then returns the task, discarding exceptions. |
| [TryStart(this Task, Exception, TaskScheduler)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception, System.Threading.Tasks.TaskScheduler)') | Tries to successfully call start. |
| [TryWait(this Task, Nullable&lt;int&gt;, Nullable&lt;CancellationToken&gt;)](Jcd.Tasks.TaskExtensions.TryWait(thisSystem.Threading.Tasks.Task,System.Nullable_int_,System.Nullable_System.Threading.CancellationToken_).md 'Jcd.Tasks.TaskExtensions.TryWait(this System.Threading.Tasks.Task, System.Nullable<int>, System.Nullable<System.Threading.CancellationToken>)') | Waits on a running task until it completes, is cancelled, faults or times out.<br/>This extension method swallows exceptions. The exception should be available on<br/>the Task.Exception property |
| [TryWait(this Task, CancellationToken)](Jcd.Tasks.TaskExtensions.TryWait(thisSystem.Threading.Tasks.Task,System.Threading.CancellationToken).md 'Jcd.Tasks.TaskExtensions.TryWait(this System.Threading.Tasks.Task, System.Threading.CancellationToken)') | Waits on a running task until it completes, is cancelled, faults or times out. |
| [TryWait(this Task, TimeSpan, Nullable&lt;CancellationToken&gt;)](Jcd.Tasks.TaskExtensions.TryWait(thisSystem.Threading.Tasks.Task,System.TimeSpan,System.Nullable_System.Threading.CancellationToken_).md 'Jcd.Tasks.TaskExtensions.TryWait(this System.Threading.Tasks.Task, System.TimeSpan, System.Nullable<System.Threading.CancellationToken>)') | Waits on a running task until it completes, is cancelled, faults or times out. |
