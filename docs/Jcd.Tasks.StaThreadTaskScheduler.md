### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## StaThreadTaskScheduler Class

The base type for a ThreadTaskScheduler that uses STA threads. Inlining is not honored. [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler')  
for details.

```csharp
public abstract class StaThreadTaskScheduler : Jcd.Tasks.ThreadTaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler') &#129106; StaThreadTaskScheduler

Derived  
&#8627; [DualStaThreadTaskScheduler](Jcd.Tasks.DualStaThreadTaskScheduler.md 'Jcd.Tasks.DualStaThreadTaskScheduler')  
&#8627; [FourStaThreadsPerCpuTaskScheduler](Jcd.Tasks.FourStaThreadsPerCpuTaskScheduler.md 'Jcd.Tasks.FourStaThreadsPerCpuTaskScheduler')  
&#8627; [OneStaThreadPerCpuTaskScheduler](Jcd.Tasks.OneStaThreadPerCpuTaskScheduler.md 'Jcd.Tasks.OneStaThreadPerCpuTaskScheduler')  
&#8627; [OneStaThreadPerTwoCpusTaskScheduler](Jcd.Tasks.OneStaThreadPerTwoCpusTaskScheduler.md 'Jcd.Tasks.OneStaThreadPerTwoCpusTaskScheduler')  
&#8627; [QuadStaThreadTaskScheduler](Jcd.Tasks.QuadStaThreadTaskScheduler.md 'Jcd.Tasks.QuadStaThreadTaskScheduler')  
&#8627; [TwoStaThreadsPerCpuTaskScheduler](Jcd.Tasks.TwoStaThreadsPerCpuTaskScheduler.md 'Jcd.Tasks.TwoStaThreadsPerCpuTaskScheduler')

| Constructors | |
| :--- | :--- |
| [StaThreadTaskScheduler(int)](Jcd.Tasks.StaThreadTaskScheduler.StaThreadTaskScheduler(int).md 'Jcd.Tasks.StaThreadTaskScheduler.StaThreadTaskScheduler(int)') | Creates an instance of the type. |
