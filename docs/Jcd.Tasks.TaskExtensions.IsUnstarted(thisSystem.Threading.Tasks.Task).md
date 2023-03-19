### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.IsUnstarted(this Task) Method

Checks if a task is unstarted and startable. (Status==Created)

```csharp
public static bool IsUnstarted(this System.Threading.Tasks.Task task);
```
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.IsUnstarted(thisSystem.Threading.Tasks.Task).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the task to inspect

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if unstarted. False otherwise.