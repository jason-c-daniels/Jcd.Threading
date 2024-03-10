#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks').[IdleTaskScheduler](IdleTaskScheduler.md 'Jcd.Threading.Tasks.IdleTaskScheduler')

## IdleTaskScheduler.ProcessorList Field

The list of underlying queue+thread task processors.  
This is provided for advanced use cases.

```csharp
protected internal readonly List<ItemProcessor<Task>> ProcessorList;
```

#### Field Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Jcd.Threading.ItemProcessor&lt;](ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')