### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TicketLockedValue&lt;T&gt;](Jcd.Tasks.TicketLockedValue_T_.md 'Jcd.Tasks.TicketLockedValue<T>')

## TicketLockedValue<T>.SetValue(T) Method

Sets the current value to the provided value.

```csharp
public T SetValue(T value);
```
#### Parameters

<a name='Jcd.Tasks.TicketLockedValue_T_.SetValue(T).value'></a>

`value` [T](Jcd.Tasks.TicketLockedValue_T_.md#Jcd.Tasks.TicketLockedValue_T_.T 'Jcd.Tasks.TicketLockedValue<T>.T')

The provided value.

#### Returns
[T](Jcd.Tasks.TicketLockedValue_T_.md#Jcd.Tasks.TicketLockedValue_T_.T 'Jcd.Tasks.TicketLockedValue<T>.T')  
The provided value.

### Example
  
```csharp  
var sv = new SingleWriterMultipleReaderValue<int>();  
  
// set the value to 10.  
setValue = swmr.SetValue(10);  
  
// set the value to 20.  
setValue = swmr.SetValue(20);  
```