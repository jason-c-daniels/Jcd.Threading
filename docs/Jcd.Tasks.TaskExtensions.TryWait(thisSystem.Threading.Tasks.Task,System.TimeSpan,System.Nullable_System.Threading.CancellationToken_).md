### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions')

## TaskExtensions.TryWait(this Task, TimeSpan, Nullable<CancellationToken>) Method

Waits on a running task until it completes, is cancelled, faults or times out.

```csharp
public static bool TryWait(this System.Threading.Tasks.Task task, System.TimeSpan timeout, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Parameters

<a name='Jcd.Tasks.TaskExtensions.TryWait(thisSystem.Threading.Tasks.Task,System.TimeSpan,System.Nullable_System.Threading.CancellationToken_).task'></a>

`task` [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

the task to wait on.

<a name='Jcd.Tasks.TaskExtensions.TryWait(thisSystem.Threading.Tasks.Task,System.TimeSpan,System.Nullable_System.Threading.CancellationToken_).timeout'></a>

`timeout` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')

the amount of time to wait. Must be a value between -1 (infinite) and  [System.Int32.MaxValue](https://docs.microsoft.com/en-us/dotnet/api/System.Int32.MaxValue 'System.Int32.MaxValue')

<a name='Jcd.Tasks.TaskExtensions.TryWait(thisSystem.Threading.Tasks.Task,System.TimeSpan,System.Nullable_System.Threading.CancellationToken_).cancellationToken'></a>

`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional cancellation token.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if ran to completion. [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') otherwise.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown if the task is unstarted.