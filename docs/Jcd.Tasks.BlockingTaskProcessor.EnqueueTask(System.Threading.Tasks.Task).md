### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.EnqueueTask(Task) Method

Enqueues a cold task for later execution. If the passed in task is not cold, it's not enqueued.

```csharp
public System.Threading.Tasks.Task EnqueueTask(System.Threading.Tasks.Task task);
```
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueTask(System.Threading.Tasks.Task).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the cold task

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
The passed in task.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
When the task is null

### Remarks
When passing in a non-cold task the task is returned so that you can still await the result  
of the associated action. This is to support framework builders who may not control  
if a task is hot or cold.