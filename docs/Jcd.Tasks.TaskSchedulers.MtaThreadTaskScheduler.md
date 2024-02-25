#### [Jcd.Tasks](index.md 'index')
### [Jcd.Tasks.TaskSchedulers](Jcd.Tasks.TaskSchedulers.md 'Jcd.Tasks.TaskSchedulers')

## MtaThreadTaskScheduler Class

The base type for a [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler') that uses MTA threads. Inlining is not honored. See [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler')  
for details.

```csharp
public abstract class MtaThreadTaskScheduler : Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler') &#129106; MtaThreadTaskScheduler

Derived  
&#8627; [DualMtaThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.DualMtaThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.DualMtaThreadTaskScheduler')  
&#8627; [FourMtaThreadsPerCpuTaskScheduler](Jcd.Tasks.TaskSchedulers.FourMtaThreadsPerCpuTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.FourMtaThreadsPerCpuTaskScheduler')  
&#8627; [OneMtaThreadPerCpuTaskScheduler](Jcd.Tasks.TaskSchedulers.OneMtaThreadPerCpuTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.OneMtaThreadPerCpuTaskScheduler')  
&#8627; [OneMtaThreadPerTwoCpusTaskScheduler](Jcd.Tasks.TaskSchedulers.OneMtaThreadPerTwoCpusTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.OneMtaThreadPerTwoCpusTaskScheduler')  
&#8627; [QuadMtaThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.QuadMtaThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.QuadMtaThreadTaskScheduler')  
&#8627; [TwoMtaThreadsPerCpuTaskScheduler](Jcd.Tasks.TaskSchedulers.TwoMtaThreadsPerCpuTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.TwoMtaThreadsPerCpuTaskScheduler')

| Constructors | |
| :--- | :--- |
| [MtaThreadTaskScheduler(int)](Jcd.Tasks.TaskSchedulers.MtaThreadTaskScheduler.MtaThreadTaskScheduler(int).md 'Jcd.Tasks.TaskSchedulers.MtaThreadTaskScheduler.MtaThreadTaskScheduler(int)') | Creates an instance of the type. |
