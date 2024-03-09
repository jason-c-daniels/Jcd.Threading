#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SpinLockExtensions](SpinLockExtensions.md 'Jcd.Threading.SpinLockExtensions')

## SpinLockExtensions.GetResourceLock(this SpinLock) Method

Gets a resource lock bound to the instance of a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock')

```csharp
public static Jcd.Threading.SpinLockResourceLock GetResourceLock(this ref System.Threading.SpinLock sem);
```
#### Parameters

<a name='Jcd.Threading.SpinLockExtensions.GetResourceLock(thisSystem.Threading.SpinLock).sem'></a>

`sem` [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock')

The [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') to create the resource lock for.

#### Returns
[SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock')  
A resource lock bound to the instance of a [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock')