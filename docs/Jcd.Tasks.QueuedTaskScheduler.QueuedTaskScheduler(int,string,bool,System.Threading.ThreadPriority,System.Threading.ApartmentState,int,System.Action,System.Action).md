### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[QueuedTaskScheduler](Jcd.Tasks.QueuedTaskScheduler.md 'Jcd.Tasks.QueuedTaskScheduler')

## QueuedTaskScheduler(int, string, bool, ThreadPriority, ApartmentState, int, Action, Action) Constructor

Initializes the scheduler.

```csharp
public QueuedTaskScheduler(int threadCount, string threadName="", bool useForegroundThreads=false, System.Threading.ThreadPriority threadPriority=System.Threading.ThreadPriority.Normal, System.Threading.ApartmentState threadApartmentState=System.Threading.ApartmentState.MTA, int threadMaxStackSize=0, System.Action threadInit=null, System.Action threadFinally=null);
```
#### Parameters

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState,int,System.Action,System.Action).threadCount'></a>

`threadCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of threads to create and use for processing work items.

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState,int,System.Action,System.Action).threadName'></a>

`threadName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name to use for each of the created threads.

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState,int,System.Action,System.Action).useForegroundThreads'></a>

`useForegroundThreads` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

A Boolean value that indicates whether to use foreground threads instead of background.

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState,int,System.Action,System.Action).threadPriority'></a>

`threadPriority` [System.Threading.ThreadPriority](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ThreadPriority 'System.Threading.ThreadPriority')

The priority to assign to each thread.

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState,int,System.Action,System.Action).threadApartmentState'></a>

`threadApartmentState` [System.Threading.ApartmentState](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ApartmentState 'System.Threading.ApartmentState')

The apartment state to use for each thread.

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState,int,System.Action,System.Action).threadMaxStackSize'></a>

`threadMaxStackSize` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The stack size to use for each thread.

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState,int,System.Action,System.Action).threadInit'></a>

`threadInit` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

An initialization routine to run on each thread.

<a name='Jcd.Tasks.QueuedTaskScheduler.QueuedTaskScheduler(int,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState,int,System.Action,System.Action).threadFinally'></a>

`threadFinally` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

A finalization routine to run on each thread.