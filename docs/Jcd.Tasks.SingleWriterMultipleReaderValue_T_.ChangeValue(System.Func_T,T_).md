### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SingleWriterMultipleReaderValue&lt;T&gt;](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>')

## SingleWriterMultipleReaderValue<T>.ChangeValue(Func<T,T>) Method

Calls the provided function, passing in the current value, and assigns the result  
of the function call, to the current value. <b>This is not recursively reentrant.  
see remarks for details.</b>

```csharp
public T ChangeValue(System.Func<T,T>? func);
```
#### Parameters

<a name='Jcd.Tasks.SingleWriterMultipleReaderValue_T_.ChangeValue(System.Func_T,T_).func'></a>

`func` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md#Jcd.Tasks.SingleWriterMultipleReaderValue_T_.T 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md#Jcd.Tasks.SingleWriterMultipleReaderValue_T_.T 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

A function to call which receives the current value, modifies it, and returns the  
modified result.

#### Returns
[T](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md#Jcd.Tasks.SingleWriterMultipleReaderValue_T_.T 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.T')  
The modified value.

### Example
Standard usage: pass in a function to manipulate the current value.  
  
```csharp  
var sv = new SynchronizedValue<int>();  
  
// increment the value by one.  
var changedValue = sv.Do(x => x + 1);  
  
// increment the value by two.  
changedValue = sv.Do(x => x + 2);  
```

### Remarks
  
<b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like  
             the following.  
  
```csharp  
var sv=new SynchronizedValue<int>(10);  
  
// deadlock yourself in a single line of code!  
var changedValue = sv.Do(x=>sv.Value+10);  
```