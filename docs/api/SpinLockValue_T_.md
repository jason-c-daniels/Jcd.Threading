#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues')

## SpinLockValue<T> Class

Provides synchronization to an underlying value through a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock').

```csharp
public class SpinLockValue<T>
```
#### Type parameters

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T'></a>

`T`

The type of the data being stored.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SpinLockValue<T>

| Constructors | |
| :--- | :--- |
| [SpinLockValue(T, bool, bool)](SpinLockValue_T_..ctor.akII8HT8casqXbD47ae38A.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.SpinLockValue(T, bool, bool)') | Creates an instance of a [SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>') |

| Properties | |
| :--- | :--- |
| [Value](SpinLockValue_T_.Value.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.Value') | Sets or gets the value. This will block. |

| Methods | |
| :--- | :--- |
| [ChangeValue(Func&lt;T,T&gt;)](SpinLockValue_T_.ChangeValue.fzSMSgQRRnf+ac/joKOCjw.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.ChangeValue(System.Func<T,T>)') | Calls the provided function, passing in the current value, and assigns the result<br/>of the function call, to the current value. <b>This is not recursively reentrant.<br/>see remarks for details.</b> |
| [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](SpinLockValue_T_.ChangeValueAsync.+dJENL57TL4Y0b8UwkPs+Q.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)') | Calls the provided function, passing in the current value, and assigns the result<br/>of the function call, to the current value. <b>This is not recursively reentrant.<br/>see remarks for details.</b> |
| [GetValue()](SpinLockValue_T_.GetValue().md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.GetValue()') | Retrieves the current value. If another thread edits the value, moment later a subsequent<br/>call will yield a different result. |
| [GetValueAsync()](SpinLockValue_T_.GetValueAsync().md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.GetValueAsync()') | Gets the value in an async friendly manner. |
| [SetValue(T)](SpinLockValue_T_.SetValue.YPSfO3TVIxqJFxeU4EWVGw.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.SetValue(T)') | Sets the current value to the provided value. |
| [SetValueAsync(T)](SpinLockValue_T_.SetValueAsync.aDUjChUjyhjuWu1dcWDjlA.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.SetValueAsync(T)') | Sets the current value to the provided value. |
