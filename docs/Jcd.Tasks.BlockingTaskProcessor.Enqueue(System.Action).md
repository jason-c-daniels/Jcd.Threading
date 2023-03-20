### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.Enqueue(Action) Method

Enqueues an action. This is a "fire and forget" method. Control is immediately  
returned to the caller.

```csharp
public void Enqueue(System.Action command);
```
#### Parameters

<a name='Jcd.Tasks.BlockingTaskProcessor.Enqueue(System.Action).command'></a>

`command` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The action to enqueue.