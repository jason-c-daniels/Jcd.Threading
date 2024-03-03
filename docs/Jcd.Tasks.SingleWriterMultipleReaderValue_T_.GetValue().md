### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SingleWriterMultipleReaderValue&lt;T&gt;](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>')

## SingleWriterMultipleReaderValue<T>.GetValue() Method

Retrieves the current value. If another thread edits the value, moment later a subsequent  
call will yield a different result.

```csharp
public T GetValue();
```

#### Returns
[T](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md#Jcd.Tasks.SingleWriterMultipleReaderValue_T_.T 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.T')  
The current value as of establishing the lock.

### Example
  
```csharp  
var sv = new SynchronizedValue<int>(15);  
  
// get the value  
setValue = sv.GetValue(20);  
```