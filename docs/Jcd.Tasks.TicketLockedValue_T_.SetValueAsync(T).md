### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TicketLockedValue&lt;T&gt;](Jcd.Tasks.TicketLockedValue_T_.md 'Jcd.Tasks.TicketLockedValue<T>')

## TicketLockedValue<T>.SetValueAsync(T) Method

Sets the current value to the provided value.

```csharp
public System.Threading.Tasks.Task<T> SetValueAsync(T value);
```
#### Parameters

<a name='Jcd.Tasks.TicketLockedValue_T_.SetValueAsync(T).value'></a>

`value` [T](Jcd.Tasks.TicketLockedValue_T_.md#Jcd.Tasks.TicketLockedValue_T_.T 'Jcd.Tasks.TicketLockedValue<T>.T')

The provided value.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Tasks.TicketLockedValue_T_.md#Jcd.Tasks.TicketLockedValue_T_.T 'Jcd.Tasks.TicketLockedValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') containing the provided value.

### Example
  
```csharp  
var sv = new SingleWriterMultipleReaderValue<int>();  
  
// set the value to 10.  
await setValue = swmr.SetValueAsync(10);  
  
// set the value to 20.  
await setValue = swmr.SetValueAsync(20);  
```