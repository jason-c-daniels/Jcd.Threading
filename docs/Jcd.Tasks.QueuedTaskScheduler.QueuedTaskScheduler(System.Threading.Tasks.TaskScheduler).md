### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler(TaskScheduler) Constructor

Initializes the scheduler.

```csharp
public QueuedTaskScheduler(System.Threading.Tasks.TaskScheduler targetScheduler);
```
#### Parameters

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(System.Threading.Tasks.TaskScheduler).targetScheduler'></a>

`targetScheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The target underlying scheduler onto which this sceduler's work is queued.