### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.TryStart(this Task, Exception, TaskScheduler) Method

Tries to successfully call start.

```csharp
public static Jcd.Tasks.TryStartResult TryStart(this System.Threading.Tasks.Task task, out System.Exception exception, System.Threading.Tasks.TaskScheduler taskScheduler=null);
```
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

The task to call Start on.

<a name='Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

The exception resulting from calling Start.

<a name='Jcd.Tasks.TaskExtensions.TryStart(thisSystem.Threading.Tasks.Task,System.Exception,System.Threading.Tasks.TaskScheduler).taskScheduler'></a>

`taskScheduler` [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')

The [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') to use for executing the task. If not provided the  
current [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') is used.

#### Returns
[TryStartResult](Jcd.Tasks.TryStartResult.md 'Jcd.Tasks.TryStartResult')  
[SuccessfullyStarted](Jcd.Tasks.TryStartResult.md#Jcd.Tasks.TryStartResult.SuccessfullyStarted 'Jcd.Tasks.TryStartResult.SuccessfullyStarted') when the Start was called and no exception occurred.  
            [AlreadyStarted](Jcd.Tasks.TryStartResult.md#Jcd.Tasks.TryStartResult.AlreadyStarted 'Jcd.Tasks.TryStartResult.AlreadyStarted') When the task was already in a started state. Start was not called.  
            [ErrorDuringStart](Jcd.Tasks.TryStartResult.md#Jcd.Tasks.TryStartResult.ErrorDuringStart 'Jcd.Tasks.TryStartResult.ErrorDuringStart') When start was called and an exception occurred during the call to start. Check the exception parameter for details.