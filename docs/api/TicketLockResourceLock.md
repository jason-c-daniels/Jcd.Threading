#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## TicketLockResourceLock Class

Provides a mechanism for establishing and releasing locks on a [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock').

```csharp
public sealed class TicketLockResourceLock : Jcd.Threading.ResourceLockBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ResourceLockBase](ResourceLockBase.md 'Jcd.Threading.ResourceLockBase') &#129106; TicketLockResourceLock

| Properties | |
| :--- | :--- |
| [IsCanceled](TicketLockResourceLock.IsCanceled.md 'Jcd.Threading.TicketLockResourceLock.IsCanceled') | Indicates if the ticket has been canceled. |
| [TicketId](TicketLockResourceLock.TicketId.md 'Jcd.Threading.TicketLockResourceLock.TicketId') | The ticked Id for this instance. |

| Methods | |
| :--- | :--- |
| [Cancel()](TicketLockResourceLock.Cancel().md 'Jcd.Threading.TicketLockResourceLock.Cancel()') | Cancels the ticket. This will register a background thread to do cleanup. |
| [Dispose()](TicketLockResourceLock.Dispose().md 'Jcd.Threading.TicketLockResourceLock.Dispose()') | Releases any locks held. |
| [Release()](TicketLockResourceLock.Release().md 'Jcd.Threading.TicketLockResourceLock.Release()') | Releases the lock on the resource. |
| [Wait()](TicketLockResourceLock.Wait().md 'Jcd.Threading.TicketLockResourceLock.Wait()') | Waits for the `NowServing` on the owning [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')<br/>to match its own `TicketId` |
| [Wait(CancellationToken)](TicketLockResourceLock.Wait./qMcaGwC9YX4SwrhBu7HUg.md 'Jcd.Threading.TicketLockResourceLock.Wait(System.Threading.CancellationToken)') | Waits for the `NowServing` on the owning [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')<br/>to match its own `TicketId` |
| [WaitAsync()](TicketLockResourceLock.WaitAsync().md 'Jcd.Threading.TicketLockResourceLock.WaitAsync()') | Asynchronously Waits for the `NowServing` on the owning [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')<br/>to match its own `TicketId` |
| [WaitAsync(CancellationToken)](TicketLockResourceLock.WaitAsync.humuPsrlUp667NFsyn7PIw.md 'Jcd.Threading.TicketLockResourceLock.WaitAsync(System.Threading.CancellationToken)') | Waits for the `NowServing` on the owning [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock')<br/>to match its own `TicketId` |
