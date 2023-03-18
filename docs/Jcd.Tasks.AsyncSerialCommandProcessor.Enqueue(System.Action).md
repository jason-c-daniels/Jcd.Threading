### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[AsyncSerialCommandProcessor](Jcd.Tasks.AsyncSerialCommandProcessor.md 'Jcd.Tasks.AsyncSerialCommandProcessor')

## AsyncSerialCommandProcessor.Enqueue(Action) Method

Enqueues a command for sequential execution. This is a "fire and forget" method.  
Control is returned to the caller immediately.

```csharp
public void Enqueue(System.Action command);
```
#### Parameters

<a name='Jcd.Tasks.AsyncSerialCommandProcessor.Enqueue(System.Action).command'></a>

`command` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The command to execute.