#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[SpinLockValue&lt;T&gt;](SpinLockValue_T_.md 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>')

## SpinLockValue<T>.ChangeValue(Func<T,T>) Method

Calls the provided function, passing in the current value, and assigns the result
of the function call, to the current value. <b>This is not recursively reentrant.

see remarks for details.</b>

```csharp
public T ChangeValue(System.Func<T,T>? func);
```
#### Parameters

<a name='Jcd.Threading.SynchronizedValues.SpinLockValue_T_.ChangeValue(System.Func_T,T_).func'></a>

`func` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

A function to call which receives the current value, modifies it, and returns the
modified result.

#### Returns
[T](SpinLockValue_T_.md#Jcd.Threading.SynchronizedValues.SpinLockValue_T_.T 'Jcd.Threading.SynchronizedValues.SpinLockValue<T>.T')
The modified value.

### Example
Standard usage: pass in a function to manipulate the current value.

```csharp
var sv = new SpinLockValue<int>();

// increment the value by one.
var changedValue = sv.ChangeValue(x => x + 1);

// increment the value by two.
changedValue = sv.ChangeValue(x => x + 2);
```

### Remarks

<b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like
             the following.

```csharp
var sv=new SpinLockValue<int>(10);

// deadlock yourself in a single line of code!
var changedValue = sv.ChangeValue(x=>sv.Value+10);
```