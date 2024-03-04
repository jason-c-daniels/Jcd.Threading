### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[MutexValue&lt;T&gt;](Jcd.Tasks.MutexValue_T_.md 'Jcd.Tasks.MutexValue<T>')

## MutexValue<T>.GetValue() Method

Retrieves the current value. If another thread edits the value, moment later a subsequent  
call will yield a different result.

```csharp
public T GetValue();
```

#### Returns
[T](Jcd.Tasks.MutexValue_T_.md#Jcd.Tasks.MutexValue_T_.T 'Jcd.Tasks.MutexValue<T>.T')  
The current value as of establishing the lock.

### Example
  
```csharp  
var sv = new SingleWriterMultipleReaderValue<int>(15);  
  
// get the value  
setValue = swmr.GetValue(20);  
```