### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.TryWaitAsync(this Task) Method

Tries to await a task regardless of status.

```csharp
public static System.Threading.Tasks.Task<bool> TryWaitAsync(this System.Threading.Tasks.Task task);
```
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.TryWaitAsync(thisSystem.Threading.Tasks.Task).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

The task to try awaiting.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
true if awaited without exception. false otherwise.