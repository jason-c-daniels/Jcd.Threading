#### [Jcd.Tasks](index.md 'index')
### [Jcd.Tasks.TaskSchedulers](Jcd.Tasks.TaskSchedulers.md 'Jcd.Tasks.TaskSchedulers')

## TwoMtaThreadsPerCpuTaskScheduler Class

A [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') that uses two MTA threads per CPU to execute  
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances. Inlining is not honored. See [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler')  
for details.

```csharp
public class TwoMtaThreadsPerCpuTaskScheduler : Jcd.Tasks.TaskSchedulers.MtaThreadTaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler') &#129106; [MtaThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.MtaThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.MtaThreadTaskScheduler') &#129106; TwoMtaThreadsPerCpuTaskScheduler