### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[ThreadTaskScheduler](Jcd.Tasks.ThreadTaskScheduler.md 'Jcd.Tasks.ThreadTaskScheduler')

## ThreadTaskScheduler.Shutdown() Method

Signals the underlying threads that the [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')  
is being shutdown. Threads will end shortly thereafter.

```csharp
public void Shutdown();
```