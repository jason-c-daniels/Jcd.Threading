### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[SimpleThreadedTaskScheduler](Jcd.Tasks.SimpleThreadedTaskScheduler.md 'Jcd.Tasks.SimpleThreadedTaskScheduler')

## SimpleThreadedTaskScheduler.Shutdown() Method

Signals the underlying threads that the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')  
is being shutdown (i.e. disposed of). Threads should shortly thereafter.

```csharp
private void Shutdown();
```