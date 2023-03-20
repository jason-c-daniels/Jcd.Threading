### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## BlockingTaskProcessor Class

Represents a high level class that enqueues and executes actions, functions, and unstarted tasks,  
waiting for each to complete before executing the next.

```csharp
public class BlockingTaskProcessor :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BlockingTaskProcessor

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

### Remarks
  
You must ensure all shared resources for the enqueued tasks have their access synchronized  
appropriately.  
  
NOTE: This was really just a thought experiment. There are probably legitimately better ways of  
doing this built in to .Net. I had trouble finding them. If you find them, please let me know!

| Constructors | |
| :--- | :--- |
| [BlockingTaskProcessor(bool)](Jcd.Tasks.BlockingTaskProcessor.BlockingTaskProcessor(bool).md 'Jcd.Tasks.BlockingTaskProcessor.BlockingTaskProcessor(bool)') | Constructs a [BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor') |

| Properties | |
| :--- | :--- |
| [HasTasks](Jcd.Tasks.BlockingTaskProcessor.HasTasks.md 'Jcd.Tasks.BlockingTaskProcessor.HasTasks') | Gets a flag indicating if there are any pending tasks. |
| [IsPaused](Jcd.Tasks.BlockingTaskProcessor.IsPaused.md 'Jcd.Tasks.BlockingTaskProcessor.IsPaused') | Gets a flag indicating if the command processing is currently paused. |
| [IsStarted](Jcd.Tasks.BlockingTaskProcessor.IsStarted.md 'Jcd.Tasks.BlockingTaskProcessor.IsStarted') | Gets a flag indicating if the task processing has started. (it might be paused though). |
| [QueueLength](Jcd.Tasks.BlockingTaskProcessor.QueueLength.md 'Jcd.Tasks.BlockingTaskProcessor.QueueLength') | The number of pending commands. |

| Methods | |
| :--- | :--- |
| [Cancel()](Jcd.Tasks.BlockingTaskProcessor.Cancel().md 'Jcd.Tasks.BlockingTaskProcessor.Cancel()') | Signals the task processor to halt all processing immediately. This also cancels all<br/>tasks created by this task task processor. This is mostly intended to be called<br/>during application shutdown. |
| [Enqueue(Action)](Jcd.Tasks.BlockingTaskProcessor.Enqueue(System.Action).md 'Jcd.Tasks.BlockingTaskProcessor.Enqueue(System.Action)') | Enqueues an action. This is a "fire and forget" method. Control is immediately<br/>returned to the caller. |
| [Enqueue(Func&lt;Task&gt;)](Jcd.Tasks.BlockingTaskProcessor.Enqueue(System.Func_System.Threading.Tasks.Task_).md 'Jcd.Tasks.BlockingTaskProcessor.Enqueue(System.Func<System.Threading.Tasks.Task>)') | Enqueues an async action. This is a "fire and forget" method.<br/>Control is returned to the caller immediately. |
| [Enqueue&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;)](Jcd.Tasks.BlockingTaskProcessor.Enqueue_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md 'Jcd.Tasks.BlockingTaskProcessor.Enqueue<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>)') | Enqueues an async function. This is a "fire and forget" method.<br/>The function result will not be available and control is immediately returned to the caller. |
| [Enqueue&lt;TResult&gt;(Func&lt;TResult&gt;)](Jcd.Tasks.BlockingTaskProcessor.Enqueue_TResult_(System.Func_TResult_).md 'Jcd.Tasks.BlockingTaskProcessor.Enqueue<TResult>(System.Func<TResult>)') | Enqueues a function. This is a "fire and forget" method.<br/>The function result will not be available and control is immediately returned to the caller. |
| [EnqueueAndGetProxy(Action)](Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy(System.Action).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy(System.Action)') | Enqueues an action and returns a proxy task that will execute the action.<br/>Awaiting the returned proxy [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') waits for the enqueued action to finish executing. |
| [EnqueueAndGetProxy(Func&lt;Task&gt;)](Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy(System.Func_System.Threading.Tasks.Task_).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy(System.Func<System.Threading.Tasks.Task>)') | Enqueues an async action and returns a proxy task that will execute the action.<br/>Awaiting the returned proxy [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') waits for the enqueued action to finish executing. |
| [EnqueueAndGetProxy&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;)](Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>)') | Enqueues an async function and returns a proxy task that will execute the function.<br/>Awaiting the returned [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') waits for the enqueued function to finish executing<br/>and returns the result. |
| [EnqueueAndGetProxy&lt;TResult&gt;(Func&lt;TResult&gt;)](Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy_TResult_(System.Func_TResult_).md 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy<TResult>(System.Func<TResult>)') | Enqueues a function and returns a proxy task that will execute the function.<br/>Awaiting the returned [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') waits for the enqueued function to finish executing<br/>and returns the result. |
| [Pause()](Jcd.Tasks.BlockingTaskProcessor.Pause().md 'Jcd.Tasks.BlockingTaskProcessor.Pause()') | Pauses the retrieval and execution of queued tasks. If a task is in the middle of being started when this is<br/>called it will still get started. |
| [PauseAsync()](Jcd.Tasks.BlockingTaskProcessor.PauseAsync().md 'Jcd.Tasks.BlockingTaskProcessor.PauseAsync()') | Pauses the retrieval and execution of queued tasks. If a task is in the middle of being started<br/>when this is called it will still get started. |
| [Resume()](Jcd.Tasks.BlockingTaskProcessor.Resume().md 'Jcd.Tasks.BlockingTaskProcessor.Resume()') | Resumes command processing. |
| [ResumeAsync()](Jcd.Tasks.BlockingTaskProcessor.ResumeAsync().md 'Jcd.Tasks.BlockingTaskProcessor.ResumeAsync()') | Resumes task processing. |
| [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') | Starts the processing of queued tasks. |
| [TryEnqueueTask(Task, bool)](Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask(System.Threading.Tasks.Task,bool).md 'Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask(System.Threading.Tasks.Task, bool)') | Tries to enqueues a task for later execution. If the passed in task is already<br/>started, it's not enqueued. |
| [TryEnqueueTask&lt;TResult&gt;(Task&lt;TResult&gt;, bool)](Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask_TResult_(System.Threading.Tasks.Task_TResult_,bool).md 'Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask<TResult>(System.Threading.Tasks.Task<TResult>, bool)') | Tries to enqueues a task for later execution. If the passed in task is not unstarted,<br/>it's not enqueued. |
