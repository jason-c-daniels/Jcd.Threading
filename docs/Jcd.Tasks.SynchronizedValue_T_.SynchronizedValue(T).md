### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>')

## SynchronizedValue(T) Constructor

Provides a simple async-safe and thread-safe method of setting, getting, acting on,  
and altering values shared among tasks and threads.

```csharp
public SynchronizedValue(T val=default(T));
```
#### Parameters

<a name='Jcd.Tasks.SynchronizedValue_T_.SynchronizedValue(T).val'></a>

`val` [T](Jcd.Tasks.SynchronizedValue_T_.md#Jcd.Tasks.SynchronizedValue_T_.T 'Jcd.Tasks.SynchronizedValue<T>.T')

The value to initialize this to

### Remarks
  
While this provides a method of easily ensuring any one shared value is appropriately  
locked during setting or getting, you still need to thoroughly understand your  
use case. For example, having two [SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>') instances accessed  
by two different threads, in rapid succession, in different orders can cause  
potentially unexpected results.  
  
In cases where the pair/tuple must be consistent at all times across all accesses,  
consider creating a struct containing the necessary fields/properties and wrapping  
that in a [SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>') instead of each individual field/property.  
  
As well this implementation uses [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') and requires Dispose to be  
called. Either implement [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') or call it directly at the appropriate  
time. See the documentation for [ChangeValue(Func&lt;T,T&gt;)](Jcd.Tasks.SynchronizedValue_T_.ChangeValue(System.Func_T,T_).md 'Jcd.Tasks.SynchronizedValue<T>.ChangeValue(System.Func<T,T>)'), [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](Jcd.Tasks.SynchronizedValue_T_.ChangeValueAsync(System.Func_T,System.Threading.Tasks.Task_T__).md 'Jcd.Tasks.SynchronizedValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)'), [Do(Action&lt;T&gt;)](Jcd.Tasks.SynchronizedValue_T_.Do(System.Action_T_).md 'Jcd.Tasks.SynchronizedValue<T>.Do(System.Action<T>)'), and [DoAsync(Func&lt;T,Task&gt;)](Jcd.Tasks.SynchronizedValue_T_.DoAsync(System.Func_T,System.Threading.Tasks.Task_).md 'Jcd.Tasks.SynchronizedValue<T>.DoAsync(System.Func<T,System.Threading.Tasks.Task>)')  
for recursive reentrancy considerations. <i>(i.e. don't try it!)</i>