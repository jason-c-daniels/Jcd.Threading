#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock')

## SemaphoreSlimResourceLock(SemaphoreSlim) Constructor

Provides a mechanism for establishing and releasing locks on a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim').

```csharp
public SemaphoreSlimResourceLock(System.Threading.SemaphoreSlim internalLock);
```
#### Parameters

<a name='Jcd.Threading.SemaphoreSlimResourceLock.SemaphoreSlimResourceLock(System.Threading.SemaphoreSlim).internalLock'></a>

`internalLock` [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

The [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') to lock and release.

### Remarks
  
Do not share instances of this type across threads or synchronization contexts.  
Behavior can be unpredictable. These are provided and meant to be used in conjunction  
with the extension classes to create a more consistent experience when using  
synchronization primitives.