# Jcd.Tasks Example Code

## TaskSchedulerExtensions Examples
This type was created to allow specifying a task scheduler to
schedule work with, in a shorter manner than calling `Task.Factory.StartNew`.
The API signatures are compatible with `Task.Run`.

```csharp
// create an instance of the custom TaskScheduler
var scheduler = new MyTaskScheduler();

// execute an action with the scheduler.
await scheduler.Run(()=>Log("Execute an action."));

// execute a function with the scheduler and return the result.
var result= await scheduler.Run(()=>Log("Execute a function and return its result",10));
Console.WriteLine($"result: {result}");

// execute an async action with the scheduler.
await scheduler.Run(()=>LogAsync("Execute an async action."));

// execute an async function with the scheduler and return the result.
result = await scheduler.Run(()=>LogAsync("Execute an async function and return its result", 20));
Console.WriteLine($"result: {result}");

// ---------------------------------------------------------------
// Log and LogAsyc
//

static void Log(string text) =>
   Console.WriteLine($"[{TaskScheduler.Current.GetType().Name}] : {text}");

static Task LogAsync(string text)
{
   Log(text);
   return Task.CompletedTask;
}

static TResult Log<TResult>(string text, TResult result)
{
   Log(text);
   return result;
}

static Task<TResult> LogAsync<TResult>(string text, TResult result) => 
   Task.FromResult(Log(text, result));

// ---------------------------------------------------------------
// The custom TaskScheduler.
//

/// <summary>
/// A non-queuing TaskScheduler that immediately executes its queued work.
/// </summary>
public class MyTaskScheduler : TaskScheduler
{
   protected override IEnumerable<Task> GetScheduledTasks() => Array.Empty<Task>();

   protected override void QueueTask(Task task) => TryExecuteTask(task);

   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
      => TryExecuteTask(task);
}
```

### TaskSchedulerExtensions Output
```text
[MyTaskScheduler] : Execute an action.
[MyTaskScheduler] : Execute a function and return its result
result: 10
[MyTaskScheduler] : Execute an async action.
[MyTaskScheduler] : Execute an async function and return its result
result: 20
```

## CurrentSchedulerTaskRunner Examples
`CurrentSchedulerTaskRunner` provides a `Task.Run` compatible API
and allows work scheduled from within a task to be scheduled on 
the same `TaskScheduler` instance as the currently executing task
was started on.

The motivation for creating this type is that Task.Run uses 
`TaskScheduler.Default` in its calls to `Task.Factory.StartNew`.
`TaskScheduler.Default` uses the global .Net `ThreadPool` to 
choose where to execute work.

`TaskScheduler.Default` is usually sufficient for most use cases.
However, it is not sufficient when the exact thread executing work 
must be controlled. Using this type when the outer level task was 
executed with a custom `TaskScheduler`that ensuring thread of 
execution, will ensure sub-tasks started with `.Run` are also
using the same scheduler.

Given the long names resulting from using this type it should be aliased in
a using statement.

This type is syntactic sugar for the following use of the `TaskSchedulerExtensions`

```csharp
TaskScheduler.Current.Run(()=>{/* do your work here.*/});
```

### CurrentSchedulerTaskRunner Sample Code
```csharp
// Alias the type.
using CSTask=Jcd.Tasks.CurrentSchedulerTaskRunner;

// class and method definition elided for brevity.
var scheduler=new MyCustomScheduler();

// use TaskSchedulerExtensions.Run to kick off the 
// outer level of work on a custom TaskScheduler
scheduler.Run(()=> {
         Console.WriteLine("Outer level of work.");
         CSTask.Run(()=>{
            Console.WriteLine("Inner level of work, guaranteed to use the same scheduler.");
         });
});
```

This pattern is useful if you have operations that need to
have a guarantee about the pool of threads executing some tasks;
for example: dedicated hardware communications pool of threads 
separated from the standard ThreadPool worker threads.

To do this you'd implement your own `TaskScheduler` that has
a dedicated pool of threads.

