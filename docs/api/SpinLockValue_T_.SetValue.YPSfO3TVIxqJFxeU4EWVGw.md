#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>')

## SpinLockValue<T>.SetValue(T) Method

Sets the current value to the provided value.

```csharp
public T SetValue(T value);
```
#### Parameters

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.SetValue(T).value'></a>

`value` [T](SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')

The provided value.

#### Returns
[T](SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')
The provided value.

### Example

```csharp
var sv = new SpinLockValue<int>();

// set the value to 10.
var result = sv.SetValue(10);

// set the value to 20.
setValue = sv.SetValue(20);
```