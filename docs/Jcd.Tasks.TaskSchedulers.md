#### [Jcd.Tasks](index.md 'index')

## Jcd.Tasks.TaskSchedulers Namespace

| Classes | |
| :--- | :--- |
| [MtaThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.MtaThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.MtaThreadTaskScheduler') | The base type for a [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler') that uses MTA threads. Inlining is not honored. See [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler')<br/>for details. |
| [StaThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.StaThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.StaThreadTaskScheduler') | The base type for a ThreadTaskScheduler that uses STA threads. Inlining is not honored. See [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler')<br/>for details. |
| [ThreadTaskScheduler](Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler.md 'Jcd.Tasks.TaskSchedulers.ThreadTaskScheduler') | A [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') derived base type that runs [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances<br/>in a fixed size pool of threads. Inlining is disabled by default to ensure only<br/>the threads managed by this [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') will process the tasks. |
