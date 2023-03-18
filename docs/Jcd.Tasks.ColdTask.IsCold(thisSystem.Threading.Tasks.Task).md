### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[ColdTask](Jcd.Tasks.ColdTask.md 'Jcd.Tasks.ColdTask')

## ColdTask.IsCold(this Task) Method

Returns true if the task status indicates execution hasn't begun. (Status==Created)

```csharp
public static bool IsCold(this System.Threading.Tasks.Task task);
```
#### Parameters

<a name='Jcd.Tasks.ColdTask.IsCold(thisSystem.Threading.Tasks.Task).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the task to inspect

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if unstarted. False otherwise.