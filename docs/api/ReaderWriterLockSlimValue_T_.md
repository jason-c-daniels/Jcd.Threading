#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues')

## ReaderWriterLockSlimValue<T> Class

Provides a simple async-safe and thread-safe method of setting, getting, acting on,
and altering values shared among tasks and threads.

```csharp
public sealed class ReaderWriterLockSlimValue<T> :
System.IDisposable
```
#### Type parameters

<a name='Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue_T_.T'></a>

`T`

The data type to synchronize access to.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ReaderWriterLockSlimValue<T>

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

### Remarks

While this provides a method of easily ensuring any one shared value is appropriately
locked during setting or getting, you still need to thoroughly understand your
use case. For example, having two [ReaderWriterLockSlimValue&lt;T&gt;](ReaderWriterLockSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>') instances accessed
by two different threads, in rapid succession, in different orders can cause
potentially unexpected results.

In cases where the pair/tuple must be consistent at all times across all accesses,
consider creating a struct containing the necessary fields/properties and wrapping
that in a [ReaderWriterLockSlimValue&lt;T&gt;](ReaderWriterLockSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>') instead of each individual field/property.

As well this implementation uses [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') and requires Dispose to be
called. Either implement [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') or call it directly at the appropriate
time. See the documentation for [ChangeValue(Func&lt;T,T&gt;)](ReaderWriterLockSlimValue_T_.ChangeValue.z+hpMSz/sZfSMoED9mE7Iw.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.ChangeValue(System.Func<T,T>)'), [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](ReaderWriterLockSlimValue_T_.ChangeValueAsync.suSdbC1rwhPx9+9ijiN7xA.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)'),
for recursive reentrancy considerations. <i>(i.e. don't try it!)</i>

| Constructors | |
| :--- | :--- |
| [ReaderWriterLockSlimValue(T)](ReaderWriterLockSlimValue_T_..ctor.K0oESzwaW247nFPUTFxbFw.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.ReaderWriterLockSlimValue(T)') | Provides a simple async-safe and thread-safe method of setting, getting, acting on,<br/>and altering values shared among tasks and threads. |

| Properties | |
| :--- | :--- |
| [Value](ReaderWriterLockSlimValue_T_.Value.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.Value') | Get or sets the synchronized value. |

| Methods | |
| :--- | :--- |
| [ChangeValue(Func&lt;T,T&gt;)](ReaderWriterLockSlimValue_T_.ChangeValue.z+hpMSz/sZfSMoED9mE7Iw.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.ChangeValue(System.Func<T,T>)') | Calls the provided function, passing in the current value, and assigns the result<br/>of the function call, to the current value. <b>This is not recursively reentrant.
<br/>see remarks for details.</b> |
| [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](ReaderWriterLockSlimValue_T_.ChangeValueAsync.suSdbC1rwhPx9+9ijiN7xA.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)') | Calls the provided function, passing in the current value, and assigns the result<br/>of the function call, to the current value. <b>This is not recursively reentrant.
<br/>see remarks for details.</b> |
| [GetValue()](ReaderWriterLockSlimValue_T_.GetValue().md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.GetValue()') | Retrieves the current value. If another thread edits the value, moment later a subsequent<br/>call will yield a different result. |
| [GetValueAsync()](ReaderWriterLockSlimValue_T_.GetValueAsync().md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.GetValueAsync()') | Gets the value in an async friendly manner. |
| [SetValue(T)](ReaderWriterLockSlimValue_T_.SetValue.vBVt5XYUfLOJkxCQYVvUgA.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.SetValue(T)') | Sets the current value to the provided value. |
| [SetValueAsync(T)](ReaderWriterLockSlimValue_T_.SetValueAsync.NdldeoAhiGgynKMh8wKB7g.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.SetValueAsync(T)') | Sets the current value to the provided value. |
