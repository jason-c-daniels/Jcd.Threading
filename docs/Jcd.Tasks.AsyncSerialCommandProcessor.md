### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## AsyncSerialCommandProcessor Class

In a background task, this class executes arbitrary tasks in the order they were enqueued,  
waiting for each to complete before executing the next.

```csharp
public class AsyncSerialCommandProcessor :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AsyncSerialCommandProcessor

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

### Remarks
Ensure all shared resources for the enqueued actions/functions have their access synchronized  
appropriately.

| Constructors | |
| :--- | :--- |
| [AsyncSerialCommandProcessor(bool)](Jcd.Tasks.AsyncSerialCommandProcessor.AsyncSerialCommandProcessor(bool).md 'Jcd.Tasks.AsyncSerialCommandProcessor.AsyncSerialCommandProcessor(bool)') | Constructs a [AsyncSerialCommandProcessor](Jcd.Tasks.AsyncSerialCommandProcessor.md 'Jcd.Tasks.AsyncSerialCommandProcessor') |

| Properties | |
| :--- | :--- |
| [HasTasks](Jcd.Tasks.AsyncSerialCommandProcessor.HasTasks.md 'Jcd.Tasks.AsyncSerialCommandProcessor.HasTasks') | Gets a flag indicating if there are any pending tasks. |
| [IsPaused](Jcd.Tasks.AsyncSerialCommandProcessor.IsPaused.md 'Jcd.Tasks.AsyncSerialCommandProcessor.IsPaused') | Gets a flag indicating if the command processing is currently paused. |
| [IsStarted](Jcd.Tasks.AsyncSerialCommandProcessor.IsStarted.md 'Jcd.Tasks.AsyncSerialCommandProcessor.IsStarted') | Gets a flag indicating if the command processing has started. (it might be paused though). |
| [QueueLength](Jcd.Tasks.AsyncSerialCommandProcessor.QueueLength.md 'Jcd.Tasks.AsyncSerialCommandProcessor.QueueLength') | The number of pending commands. |

| Methods | |
| :--- | :--- |
| [Cancel()](Jcd.Tasks.AsyncSerialCommandProcessor.Cancel().md 'Jcd.Tasks.AsyncSerialCommandProcessor.Cancel()') | Signals the task executor to halt all processing immediately. This also cancels all tasks created<br/>by this task executor instance. This is mostly intended to be called during application shutdown. |
| [Enqueue(Action)](Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue(System.Action).md 'Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue(System.Action)') | Enqueues a command for sequential execution. This is a "fire and forget" method.<br/>Control is returned to the caller immediately. |
| [Enqueue(Func&lt;Task&gt;)](Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue(System.Func_System.Threading.Tasks.Task_).md 'Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue(System.Func<System.Threading.Tasks.Task>)') | Enqueues an async command for sequential execution. This is a "fire and forget" method.<br/>Control is returned to the caller immediately. |
| [Enqueue&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;)](Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md 'Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>)') | Enqueues an async command for sequential execution. This is a "fire and forget" method.<br/>The function call result will not be available and control is returned to the caller immediately. |
| [Enqueue&lt;TResult&gt;(Func&lt;TResult&gt;)](Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue_TResult_(System.Func_TResult_).md 'Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue<TResult>(System.Func<TResult>)') | Enqueues a command for sequential execution. This is a "fire and forget" method.<br/>The command result will not be available and control is returned to the caller immediately. |
| [EnqueueAsync(Action)](Jcd.Tasks.AsyncSerialCommandProcessor.EnqueueAsync(System.Action).md 'Jcd.Tasks.AsyncSerialCommandProcessor.EnqueueAsync(System.Action)') | Enqueues a command for sequential execution. Awaiting the returned [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')<br/>waits for the command to finish executing. |
| [EnqueueAsync(Func&lt;Task&gt;)](Jcd.Tasks.AsyncSerialCommandProcessor.EnqueueAsync(System.Func_System.Threading.Tasks.Task_).md 'Jcd.Tasks.AsyncSerialCommandProcessor.EnqueueAsync(System.Func<System.Threading.Tasks.Task>)') | Asynchronously enqueues an async command for sequential execution. Awaiting the<br/>returned [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') waits for the command to finish executing. |
| [EnqueueAsync&lt;TResult&gt;(Func&lt;Task&lt;TResult&gt;&gt;)](Jcd.Tasks.AsyncSerialCommandProcessor.EnqueueAsync_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md 'Jcd.Tasks.AsyncSerialCommandProcessor.EnqueueAsync<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>)') | Asynchronously enqueues an async function for sequential execution. The result of the function execution<br/>is available by awaiting the returned [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') |
| [EnqueueAsync&lt;TResult&gt;(Func&lt;TResult&gt;)](Jcd.Tasks.AsyncSerialCommandProcessor.EnqueueAsync_TResult_(System.Func_TResult_).md 'Jcd.Tasks.AsyncSerialCommandProcessor.EnqueueAsync<TResult>(System.Func<TResult>)') | Asynchronously enqueues a command for sequential execution. The result of the function<br/>execution is available by awaiting the returned [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') |
| [Pause()](Jcd.Tasks.AsyncSerialCommandProcessor.Pause().md 'Jcd.Tasks.AsyncSerialCommandProcessor.Pause()') | Pauses the retrieval and execution of queued tasks. If a task is in the middle of being started when this is<br/>called it will still get started. |
| [PauseAsync()](Jcd.Tasks.AsyncSerialCommandProcessor.PauseAsync().md 'Jcd.Tasks.AsyncSerialCommandProcessor.PauseAsync()') | Pauses the retrieval and execution of queued tasks. If a task is in the middle of being started<br/>when this is called it will still get started. |
| [Resume()](Jcd.Tasks.AsyncSerialCommandProcessor.Resume().md 'Jcd.Tasks.AsyncSerialCommandProcessor.Resume()') | Resumes command processing. |
| [ResumeAsync()](Jcd.Tasks.AsyncSerialCommandProcessor.ResumeAsync().md 'Jcd.Tasks.AsyncSerialCommandProcessor.ResumeAsync()') | Resumes command processing. |
| [StartProcessing()](Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing().md 'Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing()') | Starts the processing of queued commands. |
