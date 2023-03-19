### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## TryRunResult Enum

The possible results of calling [TryRun(this Task, Exception)](Jcd.Tasks.TaskExtensions.TryRun(thisSystem.Threading.Tasks.Task,System.Exception).md 'Jcd.Tasks.TaskExtensions.TryRun(this System.Threading.Tasks.Task, System.Exception)')

```csharp
public enum TryRunResult
```
### Fields

<a name='Jcd.Tasks.TryRunResult.AlreadyStarted'></a>

`AlreadyStarted` 1

The task was already in a started state. Start was not called.

<a name='Jcd.Tasks.TryRunResult.ErrorDuringStart'></a>

`ErrorDuringStart` 2

An exception occurred during the call to start.

<a name='Jcd.Tasks.TryRunResult.SuccessfullyCalled'></a>

`SuccessfullyCalled` 0

Start was called and no exception resulted.