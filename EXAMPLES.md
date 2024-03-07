# Jcd.Threading Selected Example Code

## Synchronization Helpers

Several types have been implemented to help developers correctly
release locks. There are two main categories: Extension methods to
existing synchronization primitives, like `SemaphoreSlim` and
value wrappers. 

With the exception of SpinLock, the extension methods create an
`IDisposable` from a call to Lock/LockAsync. The disposable
releases the resources in the call to Dispose.

The value wrappers provide locking using a specific sort of
synchronization primitive. In the case of `SemaphoreSlim` 
the type is named `SemaphoreSlimValue`. All of these wrappers
and writes. In addition to provid 

### Synchronization Primitives Extensions
- These are located in the root namespace `Jcd.Threading`.
- All methods are called Lock or LockAsync.

```csharp
// Locking a critical section with a SemaphoreSlim
var sem = new SemaphoreSlim(1,1); // all accesses are mutually exclusive.

using (sem.Lock()) // calls Wait(). 
   criticalValue=10;
   // calls Release() because Dispose hase been called.

// the equivalent code without the extension method
sem.Wait();
try 
{
   criticalValue=10;
}
finally 
{
   sem.Release();
}

// locking a critical section with a ReaderWriterLockSlim
var rwls = new ReaderWriterLockSlim();

using (rwls.Lock(ReaderWriterLockSlimIntent.Write))
{
   criticalValue=10;   
}

// the equivalent code without the extension method
rwls.TryEnterWriteLock(-1); 
try 
{
   criticalValue=10;      
}
finally
{
   rwls.ExitWriteLock();
}
```

While the default coding pattern isn't terribly difficult to do, it does 
have room for error and is far more verbose. By wrapping the block needing
synchronized access in a using block the scope of the lock is clearer
and the code is easier to understand.

As always, wrappers of this sort introduce some degree of performance hit.
See Jcd.Threading.Examples.Benchmark output to compare the impacts of the
various techniques.


### Value Wrappers
- These are all in the namespace `Jcd.Threading.SynchronizedValues`.
- All types follow the naming pattern: {PrimitiveName}Value (e.g. SemaphoreSlimValue)
- All types have a .Value property supporting getting and setting.
- For special use cases `ChangeValue`, `ChangeValueAsync`, `GetValue`,  
  `GetValueAsync`, `SetValue`, and `SetValueAsync` are also provided.
- The expected use of these types is to provide synchronized access to
  data that will not typically need more than just the data altered.
  (i.e. no other operations occur)

```csharp
var sv = new SemaphoreSlimValue<int>();

// set the value in a thread safe manner
int someValue=10;
sv.Value = someValue; // NOTE: If another thread has also acquired
                      // the lock, this data could be stale by the 
                      // time the next line executes.

// get the value in a thread safe manner.
var staleValue = sv.Value; // this value is potentially stale.
                           // only use these value wrappers
                           // for sharing data which is allowed
                           // to be stale. Also, design for handling
                           // stale data.

// the same scenario using ReaderWriterLockSlimValue
var rwlv = new ReaderWriterLockSlimValue();

// set the value in a thread safe manner.
rwlv.Value = 13;

// get the value in a thread safe manner.
var anotherStaleValue = rwlv.Value;

```

NOTE: All synchronization suffers from potentially stale data after a
lock is released. Ensure you've held the lock for the least amount of
time necessary, but no less time than that.

Also, these types will pair well with other direct uses of synchronization
primitives, such as for pausing a thread in a CPU friendly fashion. 
When doing so, ensure that you're calling Wait and Release (on a SemaphoreSlim, 
for example) at the right times. If possible, write copious unit tests to force
every possible permutation of of how the lock is acquired and released. 

## Threading and TaskScheduling

One notable absence in System.Threading.Tasks is a direct way to
run tasks on a custom TaskScheduler.

In fact, `Task.Run` often picks `TaskScheduler.Default`, which uses the
.Net `ThreadPool`. This is suboptimal when it's required to have strict
control over which threads a `Task` runs on. (an uncommon case)

As well, Microsoft has deprecated calls to `Thread.Sleep` and
has advised developers to essentially _roll their own_ synchronization
mechanisms to allow for pausing and resuming a thread.

`Jcd.Threading` and `Jcd.Threading.Tasks` have classes to help
with these needs, when they arise.

