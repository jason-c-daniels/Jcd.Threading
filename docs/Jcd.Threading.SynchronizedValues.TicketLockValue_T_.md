#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues')

## TicketLockValue<T> Class

A value wrapper for a [TicketLock](Jcd.Threading.TicketLock.md 'Jcd.Threading.TicketLock') to block access during reads  
and writes. It guarantees in order execution of locks.

```csharp
public sealed class TicketLockValue<T>
```
#### Type parameters

<a name='Jcd.Threading.SynchronizedValues.TicketLockValue_T_.T'></a>

`T`

The data type to synchronize access to.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TicketLockValue<T>

| Constructors | |
| :--- | :--- |
| [TicketLockValue(T)](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.TicketLockValue(T).md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.TicketLockValue(T)') | Constructs an instance of [TicketLockValue&lt;T&gt;](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>') |

| Methods | |
| :--- | :--- |
| [ChangeValue(Func&lt;T,T&gt;)](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.ChangeValue(System.Func_T,T_).md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.ChangeValue(System.Func<T,T>)') | Calls the provided function, passing in the current value, and assigns the result<br/>of the function call, to the current value. <b>This is not recursively reentrant.<br/>see remarks for details.</b> |
| [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.ChangeValueAsync(System.Func_T,System.Threading.Tasks.Task_T__).md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)') | Calls the provided function, passing in the current value, and assigns the result<br/>of the function call, to the current value. <b>This is not recursively reentrant.<br/>see remarks for details.</b> |
| [GetValue()](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.GetValue().md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.GetValue()') | Retrieves the current value. If another thread edits the value, moment later a subsequent<br/>call will yield a different result. |
| [GetValueAsync()](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.GetValueAsync().md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.GetValueAsync()') | Gets the value in an async friendly manner. |
| [SetValue(T)](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.SetValue(T).md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.SetValue(T)') | Sets the current value to the provided value. |
| [SetValueAsync(T)](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.SetValueAsync(T).md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.SetValueAsync(T)') | Sets the current value to the provided value. |
