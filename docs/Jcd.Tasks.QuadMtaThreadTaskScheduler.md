### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks')

## QuadMtaThreadTaskScheduler Class

A [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') that uses exactly four MTA threads to execute  
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances. Inlining is not honored. [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler')  
for details.

```csharp
public class QuadMtaThreadTaskScheduler : Jcd.Tasks.MtaThreadTaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; [ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler') &#129106; [MtaThreadTaskScheduler](Jcd.Tasks.MtaThreadTaskScheduler.md 'Jcd.Tasks.MtaThreadTaskScheduler') &#129106; QuadMtaThreadTaskScheduler