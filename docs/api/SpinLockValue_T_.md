#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues')

## SpinLockValue<T> Class

Provides a generic mechanism for setting, getting, acting on, and altering values  
shared among tasks and threads, utilizing a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') for synchronization.

```csharp
public class SpinLockValue<T>
```
#### Type parameters

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T'></a>

`T`

The data type to synchronize access to.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SpinLockValue<T>

### Remarks
  
While this provides a method of easily ensuring any one shared value is appropriately  
locked during setting or getting, you still need to thoroughly understand your  
use case. For example, having two [SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>') instances accessed  
by two different threads, in rapid succession, in different orders can cause  
potentially unexpected results.  
  
In cases where the pair/tuple must be consistent at all times across all accesses,  
consider creating a struct containing the necessary fields/properties and wrapping  
that in a [SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>') instead of each individual field/property.  
  
As well this implementation uses [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') and requires `Dispose` to be  
called. Either implement [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') or call it directly at the appropriate  
time. See the documentation for [ChangeValue(Func&lt;T,T&gt;)](SpinLockValue_T_.ChangeValue.fzSMSgQRRnf+ac/joKOCjw.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.ChangeValue(System.Func<T,T>)'), [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](SpinLockValue_T_.ChangeValueAsync.+dJENL57TL4Y0b8UwkPs+Q.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)'),  
for recursive reentrancy considerations. <i>(i.e. don't try it!)</i>  
  
NB: If using a reference type for the underlying value, ensure your reference  
type appropriately synchronizes access to its own data. In this case these  
types only restrict access to the reference, not the data contained within  
the reference type.

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
