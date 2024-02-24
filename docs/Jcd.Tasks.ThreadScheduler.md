### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## ThreadScheduler Class

```csharp
public abstract class ThreadScheduler : System.Threading.Tasks.TaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; ThreadScheduler

| Methods | |
| :--- | :--- |
| [TryExecuteTaskInline(Task, bool)](Jcd.Tasks.ThreadScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).md 'Jcd.Tasks.ThreadScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task, bool)') | This the default implementation for this scheduler guarantees only its threads are processing tasks, so we cannot<br/>inline operations as inlining executes the task on the ThreadPool, which may not meet the same requirements as our<br/>dedicated threads. |
