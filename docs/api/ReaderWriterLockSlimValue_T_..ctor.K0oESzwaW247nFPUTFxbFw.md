#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.SynchronizedValues](Jcd.Threading.SynchronizedValues.md 'Jcd.Threading.SynchronizedValues').[ReaderWriterLockSlimValue&lt;T&gt;](ReaderWriterLockSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>')

## ReaderWriterLockSlimValue(T) Constructor

Provides a generic mechanism for setting, getting, acting on, and altering values  
shared among tasks and threads, utilizing a [System.Threading.ReaderWriterLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLock 'System.Threading.ReaderWriterLock') for synchronization.

```csharp
public ReaderWriterLockSlimValue(T val=default(T));
```
#### Parameters

<a name='Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue_T_.ReaderWriterLockSlimValue(T).val'></a>

`val` [T](ReaderWriterLockSlimValue_T_.md#Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue_T_.T 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.T')

The value to initialize this to

### Remarks
  
While this provides a method of easily ensuring any one shared value is appropriately  
locked during setting or getting, you still need to thoroughly understand your  
use case. For example, having two [ReaderWriterLockSlimValue&lt;T&gt;](ReaderWriterLockSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>') instances accessed  
by two different threads, in rapid succession, in different orders can cause  
potentially unexpected results.  
  
In cases where the pair/tuple must be consistent at all times across all accesses,  
consider creating a struct containing the necessary fields/properties and wrapping  
that in a [ReaderWriterLockSlimValue&lt;T&gt;](ReaderWriterLockSlimValue_T_.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>') instead of each individual field/property.  
  
As well this implementation uses [System.Threading.ReaderWriterLockSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ReaderWriterLockSlim 'System.Threading.ReaderWriterLockSlim') and requires `Dispose` to be  
called. Either implement [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') or call it directly at the appropriate  
time. See the documentation for [ChangeValue(Func&lt;T,T&gt;)](ReaderWriterLockSlimValue_T_.ChangeValue.z+hpMSz/sZfSMoED9mE7Iw.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.ChangeValue(System.Func<T,T>)'), [ChangeValueAsync(Func&lt;T,Task&lt;T&gt;&gt;)](ReaderWriterLockSlimValue_T_.ChangeValueAsync.suSdbC1rwhPx9+9ijiN7xA.md 'Jcd.Threading.SynchronizedValues.ReaderWriterLockSlimValue<T>.ChangeValueAsync(System.Func<T,System.Threading.Tasks.Task<T>>)'),  
for recursive reentrancy considerations. <i>(i.e. don't try it!)</i>  
  
NB: If using a reference type for the underlying value, ensure your reference  
type appropriately synchronizes access to its own data. In this case these  
types only restrict access to the reference, not the data contained within  
the reference type.