### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## OneStaThreadPerTwoCpusTaskScheduler Class

A [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') that uses one STA thread for every two CPUs to execute  
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances. At a minimum one thread is created. Inlining is not honored. See [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler')  
for details.

```csharp
public class OneStaThreadPerTwoCpusTaskScheduler : Jcd.Tasks.StaThreadTaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler') &#129106; [StaThreadTaskScheduler](Jcd.Tasks.StaThreadTaskScheduler.md 'Jcd.Tasks.StaThreadTaskScheduler') &#129106; OneStaThreadPerTwoCpusTaskScheduler