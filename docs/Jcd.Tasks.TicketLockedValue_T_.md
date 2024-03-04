### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## TicketLockedValue<T> Class

A value wrapper for a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') to block access during reads  
and writes. It guarantees in order execution of reads and writes.

```csharp
public sealed class TicketLockedValue<T> :
System.IDisposable
```
#### Type parameters

<a name='Jcd.Tasks.TicketLockedValue_T_.T'></a>

`T`

The data type to synchronize access to.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TicketLockedValue<T>

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Methods | |
| :--- | :--- |
| [GetValue()](Jcd.Tasks.TicketLockedValue_T_.GetValue().md 'Jcd.Tasks.TicketLockedValue<T>.GetValue()') | Retrieves the current value. If another thread edits the value, moment later a subsequent<br/>call will yield a different result. |
| [GetValueAsync()](Jcd.Tasks.TicketLockedValue_T_.GetValueAsync().md 'Jcd.Tasks.TicketLockedValue<T>.GetValueAsync()') | Gets the value in an async friendly manner. |
| [SetValue(T)](Jcd.Tasks.TicketLockedValue_T_.SetValue(T).md 'Jcd.Tasks.TicketLockedValue<T>.SetValue(T)') | Sets the current value to the provided value. |
| [SetValueAsync(T)](Jcd.Tasks.TicketLockedValue_T_.SetValueAsync(T).md 'Jcd.Tasks.TicketLockedValue<T>.SetValueAsync(T)') | Sets the current value to the provided value. |
