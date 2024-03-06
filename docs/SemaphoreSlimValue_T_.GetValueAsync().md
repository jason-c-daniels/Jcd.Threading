#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[SemaphoreSlimValue&lt;T&gt;](SemaphoreSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>')

## SemaphoreSlimValue<T>.GetValueAsync() Method

Gets the value in an async friendly manner.

```csharp
public System.Threading.Tasks.Task<T> GetValueAsync();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](SemaphoreSlimValue_T_.md#Jcd.Threading.SynchronizedValues.SemaphoreSlimValue_T_.T 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') containing the retrieved value.

### Example
  
```csharp  
var sv = new SemaphoreSlimValue<int>(15);  
  
// get the value  
await setValue = swmr.GetValueAsync(20);  
```