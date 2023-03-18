### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[ColdTask](Jcd.Tasks.ColdTask.md 'Jcd.Tasks.ColdTask')

## ColdTask.StartThenWait(this Task, Nullable<CancellationToken>) Method

Starts an unstarted (cold) task and waits for its completion. This does nothing if the task was already started.

```csharp
public static void StartThenWait(this System.Threading.Tasks.Task task, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters

<a name='Jcd.Tasks.ColdTask.StartThenWait(thisSystem.Threading.Tasks.Task,System.Nullable_System.Threading.CancellationToken_).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the task.

<a name='Jcd.Tasks.ColdTask.StartThenWait(thisSystem.Threading.Tasks.Task,System.Nullable_System.Threading.CancellationToken_).cancellationToken'></a>

`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The optional [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') to use.

### Remarks
WARNING: This method potentially calls Task.Wait(). Be sure you understand the risks before using it.