### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor')

## BlockingTaskProcessor.Cancel() Method

Signals the task processor to halt all processing immediately. This also cancels all  
tasks created by this task task processor. This is mostly intended to be called  
during application shutdown.

```csharp
public void Cancel();
```