### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[CurrentThreadTaskScheduler](Jcd.Tasks.CurrentThreadTaskScheduler.md 'Jcd.Tasks.CurrentThreadTaskScheduler')

## CurrentThreadTaskScheduler.QueueTask(Task) Method

Runs the provided Task synchronously on the current thread.

```csharp
protected override void QueueTask(System.Threading.Tasks.Task task);
```
#### Parameters

<a name='Jcd.Tasks.CurrentThreadTaskScheduler.QueueTask(System.Threading.Tasks.Task).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

The task to be executed.