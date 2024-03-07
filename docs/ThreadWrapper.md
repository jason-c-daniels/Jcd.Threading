#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading')

## ThreadWrapper Class

Provides basic thread management facilities such as Pause, Resume, Stop, Start and  
entering and exiting the idle state.

```csharp
public abstract class ThreadWrapper :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ThreadWrapper

Derived  
&#8627; [ItemProcessor&lt;TItem&gt;](ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>')

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

### Remarks
`Stop` will shutdown the underlying thread completely, and a subsequent call to Start will  
create a brand new thread (with associated cancellation token), while Pause and  
Resume will suspend the thread operations at the appropriate time in the main loop.

| Constructors | |
| :--- | :--- |
| [ThreadWrapper(bool, string, bool, bool, int, int, ThreadPriority, ApartmentState)](ThreadWrapper..ctor.P11YetUSK7Dh1ZnTbZWMNQ.md 'Jcd.Threading.ThreadWrapper.ThreadWrapper(bool, string, bool, bool, int, int, System.Threading.ThreadPriority, System.Threading.ApartmentState)') | Constructs a [ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper') |

| Properties | |
| :--- | :--- |
| [CancellationToken](ThreadWrapper.CancellationToken.md 'Jcd.Threading.ThreadWrapper.CancellationToken') | Gives derived types access to the [CancellationToken](ThreadWrapper.CancellationToken.md 'Jcd.Threading.ThreadWrapper.CancellationToken') |
| [IsIdle](ThreadWrapper.IsIdle.md 'Jcd.Threading.ThreadWrapper.IsIdle') | Gets a flag indicating if the item processing is currently paused. |
| [IsPaused](ThreadWrapper.IsPaused.md 'Jcd.Threading.ThreadWrapper.IsPaused') | Gets a flag indicating if the item processing is currently paused. |
| [IsStarted](ThreadWrapper.IsStarted.md 'Jcd.Threading.ThreadWrapper.IsStarted') | Gets a flag indicating if the item processing loop has started. |
| [Name](ThreadWrapper.Name.md 'Jcd.Threading.ThreadWrapper.Name') | The name of this instance of the [ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper').<br/>By default the underlying thread will be named as follows:<br/>`$"{Name}.Thread"` |
| [Thread](ThreadWrapper.Thread.md 'Jcd.Threading.ThreadWrapper.Thread') | Provides direct access to the underlying thread. |

| Methods | |
| :--- | :--- |
| [~ThreadWrapper()](ThreadWrapper.~ThreadWrapper().md 'Jcd.Threading.ThreadWrapper.~ThreadWrapper()') | finalizes the object. |
| [Dispose(bool)](ThreadWrapper.Dispose.07rvTSxJ7U5BNNbZhR87jQ.md 'Jcd.Threading.ThreadWrapper.Dispose(bool)') | Disposes of resources. |
| [EnterIdleState()](ThreadWrapper.EnterIdleState().md 'Jcd.Threading.ThreadWrapper.EnterIdleState()') | Sets the thread into the idle state. |
| [EnterPausedState()](ThreadWrapper.EnterPausedState().md 'Jcd.Threading.ThreadWrapper.EnterPausedState()') | Puts the thread into the Paused state. |
| [ExitIdleState()](ThreadWrapper.ExitIdleState().md 'Jcd.Threading.ThreadWrapper.ExitIdleState()') | Causes the owning thread to resume. This must be called by an external thread. |
| [ExitPausedState()](ThreadWrapper.ExitPausedState().md 'Jcd.Threading.ThreadWrapper.ExitPausedState()') | Causes the thread to exit the paused state. This must be called by<br/>an external thread. |
| [GetShouldContinue(CancellationToken)](ThreadWrapper.GetShouldContinue.bMNPC5sBwGtj9DuduJ/x8g.md 'Jcd.Threading.ThreadWrapper.GetShouldContinue(System.Threading.CancellationToken)') | Determines if the main thread loop should continue looping. |
| [IdleWait(CancellationToken)](ThreadWrapper.IdleWait.q69Aj6do6sbEw/LzUpxGWQ.md 'Jcd.Threading.ThreadWrapper.IdleWait(System.Threading.CancellationToken)') | Wait in idle state, if the IsIdle flag is set. |
| [Pause()](ThreadWrapper.Pause().md 'Jcd.Threading.ThreadWrapper.Pause()') | Pauses the retrieval and processing of queued items. |
| [PauseWait(CancellationToken)](ThreadWrapper.PauseWait.iLYFR/oz4tfG+yGYs8FSiw.md 'Jcd.Threading.ThreadWrapper.PauseWait(System.Threading.CancellationToken)') | Wait in the paused state if the IsPaused flag is set. |
| [PerformThreadStateCleanup()](ThreadWrapper.PerformThreadStateCleanup().md 'Jcd.Threading.ThreadWrapper.PerformThreadStateCleanup()') | Ensures thread state is reset to final, including cancellation.<br/>This is called as a thread is exiting.. |
| [PerformWork(CancellationToken)](ThreadWrapper.PerformWork.Iee0Rq4O6c1RXxlt3rXwsg.md 'Jcd.Threading.ThreadWrapper.PerformWork(System.Threading.CancellationToken)') | Performs a single unit of work. Implement in derived types not overriding ThreadProc. |
| [Resume()](ThreadWrapper.Resume().md 'Jcd.Threading.ThreadWrapper.Resume()') | Resumes item processing. |
| [Start()](ThreadWrapper.Start().md 'Jcd.Threading.ThreadWrapper.Start()') | Starts the processing of queued items. |
| [Stop()](ThreadWrapper.Stop().md 'Jcd.Threading.ThreadWrapper.Stop()') | Shuts down the thread through the CancellationToken |
| [ThreadProc()](ThreadWrapper.ThreadProc().md 'Jcd.Threading.ThreadWrapper.ThreadProc()') | The main thread control loop. |
| [YieldCpuTime(int)](ThreadWrapper.YieldCpuTime.H6HyyvoVeNoLaTObIHalbg.md 'Jcd.Threading.ThreadWrapper.YieldCpuTime(int)') | Yields very small amounts of CPU time. This can approach 1ms.<br/>Thread.Sleep and Task.Delay will wait at least 15ms. |
