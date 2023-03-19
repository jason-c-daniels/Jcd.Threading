### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## UnstartedTask Class

A Task factory that wraps the constructor with a tiny bit of logic, simplifying the process  
of directly creating unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')s.

```csharp
public static class UnstartedTask
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UnstartedTask

| Methods | |
| :--- | :--- |
| [Create(Action, Nullable&lt;CancellationToken&gt;, TaskCreationOptions)](Jcd.Tasks.UnstartedTask.Create(System.Action,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md 'Jcd.Tasks.UnstartedTask.Create(System.Action, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions)') | Creates an unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') as a proxy for an action. Once started the task will execute the action. |
| [Create(Func&lt;Task&gt;, Nullable&lt;CancellationToken&gt;, TaskCreationOptions)](Jcd.Tasks.UnstartedTask.Create(System.Func_System.Threading.Tasks.Task_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md 'Jcd.Tasks.UnstartedTask.Create(System.Func<System.Threading.Tasks.Task>, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions)') | Creates an unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') as a proxy for an asynchronous action. Once started the task will execute the action. |
| [Create&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;, Nullable&lt;CancellationToken&gt;, TaskCreationOptions)](Jcd.Tasks.UnstartedTask.Create_TResult_(System.Func_System.Threading.Tasks.Task_TResult__,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md 'Jcd.Tasks.UnstartedTask.Create<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions)') | Creates an unstarted [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') as a proxy for an asynchronous function. Once started the task will execute the function. |
| [Create&lt;TResult&gt;(Func&lt;TResult&gt;, Nullable&lt;CancellationToken&gt;, TaskCreationOptions)](Jcd.Tasks.UnstartedTask.Create_TResult_(System.Func_TResult_,System.Nullable_System.Threading.CancellationToken_,System.Threading.Tasks.TaskCreationOptions).md 'Jcd.Tasks.UnstartedTask.Create<TResult>(System.Func<TResult>, System.Nullable<System.Threading.CancellationToken>, System.Threading.Tasks.TaskCreationOptions)') | Creates an unstarted [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') as a proxy for a function. Once started the task will execute the function. |
