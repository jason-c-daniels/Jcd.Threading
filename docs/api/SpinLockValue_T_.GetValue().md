#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>')

## SpinLockValue<T>.GetValue() Method

Retrieves the current value. If another thread edits the value, moment later a subsequent  
call will yield a different result.

```csharp
public T GetValue();
```

#### Returns
[T](SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')  
The current value as of establishing the lock.

### Example
  
```csharp  
var sv = new SpinLockValue<int>(15);  
  
// get the value  
setValue = sv.GetValue(20);  
```