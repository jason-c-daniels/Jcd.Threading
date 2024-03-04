### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TicketLockedValue&lt;T&gt;](Jcd.Tasks.TicketLockedValue_T_.md 'Jcd.Tasks.TicketLockedValue<T>')

## TicketLockedValue<T>.GetValue() Method

Retrieves the current value. If another thread edits the value, moment later a subsequent  
call will yield a different result.

```csharp
public T GetValue();
```

#### Returns
[T](Jcd.Tasks.TicketLockedValue_T_.md#Jcd.Tasks.TicketLockedValue_T_.T 'Jcd.Tasks.TicketLockedValue<T>.T')  
The current value as of establishing the lock.

### Example
  
```csharp  
var sv = new SingleWriterMultipleReaderValue<int>(15);  
  
// get the value  
setValue = swmr.GetValue(20);  
```