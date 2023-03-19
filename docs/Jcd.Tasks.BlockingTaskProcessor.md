### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## BlockingTaskProcessor Class

In a background task, this class starts enqueued tasks in the order they were enqueued,  
waiting for each to complete before executing the next.

```csharp
public class BlockingTaskProcessor :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BlockingTaskProcessor

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

### Remarks
Ensure all shared resources for the enqueued actions/functions have their access synchronized  
appropriately.

| Constructors | |
| :--- | :--- |
| [BlockingTaskProcessor(bool)](Jcd.Tasks.BlockingTaskProcessor.BlockingTaskProcessor(bool).md 'Jcd.Tasks.BlockingTaskProcessor.BlockingTaskProcessor(bool)') | Constructs a [BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor') |

| Properties | |
| :--- | :--- |
| [HasTasks](Jcd.Tasks.BlockingTaskProcessor.HasTasks.md 'Jcd.Tasks.BlockingTaskProcessor.HasTasks') | Gets a flag indicating if there are any pending tasks. |
| [IsPaused](Jcd.Tasks.BlockingTaskProcessor.IsPaused.md 'Jcd.Tasks.BlockingTaskProcessor.IsPaused') | Gets a flag indicating if the command processing is currently paused. |
| [IsStarted](Jcd.Tasks.BlockingTaskProcessor.IsStarted.md 'Jcd.Tasks.BlockingTaskProcessor.IsStarted') | Gets a flag indicating if the command processing has started. (it might be paused though). |
| [QueueLength](Jcd.Tasks.BlockingTaskProcessor.QueueLength.md 'Jcd.Tasks.BlockingTaskProcessor.QueueLength') | The number of pending commands. |

| Methods | |
| :--- | :--- |
| [Cancel()](Jcd.Tasks.BlockingTaskProcessor.Cancel().md 'Jcd.Tasks.BlockingTaskProcessor.Cancel()') | Signals the command processor to halt all processing immediately. This also cancels all tasks created<br/>by this task command processor. This is mostly intended to be called during application shutdown. |
| [EnqueueAction(Action)](Jcd.Tasks.BlockingTaskProcessor.EnqueueAction(System.Action).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAction(System.Action)') | Enqueues a command for sequential execution. This is a "fire and forget" method.<br/>Control is returned to the caller immediately. |
| [EnqueueActionAsync(Action)](Jcd.Tasks.BlockingTaskProcessor.EnqueueActionAsync(System.Action).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueActionAsync(System.Action)') | Enqueues a command for sequential execution. Awaiting the returned [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')<br/>waits for the command to finish executing. |
| [EnqueueAsyncAction(Func&lt;Task&gt;)](Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncAction(System.Func_System.Threading.Tasks.Task_).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncAction(System.Func<System.Threading.Tasks.Task>)') | Enqueues an async command for sequential execution. This is a "fire and forget" method.<br/>Control is returned to the caller immediately. |
| [EnqueueAsyncActionAsync(Func&lt;Task&gt;)](Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncActionAsync(System.Func_System.Threading.Tasks.Task_).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncActionAsync(System.Func<System.Threading.Tasks.Task>)') | Asynchronously enqueues an async command for sequential execution. Awaiting the<br/>returned [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') waits for the command to finish executing. |
| [EnqueueAsyncFunc&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;)](Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFunc_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFunc<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>)') | Enqueues an async command for sequential execution. This is a "fire and forget" method.<br/>The function call result will not be available and control is returned to the caller immediately. |
| [EnqueueAsyncFuncAsync&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;)](Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFuncAsync_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFuncAsync<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>)') | Asynchronously enqueues an async function for sequential execution. The result of the function execution<br/>is available by awaiting the returned [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') |
| [EnqueueFunc&lt;TResult&gt;(Func&lt;TResult&gt;)](Jcd.Tasks.BlockingTaskProcessor.EnqueueFunc_TResult_(System.Func_TResult_).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueFunc<TResult>(System.Func<TResult>)') | Enqueues a command for sequential execution. This is a "fire and forget" method.<br/>The command result will not be available and control is returned to the caller immediately. |
| [EnqueueFuncAsync&lt;TResult&gt;(Func&lt;TResult&gt;)](Jcd.Tasks.BlockingTaskProcessor.EnqueueFuncAsync_TResult_(System.Func_TResult_).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueFuncAsync<TResult>(System.Func<TResult>)') | Asynchronously enqueues a command for sequential execution. The result of the function<br/>execution is available by awaiting the returned [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') |
| [Pause()](Jcd.Tasks.BlockingTaskProcessor.Pause().md 'Jcd.Tasks.BlockingTaskProcessor.Pause()') | Pauses the retrieval and execution of queued tasks. If a task is in the middle of being started when this is<br/>called it will still get started. |
| [PauseAsync()](Jcd.Tasks.BlockingTaskProcessor.PauseAsync().md 'Jcd.Tasks.BlockingTaskProcessor.PauseAsync()') | Pauses the retrieval and execution of queued tasks. If a task is in the middle of being started<br/>when this is called it will still get started. |
| [Resume()](Jcd.Tasks.BlockingTaskProcessor.Resume().md 'Jcd.Tasks.BlockingTaskProcessor.Resume()') | Resumes command processing. |
| [ResumeAsync()](Jcd.Tasks.BlockingTaskProcessor.ResumeAsync().md 'Jcd.Tasks.BlockingTaskProcessor.ResumeAsync()') | Resumes command processing. |
| [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') | Starts the processing of queued commands. |
| [TryEnqueueTask(Task, bool)](Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask(System.Threading.Tasks.Task,bool).md 'Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask(System.Threading.Tasks.Task, bool)') | Tries to enqueues a task for later execution. If the passed in task is already started, it's not enqueued. |
| [TryEnqueueTask&lt;T&gt;(Task&lt;T&gt;, bool)](Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask_T_(System.Threading.Tasks.Task_T_,bool).md 'Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask<T>(System.Threading.Tasks.Task<T>, bool)') | Tries to enqueues a task for later execution. If the passed in task is not unstarted, it's not enqueued. |
