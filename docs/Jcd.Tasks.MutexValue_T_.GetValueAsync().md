### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[MutexValue&lt;T&gt;](Jcd.Tasks.MutexValue_T_.md 'Jcd.Tasks.MutexValue<T>')

## MutexValue<T>.GetValueAsync() Method

Gets the value in an async friendly manner.

```csharp
public System.Threading.Tasks.Task<T> GetValueAsync();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Tasks.MutexValue_T_.md#Jcd.Tasks.MutexValue_T_.T 'Jcd.Tasks.MutexValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') containing the retrieved value.

### Example
  
```csharp  
var sv = new SingleWriterMultipleReaderValue<int>(15);  
  
// get the value  
await setValue = swmr.GetValueAsync(20);  
```