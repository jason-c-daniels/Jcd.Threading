#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ThreadWrapper](Jcd.Threading.ThreadWrapper.md 'Jcd.Threading.ThreadWrapper')

## ThreadWrapper.PerformWork(CancellationToken) Method

Performs a single unit of work. Implement in derived types not overriding ThreadProc.

```csharp
protected virtual bool PerformWork(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.ThreadWrapper.PerformWork(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

the token cancellation token to use

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if meaningful work was done. False if the it should transition to idle  
after this call.