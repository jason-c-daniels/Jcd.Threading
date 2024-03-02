### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>')

## SynchronizedValue<T>.Value Property

Get or sets the synchronized value.

```csharp
public T Value { get; set; }
```

#### Property Value
[T](Jcd.Tasks.SynchronizedValue_T_.md#Jcd.Tasks.SynchronizedValue_T_.T 'Jcd.Tasks.SynchronizedValue<T>.T')

### Example
  
```csharp  
var sv = new SynchronizedValue<int>(15);  
  
// get the value  
var theValue = sv.Value;  
  
// set the value  
sv.Value = theValue + 10;  
```