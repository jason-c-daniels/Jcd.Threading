#### [Jcd.Tasks](index.md 'index')
### [Jcd.Tasks.TaskSchedulers](Jcd.Tasks.TaskSchedulers.md 'Jcd.Tasks.TaskSchedulers')

## SimpleThreadedTaskScheduler Class

A [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') derived base type that runs [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances  
in a fixed size pool of threads. Inlining is disabled by default to ensure only  
the threads managed by this [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') will process the tasks.

```csharp
public abstract class SimpleThreadedTaskScheduler : System.Threading.Tasks.TaskScheduler,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; SimpleThreadedTaskScheduler

Derived  
&#8627; [SimpleMtaThreadedTaskScheduler](Jcd.Tasks.TaskSchedulers.SimpleMtaThreadedTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.SimpleMtaThreadedTaskScheduler')  
&#8627; [SimpleStaThreadedTaskScheduler](Jcd.Tasks.TaskSchedulers.SimpleStaThreadedTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.SimpleStaThreadedTaskScheduler')

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [SimpleThreadedTaskScheduler(int, ApartmentState)](Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.SimpleThreadedTaskScheduler(int,System.Threading.ApartmentState).md 'Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.SimpleThreadedTaskScheduler(int, System.Threading.ApartmentState)') | Constructs an instance of the type. |

| Properties | |
| :--- | :--- |
| [Threads](Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.Threads.md 'Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.Threads') | The set of threads that will process Tasks. This is provided for<br/>advanced use cases where an action needs to be taken on the entire<br/>pool of threads. |

| Methods | |
| :--- | :--- |
| [Shutdown()](Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.Shutdown().md 'Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.Shutdown()') | Signals the underlying threads that the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')<br/>is being shutdown (i.e. disposed of). Threads should shortly thereafter. |
| [TryExecuteTaskInline(Task, bool)](Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,bool).md 'Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task, bool)') | The method to attempt executing a Task in the calling thread's context.<br/>This is disabled by default. See remarks for discussion. |
