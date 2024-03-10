#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues')

## SemaphoreSlimValue<T> Class

Provides a generic mechanism for setting, getting, acting on, and altering values
shared among tasks and threads, utilizing a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') for synchronization.

```csharp
public sealed class SemaphoreSlimValue<T> :
System.IDisposable
```
#### Type parameters

<a name='Jcd.Threading.SynchronizedValues.SemaphoreSlimValue_T_.T'></a>

`T`

The data type to synchronize access to.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SemaphoreSlimValue<T>

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

### Remarks

While this provides a method of easily ensuring any one shared value is appropriately
locked during setting or getting, you still need to thoroughly understand your
use case. For example, having two [SemaphoreSlimValue&lt;T&gt;](SemaphoreSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>') instances accessed
by two different threads, in rapid succession, in different orders can cause
potentially unexpected results.

In cases where the pair/tuple must be consistent at all times across all accesses,
consider creating a struct containing the necessary fields/properties and wrapping
that in a [SemaphoreSlimValue&lt;T&gt;](SemaphoreSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>') instead of each individual field/property.

As well this implementation uses [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') and requires `Dispose` to be
called. Either implement [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') or call it directly at the appropriate
time. See the documentation for [ChangeValue(Func&lt;T,T&gt;)](SemaphoreSlimValue_T_.ChangeValue.+O/uAp/HHsOQC6SU03wHtA.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.ChangeValue(System.Func<T,T>)'), [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](SemaphoreSlimValue_T_.ChangeValueAsync.vXre1BVfvx89XqTUMHZXaA.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)'),
for recursive reentrancy considerations. <i>(i.e. don't try it!)</i>

NB: If using a reference type for the underlying value, ensure your reference
type appropriately synchronizes access to its own data. In this case these
types only restrict access to the reference, not the data contained within
the reference type.

| Constructors | |
| :--- | :--- |
| [SemaphoreSlimValue(T)](SemaphoreSlimValue_T_..ctor.N38fnmqZw1bt1wOVUOFmOA.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.SemaphoreSlimValue(T)') | Constructs an instance of [SemaphoreSlimValue&lt;T&gt;](SemaphoreSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>') |

| Properties | |
| :--- | :--- |
| [Value](SemaphoreSlimValue_T_.Value.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.Value') | The value protected by the mutex. |

| Methods | |
| :--- | :--- |
| [ChangeValue(Func&lt;T,T&gt;)](SemaphoreSlimValue_T_.ChangeValue.+O/uAp/HHsOQC6SU03wHtA.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.ChangeValue(System.Func<T,T>)') | Calls the provided function, passing in the current value, and assigns the result of the function call, to the current value. <b>This is not recursively reentrant. see remarks for details.</b> |
| [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](SemaphoreSlimValue_T_.ChangeValueAsync.vXre1BVfvx89XqTUMHZXaA.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)') | Calls the provided function, passing in the current value, and assigns the result of the function call, to the current value. <b>This is not recursively reentrant. see remarks for details.</b> |
| [GetValue()](SemaphoreSlimValue_T_.GetValue().md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.GetValue()') | Retrieves the current value. If another thread edits the value, moment later a subsequent call will yield a different result. |
| [GetValueAsync()](SemaphoreSlimValue_T_.GetValueAsync().md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.GetValueAsync()') | Gets the value in an async friendly manner. |
| [SetValue(T)](SemaphoreSlimValue_T_.SetValue.8ZbnCyUkHFAjvECVE8T60w.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.SetValue(T)') | Sets the current value to the provided value. |
| [SetValueAsync(T)](SemaphoreSlimValue_T_.SetValueAsync.Z8ZW1vYt6Keb6VkgluLFfA.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.SetValueAsync(T)') | Sets the current value to the provided value. |
