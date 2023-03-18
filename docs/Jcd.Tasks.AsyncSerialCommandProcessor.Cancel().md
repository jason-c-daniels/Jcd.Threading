### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[AsyncSerialCommandProcessor](Jcd.Tasks.AsyncSerialCommandProcessor.md 'Jcd.Tasks.AsyncSerialCommandProcessor')

## AsyncSerialCommandProcessor.Cancel() Method

Signals the task executor to halt all processing immediately. This also cancels all tasks created  
by this task executor instance. This is mostly intended to be called during application shutdown.

```csharp
public void Cancel();
```