#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues')

## TicketLockValue<T> Class

Provides a generic mechanism for setting, getting, acting on, and altering values
shared among tasks and threads, utilizing a [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock') for synchronization.

```csharp
public sealed class TicketLockValue<T>
```
#### Type parameters

<a name='Jcd.Threading.SynchronizedValues.TicketLockValue_T_.T'></a>

`T`

The data type to synchronize access to.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TicketLockValue<T>

### Remarks

While this provides a method of easily ensuring any one shared value is appropriately
locked during setting or getting, you still need to thoroughly understand your
use case. For example, having two [TicketLockValue&lt;T&gt;](TicketLockValue_T_.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>') instances accessed
by two different threads, in rapid succession, in different orders can cause
potentially unexpected results.

In cases where the pair/tuple must be consistent at all times across all accesses,
consider creating a struct containing the necessary fields/properties and wrapping
that in a [TicketLockValue&lt;T&gt;](TicketLockValue_T_.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>') instead of each individual field/property.

As well this implementation uses [TicketLock](TicketLock.md 'Jcd.Threading.TicketLock') and requires `Dispose` to be
called. Either implement [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') or call it directly at the appropriate
time. See the documentation for [ChangeValue(Func&lt;T,T&gt;)](TicketLockValue_T_.ChangeValue.6lXEnT5Pt8Em1e6VS5RuIw.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.ChangeValue(System.Func<T,T>)'), [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](TicketLockValue_T_.ChangeValueAsync.VsMLRzkQWJhOpFuMjrK6lQ.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)'),
for recursive reentrancy considerations. <i>(i.e. don't try it!)</i>

NB: If using a reference type for the underlying value, ensure your reference
type appropriately synchronizes access to its own data. In this case these
types only restrict access to the reference, not the data contained within
the reference type.

| Constructors | |
| :--- | :--- |
| [TicketLockValue(T)](TicketLockValue_T_..ctor.Qiyrb7RohSHzoHH+Tg1lNQ.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.TicketLockValue(T)') | Constructs an instance of [TicketLockValue&lt;T&gt;](TicketLockValue_T_.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>') |

| Properties | |
| :--- | :--- |
| [Value](TicketLockValue_T_.Value.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.Value') | The synchronized value. |

| Methods | |
| :--- | :--- |
| [ChangeValue(Func&lt;T,T&gt;)](TicketLockValue_T_.ChangeValue.6lXEnT5Pt8Em1e6VS5RuIw.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.ChangeValue(System.Func<T,T>)') | Calls the provided function, passing in the current value, and assigns the result of the function call, to the current value. <b>This is not recursively reentrant. see remarks for details.</b> |
| [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](TicketLockValue_T_.ChangeValueAsync.VsMLRzkQWJhOpFuMjrK6lQ.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)') | Calls the provided function, passing in the current value, and assigns the result of the function call, to the current value. <b>This is not recursively reentrant. see remarks for details.</b> |
| [GetValue()](TicketLockValue_T_.GetValue().md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.GetValue()') | Retrieves the current value. If another thread edits the value, moment later a subsequent call will yield a different result. |
| [GetValueAsync()](TicketLockValue_T_.GetValueAsync().md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.GetValueAsync()') | Gets the value in an async friendly manner. |
| [SetValue(T)](TicketLockValue_T_.SetValue.ZYSOaNTkB2fU3Z5VseNYFw.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.SetValue(T)') | Sets the current value to the provided value. |
| [SetValueAsync(T)](TicketLockValue_T_.SetValueAsync.uUJCArRXcAWhrlvAQaJNEw.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.SetValueAsync(T)') | Sets the current value to the provided value. |
