### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.EnqueueTask<T>(Task<T>) Method

Enqueues a cold task for later execution. If the passed in task is not cold, it's not enqueued.

```csharp
public System.Threading.Tasks.Task<T> EnqueueTask<T>(System.Threading.Tasks.Task<T> task);
```
#### Type parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueTask_T_(System.Threading.Tasks.Task_T_).T'></a>

`T`

The result type of the task.
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueTask_T_(System.Threading.Tasks.Task_T_).task'></a>

`task` [System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Tasks.BlockingTaskProcessor.EnqueueTask_T_(System.Threading.Tasks.Task_T_).md#Jcd.Tasks.BlockingTaskProcessor.EnqueueTask_T_(System.Threading.Tasks.Task_T_).T 'Jcd.Tasks.BlockingTaskProcessor.EnqueueTask<T>(System.Threading.Tasks.Task<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

the cold task

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Tasks.BlockingTaskProcessor.EnqueueTask_T_(System.Threading.Tasks.Task_T_).md#Jcd.Tasks.BlockingTaskProcessor.EnqueueTask_T_(System.Threading.Tasks.Task_T_).T 'Jcd.Tasks.BlockingTaskProcessor.EnqueueTask<T>(System.Threading.Tasks.Task<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The passed in task.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
When the task is null

### Remarks
  
When passing in a non-cold task the task is returned so that you can still await the result  
of the associated action. This is to support framework builders who may not control  
if a task is hot or cold.  
  
The reason for not enqueuing is to prevent such tasks, which can't be started, from  
occupying a position in the execution queue. This allows the processor to