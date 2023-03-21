### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.TryWait(this Task, CancellationToken) Method

Waits on a running task until it completes, is cancelled, faults or times out.

```csharp
public static bool TryWait(this System.Threading.Tasks.Task task, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.TryWait(thisSystem.Threading.Tasks.Task,System.Threading.CancellationToken).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the task to wait on.

<a name='Jcd.Tasks.TaskExtensions.TryWait(thisSystem.Threading.Tasks.Task,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

An optional cancellation token.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if it ran to completion. [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') otherwise.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown if the task is unstarted.