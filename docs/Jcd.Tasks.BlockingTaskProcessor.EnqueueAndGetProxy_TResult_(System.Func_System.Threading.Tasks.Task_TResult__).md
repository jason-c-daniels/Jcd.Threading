### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.EnqueueAndGetProxy<TResult>(Func<Task<TResult>>) Method

Enqueues an async function and returns a proxy task that will execute the function.  
Awaiting the returned [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') waits for the enqueued function to finish executing  
and returns the result.

```csharp
public System.Threading.Tasks.Task<TResult> EnqueueAndGetProxy<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> command);
```
#### Type parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).TResult'></a>

`TResult`

The data type returned by the function.
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).command'></a>

`command` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md#Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).TResult 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The async function to enqueue.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md#Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).TResult 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAndGetProxy<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') that will execute the enqueued action.

### Remarks
Awaiting this task before [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') is called will cause the calling  
thread of execution to block until [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') is called. Ensure that  
either [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') has already been called, or that your program has  
a mechanism in another thread to call [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()'). You really need to  
call [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') for awaiting the result to work.