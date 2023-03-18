### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[AsyncSerialCommandProcessor](Jcd.Tasks.AsyncSerialCommandProcessor.md 'Jcd.Tasks.AsyncSerialCommandProcessor')

## AsyncSerialCommandProcessor.Enqueue(Func<Task>) Method

Enqueues an async command for sequential execution. This is a "fire and forget" method.  
Control is returned to the caller immediately.

```csharp
public void Enqueue(System.Func<System.Threading.Tasks.Task> command);
```
#### Parameters

<a name='Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue(System.Func_System.Threading.Tasks.Task_).command'></a>

`command` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The asynchronous command to execute.