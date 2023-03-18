### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## ColdTask Class

A Task factory that wraps the constructor with a tiny bit of logic, simplifying the process  
of directly creating unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')s.

```csharp
public static class ColdTask
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ColdTask

| Methods | |
| :--- | :--- |
| [FromAction(Action, Nullable&lt;CancellationToken&gt;, TaskCreationOptions)](Jcd.Tasks.ColdTask.FromAction(System.Action,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md 'Jcd.Tasks.ColdTask.FromAction(System.Action, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions)') | Creates an unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') from an action. Once started the task will execute the action. |
| [FromAsyncAction(Func&lt;Task&gt;, Nullable&lt;CancellationToken&gt;, TaskCreationOptions)](Jcd.Tasks.ColdTask.FromAsyncAction(System.Func_System.Threading.Tasks.Task_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md 'Jcd.Tasks.ColdTask.FromAsyncAction(System.Func<System.Threading.Tasks.Task>, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions)') | Creates an unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') from an async action. Once started the task will execute the action. |
| [FromAsyncFunc&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;, Nullable&lt;CancellationToken&gt;, TaskCreationOptions)](Jcd.Tasks.ColdTask.FromAsyncFunc_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md 'Jcd.Tasks.ColdTask.FromAsyncFunc<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions)') | Creates an unstarted [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') from an asynchronous function. Once started the task will execute the function. |
| [FromFunc&lt;TResult&gt;(Func&lt;TResult&gt;, Nullable&lt;CancellationToken&gt;, TaskCreationOptions)](Jcd.Tasks.ColdTask.FromFunc_TResult_(System.Func_TResult_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md 'Jcd.Tasks.ColdTask.FromFunc<TResult>(System.Func<TResult>, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions)') | Creates an unstarted [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') from a function. Once started the task will execute the function. |
| [IsCold(this Task)](Jcd.Tasks.ColdTask.IsCold(thisSystem.Threading.Tasks.Task).md 'Jcd.Tasks.ColdTask.IsCold(this System.Threading.Tasks.Task)') | Returns true if the task status indicates execution hasn't begun. (Status==Created) |
| [StartEx(this Task)](Jcd.Tasks.ColdTask.StartEx(thisSystem.Threading.Tasks.Task).md 'Jcd.Tasks.ColdTask.StartEx(this System.Threading.Tasks.Task)') | Starts an unstarted task then returns the task. If the task isn't cold it isn't started, it's still returned. |
