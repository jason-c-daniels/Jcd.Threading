#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[TicketLockValue&lt;T&gt;](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>')

## TicketLockValue<T>.SetValue(T) Method

Sets the current value to the provided value.

```csharp
public T SetValue(T value);
```
#### Parameters

<a name='Jcd.Threading.SynchronizedValues.TicketLockValue_T_.SetValue(T).value'></a>

`value` [T](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.md#Jcd.Threading.SynchronizedValues.TicketLockValue_T_.T 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.T')

The provided value.

#### Returns
[T](Jcd.Threading.SynchronizedValues.TicketLockValue_T_.md#Jcd.Threading.SynchronizedValues.TicketLockValue_T_.T 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.T')  
The provided value.

### Example
  
```csharp  
var sv = new TicketLockValue<int>();  
  
// set the value to 10.  
setValue = swmr.SetValue(10);  
  
// set the value to 20.  
setValue = swmr.SetValue(20);  
```