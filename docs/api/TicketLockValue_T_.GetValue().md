#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[TicketLockValue&lt;T&gt;](TicketLockValue_T_.md 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>')

## TicketLockValue<T>.GetValue() Method

Retrieves the current value. If another thread edits the value, moment later a subsequent
call will yield a different result.

```csharp
public T GetValue();
```

#### Returns
[T](TicketLockValue_T_.md#Jcd.Threading.SynchronizedValues.TicketLockValue_T_.T 'Jcd.Threading.SynchronizedValues.TicketLockValue<T>.T')
The current value as of establishing the lock.

### Example

```csharp
var sv = new TicketLockedValue<int>(15);

// get the value
setValue = sv.GetValue(20);
```