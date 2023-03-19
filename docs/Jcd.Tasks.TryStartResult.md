### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## TryStartResult Enum

The possible results of calling [TryStart(this Task, Exception)](Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception).md 'Jcd.Tasks.TaskExtensions.TryStart(this System.Threading.Tasks.Task, System.Exception)')

```csharp
public enum TryStartResult
```
### Fields

<a name='Jcd.Tasks.TryStartResult.AlreadyStarted'></a>

`AlreadyStarted` 1

The task was already in a started state. Start was not called.

<a name='Jcd.Tasks.TryStartResult.ErrorDuringStart'></a>

`ErrorDuringStart` 2

An exception occurred during the call to start.

<a name='Jcd.Tasks.TryStartResult.SuccessfullyCalled'></a>

`SuccessfullyCalled` 0

Start was called and no exception resulted.