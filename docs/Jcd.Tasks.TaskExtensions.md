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
| [Run(this Task)](Jcd.Tasks.TaskExtensions.Run(thisSystem.Threading.Tasks.Task).md 'Jcd.Tasks.TaskExtensions.Run(this System.Threading.Tasks.Task)') | Calls [TryRun(this Task, Exception)](Jcd.Tasks.TaskExtensions.TryRun(thisSystem.Threading.Tasks.Task,System.Exception).md 'Jcd.Tasks.TaskExtensions.TryRun(this System.Threading.Tasks.Task, System.Exception)') on a task then returns the task, discarding exceptions. |
| [Run&lt;TResult&gt;(this Task&lt;TResult&gt;)](Jcd.Tasks.TaskExtensions.Run_TResult_(thisSystem.Threading.Tasks.Task_TResult_).md 'Jcd.Tasks.TaskExtensions.Run<TResult>(this System.Threading.Tasks.Task<TResult>)') | Calls [TryRun(this Task, Exception)](Jcd.Tasks.TaskExtensions.TryRun(thisSystem.Threading.Tasks.Task,System.Exception).md 'Jcd.Tasks.TaskExtensions.TryRun(this System.Threading.Tasks.Task, System.Exception)') on a task then returns the task, discarding exceptions. |
| [TryRun(this Task, Exception)](Jcd.Tasks.TaskExtensions.TryRun(thisSystem.Threading.Tasks.Task,System.Exception).md 'Jcd.Tasks.TaskExtensions.TryRun(this System.Threading.Tasks.Task, System.Exception)') | Tries to successfully call start. |
| [TryWait(this Task)](Jcd.Tasks.TaskExtensions.TryWait(thisSystem.Threading.Tasks.Task).md 'Jcd.Tasks.TaskExtensions.TryWait(this System.Threading.Tasks.Task)') | Tries to await a task regardless of status. |
| [TryWaitAsync(this Task)](Jcd.Tasks.TaskExtensions.TryWaitAsync(thisSystem.Threading.Tasks.Task).md 'Jcd.Tasks.TaskExtensions.TryWaitAsync(this System.Threading.Tasks.Task)') | Tries to await a task regardless of status. |
