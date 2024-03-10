#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper')

## ThreadWrapper.GetShouldContinue(CancellationToken) Method

Determines if the main thread loop should continue looping.

```csharp
protected virtual bool GetShouldContinue(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Jcd.Threading.ThreadWrapper.GetShouldContinue(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

the token to check for cancellation

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the main thread loop should continue.