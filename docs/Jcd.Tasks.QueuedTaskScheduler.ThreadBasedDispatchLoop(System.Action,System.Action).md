### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler.ThreadBasedDispatchLoop(Action, Action) Method

The dispatch loop run by all threads in this scheduler.

```csharp
private void ThreadBasedDispatchLoop(System.Action threadInit, System.Action threadFinally);
```
#### Parameters

<a name='Jcd.Tasks.QueuedTaskScheduler.ThreadBasedDispatchLoop(System.Action,System.Action).threadInit'></a>

`threadInit` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

An initialization routine to run when the thread begins.

<a name='Jcd.Tasks.QueuedTaskScheduler.ThreadBasedDispatchLoop(System.Action,System.Action).threadFinally'></a>

`threadFinally` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

A finalization routine to run before the thread ends.