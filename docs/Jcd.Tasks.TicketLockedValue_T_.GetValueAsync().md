### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[TicketLockedValue&lt;T&gt;](Jcd.Tasks.TicketLockedValue_T_.md 'Jcd.Tasks.TicketLockedValue<T>')

## TicketLockedValue<T>.GetValueAsync() Method

Gets the value in an async friendly manner.

```csharp
public System.Threading.Tasks.Task<T> GetValueAsync();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Tasks.TicketLockedValue_T_.md#Jcd.Tasks.TicketLockedValue_T_.T 'Jcd.Tasks.TicketLockedValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') containing the retrieved value.

### Example
  
```csharp  
var sv = new SingleWriterMultipleReaderValue<int>(15);  
  
// get the value  
await setValue = swmr.GetValueAsync(20);  
```