### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SpinLockedValue&lt;T&gt;](Jcd.Tasks.SpinLockedValue_T_.md 'Jcd.Tasks.SpinLockedValue<T>')

## SpinLockedValue(T, bool) Constructor

Creates an instance of a [SpinLockedValue&lt;T&gt;](Jcd.Tasks.SpinLockedValue_T_.md 'Jcd.Tasks.SpinLockedValue<T>')

```csharp
public SpinLockedValue(T initialValue=default(T), bool useMemoryBarrier=false);
```
#### Parameters

<a name='Jcd.Tasks.SpinLockedValue_T_.SpinLockedValue(T,bool).initialValue'></a>

`initialValue` [T](Jcd.Tasks.SpinLockedValue_T_.md#Jcd.Tasks.SpinLockedValue_T_.T 'Jcd.Tasks.SpinLockedValue<T>.T')

The initial value

<a name='Jcd.Tasks.SpinLockedValue_T_.SpinLockedValue(T,bool).useMemoryBarrier'></a>

`useMemoryBarrier` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the call to Exit should use a memory barrier to notify other threads the lock has been freed(much slower!).