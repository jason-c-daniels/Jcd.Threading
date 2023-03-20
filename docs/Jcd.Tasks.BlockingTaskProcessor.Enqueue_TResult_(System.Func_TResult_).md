### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.Enqueue<TResult>(Func<TResult>) Method

Enqueues a function. This is a "fire and forget" method.  
The function result will not be available and control is immediately returned to the caller.

```csharp
public void Enqueue<TResult>(System.Func<TResult> command);
```
#### Type parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.Enqueue_TResult_(System.Func_TResult_).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.Enqueue_TResult_(System.Func_TResult_).command'></a>

`command` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TResult](Jcd.Tasks.BlockingTaskProcessor.Enqueue_TResult_(System.Func_TResult_).md#Jcd.Tasks.BlockingTaskProcessor.Enqueue_TResult_(System.Func_TResult_).TResult 'Jcd.Tasks.BlockingTaskProcessor.Enqueue<TResult>(System.Func<TResult>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The command to enqueue.