#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper')

## ThreadWrapper.IdleWait(CancellationToken) Method

Wait in idle state, if the IsIdle flag is set.

```csharp
protected bool IdleWait(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.ThreadWrapper.IdleWait(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

the token to observe for cancellation.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
true if we waited in the idle state.