## SimpleThreadedTaskScheduler Example
This type is provided to ease the use of creating a `TaskScheduler`
implementation which has a dedicated pool of threads, which it
is always guaranteed to schedule work on.

By default it forbids inlining (which may execute a task on the global 
`ThreadPool`). This can be overridden in derived types.

When deriving from this type you must provide a thread count and
the `ApartmentState`

### Example SimpleThreadedTaskScheduler implementation
```csharp
// An MTA thread hosting scheduler with one thread per CPU.
public class MyScheduler : SimpleThreadedTaskScheduler
{
   public MyScheduler() : base(Environment.ProcessorCount) { }
}
```

From here you can use the scheduler just like any other TaskScheduler.

NOTE: It uses some IDisposable items for queue management and must
be disposed of properly when done with the scheduler.

## CustomSchedulerTaskRunner Example
`CurrentSchedulerTaskRunner` provides a `Task.Run` compatible API, and
a singleton instance of the underlying TaskScheduler that it will use. 
It ensures all work is scheduled singleton `TaskScheduler` instance it owns.

Given the long names resulting from using this type it should be aliased in 
a using statement.

### CustomSchedulerTaskRunner Sample Code 
```csharp
// Alias the type.
using MyTaskRunner=Jcd.Tasks.CustomSchedulerTaskRunner<MyScheduler>;

// class and method definition elided for brevity.

MyTaskRunner.Run(()=> {
         Console.WriteLine("Outer level of work.");
         MyTaskRunner.Run(()=>{
            Console.WriteLine("Inner level of work, guaranteed to use the same scheduler.");
         });
});
```

This pattern is useful if you have operations that need to
have a guarantee about the pool of threads executing some tasks,
and you only ever need one instance of the type of scheduler
you're using.

## SynchronizedValue Examples
This type was created to act as a replacement for the non-CLS compliant type `Interlocked`.
It uses `SemaphoreSlim` to control access and therefore implements `IDisposable` for all the
good and bad that comes with that. The following example has three threads modifying the value,
and one thread reporting on the value.

```csharp
using Jcd.Tasks;
using Jcd.Tasks.Examples;

var       counter = new SynchronizedValue<int>();
using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(0.11)); // set a total run time of 0.11 minutes

// create a hot-task that starts incrementing the value by 1 every 100 ms;
var incrementTask = CreateIncrementTask(cts, counter);

// create a hot-task that starts decrements the value by 3 every 420 ms;
var decBy4Task = CreateDecrementBy4Task(cts, counter);

// create a hot-task that sets the to 10 every 5 seconds;
var setTo20Task = CreateSetTo20Task(cts, counter);

// create a hot-task that reports the value and a timestamp every 100ms
var reportValueTask = CreateReportValueTask(cts, counter);

// wait for the tasks to finish regardless if their faulted or cancelled status.
await Task.WhenAll(reportValueTask, setTo20Task, decBy4Task, incrementTask);

// now report their statuses.
Console.WriteLine($"reportValue.Status {reportValueTask.Status}");
Console.WriteLine($"setTo20Task.Status {setTo20Task.Status}");
Console.WriteLine($"decBy4Task.Status {decBy4Task.Status}");
Console.WriteLine($"incrementTask.Status {incrementTask.Status}");
```

### SynchronizedValue Examples Output

The output of the above code should roughly similar to the following:

