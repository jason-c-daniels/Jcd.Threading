#### [Jcd.Tasks](index.md 'index')

## Jcd.Tasks Namespace

Provides types and extension methods to assist with the creation, execution, and  
management of unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances.

| Classes | |
| :--- | :--- |
| [CurrentSchedulerTaskRunner](Jcd.Tasks.CurrentSchedulerTaskRunner.md 'Jcd.Tasks.CurrentSchedulerTaskRunner') | A static class that schedules tasks on the current [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') or<br/>a user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') if null is passed in or none is specified. |
| [CustomSchedulerTaskRunner&lt;TScheduler&gt;](Jcd.Tasks.CustomSchedulerTaskRunner_TScheduler_.md 'Jcd.Tasks.CustomSchedulerTaskRunner<TScheduler>') | A singleton [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') bound task runner. It ensures all tasks it creates<br/>are registered with either its own, or a user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler'). |
| [SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>') | Provides a simple async-safe and thread-safe method of setting, getting, acting on,<br/>and altering values shared among tasks and threads. |
| [TaskSchedulerExtensions](Jcd.Tasks.TaskSchedulerExtensions.md 'Jcd.Tasks.TaskSchedulerExtensions') | Adds various `Run` extension for any [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') derived type.<br/>This allows tasks to be scheduled with the desired [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler')<br/>in a manner similar to `Task.Run` |
