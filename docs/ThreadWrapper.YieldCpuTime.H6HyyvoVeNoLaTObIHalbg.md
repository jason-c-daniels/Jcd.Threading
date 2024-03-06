#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper')

## ThreadWrapper.YieldCpuTime(int) Method

Yields very small amounts of CPU time. This can approach 1ms.  
Thread.Sleep and Task.Delay will wait at least 15ms.

```csharp
protected void YieldCpuTime(int timeToYieldInMilliseconds);
```
#### Parameters

<a name='Jcd.Threading.ThreadWrapper.YieldCpuTime(int).timeToYieldInMilliseconds'></a>

`timeToYieldInMilliseconds` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The amount of time to wait, in milliseconds.