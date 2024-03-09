#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock')

## SpinLockResourceLock(SpinLock) Constructor

Creates an instance of [SpinLockResourceLock](SpinLockResourceLock.md 'Jcd.Threading.SpinLockResourceLock') bound to a specific [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock')

```csharp
public SpinLockResourceLock(ref System.Threading.SpinLock internalLock);
```
#### Parameters

<a name='Jcd.Threading.SpinLockResourceLock.SpinLockResourceLock(System.Threading.SpinLock).internalLock'></a>

`internalLock` [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock')

The [System.Threading.SpinLock](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SpinLock 'System.Threading.SpinLock') to bind to.