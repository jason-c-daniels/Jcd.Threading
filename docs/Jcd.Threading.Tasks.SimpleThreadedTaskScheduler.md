#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks')

## SimpleThreadedTaskScheduler Class

A [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') derived base type that runs [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances  
in a fixed size pool of threads. Inlining is disabled by default to ensure only  
the threads managed by this [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') will process the tasks.

```csharp
public class SimpleThreadedTaskScheduler : System.Threading.Tasks.TaskScheduler,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; SimpleThreadedTaskScheduler

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [SimpleThreadedTaskScheduler(int, ApartmentState)](Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.SimpleThreadedTaskScheduler(int,System.Threading.ApartmentState).md 'Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.SimpleThreadedTaskScheduler(int, System.Threading.ApartmentState)') | Constructs an instance of the type. |

| Properties | |
| :--- | :--- |
| [Threads](Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.Threads.md 'Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.Threads') | The set of threads that will process Tasks. This is provided for<br/>advanced use cases where an action needs to be taken on the entire<br/>pool of threads. |

| Methods | |
| :--- | :--- |
| [~SimpleThreadedTaskScheduler()](Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.~SimpleThreadedTaskScheduler().md 'Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.~SimpleThreadedTaskScheduler()') | |
| [Dispose(bool)](Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.Dispose(bool).md 'Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.Dispose(bool)') | Disposes unmanaged resources |
| [Shutdown()](Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.Shutdown().md 'Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.Shutdown()') | Signals the underlying threads that the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')<br/>is being shutdown (i.e. disposed of). Threads should shortly thereafter. |
| [TryExecuteTaskInline(Task, bool)](Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).md 'Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task, bool)') | The method to attempt executing a Task in the calling thread's context.<br/>This is disabled by default. See remarks for discussion. |
