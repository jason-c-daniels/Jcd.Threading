#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[ReaderWriterLockSlimValue&lt;T&gt;](ReaderWriterLockSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>')

## ReaderWriterLockSlimValue<T>.Value Property

Get or sets the synchronized value.

```csharp
public T Value { get; set; }
```

#### Property Value
[T](ReaderWriterLockSlimValue_T_.md#Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue_T_.T 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.T')

### Example
  
```csharp  
var sv = new ReaderWriterLockSlimValue<int>(15);  
  
// get the value  
var theValue = sv.Value;  
  
// set the value  
sv.Value = theValue + 10;  
```