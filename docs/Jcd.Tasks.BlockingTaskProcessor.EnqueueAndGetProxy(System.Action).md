### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.EnqueueAndGetProxy(Action) Method

Enqueues an action and returns a proxy task that will execute the action.  
Awaiting the returned proxy [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') waits for the enqueued action to finish executing.

```csharp
public System.Threading.Tasks.Task EnqueueAndGetProxy(System.Action command);
```
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy(System.Action).command'></a>

`command` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The action to execute.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') that will execute the enqueued action.

### Remarks
Awaiting this task before [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') is called will cause the calling  
thread of execution to block until [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') is called. Ensure that  
either [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') has already been called, or that your program has  
a mechanism in another thread to call [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()'). You really need to  
call [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') for awaiting the result to work.