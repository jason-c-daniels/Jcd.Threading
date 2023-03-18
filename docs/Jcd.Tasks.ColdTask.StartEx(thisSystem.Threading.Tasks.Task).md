### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[ColdTask](Jcd.Tasks.ColdTask.md 'Jcd.Tasks.ColdTask')

## ColdTask.StartEx(this Task) Method

Starts an unstarted task then returns the task. If the task isn't cold it isn't started, it's still returned.

```csharp
public static System.Threading.Tasks.Task StartEx(this System.Threading.Tasks.Task task);
```
#### Parameters

<a name='Jcd.Tasks.ColdTask.StartEx(thisSystem.Threading.Tasks.Task).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the task

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
the task