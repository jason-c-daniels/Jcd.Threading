### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.EnqueueAsyncFuncAsync<TResult>(Func<Task<TResult>>) Method

Asynchronously enqueues an async function for sequential execution. The result of the function execution  
is available by awaiting the returned [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

```csharp
public System.Threading.Tasks.Task<TResult> EnqueueAsyncFuncAsync<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> asyncFunction);
```
#### Type parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFuncAsync_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).TResult'></a>

`TResult`

The data type returned by the function
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFuncAsync_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).asyncFunction'></a>

`asyncFunction` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFuncAsync_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md#Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFuncAsync_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).TResult 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFuncAsync<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The async function to execute.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFuncAsync_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md#Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFuncAsync_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).TResult 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFuncAsync<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') that will execute the enqueued action.

### Remarks
Awaiting this task before [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') is called will cause the calling  
thread of execution to block until [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') is called. Ensure that  
either [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') has already been called, or that your program has  
a mechanism in another thread to call [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()'). You really need to  
call [StartProcessing()](Jcd.Tasks.BlockingTaskProcessor.StartProcessing().md 'Jcd.Tasks.BlockingTaskProcessor.StartProcessing()') for awaiting the result to work.