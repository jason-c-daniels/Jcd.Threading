#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues')

## SpinLockValue<T> Class

Provides synchronization to an underlying value through a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock').

```csharp
internal class SpinLockValue<T>
```
#### Type parameters

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T'></a>

`T`

The type of the data being stored.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SpinLockValue<T>

| Constructors | |
| :--- | :--- |
| [SpinLockValue(T, bool)](SpinLockValue_T_..ctor.qpkrjfL/d0xwDTxUwb237w.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.SpinLockValue(T, bool)') | Creates an instance of a [SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>') |

| Properties | |
| :--- | :--- |
| [Value](SpinLockValue_T_.Value.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.Value') | Sets or gets the value. This will block. |

| Methods | |
| :--- | :--- |
| [ChangeValue(Func&lt;T,T&gt;)](SpinLockValue_T_.ChangeValue.fzSMSgQRRnf+ac/joKOCjw.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.ChangeValue(System.Func<T,T>)') | Calls the provided function, passing in the current value, and assigns the result<br/>of the function call, to the current value. <b>This is not recursively reentrant.<br/>see remarks for details.</b> |
| [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](SpinLockValue_T_.ChangeValueAsync.+dJENL57TL4Y0b8UwkPs+Q.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)') | Calls the provided function, passing in the current value, and assigns the result<br/>of the function call, to the current value. <b>This is not recursively reentrant.<br/>see remarks for details.</b> |
