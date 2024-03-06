#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[SemaphoreSlimValue&lt;T&gt;](SemaphoreSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>')

## SemaphoreSlimValue<T>.SetValue(T) Method

Sets the current value to the provided value.

```csharp
public T SetValue(T value);
```
#### Parameters

<a name='Jcd.Threading.SynchronizedValues.SemaphoreSlimValue_T_.SetValue(T).value'></a>

`value` [T](SemaphoreSlimValue_T_.md#Jcd.Threading.SynchronizedValues.SemaphoreSlimValue_T_.T 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.T')

The provided value.

#### Returns
[T](SemaphoreSlimValue_T_.md#Jcd.Threading.SynchronizedValues.SemaphoreSlimValue_T_.T 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.T')  
The provided value.

### Example
  
```csharp  
var sv = new SemaphoreSlimValue<int>();  
  
// set the value to 10.  
setValue = swmr.SetValue(10);  
  
// set the value to 20.  
setValue = swmr.SetValue(20);  
```