### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler.QueuedTaskSchedulerQueue Class

Provides a scheduling queue associatd with a QueuedTaskScheduler.

```csharp
private sealed class QueuedTaskScheduler.QueuedTaskSchedulerQueue : System.Threading.Tasks.TaskScheduler,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; QueuedTaskSchedulerQueue

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [QueuedTaskSchedulerQueue(int, QueuedTaskScheduler)](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.QueuedTaskSchedulerQueue(int,Jcd.Tasks.QueuedTaskScheduler).md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.QueuedTaskSchedulerQueue(int, Jcd.Tasks.QueuedTaskScheduler)') | Initializes the queue. |

| Fields | |
| :--- | :--- |
| [_disposed](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue._disposed.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue._disposed') | Whether this queue has been disposed. |
| [_pool](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue._pool.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue._pool') | The scheduler with which this pool is associated. |
| [_priority](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue._priority.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue._priority') | Gets the priority for this queue. |
| [_workItems](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue._workItems.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue._workItems') | The work items stored in this queue. |

| Properties | |
| :--- | :--- |
| [MaximumConcurrencyLevel](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.MaximumConcurrencyLevel.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.MaximumConcurrencyLevel') | Gets the maximum concurrency level to use when processing tasks. |
| [WaitingTasks](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.WaitingTasks.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.WaitingTasks') | Gets the number of tasks waiting in this scheduler. |

| Methods | |
| :--- | :--- |
| [Dispose()](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.Dispose().md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.Dispose()') | Signals that the queue should be removed from the scheduler as soon as the queue is empty. |
| [ExecuteTask(Task)](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.ExecuteTask(System.Threading.Tasks.Task).md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.ExecuteTask(System.Threading.Tasks.Task)') | Runs the specified ask. |
| [GetScheduledTasks()](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.GetScheduledTasks().md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.GetScheduledTasks()') | Gets the tasks scheduled to this scheduler. |
| [QueueTask(Task)](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.QueueTask(System.Threading.Tasks.Task).md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.QueueTask(System.Threading.Tasks.Task)') | Queues a task to the scheduler. |
| [TryExecuteTaskInline(Task, bool)](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.TryExecuteTaskInline(System.Threading.Tasks.Task, bool)') | Tries to execute a task synchronously on the current thread. |
