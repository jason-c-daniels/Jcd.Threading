#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[ReaderWriterLockSlimValue&lt;T&gt;](ReaderWriterLockSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>')

## ReaderWriterLockSlimValue<T>.SetValue(T) Method

Sets the current value to the provided value.

```csharp
public T SetValue(T value);
```
#### Parameters

<a name='Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue_T_.SetValue(T).value'></a>

`value` [T](ReaderWriterLockSlimValue_T_.md#Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue_T_.T 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.T')

The provided value.

#### Returns
[T](ReaderWriterLockSlimValue_T_.md#Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue_T_.T 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.T')  
The provided value.

### Example
  
```csharp  
var sv = new ReaderWriterLockSlimValue<int>();  
  
// set the value to 10.  
setValue = sv.SetValue(10);  
  
// set the value to 20.  
setValue = sv.SetValue(20);  
```