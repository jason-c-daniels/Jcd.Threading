#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading](Jcd.Threading.md 'Jcd.Threading').[ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper')

## ThreadWrapper(bool, string, bool, int, int, ThreadPriority, ApartmentState) Constructor

Constructs a [ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper')

```csharp
protected ThreadWrapper(bool autoStart=true, string? name=null, bool useBackgroundThread=true, int timeToYieldInMs=15, int idleAfterNoWorkDoneCount=15, System.Threading.ThreadPriority priority=System.Threading.ThreadPriority.Normal, System.Threading.ApartmentState apartmentState=System.Threading.ApartmentState.Unknown);
```
#### Parameters

<a name='Jcd.Threading.ThreadWrapper.ThreadWrapper(bool,string,bool,int,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).autoStart'></a>

`autoStart` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the thread should be automatically started in the constructor.

<a name='Jcd.Threading.ThreadWrapper.ThreadWrapper(bool,string,bool,int,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of this [ThreadWrapper](ThreadWrapper.md 'Jcd.Threading.ThreadWrapper'), propagated to the underlying thread as "{name}.Thread".

<a name='Jcd.Threading.ThreadWrapper.ThreadWrapper(bool,string,bool,int,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).useBackgroundThread'></a>

`useBackgroundThread` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the processing thread is a background thread.

<a name='Jcd.Threading.ThreadWrapper.ThreadWrapper(bool,string,bool,int,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).timeToYieldInMs'></a>

`timeToYieldInMs` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The amount of CPU time to yield per cycle through the main loop. Only positive numbers will trigger a yield.

<a name='Jcd.Threading.ThreadWrapper.ThreadWrapper(bool,string,bool,int,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).idleAfterNoWorkDoneCount'></a>

`idleAfterNoWorkDoneCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

the number of iterations with no work before transitioning to the idle state. Set to -1 to disable idle state detection and transition.

<a name='Jcd.Threading.ThreadWrapper.ThreadWrapper(bool,string,bool,int,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).priority'></a>

`priority` [System.Threading.ThreadPriority](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ThreadPriority 'System.Threading.ThreadPriority')

The priority to start the processing thread at.

<a name='Jcd.Threading.ThreadWrapper.ThreadWrapper(bool,string,bool,int,int,System.Threading.ThreadPriority,System.Threading.ApartmentState).apartmentState'></a>

`apartmentState` [System.Threading.ApartmentState](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ApartmentState 'System.Threading.ApartmentState')

The apartment state for the underlying thread.

### Remarks

NOTE: The underlying thread is not created until the first call to `Start` and will change when calling `Stop`
followed by `Start`. This is because the thread ends completely with a call to `Stop`.

If resuming  the same thread is the desired behavior, call `Pause` and `Resume` instead.