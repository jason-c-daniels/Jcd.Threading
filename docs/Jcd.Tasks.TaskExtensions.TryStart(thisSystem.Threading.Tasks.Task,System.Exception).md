### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.TryStart(this Task, Exception) Method

Tries to successfully call start.

```csharp
public static Jcd.Tasks.TryStartResult TryStart(this System.Threading.Tasks.Task task, out System.Exception exception);
```
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

The

<a name='Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

#### Returns
[TryStartResult](Jcd.Tasks.TryStartResult.md 'Jcd.Tasks.TryStartResult')  
[SuccessfullyCalled](Jcd.Tasks.TryStartResult.md#Jcd.Tasks.TryStartResult.SuccessfullyCalled 'Jcd.Tasks.TryStartResult.SuccessfullyCalled') when the Start was called and no exception occurred.  
            [AlreadyStarted](Jcd.Tasks.TryStartResult.md#Jcd.Tasks.TryStartResult.AlreadyStarted 'Jcd.Tasks.TryStartResult.AlreadyStarted') When the task was already in a started state. Start was not called.  
            [ErrorDuringStart](Jcd.Tasks.TryStartResult.md#Jcd.Tasks.TryStartResult.ErrorDuringStart 'Jcd.Tasks.TryStartResult.ErrorDuringStart') When start was called and an exception occurred during the call to start. Check the exception parameter for details.