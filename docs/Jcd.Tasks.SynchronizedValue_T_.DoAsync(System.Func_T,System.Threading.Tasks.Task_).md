### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>')

## SynchronizedValue<T>.DoAsync(Func<T,Task>) Method

Executes an asynchronous action on the synchronized value after locking it.  
<b>This is not recursively reentrant. See remarks for details.</b>

```csharp
public System.Threading.Tasks.Task DoAsync(System.Func<T,System.Threading.Tasks.Task> asyncAction);
```
#### Parameters

<a name='Jcd.Tasks.SynchronizedValue_T_.DoAsync(System.Func_T,System.Threading.Tasks.Task_).asyncAction'></a>

`asyncAction` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](Jcd.Tasks.SynchronizedValue_T_.md#Jcd.Tasks.SynchronizedValue_T_.T 'Jcd.Tasks.SynchronizedValue<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The function to call.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
A [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') for the action.

### Example
Standard usage: pass in an asynchronous action to action the current value.  
  
```csharp  
var sv = new SynchronizedValue<int>();  
  
// increment the value by one and discard the result.  
var changedValue = await sv.DoAsync(x => x + 1);  
  
// increment the value by two and discard the result.  
await sv.DoAsync(x => x + 2);  
  
// Perform some other operation that requires the value to  
remain unchanged during the operation.  
await sv.DoAsync(x => DoSomething(x));  
```

### Remarks
  
<b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like  
             the following.  
  
```csharp  
var sv=new SynchronizedValue<int>(10);  
  
// deadlock yourself in a single line of code!  
await sv.DoAsync(x=>sv.Value+10);  
```