### ThreadWrapper

`ThreadWrapper` wraps a managed `Thread` and provides it with
its own `ThreadStart`delegate that handles pausing, resuming
and automatic idling.

Derive from this type to implement your own custom thread, while 
having the details of pause, resume, and idle handled for you.
All typical thread creation parameters are supported, including 
threading apartment model.

```csharp
// define our own specialized thread...
public class MyItemQueueProcessingThread : ThreadWrapper
{
   private ConcurrentQueue<MyItem> = new();
   
   public MyItemQueueProcessingThread() : base(name:"MyCoolClass", autoStart:false) { }
   
   protected override bool PerformWork() 
   {
      // check if there are any items in the ConcurrentQueue<MyItem>.
      if (cq.Count == 0 ) 
      {
         return false; // we did no work and none is pending. Indicate we can go to idle state.
      }
      MyItem item;
      if (cq.TryDequeue(out item))
      {
         // do something with the item.
      }
      return cq.Count > 0; // indicate we either did work or have work pending.
   }
   
   // implement a special loop end criteria.
   protected override bool GetShouldContinue(CancellationToken token) 
   {
      if (queue)   
      return !token.IsCancellationRequested; 
   }
   
   public Enqueue(MyItem item) 
   {
      cq.Enqueue();
      ExitIdleState(); // exits the idle state so that processing can continue.
   }
}

// use the custom thread+queue processor.
var qp = new MyItemQueueProcessingThread();

var t = qp.Thread; // this is null. The thread isn't started (or created) yet.

qp.Start();

t = qp.Thread; // This is populated now.

qp.Pause(); // suspend processing.

// populate the queue
qp.Enqueue(new MyItem(...));
qp.Enqueue(new MyItem(...));
qp.Enqueue(new MyItem(...));

// resume processing.
qp.Resume(); // let the processing proceed.

```


### IdleTaskScheduler
A custom `TaskScheduler`, `IdleTaskScheduler`, and mechanisms to
ease the use of this or other custom `TaskScheduler`s are also
provided in this library.

This task scheduler maintains its own pool of threads,
(Built atop ThreadWrapper) to provide idle-aware,
round robin task scheduling.

```csharp

// create a scheduler with two threads meant for scheduling UI threads.
var uiScheduler = new IdleTaskScheduler(name:"UI Scheduler", apartmentState: ApartmentState.STA);

// create a scheduler with the default number of threads[1]
// meant for scheduling UI threads.
// [1] Number of processors - 2, with a minimum of 2. 
var bgScheduler = new IdleTaskScheduler("Background Scheduler", apartmentState: ApartmentState.STA);

// begin scheduling work!

```


#### Run Extension

To allow programmers to use an arbitrary task scheduler in a 
familiar manner (i.e. Task.Run) a number of `TaskScheduler` 
extension methods, all overloads of Run, have been provided 
to do this.

```csharp
var ts = new IdleTaskScheduler(name:"My Scheduler");

// the default way of scheduling on a custom task scheduler
Task.Factory.StartNew(()=>{/*do some work*/}
                                , CancellationToken.None
                                , TaskCreationOptions.DenyChildAttach
                                , ts)
                                 );

// as you can see that's quite verbose and unles a person
// has written that code a lot, will not be very intuitive.
// the above code can now be written as:

ts.Run(()=>{/*do some work*/}); // a far more intuitive API!

```

Since most use cases will only need a single TaskScheduler
a static-class singleton has been provided to remove the need
to track the single instance of the app's custom `TaskScheduler`.
`CustomSchedulerTaskRunner<TScheduler>`

The name of the base singleton is a bit ugly at the moment,
but with type aliasing the experience will be similar to
`Task.Run`.

The only constraint is the `TaskScheduler` type used must have
a parameterless constructor.

```csharp
// in your global usings file: register the custom scheduler as follows 
global using UiTask = 
   Jcd.Threading.Tasks.CustomSchedulerTaskRunner<MyCode.MyUiScheduler>;

global using BgTask = 
   Jcd.Threading.Tasks.CustomSchedulerTaskRunner<MyCode.MyBackgroundScheduler>;

// in any other source file in that project...

UiTask.Run(()=>{/*Do some UI work, such as showing a dialog or main window on startup. this needs at least two threads!*/});

BgTask.Run(()=>{/*Do some background work.*/});


```
