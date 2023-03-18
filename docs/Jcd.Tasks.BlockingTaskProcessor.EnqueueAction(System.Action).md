### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.EnqueueAction(Action) Method

Enqueues a command for sequential execution. This is a "fire and forget" method.  
Control is returned to the caller immediately.

```csharp
public void EnqueueAction(System.Action command);
```
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.EnqueueAction(System.Action).command'></a>

`command` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The command to execute.