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
&#8627; [ItemProcessor&lt;TItem&gt;](Jcd.Threading.ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>')

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

### Remarks
`Stop` will shutdown the underlying thread completely, and a subsequent call to Start will  
create a brand new thread (with associated cancellation token), while Pause and  
Resume will suspend the thread operations at

| Constructors | |
| :--- | :--- |
| [ThreadWrapper(bool, string, bool, bool, int, ThreadPriority, ApartmentState)](Jcd.Threading.ThreadWrapper.ThreadWrapper(bool,string,bool,bool,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).md 'Jcd.Threading.ThreadWrapper.ThreadWrapper(bool, string, bool, bool, int, System.Threading.ThreadPriority, System.Threading.ApartmentState)') | Constructs a [ThreadWrapper](Jcd.Threading.ThreadWrapper.md 'Jcd.Threading.ThreadWrapper') |

| Properties | |
| :--- | :--- |
| [CancellationToken](Jcd.Threading.ThreadWrapper.CancellationToken.md 'Jcd.Threading.ThreadWrapper.CancellationToken') | Gives derived types access to the [CancellationToken](Jcd.Threading.ThreadWrapper.CancellationToken.md 'Jcd.Threading.ThreadWrapper.CancellationToken') |
| [IsIdle](Jcd.Threading.ThreadWrapper.IsIdle.md 'Jcd.Threading.ThreadWrapper.IsIdle') | Gets a flag indicating if the item processing is currently paused. |
| [IsPaused](Jcd.Threading.ThreadWrapper.IsPaused.md 'Jcd.Threading.ThreadWrapper.IsPaused') | Gets a flag indicating if the item processing is currently paused. |
| [IsStarted](Jcd.Threading.ThreadWrapper.IsStarted.md 'Jcd.Threading.ThreadWrapper.IsStarted') | Gets a flag indicating if the item processing loop has started. |
| [Name](Jcd.Threading.ThreadWrapper.Name.md 'Jcd.Threading.ThreadWrapper.Name') | The name of this instance of the [ThreadWrapper](Jcd.Threading.ThreadWrapper.md 'Jcd.Threading.ThreadWrapper').<br/>By default the underlying thread will be named as follows:<br/>`$"{Name}.Thread"` |
| [Thread](Jcd.Threading.ThreadWrapper.Thread.md 'Jcd.Threading.ThreadWrapper.Thread') | Provides direct access to the underlying thread. |

| Methods | |
| :--- | :--- |
| [~ThreadWrapper()](Jcd.Threading.ThreadWrapper.~ThreadWrapper().md 'Jcd.Threading.ThreadWrapper.~ThreadWrapper()') | finalizes the object. |
| [Dispose(bool)](Jcd.Threading.ThreadWrapper.Dispose(bool).md 'Jcd.Threading.ThreadWrapper.Dispose(bool)') | Disposes of resources. |
| [EnterIdleState()](Jcd.Threading.ThreadWrapper.EnterIdleState().md 'Jcd.Threading.ThreadWrapper.EnterIdleState()') | Sets the thread into the idle state. |
| [EnterPausedState()](Jcd.Threading.ThreadWrapper.EnterPausedState().md 'Jcd.Threading.ThreadWrapper.EnterPausedState()') | Puts the thread into the Paused state. |
| [ExitIdleState()](Jcd.Threading.ThreadWrapper.ExitIdleState().md 'Jcd.Threading.ThreadWrapper.ExitIdleState()') | Causes the owning thread to resume. This must be called by an external thread. |
| [ExitPausedState()](Jcd.Threading.ThreadWrapper.ExitPausedState().md 'Jcd.Threading.ThreadWrapper.ExitPausedState()') | Causes the thread to exit the paused state. This must be called by<br/>an external thread. |
| [GetShouldContinue(CancellationToken)](Jcd.Threading.ThreadWrapper.GetShouldContinue(System.Threading.CancellationToken).md 'Jcd.Threading.ThreadWrapper.GetShouldContinue(System.Threading.CancellationToken)') | Determines if the main thread loop should continue looping. |
| [IdleWait(CancellationToken)](Jcd.Threading.ThreadWrapper.IdleWait(System.Threading.CancellationToken).md 'Jcd.Threading.ThreadWrapper.IdleWait(System.Threading.CancellationToken)') | Wait in idle state, if the IsIdle flag is set. |
| [Pause()](Jcd.Threading.ThreadWrapper.Pause().md 'Jcd.Threading.ThreadWrapper.Pause()') | Pauses the retrieval and processing of queued items. |
| [PauseWait(CancellationToken)](Jcd.Threading.ThreadWrapper.PauseWait(System.Threading.CancellationToken).md 'Jcd.Threading.ThreadWrapper.PauseWait(System.Threading.CancellationToken)') | Wait in the paused state if the IsPaused flag is set. |
| [PerformStateThreadCleanup()](Jcd.Threading.ThreadWrapper.PerformStateThreadCleanup().md 'Jcd.Threading.ThreadWrapper.PerformStateThreadCleanup()') | Ensures thread state is reset to final, including cancellation.<br/>This is called as a thread is exiting.. |
| [PerformWork(CancellationToken)](Jcd.Threading.ThreadWrapper.PerformWork(System.Threading.CancellationToken).md 'Jcd.Threading.ThreadWrapper.PerformWork(System.Threading.CancellationToken)') | Performs a single unit of work. Implement in derived types not overriding ThreadProc. |
| [Resume()](Jcd.Threading.ThreadWrapper.Resume().md 'Jcd.Threading.ThreadWrapper.Resume()') | Resumes item processing. |
| [Start()](Jcd.Threading.ThreadWrapper.Start().md 'Jcd.Threading.ThreadWrapper.Start()') | Starts the processing of queued items. |
| [Stop()](Jcd.Threading.ThreadWrapper.Stop().md 'Jcd.Threading.ThreadWrapper.Stop()') | Shuts down the thread through the CancellationToken |
| [ThreadProc()](Jcd.Threading.ThreadWrapper.ThreadProc().md 'Jcd.Threading.ThreadWrapper.ThreadProc()') | The main thread control loop. |
| [YieldCpuTime(int)](Jcd.Threading.ThreadWrapper.YieldCpuTime(int).md 'Jcd.Threading.ThreadWrapper.YieldCpuTime(int)') | Yields very small amounts of CPU time. This can approach 1ms.<br/>Thread.Sleep and Task.Delay will wait at least 15ms. |
