### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler.FindNextTask_NeedsLock(Task, QueuedTaskSchedulerQueue) Method

Find the next task that should be executed, based on priorities and fairness and the like.

```csharp
private void FindNextTask_NeedsLock(out System.Threading.Tasks.Task targetTask, out Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue queueForTargetTask);
```
#### Parameters

<a name='Jcd.Tasks.QueuedTaskScheduler.FindNextTask_NeedsLock(System.Threading.Tasks.Task,Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue).targetTask'></a>

`targetTask` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

The found task, or null if none was found.

<a name='Jcd.Tasks.QueuedTaskScheduler.FindNextTask_NeedsLock(System.Threading.Tasks.Task,Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue).queueForTargetTask'></a>

`queueForTargetTask` [QueuedTaskSchedulerQueue](Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue.md 'Jcd.Tasks.QueuedTaskScheduler.QueuedTaskSchedulerQueue')

The scheduler associated with the found task.  Due to security checks inside of TPL,    
this scheduler needs to be used to execute that task.