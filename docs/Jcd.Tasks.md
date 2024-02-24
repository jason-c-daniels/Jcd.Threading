## Jcd.Tasks Namespace

Provides types and extension methods to assist with the creation, execution, and  
management of unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances.

| Classes | |
| :--- | :--- |
| [BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor') | Represents a high level object that enqueues and executes actions, functions, and unstarted tasks,<br/>waiting for each to complete before executing the next. |
| [CurrentSchedulerTaskRunner](Jcd.Tasks.CurrentSchedulerTaskRunner.md 'Jcd.Tasks.CurrentSchedulerTaskRunner') | A TaskRunner that schedules tasks on the current TaskScheduler or a user provided TaskScheduler. |
| [CurrentThreadTaskScheduler](Jcd.Tasks.CurrentThreadTaskScheduler.md 'Jcd.Tasks.CurrentThreadTaskScheduler') | |
| [DualSTAThreadScheduler](Jcd.Tasks.DualSTAThreadScheduler.md 'Jcd.Tasks.DualSTAThreadScheduler') | Provides two STA threads |
| [QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler') | Provides a TaskScheduler that provides control over priorities, fairness, and the underlying threads utilized. |
| [QueuedTaskScheduler.QueuedTaskSchedulerDebugView](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerDebugView.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerDebugView') | Debug view for the QueuedTaskScheduler. |
| [QueuedTaskScheduler.QueuedTaskSchedulerQueue](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue') | Provides a scheduling queue associatd with a QueuedTaskScheduler. |
| [QueuedTaskScheduler.QueuedTaskSchedulerQueue.QueuedTaskSchedulerQueueDebugView](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.QueuedTaskSchedulerQueueDebugView.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.QueuedTaskSchedulerQueueDebugView') | A debug view for the queue. |
| [QueuedTaskScheduler.QueueGroup](Jcd.Tasks.QueuedTaskScheduler.QueueGroup.md 'Jcd.Tasks.QueuedTaskScheduler.QueueGroup') | A group of queues a the same priority level. |
| [SchedulerBoundTaskRunner&lt;TScheduler&gt;](Jcd.Tasks.SchedulerBoundTaskRunner_TScheduler_.md 'Jcd.Tasks.SchedulerBoundTaskRunner<TScheduler>') | A TaskScheduler bound task runner. It ensures all tasks it creates are registered with either its own,<br/>or a user provided TaskScheduler. |
| [SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>') | Provides a simple async-safe method of setting, getting, and altering values intended<br/>to be shared among tasks and threads. |
| [TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions') | A set of helpers for [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') objects. |
| [ThreadScheduler](Jcd.Tasks.ThreadScheduler.md 'Jcd.Tasks.ThreadScheduler') | |
| [UnstartedTask](Jcd.Tasks.UnstartedTask.md 'Jcd.Tasks.UnstartedTask') | A Task factory that wraps the constructor with a tiny bit of logic, simplifying the process<br/>of directly creating unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')s. |

| Enums | |
| :--- | :--- |
| [TryStartResult](Jcd.Tasks.TryStartResult.md 'Jcd.Tasks.TryStartResult') | The possible results of calling [TryStart(this Task, Exception, TaskScheduler)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception, System.Threading.Tasks.TaskScheduler)') |
