### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler(TaskScheduler, int) Constructor

Initializes the scheduler.

```csharp
public QueuedTaskScheduler(System.Threading.Tasks.TaskScheduler targetScheduler, int maxConcurrencyLevel);
```
#### Parameters

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(System.Threading.Tasks.TaskScheduler,int).targetScheduler'></a>

`targetScheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The target underlying scheduler onto which this sceduler's work is queued.

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(System.Threading.Tasks.TaskScheduler,int).maxConcurrencyLevel'></a>

`maxConcurrencyLevel` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximum degree of concurrency allowed for this scheduler's work.