### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SingleWriterMultipleReaderValue&lt;T&gt;](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>')

## SingleWriterMultipleReaderValue<T>.Value Property

Get or sets the synchronized value.

```csharp
public T Value { get; set; }
```

#### Property Value
[T](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md#Jcd.Tasks.SingleWriterMultipleReaderValue_T_.T 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.T')

### Example
  
```csharp  
var sv = new SynchronizedValue<int>(15);  
  
// get the value  
var theValue = sv.Value;  
  
// set the value  
sv.Value = theValue + 10;  
```