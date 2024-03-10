#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock')

## SemaphoreSlimResourceLock(SemaphoreSlim) Constructor

Provides a single-use mechanism for establishing and releasing locks on a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim').

```csharp
public SemaphoreSlimResourceLock(System.Threading.SemaphoreSlim internalLock);
```
#### Parameters

<a name='Jcd.Threading.SemaphoreSlimResourceLock.SemaphoreSlimResourceLock(System.Threading.SemaphoreSlim).internalLock'></a>

`internalLock` [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

The [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') to lock and release.

### Remarks

Do not share instances of this type across threads or synchronization contexts.
Behavior can be unpredictable. This exists to be used in conjunction
with the .Lock extension method for [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') and
advanced use cases.