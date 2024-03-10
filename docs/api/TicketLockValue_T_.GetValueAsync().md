#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[TicketLockValue&lt;T&gt;](TicketLockValue_T_.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>')

## TicketLockValue<T>.GetValueAsync() Method

Gets the value in an async friendly manner.

```csharp
public System.Threading.Tasks.Task<T> GetValueAsync();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](TicketLockValue_T_.md#Jcd.Threading.SynchronizedValues.TicketLockValue_T_.T 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') containing the retrieved value.

### Example
  
```csharp  
var sv = new TicketLockedValue<int>(15);  
  
// get the value  
var result = await sv.GetValueAsync(20);  
```