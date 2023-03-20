### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.TryEnqueueTask(Task, bool) Method

Tries to enqueues a task for later execution. If the passed in task is already  
started, it's not enqueued.

```csharp
public System.Threading.Tasks.Task TryEnqueueTask(System.Threading.Tasks.Task task, out bool enqueued);
```
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask(System.Threading.Tasks.Task,bool).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the unstarted task

<a name='Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask(System.Threading.Tasks.Task,bool).enqueued'></a>

`enqueued` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

a flag indicating if the task was actually enqueued.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
The passed in task.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
When [task](Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask(System.Threading.Tasks.Task,bool).md#Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask(System.Threading.Tasks.Task,bool).task 'Jcd.Tasks.BlockingTaskProcessor.TryEnqueueTask(System.Threading.Tasks.Task, bool).task') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null')

### Remarks
  
When passing in a previously started task the task is still returned so that you can still await the result  
of the associated action. This is to support framework builders who may not control  
if a task is unstarted or not.  
  
The reason for not enqueuing is to prevent such tasks, which can't be started, from  
occupying a position in the execution queue. This allows the processor to get to actual  
unstarted tasks sooner.