#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks')

## InlineTaskScheduler Class

Executes all tasks inline, without queuing or scheduling.  
As a result this executes work in the .Net ThreadPool.  
So, consequently, it can hardly be called a TaskScheduler.

```csharp
public class InlineTaskScheduler : System.Threading.Tasks.TaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Threading.Tasks.TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskScheduler 'System.Threading.Tasks.TaskScheduler') &#129106; InlineTaskScheduler