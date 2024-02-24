### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler.ActivateNewQueue(int) Method

Creates and activates a new scheduling queue for this scheduler.

```csharp
public System.Threading.Tasks.TaskScheduler ActivateNewQueue(int priority);
```
#### Parameters

<a name='Jcd.Tasks.QueuedTaskScheduler.ActivateNewQueue(int).priority'></a>

`priority` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The priority level for the new queue.

#### Returns
[System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')  
The newly created and activated queue at the specified priority.