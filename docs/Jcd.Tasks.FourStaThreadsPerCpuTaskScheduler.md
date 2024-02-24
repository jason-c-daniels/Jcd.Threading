### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## FourStaThreadsPerCpuTaskScheduler Class

A [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') that uses four STA threads per CPU to execute  
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances. Inlining is not honored. See [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler')  
for details.

```csharp
public class FourStaThreadsPerCpuTaskScheduler : Jcd.Tasks.StaThreadTaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler') &#129106; [StaThreadTaskScheduler](Jcd.Tasks.StaThreadTaskScheduler.md 'Jcd.Tasks.StaThreadTaskScheduler') &#129106; FourStaThreadsPerCpuTaskScheduler