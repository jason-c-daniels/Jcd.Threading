### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[AsyncSerialCommandProcessor](Jcd.Tasks.AsyncSerialCommandProcessor.md 'Jcd.Tasks.AsyncSerialCommandProcessor')

## AsyncSerialCommandProcessor.EnqueueAsync(Action) Method

Enqueues a command for sequential execution. Awaiting the returned [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
waits for the command to finish executing.

```csharp
public System.Threading.Tasks.Task EnqueueAsync(System.Action command);
```
#### Parameters

<a name='Jcd.Tasks.AsyncSerialCommandProcessor.EnqueueAsync(System.Action).command'></a>

`command` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The command to execute.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
The [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') that will execute the enqueued action.

### Remarks
Awaiting this task before [StartProcessing()](Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing().md 'Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing()') is called will cause the calling  
thread of execution to block until [StartProcessing()](Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing().md 'Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing()') is called. Ensure that  
either [StartProcessing()](Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing().md 'Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing()') has already been called, or that your program has  
a mechanism in another thread to call [StartProcessing()](Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing().md 'Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing()'). You really need to  
call [StartProcessing()](Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing().md 'Jcd.Tasks.AsyncSerialCommandProcessor.StartProcessing()') for awaiting the result to work.