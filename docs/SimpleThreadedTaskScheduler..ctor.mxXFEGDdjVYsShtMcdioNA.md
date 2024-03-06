#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks').[SimpleThreadedTaskScheduler](SimpleThreadedTaskScheduler.md 'Jcd.Threading.Tasks.SimpleThreadedTaskScheduler')

## SimpleThreadedTaskScheduler(int, ApartmentState) Constructor

Constructs an instance of the type.

```csharp
public SimpleThreadedTaskScheduler(int threadCount, System.Threading.ApartmentState state=System.Threading.ApartmentState.Unknown);
```
#### Parameters

<a name='Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.SimpleThreadedTaskScheduler(int,System.Threading.ApartmentState).threadCount'></a>

`threadCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of threads to create.

<a name='Jcd.Threading.Tasks.SimpleThreadedTaskScheduler.SimpleThreadedTaskScheduler(int,System.Threading.ApartmentState).state'></a>

`state` [System.Threading.ApartmentState](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ApartmentState 'System.Threading.ApartmentState')

the thread apartment state setting for all threads.