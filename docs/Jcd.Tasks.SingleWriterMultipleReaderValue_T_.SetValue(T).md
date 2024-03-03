### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SingleWriterMultipleReaderValue&lt;T&gt;](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>')

## SingleWriterMultipleReaderValue<T>.SetValue(T) Method

Sets the current value to the provided value.

```csharp
public T SetValue(T value);
```
#### Parameters

<a name='Jcd.Tasks.SingleWriterMultipleReaderValue_T_.SetValue(T).value'></a>

`value` [T](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md#Jcd.Tasks.SingleWriterMultipleReaderValue_T_.T 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.T')

The provided value.

#### Returns
[T](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md#Jcd.Tasks.SingleWriterMultipleReaderValue_T_.T 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.T')  
The provided value.

### Example
  
```csharp  
var sv = new SynchronizedValue<int>();  
  
// set the value to 10.  
setValue = sv.SetValue(10);  
  
// set the value to 20.  
setValue = sv.SetValue(20);  
```