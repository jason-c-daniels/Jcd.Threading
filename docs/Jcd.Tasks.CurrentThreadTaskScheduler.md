### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## CurrentThreadTaskScheduler Class

```csharp
public sealed class CurrentThreadTaskScheduler : System.Threading.Tasks.TaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; CurrentThreadTaskScheduler

| Properties | |
| :--- | :--- |
| [MaximumConcurrencyLevel](Jcd.Tasks.CurrentThreadTaskScheduler.MaximumConcurrencyLevel.md 'Jcd.Tasks.CurrentThreadTaskScheduler.MaximumConcurrencyLevel') | Gets the maximum degree of parallelism for this scheduler. |

| Methods | |
| :--- | :--- |
| [GetScheduledTasks()](Jcd.Tasks.CurrentThreadTaskScheduler.GetScheduledTasks().md 'Jcd.Tasks.CurrentThreadTaskScheduler.GetScheduledTasks()') | Gets the Tasks currently scheduled to this scheduler. |
| [QueueTask(Task)](Jcd.Tasks.CurrentThreadTaskScheduler.QueueTask(System.Threading.Tasks.Task).md 'Jcd.Tasks.CurrentThreadTaskScheduler.QueueTask(System.Threading.Tasks.Task)') | Runs the provided Task synchronously on the current thread. |
| [TryExecuteTaskInline(Task, bool)](Jcd.Tasks.CurrentThreadTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).md 'Jcd.Tasks.CurrentThreadTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task, bool)') | Runs the provided Task synchronously on the current thread. |
