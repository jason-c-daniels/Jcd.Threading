#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>')

## SpinLockValue<T>.SetValueAsync(T) Method

Sets the current value to the provided value.

```csharp
public System.Threading.Tasks.Task<T> SetValueAsync(T value);
```
#### Parameters

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.SetValueAsync(T).value'></a>

`value` [T](SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')

The provided value.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') containing the provided value.

### Example

```csharp
var sv = new SpinLockValue<int>();

// set the value to 10.
var result = await sv.SetValueAsync(10);

// set the value to 20.
result = await sv.SetValueAsync(20);
```