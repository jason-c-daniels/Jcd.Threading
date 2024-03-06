#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ItemProcessor&lt;TItem&gt;](ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>')

## ItemProcessor(Action<TItem>, bool, string, bool, bool, int, ThreadPriority, ApartmentState) Constructor

Constructs a [ItemProcessor&lt;TItem&gt;](ItemProcessor_TItem_.md 'Jcd.Threading.ItemProcessor<TItem>')

```csharp
public ItemProcessor(System.Action<TItem?> action, bool autoStart=true, string? name=null, bool useBackgroundThread=true, bool yieldEachCpuCycle=true, int timeToYieldInMs=15, System.Threading.ThreadPriority priority=System.Threading.ThreadPriority.Normal, System.Threading.ApartmentState apartmentState=System.Threading.ApartmentState.Unknown);
```
#### Parameters

<a name='Jcd.Threading.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,bool,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TItem](ItemProcessor_TItem_.md#Jcd.Threading.ItemProcessor_TItem_.TItem 'Jcd.Threading.ItemProcessor<TItem>.TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The action to execute on each item.

<a name='Jcd.Threading.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,bool,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).autoStart'></a>

`autoStart` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the thread should be automatically started.

<a name='Jcd.Threading.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,bool,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of this ItemProcessor, propagated to the underlying thread.

<a name='Jcd.Threading.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,bool,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).useBackgroundThread'></a>

`useBackgroundThread` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the processing thread is a background thread.

<a name='Jcd.Threading.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,bool,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).yieldEachCpuCycle'></a>

`yieldEachCpuCycle` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if CPU time will be yielded each pass through the main loop.

<a name='Jcd.Threading.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,bool,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).timeToYieldInMs'></a>

`timeToYieldInMs` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Indicates the amount of time to yiel when yielded each pas through the main loop.

<a name='Jcd.Threading.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,bool,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).priority'></a>

`priority` [System.Threading.ThreadPriority](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ThreadPriority 'System.Threading.ThreadPriority')

The priority to start the processing thread at.

<a name='Jcd.Threading.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,bool,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).apartmentState'></a>

`apartmentState` [System.Threading.ApartmentState](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ApartmentState 'System.Threading.ApartmentState')

The apartment state for the underlying thread.