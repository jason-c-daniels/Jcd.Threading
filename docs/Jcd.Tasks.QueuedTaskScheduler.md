### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## QueuedTaskScheduler Class

Provides a TaskScheduler that provides control over priorities, fairness, and the underlying threads utilized.

```csharp
public sealed class QueuedTaskScheduler : System.Threading.Tasks.TaskScheduler,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; QueuedTaskScheduler

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [QueuedTaskScheduler()](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler().md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler()') | Initializes the scheduler. |
| [QueuedTaskScheduler(int, string, bool, ThreadPriority, ApartmentState, int, Action, Action)](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState,int,System.Action,System.Action).md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int, string, bool, System.Threading.ThreadPriority, System.Threading.ApartmentState, int, System.Action, System.Action)') | Initializes the scheduler. |
| [QueuedTaskScheduler(int)](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int).md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int)') | Initializes the scheduler. |
| [QueuedTaskScheduler(TaskScheduler, int)](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(System.Threading.Tasks.TaskScheduler,int).md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(System.Threading.Tasks.TaskScheduler, int)') | Initializes the scheduler. |
| [QueuedTaskScheduler(TaskScheduler)](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(System.Threading.Tasks.TaskScheduler)') | Initializes the scheduler. |

| Fields | |
| :--- | :--- |
| [_blockingTaskQueue](Jcd.Tasks.QueuedTaskScheduler._blockingTaskQueue.md 'Jcd.Tasks.QueuedTaskScheduler._blockingTaskQueue') | The collection of tasks to be executed on our custom threads. |
| [_concurrencyLevel](Jcd.Tasks.QueuedTaskScheduler._concurrencyLevel.md 'Jcd.Tasks.QueuedTaskScheduler._concurrencyLevel') | The maximum allowed concurrency level of this scheduler.  If custom threads are<br/>used, this represents the number of created threads. |
| [_delegatesQueuedOrRunning](Jcd.Tasks.QueuedTaskScheduler._delegatesQueuedOrRunning.md 'Jcd.Tasks.QueuedTaskScheduler._delegatesQueuedOrRunning') | The number of Tasks that have been queued or that are running whiel using an underlying scheduler. |
| [_disposeCancellation](Jcd.Tasks.QueuedTaskScheduler._disposeCancellation.md 'Jcd.Tasks.QueuedTaskScheduler._disposeCancellation') | Cancellation token used for disposal. |
| [_nonthreadsafeTaskQueue](Jcd.Tasks.QueuedTaskScheduler._nonthreadsafeTaskQueue.md 'Jcd.Tasks.QueuedTaskScheduler._nonthreadsafeTaskQueue') | The queue of tasks to process when using an underlying target scheduler. |
| [_queueGroups](Jcd.Tasks.QueuedTaskScheduler._queueGroups.md 'Jcd.Tasks.QueuedTaskScheduler._queueGroups') | A sorted list of round-robin queue lists.  Tasks with the smallest priority value<br/>are preferred.  Priority groups are round-robin'd through in order of priority. |
| [_targetScheduler](Jcd.Tasks.QueuedTaskScheduler._targetScheduler.md 'Jcd.Tasks.QueuedTaskScheduler._targetScheduler') | The scheduler onto which actual work is scheduled. |
| [_taskProcessingThread](Jcd.Tasks.QueuedTaskScheduler._taskProcessingThread.md 'Jcd.Tasks.QueuedTaskScheduler._taskProcessingThread') | Whether we're processing tasks on the current thread. |
| [_threads](Jcd.Tasks.QueuedTaskScheduler._threads.md 'Jcd.Tasks.QueuedTaskScheduler._threads') | The threads used by the scheduler to process work. |

| Properties | |
| :--- | :--- |
| [DebugQueueCount](Jcd.Tasks.QueuedTaskScheduler.DebugQueueCount.md 'Jcd.Tasks.QueuedTaskScheduler.DebugQueueCount') | Gets the number of queues currently activated. |
| [DebugTaskCount](Jcd.Tasks.QueuedTaskScheduler.DebugTaskCount.md 'Jcd.Tasks.QueuedTaskScheduler.DebugTaskCount') | Gets the number of tasks currently scheduled. |
| [MaximumConcurrencyLevel](Jcd.Tasks.QueuedTaskScheduler.MaximumConcurrencyLevel.md 'Jcd.Tasks.QueuedTaskScheduler.MaximumConcurrencyLevel') | Gets the maximum concurrency level to use when processing tasks. |

| Methods | |
| :--- | :--- |
| [ActivateNewQueue()](Jcd.Tasks.QueuedTaskScheduler.ActivateNewQueue().md 'Jcd.Tasks.QueuedTaskScheduler.ActivateNewQueue()') | Creates and activates a new scheduling queue for this scheduler. |
| [ActivateNewQueue(int)](Jcd.Tasks.QueuedTaskScheduler.ActivateNewQueue(int).md 'Jcd.Tasks.QueuedTaskScheduler.ActivateNewQueue(int)') | Creates and activates a new scheduling queue for this scheduler. |
| [Dispose()](Jcd.Tasks.QueuedTaskScheduler.Dispose().md 'Jcd.Tasks.QueuedTaskScheduler.Dispose()') | Initiates shutdown of the scheduler. |
| [FindNextTask_NeedsLock(Task, QueuedTaskSchedulerQueue)](Jcd.Tasks.QueuedTaskScheduler.FindNextTask_NeedsLock(System.Threading.Tasks.Task,Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue).md 'Jcd.Tasks.QueuedTaskScheduler.FindNextTask_NeedsLock(System.Threading.Tasks.Task, Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue)') | Find the next task that should be executed, based on priorities and fairness and the like. |
| [GetScheduledTasks()](Jcd.Tasks.QueuedTaskScheduler.GetScheduledTasks().md 'Jcd.Tasks.QueuedTaskScheduler.GetScheduledTasks()') | Gets the tasks scheduled to this scheduler. |
| [NotifyNewWorkItem()](Jcd.Tasks.QueuedTaskScheduler.NotifyNewWorkItem().md 'Jcd.Tasks.QueuedTaskScheduler.NotifyNewWorkItem()') | Notifies the pool that there's a new item to be executed in one of the round-robin queues. |
| [ProcessPrioritizedAndBatchedTasks()](Jcd.Tasks.QueuedTaskScheduler.ProcessPrioritizedAndBatchedTasks().md 'Jcd.Tasks.QueuedTaskScheduler.ProcessPrioritizedAndBatchedTasks()') | Process tasks one at a time in the best order.  <br/>This should be run in a Task generated by QueueTask.<br/>It's been separated out into its own method to show up better in Parallel Tasks. |
| [QueueTask(Task)](Jcd.Tasks.QueuedTaskScheduler.QueueTask(System.Threading.Tasks.Task).md 'Jcd.Tasks.QueuedTaskScheduler.QueueTask(System.Threading.Tasks.Task)') | Queues a task to the scheduler. |
| [RemoveQueue_NeedsLock(QueuedTaskSchedulerQueue)](Jcd.Tasks.QueuedTaskScheduler.RemoveQueue_NeedsLock(Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue).md 'Jcd.Tasks.QueuedTaskScheduler.RemoveQueue_NeedsLock(Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue)') | Removes a scheduler from the group. |
| [ThreadBasedDispatchLoop(Action, Action)](Jcd.Tasks.QueuedTaskScheduler.ThreadBasedDispatchLoop(System.Action,System.Action).md 'Jcd.Tasks.QueuedTaskScheduler.ThreadBasedDispatchLoop(System.Action, System.Action)') | The dispatch loop run by all threads in this scheduler. |
| [TryExecuteTaskInline(Task, bool)](Jcd.Tasks.QueuedTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).md 'Jcd.Tasks.QueuedTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task, bool)') | Tries to execute a task synchronously on the current thread. |
