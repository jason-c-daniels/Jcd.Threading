### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SingleWriterMultipleReaderValue&lt;T&gt;](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>')

## SingleWriterMultipleReaderValue<T>.GetValueAsync() Method

Gets the value in an async friendly manner.

```csharp
public System.Threading.Tasks.Task<T> GetValueAsync();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Tasks.SingleWriterMultipleReaderValue_T_.md#Jcd.Tasks.SingleWriterMultipleReaderValue_T_.T 'Jcd.Tasks.SingleWriterMultipleReaderValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') containing the retrieved value.

### Example
  
```csharp  
var sv = new SynchronizedValue<int>(15);  
  
// get the value  
await setValue = sv.GetValueAsync(20);  
```