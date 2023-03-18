### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[ColdTask](Jcd.Tasks.ColdTask.md 'Jcd.Tasks.ColdTask')

## ColdTask.StartThenWaitForResult<TResult>(this Task<TResult>, Nullable<CancellationToken>) Method

Starts an unstarted (cold) task and waits for its completion. This does nothing if the task was already started.

```csharp
public static TResult StartThenWaitForResult<TResult>(this System.Threading.Tasks.Task<TResult> task, System.Nullable<System.Threading.CancellationToken> cancellationToken=null);
```
#### Type parameters

<a name='Jcd.Tasks.ColdTask.StartThenWaitForResult_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Nullable_System.Threading.CancellationToken_).TResult'></a>

`TResult`
#### Parameters

<a name='Jcd.Tasks.ColdTask.StartThenWaitForResult_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Nullable_System.Threading.CancellationToken_).task'></a>

`task` [System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](Jcd.Tasks.ColdTask.StartThenWaitForResult_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Nullable_System.Threading.CancellationToken_).md#Jcd.Tasks.ColdTask.StartThenWaitForResult_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Nullable_System.Threading.CancellationToken_).TResult 'Jcd.Tasks.ColdTask.StartThenWaitForResult<TResult>(this System.Threading.Tasks.Task<TResult>, System.Nullable<System.Threading.CancellationToken>).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

the task.

<a name='Jcd.Tasks.ColdTask.StartThenWaitForResult_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Nullable_System.Threading.CancellationToken_).cancellationToken'></a>

`cancellationToken` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The optional [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') to use.

#### Returns
[TResult](Jcd.Tasks.ColdTask.StartThenWaitForResult_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Nullable_System.Threading.CancellationToken_).md#Jcd.Tasks.ColdTask.StartThenWaitForResult_TResult_(thisSystem.Threading.Tasks.Task_TResult_,System.Nullable_System.Threading.CancellationToken_).TResult 'Jcd.Tasks.ColdTask.StartThenWaitForResult<TResult>(this System.Threading.Tasks.Task<TResult>, System.Nullable<System.Threading.CancellationToken>).TResult')

### Remarks
WARNING: This method potentially calls Task.Wait(). Be sure you understand the risks before using it.