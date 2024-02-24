### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler.ActivateNewQueue() Method

Creates and activates a new scheduling queue for this scheduler.

```csharp
public System.Threading.Tasks.TaskScheduler ActivateNewQueue();
```

#### Returns
[System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')  
The newly created and activated queue at priority 0.