### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[AsyncSerialCommandProcessor](Jcd.Tasks.AsyncSerialCommandProcessor.md 'Jcd.Tasks.AsyncSerialCommandProcessor')

## AsyncSerialCommandProcessor.Enqueue<TResult>(Func<TResult>) Method

Enqueues a command for sequential execution. This is a "fire and forget" method.  
The command result will not be available and control is returned to the caller immediately.

```csharp
public void Enqueue<TResult>(System.Func<TResult> command);
```
#### Type parameters

<a name='Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue_TResult_(System.Func_TResult_).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue_TResult_(System.Func_TResult_).command'></a>

`command` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TResult](Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue_TResult_(System.Func_TResult_).md#Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue_TResult_(System.Func_TResult_).TResult 'Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue<TResult>(System.Func<TResult>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The command to execute.