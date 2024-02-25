#### [Jcd.Tasks](index.md 'index')
### [Jcd.Tasks.TaskSchedulers](Jcd.Tasks.TaskSchedulers.md 'Jcd.Tasks.TaskSchedulers').[ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler')

## ThreadTaskScheduler.Threads Property

The set of threads that will process Tasks. This is provided for  
advanced use cases where an action needs to be taken on the entire  
pool of threads.

```csharp
public System.Collections.Generic.IReadOnlyList<System.Threading.Thread> Threads { get; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')[System.Threading.Thread](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Thread 'System.Threading.Thread')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')