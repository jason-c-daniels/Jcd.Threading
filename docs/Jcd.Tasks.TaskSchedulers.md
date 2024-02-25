#### [Jcd.Tasks](index.md 'index')

## Jcd.Tasks.TaskSchedulers Namespace

| Classes | |
| :--- | :--- |
| [SimpleMtaThreadedTaskScheduler](Jcd.Tasks.TaskSchedulers.SimpleMtaThreadedTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.SimpleMtaThreadedTaskScheduler') | An ease of use wrapper on top of [SimpleThreadedTaskScheduler](Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler') that uses MTA threads. Inlining is not honored.<br/>for details. |
| [SimpleStaThreadedTaskScheduler](Jcd.Tasks.TaskSchedulers.SimpleStaThreadedTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.SimpleStaThreadedTaskScheduler') | An ease of use wrapper on top of [SimpleThreadedTaskScheduler](Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler') that uses STA threads. Inlining is not honored. |
| [SimpleThreadedTaskScheduler](Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.SimpleThreadedTaskScheduler') | A [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') derived base type that runs [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances<br/>in a fixed size pool of threads. Inlining is disabled by default to ensure only<br/>the threads managed by this [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') will process the tasks. |
