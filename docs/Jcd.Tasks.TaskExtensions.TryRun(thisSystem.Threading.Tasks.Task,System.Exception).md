### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.TryRun(this Task, Exception) Method

Tries to successfully call start.

```csharp
public static Jcd.Tasks.TryRunResult TryRun(this System.Threading.Tasks.Task task, out System.Exception exception);
```
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.TryRun(thisSystem.Threading.Tasks.Task,System.Exception).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

The

<a name='Jcd.Tasks.TaskExtensions.TryRun(thisSystem.Threading.Tasks.Task,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

#### Returns
[TryRunResult](Jcd.Tasks.TryRunResult.md 'Jcd.Tasks.TryRunResult')  
[SuccessfullyCalled](Jcd.Tasks.TryRunResult.md#Jcd.Tasks.TryRunResult.SuccessfullyCalled 'Jcd.Tasks.TryRunResult.SuccessfullyCalled') when the Start was called and no exception occurred.  
            [AlreadyStarted](Jcd.Tasks.TryRunResult.md#Jcd.Tasks.TryRunResult.AlreadyStarted 'Jcd.Tasks.TryRunResult.AlreadyStarted') When the task was already in a started state. Start was not called.  
            [ErrorDuringStart](Jcd.Tasks.TryRunResult.md#Jcd.Tasks.TryRunResult.ErrorDuringStart 'Jcd.Tasks.TryRunResult.ErrorDuringStart') When start was called and an exception occurred during the call to start. Check the exception parameter for details.