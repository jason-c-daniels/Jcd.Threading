### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## SynchronizedValue<T> Class

Provides a simple async-safe method of setting, getting, and altering values intended to be shared among tasks and threads.

```csharp
public class SynchronizedValue<T> :
System.IDisposable
```
#### Type parameters

<a name='Jcd.Tasks.SynchronizedValue_T_.T'></a>

`T`

The data type to synchronize access to.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SynchronizedValue<T>

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

### Remarks
  
While this provides a method of easily ensuring any one shared value is appropriately  
locked during setting or getting, you still need to thoroughly understand your  
use case. For example, having two [SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>') instances accessed  
by two different threads, in rapid succession, in different orders can cause  
potentially unexpected results.  
  
In cases where the pair/tuple must be consistent at all times across all threads,  
consider creating a struct containing the necessary fields/properties and wrapping that  
in a SynchronizedValue instead of each individual field/property.  
  
As well this implementation uses [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') and requires Dispose to be called.  
Either implement [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') or call it directly at the appropriate time.

| Constructors | |
| :--- | :--- |
| [SynchronizedValue(T)](Jcd.Tasks.SynchronizedValue_T_.SynchronizedValue(T).md 'Jcd.Tasks.SynchronizedValue<T>.SynchronizedValue(T)') | Constructs an [SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>') instance. |

| Properties | |
| :--- | :--- |
| [Value](Jcd.Tasks.SynchronizedValue_T_.Value.md 'Jcd.Tasks.SynchronizedValue<T>.Value') | The synchronized value. |

| Methods | |
| :--- | :--- |
| [ChangeValue(Func&lt;T,T&gt;)](Jcd.Tasks.SynchronizedValue_T_.ChangeValue(System.Func_T,T_).md 'Jcd.Tasks.SynchronizedValue<T>.ChangeValue(System.Func<T,T>)') | Calls the provided function, passing in the current value, and assigns the result of the<br/>function call, to the current value. |
| [ChangeValueAsync(Func&lt;T,T&gt;)](Jcd.Tasks.SynchronizedValue_T_.ChangeValueAsync(System.Func_T,T_).md 'Jcd.Tasks.SynchronizedValue<T>.ChangeValueAsync(System.Func<T,T>)') | Calls the provided function, passing in the current value, and assigns the result of the<br/>function call, to the current value. |
| [GetValue()](Jcd.Tasks.SynchronizedValue_T_.GetValue().md 'Jcd.Tasks.SynchronizedValue<T>.GetValue()') | Retrieves the current value. If another thread edits the value, moment later a subsequent<br/>call will yield a different result. |
| [GetValueAsync()](Jcd.Tasks.SynchronizedValue_T_.GetValueAsync().md 'Jcd.Tasks.SynchronizedValue<T>.GetValueAsync()') | Gets the value in an async friendly manner. |
| [SetValue(T)](Jcd.Tasks.SynchronizedValue_T_.SetValue(T).md 'Jcd.Tasks.SynchronizedValue<T>.SetValue(T)') | Sets the current value to the provided value. |
| [SetValueAsync(T)](Jcd.Tasks.SynchronizedValue_T_.SetValueAsync(T).md 'Jcd.Tasks.SynchronizedValue<T>.SetValueAsync(T)') | Sets the current value to the provided value. |
