### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[AsyncSerialCommandProcessor](Jcd.Tasks.AsyncSerialCommandProcessor.md 'Jcd.Tasks.AsyncSerialCommandProcessor')

## AsyncSerialCommandProcessor.Pause() Method

Pauses the retrieval and execution of queued tasks. If a task is in the middle of being started when this is  
called it will still get started.

```csharp
public void Pause();
```