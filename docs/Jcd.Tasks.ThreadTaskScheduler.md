### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## ThreadTaskScheduler Class

A [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') derived base type that runs [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances  
in a fixed size pool of threads. Inlining is disabled by default to ensure only  
the threads managed by this [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') will process the tasks.

```csharp
public abstract class ThreadTaskScheduler : System.Threading.Tasks.TaskScheduler,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; ThreadTaskScheduler

Derived  
&#8627; [MtaThreadTaskScheduler](Jcd.Tasks.MtaThreadTaskScheduler.md 'Jcd.Tasks.MtaThreadTaskScheduler')  
&#8627; [StaThreadTaskScheduler](Jcd.Tasks.StaThreadTaskScheduler.md 'Jcd.Tasks.StaThreadTaskScheduler')

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [ThreadTaskScheduler(int, ApartmentState)](Jcd.Tasks.ThreadTaskScheduler.ThreadTaskScheduler(int,System.Threading.ApartmentState).md 'Jcd.Tasks.ThreadTaskScheduler.ThreadTaskScheduler(int, System.Threading.ApartmentState)') | Constructs an instance of the type. |

| Properties | |
| :--- | :--- |
| [Threads](Jcd.Tasks.ThreadTaskScheduler.Threads.md 'Jcd.Tasks.ThreadTaskScheduler.Threads') | The set of threads that will process Tasks. This is provided for<br/>advanced use cases where an action needs to be taken on the entire<br/>pool of threads. |

| Methods | |
| :--- | :--- |
| [Shutdown()](Jcd.Tasks.ThreadTaskScheduler.Shutdown().md 'Jcd.Tasks.ThreadTaskScheduler.Shutdown()') | Signals the underlying threads that the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')<br/>is being shutdown. Threads will end shortly thereafter. |
| [TryExecuteTaskInline(Task, bool)](Jcd.Tasks.ThreadTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).md 'Jcd.Tasks.ThreadTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task, bool)') | The method to attempt executing a Task in the calling thread's context.<br/>This is disabled by default. See remarks for discussion. |
