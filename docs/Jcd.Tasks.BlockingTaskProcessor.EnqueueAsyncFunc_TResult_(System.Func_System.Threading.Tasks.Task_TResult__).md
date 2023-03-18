### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.EnqueueAsyncFunc<TResult>(Func<Task<TResult>>) Method

Enqueues an async command for sequential execution. This is a "fire and forget" method.  
The function call result will not be available and control is returned to the caller immediately.

```csharp
public void EnqueueAsyncFunc<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> command);
```
#### Type parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFunc_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFunc_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).command'></a>

`command` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFunc_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md#Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFunc_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).TResult 'Jcd.Tasks.BlockingTaskProcessor.EnqueueAsyncFunc<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The async command to execute.