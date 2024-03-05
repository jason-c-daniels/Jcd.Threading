#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[SpinLockValue&lt;T&gt;](Jcd.Threading.SynchronizedValues.SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>')

## SpinLockValue<T>.ChangeValueAsync(Func<T,Task<T>>) Method

Calls the provided function, passing in the current value, and assigns the result  
of the function call, to the current value. <b>This is not recursively reentrant.  
see remarks for details.</b>

```csharp
public System.Threading.Tasks.Task<T> ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>? func);
```
#### Parameters

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.ChangeValueAsync(System.Func_T,System.Threading.Tasks.Task_T__).func'></a>

`func` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](Jcd.Threading.SynchronizedValues.SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Threading.SynchronizedValues.SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The function to call.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](Jcd.Threading.SynchronizedValues.SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A [System.Threading.Tasks.Task&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1') containing the modified value.

### Example
Standard usage: pass in a function to manipulate the current value.  
  
```csharp  
var sv = new SpinLockValue<int>();  
  
// increment the value by one.  
var changedValue = await sv.ChangeValueAsync(x => x + 1);  
  
// increment the value by two.  
changedValue = await sv.ChangeValueAsync(x => x + 2);  
  
// Perform some operation that requires the value to remain unchanged during the operation.  
var sameValue = await sv.ChangeValueAsync(x => { DoSomething(x); return x;});  
```

### Remarks
  
<b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like  
             the following.  
  
```csharp  
var sv=new SpinLockValue<int>(10);  
  
// deadlock yourself in a single line of code!  
var changedValue = await sv.ChangeValueAsync(x=>sv.Value+10);  
```