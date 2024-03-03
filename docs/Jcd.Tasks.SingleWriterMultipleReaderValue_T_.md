### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## SingleWriterMultipleReaderValue<T> Class

A value wrapper for a [System.Threading.ManualResetEventSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ManualResetEventSlim 'System.Threading.ManualResetEventSlim') to block read access while  
the sole owning thread is updating the value. Otherwise reads are not blocked.

```csharp
public sealed class SingleWriterMultipleReaderValue<T> :
System.IDisposable
```
#### Type parameters

<a name='Jcd.Tasks.SingleWriterMultipleReaderValue_T_.T'></a>

`T`

The data type to synchronize access to.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SingleWriterMultipleReaderValue<T>

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

### Remarks
It is the consumers responsibility to use this class as intended.  
Multiple writes are not blocked. Unpredictable behavior may result if multiple  
threads set the value at the same time.

| Properties | |
| :--- | :--- |
| [Value](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.Value.md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.Value') | Get or sets the synchronized value. |

| Methods | |
| :--- | :--- |
| [ChangeValue(Func&lt;T,T&gt;)](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.ChangeValue(System.Func_T,T_).md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.ChangeValue(System.Func<T,T>)') | Calls the provided function, passing in the current value, and assigns the result<br/>of the function call, to the current value. <b>This is not recursively reentrant.<br/>see remarks for details.</b> |
| [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.ChangeValueAsync(System.Func_T,System.Threading.Tasks.Task_T__).md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)') | Calls the provided function, passing in the current value, and assigns the result<br/>of the function call, to the current value. <b>This is not recursively reentrant.<br/>see remarks for details.</b> |
| [GetValue()](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.GetValue().md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.GetValue()') | Retrieves the current value. If another thread edits the value, moment later a subsequent<br/>call will yield a different result. |
| [GetValueAsync()](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.GetValueAsync().md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.GetValueAsync()') | Gets the value in an async friendly manner. |
| [SetValue(T)](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.SetValue(T).md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.SetValue(T)') | Sets the current value to the provided value. |
| [SetValueAsync(T)](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.SetValueAsync(T).md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.SetValueAsync(T)') | Sets the current value to the provided value. |
