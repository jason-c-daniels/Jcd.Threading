### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>')

## SynchronizedValue<T>.Value Property

Get the synchronized value.

```csharp
public T Value { get; }
```

#### Property Value
[T](Jcd.Tasks.SynchronizedValue_T_.md#Jcd.Tasks.SynchronizedValue_T_.T 'Jcd.Tasks.SynchronizedValue<T>.T')

### Example
  
```csharp  
var sv = new SimpleInterlockedValue<int>(15);  
  
// get the value  
setValue = sv.Value;  
```