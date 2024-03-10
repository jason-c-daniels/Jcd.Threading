#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper')

## ThreadWrapper.ThreadProc() Method

The main thread control loop.

```csharp
protected virtual void ThreadProc();
```

### Remarks
  
You should only override this for advanced use cases.  
Override `GetShouldContinue` for determining when the thread ends.  
Override `PerformWork` to do a single unit of work on each pass through the loop.  
  
If you choose to override this and supply your own main loop for the thread,  
You will need to check for cancellation, Call `IdleWait` and `PauseWait`  
at the appropriate time in your loop, as well as `YieldCpuTime` to ensure  
your thread doesn't monopolize the CPU.  
use cases.