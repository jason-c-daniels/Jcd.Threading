### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.Enqueue<TResult>(Func<Task<TResult>>) Method

Enqueues an async function. This is a "fire and forget" method.  
The function result will not be available and control is immediately returned to the caller.

```csharp
public void Enqueue<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> command);
```
#### Type parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.Enqueue_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.Enqueue_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).command'></a>

`command` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.BlockingTaskProcessor.Enqueue_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).md#Jcd.Tasks.BlockingTaskProcessor.Enqueue_TResult_(System.Func_System.Threading.Tasks.Task_TResult__).TResult 'Jcd.Tasks.BlockingTaskProcessor.Enqueue<TResult>(System.Func<System.Threading.Tasks.Task<TResult>>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The async function to enqueue.