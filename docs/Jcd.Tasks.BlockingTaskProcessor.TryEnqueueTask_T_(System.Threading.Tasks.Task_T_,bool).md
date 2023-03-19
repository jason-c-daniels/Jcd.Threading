### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.TryEnqueueTask<T>(Task<T>, bool) Method

Tries to enqueues a task for later execution. If the passed in task is not unstarted, it's not enqueued.

```csharp
public System.Threading.Tasks.Task<T> TryEnqueueTask<T>(System.Threading.Tasks.Task<T> task, out bool enqueued);
```
#### Type parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask_T_(System.Threading.Tasks.Task_T_,bool).T'></a>

`T`

The result type of the task.
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask_T_(System.Threading.Tasks.Task_T_,bool).task'></a>

`task` [System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask_T_(System.Threading.Tasks.Task_T_,bool).md#Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask_T_(System.Threading.Tasks.Task_T_,bool).T 'Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask<T>(System.Threading.Tasks.Task<T>, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

the unstarted task

<a name='Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask_T_(System.Threading.Tasks.Task_T_,bool).enqueued'></a>

`enqueued` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

a flag indicating if the task was actually enqueued

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask_T_(System.Threading.Tasks.Task_T_,bool).md#Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask_T_(System.Threading.Tasks.Task_T_,bool).T 'Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask<T>(System.Threading.Tasks.Task<T>, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The passed in task, or a cancelled [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') if the passed in task is null.

### Remarks
  
When passing in a previously started task the task is returned so that you can still await the result  
of the associated action. This is to support framework builders who may not control  
if a task is started or not.  
  
The reason for not enqueuing is to prevent such tasks, which can't be started, from  
occupying a position in the execution queue. This allows the processor to get to actual  
unstarted tasks sooner.