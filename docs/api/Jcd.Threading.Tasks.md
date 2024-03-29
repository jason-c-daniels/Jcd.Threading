#### [Jcd.Threading](index.md 'index')

## Jcd.Threading.Tasks Namespace

Provides types and extension methods to assist with the creation and scheduling
of work with custom [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') instances.

| Classes | |
| :--- | :--- |
| [CurrentTaskSchedulerRunner](CurrentTaskSchedulerRunner.md 'Jcd.Threading.Tasks.CurrentTaskSchedulerRunner') | A static class that schedules tasks on the current [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') or a user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') if null is passed in or none is specified. |
| [CustomSchedulerTaskRunner&lt;TScheduler&gt;](CustomSchedulerTaskRunner_TScheduler_.md 'Jcd.Threading.Tasks.CustomSchedulerTaskRunner<TScheduler>') | A singleton [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') bound task runner. It ensures all tasks it creates are registered with either its own, or a user provided [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler'). |
| [IdleTaskScheduler](IdleTaskScheduler.md 'Jcd.Threading.Tasks.IdleTaskScheduler') | Provides a mechanism for task scheduling using a round robin mechanism for a pool of privately managed threads. Derive from this type to implement your own specialization. |
| [TaskSchedulerExtensions](TaskSchedulerExtensions.md 'Jcd.Threading.Tasks.TaskSchedulerExtensions') | Adds various `Run` extension for any [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') derived type. This allows tasks to be scheduled with the desired [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') in a manner similar to `Task.Run` |
