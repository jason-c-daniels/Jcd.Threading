#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[SemaphoreSlimValue&lt;T&gt;](SemaphoreSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>')

## SemaphoreSlimValue<T>.GetValue() Method

Retrieves the current value. If another thread edits the value, moment later a subsequent  
call will yield a different result.

```csharp
public T GetValue();
```

#### Returns
[T](SemaphoreSlimValue_T_.md#Jcd.Threading.SynchronizedValues.SemaphoreSlimValue_T_.T 'Jcd.Threading.SynchronizedValues.SemaphoreSlimValue<T>.T')  
The current value as of establishing the lock.

### Example
  
```csharp  
var sv = new SemaphoreSlimValue<int>(15);  
  
// get the value  
setValue = swmr.GetValue(20);  
```