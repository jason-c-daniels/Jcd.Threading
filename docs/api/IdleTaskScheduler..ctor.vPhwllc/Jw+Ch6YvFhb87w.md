#### [Jcd.Threading](index.md 'index')
### [Jcd.Threading.Tasks](Jcd.Threading.Tasks.md 'Jcd.Threading.Tasks').[IdleTaskScheduler](IdleTaskScheduler.md 'Jcd.Threading.Tasks.IdleTaskScheduler')

## IdleTaskScheduler(int, ApartmentState, string) Constructor

Creates an instance of [IdleTaskScheduler](IdleTaskScheduler.md 'Jcd.Threading.Tasks.IdleTaskScheduler')

```csharp
public IdleTaskScheduler(int threadCount=0, System.Threading.ApartmentState apartmentState=System.Threading.ApartmentState.Unknown, string name="");
```
#### Parameters

<a name='Jcd.Threading.Tasks.IdleTaskScheduler.IdleTaskScheduler(int,System.Threading.ApartmentState,string).threadCount'></a>

`threadCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

the number of threads to use for scheduling tasks.

<a name='Jcd.Threading.Tasks.IdleTaskScheduler.IdleTaskScheduler(int,System.Threading.ApartmentState,string).apartmentState'></a>

`apartmentState` [System.Threading.ApartmentState](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ApartmentState 'System.Threading.ApartmentState')

The [System.Threading.ApartmentState](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.ApartmentState 'System.Threading.ApartmentState') of the threads to create.

<a name='Jcd.Threading.Tasks.IdleTaskScheduler.IdleTaskScheduler(int,System.Threading.ApartmentState,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of this TaskScheduler instance. Useful for debugging.