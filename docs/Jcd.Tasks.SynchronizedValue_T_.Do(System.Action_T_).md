#### [Jcd.Tasks](index.md 'index')
### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>')

## SynchronizedValue<T>.Do(Action<T>) Method

Executes an action on the synchronized value after locking it.  
<b>This is not recursively reentrant. See remarks for details.</b>

```csharp
public void Do(System.Action<T>? action);
```
#### Parameters

<a name='Jcd.Tasks.SynchronizedValue_T_.Do(System.Action_T_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](Jcd.Tasks.SynchronizedValue_T_.md#Jcd.Tasks.SynchronizedValue_T_.T 'Jcd.Tasks.SynchronizedValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The function to call.

### Example
Standard usage: pass in an asynchronous action to action the current value.  
  
```csharp  
var sv = new SynchronizedValue<int>();  
  
// increment the value by one and discard the result.  
sv.Do(x => x + 1);  
  
// increment the value by two and discard the result.  
sv.Do(x => x + 2);  
  
// Perform some other operation that requires the value to  
remain unchanged during the operation.  
sv.Do(x => DoSomething(x));  
```

### Remarks
  
<b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like  
             the following.  
  
```csharp  
var sv=new SynchronizedValue<int>(10);  
  
// deadlock yourself in a single line of code!  
sv.Do(x=>sv.Value+10);  
```