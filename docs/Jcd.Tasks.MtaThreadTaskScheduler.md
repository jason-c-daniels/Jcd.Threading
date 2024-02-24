### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## MtaThreadTaskScheduler Class

The base type for a [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler') that uses MTA threads. Inlining is not honored. See [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler')  
for details.

```csharp
public abstract class MtaThreadTaskScheduler : Jcd.Tasks.ThreadTaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler') &#129106; MtaThreadTaskScheduler

Derived  
&#8627; [DualMtaThreadTaskScheduler](Jcd.Tasks.DualMtaThreadTaskScheduler.md 'Jcd.Tasks.DualMtaThreadTaskScheduler')  
&#8627; [FourMtaThreadsPerCpuTaskScheduler](Jcd.Tasks.FourMtaThreadsPerCpuTaskScheduler.md 'Jcd.Tasks.FourMtaThreadsPerCpuTaskScheduler')  
&#8627; [OneMtaThreadPerCpuTaskScheduler](Jcd.Tasks.OneMtaThreadPerCpuTaskScheduler.md 'Jcd.Tasks.OneMtaThreadPerCpuTaskScheduler')  
&#8627; [OneMtaThreadPerTwoCpusTaskScheduler](Jcd.Tasks.OneMtaThreadPerTwoCpusTaskScheduler.md 'Jcd.Tasks.OneMtaThreadPerTwoCpusTaskScheduler')  
&#8627; [QuadMtaThreadTaskScheduler](Jcd.Tasks.QuadMtaThreadTaskScheduler.md 'Jcd.Tasks.QuadMtaThreadTaskScheduler')  
&#8627; [TwoMtaThreadsPerCpuTaskScheduler](Jcd.Tasks.TwoMtaThreadsPerCpuTaskScheduler.md 'Jcd.Tasks.TwoMtaThreadsPerCpuTaskScheduler')

| Constructors | |
| :--- | :--- |
| [MtaThreadTaskScheduler(int)](Jcd.Tasks.MtaThreadTaskScheduler.MtaThreadTaskScheduler(int).md 'Jcd.Tasks.MtaThreadTaskScheduler.MtaThreadTaskScheduler(int)') | Creates an instance of the type. |
