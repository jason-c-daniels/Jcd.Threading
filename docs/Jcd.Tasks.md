## Jcd.Tasks Namespace

Provides classes and extension methods to assist with the creation, execution, and  
management of [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances.

| Classes | |
| :--- | :--- |
| [BlockingTaskProcessor](Jcd.Tasks.BlockingTaskProcessor.md 'Jcd.Tasks.BlockingTaskProcessor') | Represents a high level object that enqueues and executes actions, functions, and unstarted tasks,<br/>waiting for each to complete before executing the next. |
| [SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>') | Provides a simple async-safe method of setting, getting, and altering values intended to be shared among tasks and threads. |
| [TaskExtensions](Jcd.Tasks.TaskExtensions.md 'Jcd.Tasks.TaskExtensions') | A set of helpers for [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') objects. |
| [UnstartedTask](Jcd.Tasks.UnstartedTask.md 'Jcd.Tasks.UnstartedTask') | A Task factory that wraps the constructor with a tiny bit of logic, simplifying the process<br/>of directly creating unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')s. |

| Enums | |
| :--- | :--- |
| [TryRunResult](Jcd.Tasks.TryRunResult.md 'Jcd.Tasks.TryRunResult') | The possible results of calling [TryRun(this Task, Exception)](Jcd.Tasks.TaskExtensions.TryRun(thisSystem.Threading.Tasks.Task,System.Exception).md 'Jcd.Tasks.TaskExtensions.TryRun(this System.Threading.Tasks.Task, System.Exception)') |
