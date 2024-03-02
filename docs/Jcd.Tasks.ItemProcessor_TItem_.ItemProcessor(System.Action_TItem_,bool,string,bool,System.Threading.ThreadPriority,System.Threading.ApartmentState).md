### [Jcd.Tasks](Jcd.Tasks.md 'Jcd.Tasks').[ItemProcessor&lt;TItem&gt;](Jcd.Tasks.ItemProcessor_TItem_.md 'Jcd.Tasks.ItemProcessor<TItem>')

## ItemProcessor(Action<TItem>, bool, string, bool, ThreadPriority, ApartmentState) Constructor

Constructs a [ItemProcessor&lt;TItem&gt;](Jcd.Tasks.ItemProcessor_TItem_.md 'Jcd.Tasks.ItemProcessor<TItem>')

```csharp
public ItemProcessor(System.Action<TItem?> action, bool autoStart=true, string? name=null, bool useBackgroundThread=true, System.Threading.ThreadPriority priority=System.Threading.ThreadPriority.Normal, System.Threading.ApartmentState apartmentState=System.Threading.ApartmentState.Unknown);
```
#### Parameters

<a name='Jcd.Tasks.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TItem](Jcd.Tasks.ItemProcessor_TItem_.md#Jcd.Tasks.ItemProcessor_TItem_.TItem 'Jcd.Tasks.ItemProcessor<TItem>.TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The action to execute on each item.

<a name='Jcd.Tasks.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState).autoStart'></a>

`autoStart` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the thread should be automatically started.

<a name='Jcd.Tasks.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of this ItemProcessor, propagated to the underlying thread.

<a name='Jcd.Tasks.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState).useBackgroundThread'></a>

`useBackgroundThread` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the processing thread is a background thread.

<a name='Jcd.Tasks.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState).priority'></a>

`priority` [System.Threading.ThreadPriority](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ThreadPriority 'System.Threading.ThreadPriority')

The priority to start the processing thread at.

<a name='Jcd.Tasks.ItemProcessor_TItem_.ItemProcessor(System.Action_TItem_,bool,string,bool,System.Threading.ThreadPriority,System.Threading.ApartmentState).apartmentState'></a>

`apartmentState` [System.Threading.ApartmentState](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ApartmentState 'System.Threading.ApartmentState')

The apartment state for the underlying thread.