#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks')

## IdleTaskScheduler Class

Provides a mechanism for task scheduling using a round robin mechanism for a pool
of privately managed threads. Derive from this type to implement your own specialization.

```csharp
public class IdleTaskScheduler : System.Threading.Tasks.TaskScheduler,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; IdleTaskScheduler

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [IdleTaskScheduler(int, ApartmentState, string)](IdleTaskScheduler..ctor.vPhwllc/Jw+Ch6YvFhb87w.md 'Jcd.Threading.Tasks.IdleTaskScheduler.IdleTaskScheduler(int, System.Threading.ApartmentState, string)') | Creates an instance of [IdleTaskScheduler](IdleTaskScheduler.md 'Jcd.Threading.Tasks.IdleTaskScheduler') |

| Fields | |
| :--- | :--- |
| [ProcessorList](IdleTaskScheduler.ProcessorList.md 'Jcd.Threading.Tasks.IdleTaskScheduler.ProcessorList') | The list of underlying queue+thread task processors.<br/>This is provided for advanced use cases. |

| Properties | |
| :--- | :--- |
| [Name](IdleTaskScheduler.Name.md 'Jcd.Threading.Tasks.IdleTaskScheduler.Name') | The name of the instance of the task scheduler. |
| [Threads](IdleTaskScheduler.Threads.md 'Jcd.Threading.Tasks.IdleTaskScheduler.Threads') | Provides access to the underlying threads. |

| Methods | |
| :--- | :--- |
| [~IdleTaskScheduler()](IdleTaskScheduler.~IdleTaskScheduler().md 'Jcd.Threading.Tasks.IdleTaskScheduler.~IdleTaskScheduler()') | Finalizes stuff. |
| [Dispose(bool)](IdleTaskScheduler.Dispose.M9DA/s1G+TZhfK2gYP/ajA.md 'Jcd.Threading.Tasks.IdleTaskScheduler.Dispose(bool)') | Cleans up resources and shuts down background threads. |
