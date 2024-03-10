#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[SemaphoreSlimExtensions](SemaphoreSlimExtensions.md 'Jcd.Threading.SemaphoreSlimExtensions')

## SemaphoreSlimExtensions.GetResourceLock(this SemaphoreSlim) Method

Gets a resource lock bound to the instance of a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

```csharp
public static Jcd.Threading.SemaphoreSlimResourceLock GetResourceLock(this System.Threading.SemaphoreSlim sem);
```
#### Parameters

<a name='Jcd.Threading.SemaphoreSlimExtensions.GetResourceLock(thisSystem.Threading.SemaphoreSlim).sem'></a>

`sem` [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')

The [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim') to create the resource lock for.

#### Returns
[SemaphoreSlimResourceLock](SemaphoreSlimResourceLock.md 'Jcd.Threading.SemaphoreSlimResourceLock')  
A resource lock bound to the instance of a [System.Threading.SemaphoreSlim](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.SemaphoreSlim 'System.Threading.SemaphoreSlim')