```text
2023-03-18T12:43:02.1173968-05:00 : counter.Value = 1
2023-03-18T12:43:02.2270726-05:00 : counter.Value = 2
2023-03-18T12:43:02.3301075-05:00 : counter.Value = 3
2023-03-18T12:43:02.4400485-05:00 : counter.Value = 4
2023-03-18T12:43:02.5492861-05:00 : counter.Value = 2
2023-03-18T12:43:02.6591205-05:00 : counter.Value = 2
2023-03-18T12:43:02.7721114-05:00 : counter.Value = 4
2023-03-18T12:43:02.8772863-05:00 : counter.Value = 2
2023-03-18T12:43:02.9882733-05:00 : counter.Value = 2
2023-03-18T12:43:03.0985160-05:00 : counter.Value = 4
2023-03-18T12:43:03.2084325-05:00 : counter.Value = 5
2023-03-18T12:43:03.3181794-05:00 : counter.Value = 3
2023-03-18T12:43:03.4335586-05:00 : counter.Value = 3
2023-03-18T12:43:03.5434152-05:00 : counter.Value = 5
2023-03-18T12:43:03.6533078-05:00 : counter.Value = 5
2023-03-18T12:43:03.7628965-05:00 : counter.Value = 4
2023-03-18T12:43:03.8797796-05:00 : counter.Value = 5
2023-03-18T12:43:03.9808191-05:00 : counter.Value = 5
2023-03-18T12:43:04.0906125-05:00 : counter.Value = 6
2023-03-18T12:43:04.2016158-05:00 : counter.Value = 5
2023-03-18T12:43:04.3110516-05:00 : counter.Value = 5
2023-03-18T12:43:04.4260432-05:00 : counter.Value = 7
2023-03-18T12:43:04.5365307-05:00 : counter.Value = 7
2023-03-18T12:43:04.6463788-05:00 : counter.Value = 6
2023-03-18T12:43:04.7571726-05:00 : counter.Value = 7
2023-03-18T12:43:04.8669400-05:00 : counter.Value = 8
2023-03-18T12:43:04.9814393-05:00 : counter.Value = 8
2023-03-18T12:43:05.0912601-05:00 : counter.Value = 6
2023-03-18T12:43:05.2016218-05:00 : counter.Value = 7
2023-03-18T12:43:05.3111081-05:00 : counter.Value = 9
2023-03-18T12:43:05.4211987-05:00 : counter.Value = 9
2023-03-18T12:43:05.5358968-05:00 : counter.Value = 7
2023-03-18T12:43:05.6457578-05:00 : counter.Value = 9
2023-03-18T12:43:05.7554969-05:00 : counter.Value = 9
2023-03-18T12:43:05.8652770-05:00 : counter.Value = 7
2023-03-18T12:43:05.9806659-05:00 : counter.Value = 8
2023-03-18T12:43:06.0901124-05:00 : counter.Value = 9
2023-03-18T12:43:06.2002277-05:00 : counter.Value = 10
2023-03-18T12:43:06.3100703-05:00 : counter.Value = 8
2023-03-18T12:43:06.4199452-05:00 : counter.Value = 10
2023-03-18T12:43:06.5337006-05:00 : counter.Value = 10
2023-03-18T12:43:06.6435961-05:00 : counter.Value = 12
2023-03-18T12:43:06.7538127-05:00 : counter.Value = 10
2023-03-18T12:43:06.8638225-05:00 : counter.Value = 11
2023-03-18T12:43:06.9736779-05:00 : counter.Value = 12
2023-03-18T12:43:07.0215673-05:00 : Reset to 10!
2023-03-18T12:43:07.0833536-05:00 : counter.Value = 11
2023-03-18T12:43:07.1928076-05:00 : counter.Value = 9
2023-03-18T12:43:07.3031394-05:00 : counter.Value = 9
2023-03-18T12:43:07.4129646-05:00 : counter.Value = 10
2023-03-18T12:43:07.5233343-05:00 : counter.Value = 11
2023-03-18T12:43:07.6373707-05:00 : counter.Value = 9
2023-03-18T12:43:07.7471527-05:00 : counter.Value = 11
2023-03-18T12:43:07.8570405-05:00 : counter.Value = 12
2023-03-18T12:43:07.9668396-05:00 : counter.Value = 12
2023-03-18T12:43:08.0666566-05:00 : counter.Value = 10
2023-03-18T12:43:08.1710265-05:00 : counter.Value = 11
2023-03-18T12:43:08.2808028-05:00 : counter.Value = 13
2023-03-18T12:43:08.3904942-05:00 : counter.Value = 14
2023-03-18T12:43:08.5002954-05:00 : counter.Value = 11
2023-03-18T12:43:08.6105815-05:00 : counter.Value = 13
reportValue.Status Canceled
setTo20Task.Status Canceled
decBy4Task.Status Canceled
incrementTask.Status Canceled
```

