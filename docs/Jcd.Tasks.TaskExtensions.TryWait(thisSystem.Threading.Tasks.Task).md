### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.TryWait(this Task) Method

Tries to await a task regardless of status.

```csharp
public static bool TryWait(this System.Threading.Tasks.Task task);
```
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.TryWait(thisSystem.Threading.Tasks.Task).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

The task to try awaiting.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if awaited without exception. false otherwise.