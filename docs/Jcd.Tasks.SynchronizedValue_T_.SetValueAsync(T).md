### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>')

## SynchronizedValue<T>.SetValueAsync(T) Method

Sets the current value to the provided value.

```csharp
public System.Threading.Tasks.Task<T> SetValueAsync(T value);
```
#### Parameters

<a name='Jcd.Tasks.SynchronizedValue_T_.SetValueAsync(T).value'></a>

`value` [T](Jcd.Tasks.SynchronizedValue_T_.md#Jcd.Tasks.SynchronizedValue_T_.T 'Jcd.Tasks.SynchronizedValue<T>.T')

The provided value.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Tasks.SynchronizedValue_T_.md#Jcd.Tasks.SynchronizedValue_T_.T 'Jcd.Tasks.SynchronizedValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') containing the provided value.

### Example
  
```csharp  
var sv = new SynchronizedValue<int>();  
  
// set the value to 10.  
await setValue = sv.SetValueAsync(10);  
  
// set the value to 20.  
await setValue = sv.SetValueAsync(20);  
```