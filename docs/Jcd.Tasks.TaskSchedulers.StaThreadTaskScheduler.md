#### [Jcd.Tasks](index.md 'index')
### [Jcd.Tasks.TaskSchedulers](Jcd.Tasks.TaskSchedulers.md 'Jcd.Tasks.TaskSchedulers')

## StaThreadTaskScheduler Class

The base type for a ThreadTaskScheduler that uses STA threads. Inlining is not honored. See [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler')  
for details.

```csharp
public abstract class StaThreadTaskScheduler : Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler') &#129106; StaThreadTaskScheduler

Derived  
&#8627; [DualStaThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.DualStaThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.DualStaThreadTaskScheduler')  
&#8627; [FourStaThreadsPerCpuTaskScheduler](Jcd.Tasks.TaskSchedulers.FourStaThreadsPerCpuTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.FourStaThreadsPerCpuTaskScheduler')  
&#8627; [OneStaThreadPerCpuTaskScheduler](Jcd.Tasks.TaskSchedulers.OneStaThreadPerCpuTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.OneStaThreadPerCpuTaskScheduler')  
&#8627; [OneStaThreadPerTwoCpusTaskScheduler](Jcd.Tasks.TaskSchedulers.OneStaThreadPerTwoCpusTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.OneStaThreadPerTwoCpusTaskScheduler')  
&#8627; [QuadStaThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.QuadStaThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.QuadStaThreadTaskScheduler')  
&#8627; [TwoStaThreadsPerCpuTaskScheduler](Jcd.Tasks.TaskSchedulers.TwoStaThreadsPerCpuTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.TwoStaThreadsPerCpuTaskScheduler')

| Constructors | |
| :--- | :--- |
| [StaThreadTaskScheduler(int)](Jcd.Tasks.TaskSchedulers.StaThreadTaskScheduler.StaThreadTaskScheduler(int).md 'Jcd.Tasks.TaskSchedulers.StaThreadTaskScheduler.StaThreadTaskScheduler(int)') | Creates an instance of the type. |
