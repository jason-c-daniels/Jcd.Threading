## Jcd.Tasks Namespace

Provides classes and extension methods to assist with the creation, execution, and  
management of [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances.

| Classes | |
| :--- | :--- |
| [AsyncSerialCommandProcessor](Jcd.Tasks.AsyncSerialCommandProcessor.md 'Jcd.Tasks.AsyncSerialCommandProcessor') | In a background task, this class executes arbitrary tasks in the order they were enqueued,<br/>waiting for each to complete before executing the next. |
| [ColdTask](Jcd.Tasks.ColdTask.md 'Jcd.Tasks.ColdTask') | A Task factory that wraps the constructor with a tiny bit of logic, simplifying the process<br/>of directly creating unstarted [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')s. |
| [SynchronizedValue&lt;T&gt;](Jcd.Tasks.SynchronizedValue_T_.md 'Jcd.Tasks.SynchronizedValue<T>') | Provides a simple async-safe method of setting, getting, and altering values intended to be shared among tasks and threads. |
