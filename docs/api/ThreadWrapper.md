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
| [ThreadWrapper(bool, string, bool, int, int, ThreadPriority, ApartmentState)](ThreadWrapper..ctor.yS0P2oMxyzToT2DfFJKAkA.md 'Jcd.Threading.ThreadWrapper.ThreadWrapper(bool, string, bool, int, int, System.Threading.ThreadPriority, System.Threading.ApartmentState)') | Constructs a [ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper') |

| Properties | |
| :--- | :--- |
| [ApartmentState](ThreadWrapper.ApartmentState.md 'Jcd.Threading.ThreadWrapper.ApartmentState') | The thread apartment state used to create the underlying thread. |
| [AutoStart](ThreadWrapper.AutoStart.md 'Jcd.Threading.ThreadWrapper.AutoStart') | A flag indicating if the underlying thread should be immediately started. |
| [CancellationToken](ThreadWrapper.CancellationToken.md 'Jcd.Threading.ThreadWrapper.CancellationToken') | Gives derived types access to the [CancellationToken](ThreadWrapper.CancellationToken.md 'Jcd.Threading.ThreadWrapper.CancellationToken') |
| [IdleAfterNoWorkDoneCount](ThreadWrapper.IdleAfterNoWorkDoneCount.md 'Jcd.Threading.ThreadWrapper.IdleAfterNoWorkDoneCount') | The number of passes through the loop with no work performed before entering the idle state. |
| [IsIdle](ThreadWrapper.IsIdle.md 'Jcd.Threading.ThreadWrapper.IsIdle') | Gets a flag indicating if the item processing is currently paused. |
| [IsPaused](ThreadWrapper.IsPaused.md 'Jcd.Threading.ThreadWrapper.IsPaused') | Gets a flag indicating if the item processing is currently paused. |
| [IsStarted](ThreadWrapper.IsStarted.md 'Jcd.Threading.ThreadWrapper.IsStarted') | Gets a flag indicating if the item processing loop has started. |
| [Name](ThreadWrapper.Name.md 'Jcd.Threading.ThreadWrapper.Name') | The name of this instance of the [ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper'). By default the underlying thread will be named as follows: `$"{Name}.Thread"` |
| [Priority](ThreadWrapper.Priority.md 'Jcd.Threading.ThreadWrapper.Priority') | The priority with which to create the underlying thread. |
| [Thread](ThreadWrapper.Thread.md 'Jcd.Threading.ThreadWrapper.Thread') | Provides direct access to the underlying thread. |
| [TimeToYieldInMs](ThreadWrapper.TimeToYieldInMs.md 'Jcd.Threading.ThreadWrapper.TimeToYieldInMs') | The amount of time to yield each pass through the loop. |
| [UseBackgroundThread](ThreadWrapper.UseBackgroundThread.md 'Jcd.Threading.ThreadWrapper.UseBackgroundThread') | A flag indicating if the thread will be a background thread. |
| [YieldEachCycle](ThreadWrapper.YieldEachCycle.md 'Jcd.Threading.ThreadWrapper.YieldEachCycle') | A flag indicating if CPU time should be yielded every CPU cycle. |

| Methods | |
| :--- | :--- |
| [~ThreadWrapper()](ThreadWrapper.~ThreadWrapper().md 'Jcd.Threading.ThreadWrapper.~ThreadWrapper()') | finalizes the object. |
| [CancelAllProcessing()](ThreadWrapper.CancelAllProcessing().md 'Jcd.Threading.ThreadWrapper.CancelAllProcessing()') | Cancels the internally managed [CancellationToken](ThreadWrapper.CancellationToken.md 'Jcd.Threading.ThreadWrapper.CancellationToken') and ignores any exceptions. |
| [Dispose(bool)](ThreadWrapper.Dispose.07rvTSxJ7U5BNNbZhR87jQ.md 'Jcd.Threading.ThreadWrapper.Dispose(bool)') | Disposes of resources. |
| [EnterIdleState()](ThreadWrapper.EnterIdleState().md 'Jcd.Threading.ThreadWrapper.EnterIdleState()') | Sets the thread into the idle state. |
| [EnterPausedState()](ThreadWrapper.EnterPausedState().md 'Jcd.Threading.ThreadWrapper.EnterPausedState()') | Puts the thread into the Paused state. |
| [ExitIdleState()](ThreadWrapper.ExitIdleState().md 'Jcd.Threading.ThreadWrapper.ExitIdleState()') | Causes the owning thread to resume. This must be called by an external thread. |
| [ExitPausedState()](ThreadWrapper.ExitPausedState().md 'Jcd.Threading.ThreadWrapper.ExitPausedState()') | Causes the thread to exit the paused state. This must be called by an external thread. |
| [GetShouldContinue(CancellationToken)](ThreadWrapper.GetShouldContinue.bMNPC5sBwGtj9DuduJ/x8g.md 'Jcd.Threading.ThreadWrapper.GetShouldContinue(System.Threading.CancellationToken)') | Determines if the main thread loop should continue looping. |
| [IdleWait(CancellationToken)](ThreadWrapper.IdleWait.q69Aj6do6sbEw/LzUpxGWQ.md 'Jcd.Threading.ThreadWrapper.IdleWait(System.Threading.CancellationToken)') | Wait in idle state, if the IsIdle flag is set. |
| [Pause()](ThreadWrapper.Pause().md 'Jcd.Threading.ThreadWrapper.Pause()') | Pauses the retrieval and processing of queued items. |
| [PauseWait(CancellationToken)](ThreadWrapper.PauseWait.iLYFR/oz4tfG+yGYs8FSiw.md 'Jcd.Threading.ThreadWrapper.PauseWait(System.Threading.CancellationToken)') | Wait in the paused state if the IsPaused flag is set. |
| [PerformThreadStateCleanup()](ThreadWrapper.PerformThreadStateCleanup().md 'Jcd.Threading.ThreadWrapper.PerformThreadStateCleanup()') | Ensures thread state is reset to final, including cancellation. This is called as a thread is exiting.. |
| [PerformWork(CancellationToken)](ThreadWrapper.PerformWork.Iee0Rq4O6c1RXxlt3rXwsg.md 'Jcd.Threading.ThreadWrapper.PerformWork(System.Threading.CancellationToken)') | Performs a single unit of work. Implement in derived types not overriding ThreadProc. |
| [Resume()](ThreadWrapper.Resume().md 'Jcd.Threading.ThreadWrapper.Resume()') | Resumes item processing. |
| [Start()](ThreadWrapper.Start().md 'Jcd.Threading.ThreadWrapper.Start()') | Starts the processing of queued items. |
| [Stop()](ThreadWrapper.Stop().md 'Jcd.Threading.ThreadWrapper.Stop()') | Shuts down the thread through the CancellationToken |
| [ThreadProc()](ThreadWrapper.ThreadProc().md 'Jcd.Threading.ThreadWrapper.ThreadProc()') | The main thread control loop. |
| [YieldCpuTime(int)](ThreadWrapper.YieldCpuTime.H6HyyvoVeNoLaTObIHalbg.md 'Jcd.Threading.ThreadWrapper.YieldCpuTime(int)') | Yields very small amounts of CPU time. This can approach 1ms. Thread.Sleep and Task.Delay will wait at least 15ms. |
