# Verbose Examples

## SynchronizedValue Examples
This type was created to act as a replacement for the non-CLS compliant type `Interlocked`.
It uses `SemaphoreSlim` to control access and therefore implements `IDisposable` for all the
good and bad that comes with that. The following example has three threads modifying the value,
and one thread reporting on the value.

Note: The extension method StartEx only starts a task that can be started and returns the task.
This is because 

```csharp
using Jcd.Tasks;
using Jcd.Tasks.Examples;

var counter = new SynchronizedValue<int>();
using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(0.11)); // set a total run time of 0.11 minutes

// create a hot-task that starts incrementing the value by 1 every 100 ms;
var incrementTask = Task.Run(async () =>
{
    while (!cts.IsCancellationRequested)
    {
        await Task.Delay(100,cts.Token);
        await counter.ChangeValueAsync(x => x + 1);
    }

    if (cts.IsCancellationRequested) throw new TaskCanceledException();
},cts.Token);

// create a hot-task that starts decrements the value by 3 every 420 ms;
var decBy4Task = Task.Run(async () =>
{
    while (!cts.IsCancellationRequested)
    {
        await Task.Delay(420,cts.Token);
        await counter.ChangeValueAsync(x => x - 3);
    }
    if (cts.IsCancellationRequested) throw new TaskCanceledException();
}, cts.Token);

// create a hot-task that sets the to 10 every 5 seconds;
var setTo20Task = Task.Run(async () =>
{
    while (!cts.IsCancellationRequested)
    {
        await Task.Delay(5000,cts.Token);
        await counter.SetValueAsync(10);
        Console.WriteLine($"{DateTime.Now:O} : Reset to 10!");
        await Console.Out.FlushAsync();
    }
    if (cts.IsCancellationRequested) throw new TaskCanceledException();
}, cts.Token);

// create a hot-task that reports the value and a timestamp every 100ms
var reportValue = Task.Run(async () =>
{
    while (!cts.IsCancellationRequested)
    {
        await Task.Delay(100,cts.Token);
        Console.WriteLine($"{DateTime.Now:O} : counter.Value = {counter.Value}");
    }
    if (cts.IsCancellationRequested) throw new TaskCanceledException();
}, cts.Token);

// Now ensure the tasks have completed. The TryAwait(Async) extension method can be used 
// if there's any question as to the faulted/canceled state, and your application won't 
// care/knows how to recover.
//
// In this case, since the Task.Delay is using the cancellation token, and we directly 
// raise the TaskCanceledException we are expecting the tasks to be cancelled.
// And this application is merely reporting statuses on completion.
//
// NOTE: Only use this method if your application knows how to recover from cancelled or 
// faulted tasks.
//

// wait for the tasks to finish regardless if their faulted or cancelled status.
while (
    !reportValueTask.IsCompleted ||
    !setTo20Task.IsCompleted ||
    !decBy4Task.IsCompleted ||
    !incrementTask.IsCompleted)
    await Task.Yield();

// now report their statuses.
Console.WriteLine($"reportValue.Status {reportValue.Status}");
Console.WriteLine($"setTo20Task.Status {setTo20Task.Status}");
Console.WriteLine($"decBy4Task.Status {decBy4Task.Status}");
Console.WriteLine($"incrementTask.Status {incrementTask.Status}");

return 0;
```

### Output from SynchronizedValue Example

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

## UnstartedTask Example

Below, in code are a variety of ways to use `UnstartedTask`. It also provides the extension method
`IsUnstarted` as shown below.

```csharp
//--------------------------------------------
// create an unstarted task from an action.
//--------------------------------------------
var ctA = UnstartedTask.Create(() => Console.WriteLine("I'm an unstarted task from an action."));
Console.WriteLine($"ctA.Status = {ctA.Status} | Is it an unstarted task? {ctA.IsUnstarted()}");

// start the unstarted task.
ctA.Start();
Console.WriteLine($"Is ctA an unstarted task? {ctA.IsUnstarted()}");
await ctA; // wait for it to finish. Should do the output between ctA.Start() and here.
// don't do this though, starting it a second time gives an exception.
Console.Write("Try starting it again! (it won't work); ");
try {ctA.Start(); } catch(Exception ex){Console.WriteLine($"Bad Programmer Error: {ex.Message}");}
Console.WriteLine();

//--------------------------------------------
// create an unstarted task from an async action.
//--------------------------------------------
var ctaA = UnstartedTask.Create(async () =>
{
    await Task.Delay(1000);
    Console.WriteLine("I'm an unstarted task from an async action.");
});

// start the unstarted task.
ctaA.Start();
Console.WriteLine($"Is ctaA an unstarted task? {ctaA.IsUnstarted()}");
await ctaA; // wait for it to finish. Should do the output between ctaA.Start() and here.

Console.WriteLine();

//--------------------------------------------
// create an unstarted task from a function
//--------------------------------------------
var ctF = UnstartedTask.Create(() => TimesTen(10));
Console.WriteLine($"ctF.Status = {ctF.Status} | Is it an unstarted task? {ctF.IsUnstarted()}");

// start the task.
ctF.Start();
Console.WriteLine($"Is ctF an unstarted task? {ctF.IsUnstarted()}");
Console.WriteLine($"The result of the task is {await ctF}");

Console.WriteLine();

//--------------------------------------------
// create an unstarted task from an async function
//--------------------------------------------
var ctaF = UnstartedTask.Create(async ()=>await TimesTenAsync(12));

Console.WriteLine($"ctaF.Status = {ctaF.Status} | Is it an unstarted task? {ctaF.IsUnstarted()}");

// start the task.
ctaF.Start();
Console.WriteLine($"Is ctaF an unstarted task? {ctaF.IsUnstarted()}");
Console.WriteLine($"The result of the task is {await ctaF}");

Console.WriteLine();


// another no-no, saved for the end. It'll hang the app.
var unstarted = UnstartedTask.Create(() => { /* This part is unimportant. */ });
Console.WriteLine($"unstarted.Status = {unstarted.Status} | Is it an unstarted task? {unstarted.IsUnstarted()}");
Console.WriteLine("Now we await the unstarted task and wait forever. (Press CTRL-C to end)");
await unstarted;

int TimesTen(int input) => input * 10;

async Task<int> TimesTenAsync(int input)
{
    await Task.Delay(1000);
    return input * 10;
}

return 0;
```

### Output from the UnstartedTask Example
```text
ctA.Status = Created | Is it an unstarted task? True
Is ctA an unstarted task? False
I'm an unstarted task from an action.
Try starting it again! (it won't work); Bad Programmer Error: Start may not be called on a task that has completed.

Is ctaA an unstarted task? False
I'm an unstarted task from an async action.

ctF.Status = Created | Is it an unstarted task? True
Is ctF an unstarted task? False
The result of the task is 100

ctaF.Status = Created | Is it an unstarted task? True
Is ctaF an unstarted task? False
The result of the task is 120

unstarted.Status = Created | Is it an unstarted task? True
Now we await the unstarted task and wait forever. (Press CTRL-C to end)
```



## BlockingTaskProcessor Example
```csharp
using System.Diagnostics;
using Jcd.Tasks;

// run the example code.
await BlockingTaskProcessorExample.Run();

return 0;

/// <summary>
/// Demonstrates some of the uses of <see cref="Tasks.BlockingTaskProcessor"/>
/// </summary>
public static class BlockingTaskProcessorExample
{
    private static readonly BlockingTaskProcessor TaskProcessor = new(false); // don't start right away.

    /// <summary>
    /// Runs the example code. Returns 0 if successful. Throws an exception otherwise.
    /// </summary>
    /// <returns>0</returns>
    /// <exception cref="TaskCanceledException"></exception>
    public static async Task<int> Run()
    {
        // Start up the enqueued task processing. The queue should be empty.
        // We start up here because some of the tasks will manipulate the queue status.
        // Ensuring task processing has already begun nearly ensures something gets processed
        // before the first pause occurs.
        TaskProcessor.StartProcessing();

        // This example starts up five tasks that manipulate the queue in various ways and which will last for 
        // differing amounts of time.
        
        // create a task that enqueues work every 0.2 seconds with a lifespan of 120 seconds.. Each enqueued task delays for PI/100 seconds.
        var ctsQueuer1 = StartQueuerTask();
        
        // create another task that enqueues work every 90ms with a lifespan of 120 seconds.. Each enqueued task delays for 100ms
        var ctsQueuer2 = StartQueuerTask(10d/1000d,90d/1000d);
        
        // create a task that periodically resumes the queue (every 6 seconds) with a lifespan of 120 seconds.
        var ctsResumer1 = StartResumerTask(6.0);
        
        // create a task that periodically pauses the queue (every 3 seconds)  with a lifespan of 120 seconds.
        var ctsPauser1 = StartPauserTask(3.0);
        
        // create a task that spams calls to TaskProcessor.Pause. This is done for... reasons.
        var ctsSpastic = SpasticPauserTask(Math.PI*(1+1d/3d),60);
        
        // create a task that periodically calls TaskProcessor.Cancel every 10 seconds for one minute.
        var ctsCanceler = StartCancellerTask(); 
        
        // create a task that periodically calls TaskProcessor.StartProcessing every 8 seconds for one minute.
        var ctsStarter = StartStarterTask();
        
        // wait, yielding CPU time, until all tasks have been cancelled by their cancellation tokens
        while (!ctsPauser1.IsCancellationRequested ||
               !ctsQueuer1.IsCancellationRequested ||
               !ctsQueuer2.IsCancellationRequested ||
               !ctsResumer1.IsCancellationRequested ||
               !ctsSpastic.IsCancellationRequested ||
               !ctsCanceler.IsCancellationRequested ||
               !ctsStarter.IsCancellationRequested
              ) await Task.Yield(); 

        // cancel all pending tasks (there should be a lot of them)
        TaskProcessor.Cancel();
        
        // NOTE: interpreting the output is a bit messy.
        
        return 0;
    }

    private static CancellationTokenSource StartQueuerTask(double busyWorkDelayInSeconds=Math.PI/100.0,double enqueueDelayInSeconds=0.2, double lifeSpanInSeconds=120)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
        {
            // enqueue an async action when called.
            void Enqueue(long item, long thId)
            {
                Debug.WriteLine($"{thId}:{item} enqueuing : q.Length= {TaskProcessor.QueueLength}");
                Debug.Flush();
                TaskProcessor.EnqueueAsyncAction(async () =>
                {
                    Console.WriteLine($"{thId}:{item} began");
                    await Console.Out.FlushAsync();
                    await Task.Delay(TimeSpan.FromSeconds(busyWorkDelayInSeconds), cts.Token);
                    Console.WriteLine($"{thId}:{item} finished");
                    await Console.Out.FlushAsync();
                });
                Debug.WriteLine($"{thId}:{item} enqueued");
                Debug.Flush();
            }

            long i = 0;
            while (!cts.IsCancellationRequested)
            {
                Enqueue(i++, Environment.CurrentManagedThreadId);
                await Task.Delay(TimeSpan.FromSeconds(enqueueDelayInSeconds), cts.Token);
            }
        },cts.Token);
        return cts;
    }

    private static CancellationTokenSource StartPauserTask(double delayInSeconds=Math.PI-0.1,double lifeSpanInSeconds=120)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                if (TaskProcessor.IsPaused) continue;
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                Console.WriteLine($"Pausing from {nameof(StartPauserTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
                await TaskProcessor.PauseAsync();
                Console.WriteLine($"Paused from {nameof(StartPauserTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
            }
        }, cts.Token);
        return cts;
    }
    
    private static CancellationTokenSource StartCancellerTask(double delayInSeconds=30,double lifeSpanInSeconds=60)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                if (TaskProcessor.IsPaused) continue;
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                Console.WriteLine($"Cancelling from {nameof(StartCancellerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
                TaskProcessor.Cancel();
                Console.WriteLine($"Canceled from {nameof(StartCancellerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
            }
        }, cts.Token);
        return cts;
    }

    private static CancellationTokenSource StartStarterTask(double delayInSeconds = 8, double lifeSpanInSeconds = 60)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                if (TaskProcessor.IsPaused) continue;
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                Console.WriteLine($"(re?)Starting from {nameof(StartCancellerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
                TaskProcessor.StartProcessing();
                Console.WriteLine($"(re?)Started from {nameof(StartCancellerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
            }
        }, cts.Token);
        return cts;
    }

    private static CancellationTokenSource StartResumerTask(double delayInSeconds=Math.PI,double lifeSpanInSeconds=120)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                if (!TaskProcessor.IsPaused) continue; // do nothing until the queue is paused.
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                Console.WriteLine($"Resuming from {nameof(StartResumerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
                await TaskProcessor.ResumeAsync();
                Console.WriteLine($"Resume from {nameof(StartResumerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
            }
        }, cts.Token);
        return cts;
    }

    private static CancellationTokenSource SpasticPauserTask(double delayInSeconds=Math.PI*3,double lifeSpanInSeconds=120,int numberOfThreads=100)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
            {
                while (!cts.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                    await Task.WhenAll(
                        Enumerable.Range(0,numberOfThreads).Select(x=>
                            Task.Run(async () =>
                            {
                                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds/2), cts.Token);
                                Console.WriteLine($"Pausing [{x}] from {nameof(SpasticPauserTask)} {Environment.CurrentManagedThreadId}");
                                await Console.Out.FlushAsync();
                                await TaskProcessor.PauseAsync();
                                Console.WriteLine($"Paused [{x}] from {nameof(SpasticPauserTask)} {Environment.CurrentManagedThreadId}");
                                await Console.Out.FlushAsync();
                            }, cts.Token)
                        ));
                    await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                }
            }, cts.Token);
        return cts;
    }
}
```

### Example Output For BlockingTaskProcessor Example
Your run should resemble this output. It's truncated as the example runs for two minutes.

```text
7:0 began
7:0 finished
9:0 began
9:0 finished
25:1 began
25:1 finished
9:2 began
9:2 finished
14:1 began
14:1 finished
24:3 began
24:3 finished
26:4 began
26:4 finished
24:2 began
24:2 finished
4:5 began
4:5 finished
14:6 began
14:6 finished
17:3 began
17:3 finished
29:7 began
29:7 finished
4:8 began
4:8 finished
24:4 began
24:4 finished
20:9 began
20:9 finished
15:10 began
15:10 finished
25:5 began
25:5 finished
21:11 began
21:11 finished
14:12 began
14:12 finished
9:13 began
9:13 finished
29:6 began
29:6 finished
29:14 began
29:14 finished
29:15 began
29:15 finished
12:7 began
12:7 finished
11:16 began
11:16 finished
16:17 began
16:17 finished
21:8 began
21:8 finished
7:18 began
7:18 finished
15:19 began
15:19 finished
19:9 began
19:9 finished
21:20 began
21:20 finished
9:21 began
9:21 finished
21:10 began
21:10 finished
19:22 began
19:22 finished
16:23 began
16:23 finished
15:11 began
15:11 finished
4:24 began
4:24 finished
9:25 began
9:25 finished
9:12 began
9:12 finished
11:26 began
11:26 finished
25:27 began
25:27 finished
7:28 began
7:28 finished
23:13 began
23:13 finished
31:29 began
31:29 finished
24:30 began
24:30 finished
29:14 began
29:14 finished
15:31 began
15:31 finished
Pausing from StartPauserTask 17
Paused from StartPauserTask 19
Pausing [62] from SpasticPauserTask 25
Pausing [71] from SpasticPauserTask 29
Pausing [76] from SpasticPauserTask 23
Pausing [1] from SpasticPauserTask 9
Pausing [55] from SpasticPauserTask 7
Pausing [47] from SpasticPauserTask 7
Pausing [19] from SpasticPauserTask 14
Pausing [77] from SpasticPauserTask 12
Pausing [67] from SpasticPauserTask 26
Pausing [9] from SpasticPauserTask 10
Pausing [74] from SpasticPauserTask 17
Pausing [6] from SpasticPauserTask 20
Pausing [65] from SpasticPauserTask 21
Pausing [99] from SpasticPauserTask 15
Pausing [5] from SpasticPauserTask 30
Pausing [72] from SpasticPauserTask 22
Pausing [15] from SpasticPauserTask 24
Pausing [66] from SpasticPauserTask 4
Pausing [11] from SpasticPauserTask 4
Pausing [30] from SpasticPauserTask 25
Pausing [33] from SpasticPauserTask 29
Pausing [44] from SpasticPauserTask 23
Pausing [24] from SpasticPauserTask 9
Pausing [17] from SpasticPauserTask 33
Pausing [46] from SpasticPauserTask 7
Pausing [51] from SpasticPauserTask 14
Pausing [50] from SpasticPauserTask 12
Pausing [70] from SpasticPauserTask 26
Pausing [78] from SpasticPauserTask 10
Pausing [57] from SpasticPauserTask 17
Pausing [64] from SpasticPauserTask 20
Pausing [75] from SpasticPauserTask 21
Pausing [61] from SpasticPauserTask 15
Pausing [96] from SpasticPauserTask 15
Pausing [39] from SpasticPauserTask 22
Pausing [35] from SpasticPauserTask 24
Pausing [93] from SpasticPauserTask 24
Pausing [43] from SpasticPauserTask 4
Pausing [91] from SpasticPauserTask 4
Pausing [32] from SpasticPauserTask 29
Pausing [31] from SpasticPauserTask 23
Pausing [29] from SpasticPauserTask 9
Pausing [10] from SpasticPauserTask 33
Pausing [18] from SpasticPauserTask 7
Pausing [69] from SpasticPauserTask 14
Pausing [58] from SpasticPauserTask 12
Pausing [54] from SpasticPauserTask 26
Pausing [49] from SpasticPauserTask 10
Pausing [41] from SpasticPauserTask 17
Pausing [98] from SpasticPauserTask 20
Pausing [79] from SpasticPauserTask 20
Pausing [4] from SpasticPauserTask 30
Pausing [95] from SpasticPauserTask 15
Pausing [59] from SpasticPauserTask 15
Pausing [27] from SpasticPauserTask 31
Pausing [92] from SpasticPauserTask 24
Pausing [34] from SpasticPauserTask 25
Pausing [90] from SpasticPauserTask 4
Pausing [89] from SpasticPauserTask 29
Pausing [88] from SpasticPauserTask 23
Pausing [87] from SpasticPauserTask 9
Pausing [86] from SpasticPauserTask 33
Pausing [85] from SpasticPauserTask 7
Pausing [3] from SpasticPauserTask 7
Pausing [83] from SpasticPauserTask 12
Pausing [82] from SpasticPauserTask 26
Pausing [81] from SpasticPauserTask 10
Pausing [80] from SpasticPauserTask 17
Pausing [97] from SpasticPauserTask 21
Pausing [73] from SpasticPauserTask 20
Pausing [63] from SpasticPauserTask 30
Pausing [94] from SpasticPauserTask 22
Pausing [36] from SpasticPauserTask 15
Pausing [45] from SpasticPauserTask 15
Pausing [20] from SpasticPauserTask 24
Pausing [53] from SpasticPauserTask 25
Pausing [38] from SpasticPauserTask 4
Pausing [12] from SpasticPauserTask 29
Pausing [14] from SpasticPauserTask 23
Pausing [22] from SpasticPauserTask 9
Pausing [37] from SpasticPauserTask 9
Pausing [84] from SpasticPauserTask 14
Pausing [60] from SpasticPauserTask 7
Pausing [56] from SpasticPauserTask 12
Pausing [52] from SpasticPauserTask 26
Pausing [48] from SpasticPauserTask 10
Pausing [42] from SpasticPauserTask 17
Pausing [40] from SpasticPauserTask 21
Pausing [26] from SpasticPauserTask 20
Pausing [21] from SpasticPauserTask 30
Pausing [0] from SpasticPauserTask 22
Pausing [7] from SpasticPauserTask 31
Pausing [28] from SpasticPauserTask 15
Pausing [23] from SpasticPauserTask 24
Paused [6] from SpasticPauserTask 24
Pausing [68] from SpasticPauserTask 29
Pausing [8] from SpasticPauserTask 23
Pausing [13] from SpasticPauserTask 33
Pausing [25] from SpasticPauserTask 9
Pausing [2] from SpasticPauserTask 14
Paused [62] from SpasticPauserTask 12
Paused [71] from SpasticPauserTask 26
Paused [76] from SpasticPauserTask 7
Paused [1] from SpasticPauserTask 10
Paused [55] from SpasticPauserTask 17
Paused [17] from SpasticPauserTask 17
Paused [19] from SpasticPauserTask 20
Paused [77] from SpasticPauserTask 30
Paused [67] from SpasticPauserTask 22
Paused [70] from SpasticPauserTask 22
Paused [74] from SpasticPauserTask 31
Pausing [16] from SpasticPauserTask 4
Paused [65] from SpasticPauserTask 25
Paused [99] from SpasticPauserTask 15
Paused [5] from SpasticPauserTask 29
Paused [72] from SpasticPauserTask 23
Paused [15] from SpasticPauserTask 24
Paused [66] from SpasticPauserTask 9
Paused [11] from SpasticPauserTask 14
Paused [30] from SpasticPauserTask 33
Paused [33] from SpasticPauserTask 12
Paused [44] from SpasticPauserTask 7
Paused [24] from SpasticPauserTask 26
Paused [47] from SpasticPauserTask 16
Paused [46] from SpasticPauserTask 17
Paused [51] from SpasticPauserTask 10
Paused [50] from SpasticPauserTask 20
Paused [58] from SpasticPauserTask 10
Paused [78] from SpasticPauserTask 22
Paused [57] from SpasticPauserTask 31
Paused [64] from SpasticPauserTask 4
Paused [75] from SpasticPauserTask 30
Paused [61] from SpasticPauserTask 25
Paused [4] from SpasticPauserTask 25
Paused [39] from SpasticPauserTask 23
Paused [35] from SpasticPauserTask 15
Paused [93] from SpasticPauserTask 9
Paused [43] from SpasticPauserTask 24
Paused [91] from SpasticPauserTask 33
Paused [90] from SpasticPauserTask 33
Paused [89] from SpasticPauserTask 33
Paused [88] from SpasticPauserTask 33
Paused [87] from SpasticPauserTask 33
Paused [18] from SpasticPauserTask 17
Paused [69] from SpasticPauserTask 16
Paused [9] from SpasticPauserTask 21
Paused [54] from SpasticPauserTask 10
Paused [49] from SpasticPauserTask 20
Paused [41] from SpasticPauserTask 31
Paused [98] from SpasticPauserTask 22
Paused [79] from SpasticPauserTask 4
Paused [96] from SpasticPauserTask 29
Paused [95] from SpasticPauserTask 25
Paused [59] from SpasticPauserTask 30
Paused [27] from SpasticPauserTask 15
Paused [92] from SpasticPauserTask 23
Paused [34] from SpasticPauserTask 9
Paused [32] from SpasticPauserTask 14
Paused [31] from SpasticPauserTask 7
Paused [29] from SpasticPauserTask 12
Paused [10] from SpasticPauserTask 26
Paused [86] from SpasticPauserTask 33
Paused [85] from SpasticPauserTask 24
Paused [3] from SpasticPauserTask 16
Paused [83] from SpasticPauserTask 21
Paused [82] from SpasticPauserTask 17
Paused [81] from SpasticPauserTask 10
Paused [80] from SpasticPauserTask 20
Paused [40] from SpasticPauserTask 10
Paused [73] from SpasticPauserTask 4
Paused [63] from SpasticPauserTask 22
Paused [0] from SpasticPauserTask 22
Paused [36] from SpasticPauserTask 25
Paused [28] from SpasticPauserTask 20
Paused [20] from SpasticPauserTask 15
Paused [38] from SpasticPauserTask 9
Paused [12] from SpasticPauserTask 14
Paused [14] from SpasticPauserTask 7
Paused [22] from SpasticPauserTask 23
Paused [37] from SpasticPauserTask 26
Paused [84] from SpasticPauserTask 33
Paused [60] from SpasticPauserTask 12
Paused [56] from SpasticPauserTask 24
Paused [52] from SpasticPauserTask 21
Paused [48] from SpasticPauserTask 17
Paused [42] from SpasticPauserTask 16
Paused [97] from SpasticPauserTask 31
Paused [26] from SpasticPauserTask 10
Paused [21] from SpasticPauserTask 4
Paused [94] from SpasticPauserTask 29
Paused [7] from SpasticPauserTask 22
Paused [45] from SpasticPauserTask 30
Paused [23] from SpasticPauserTask 20
Paused [53] from SpasticPauserTask 25
Paused [68] from SpasticPauserTask 15
Paused [8] from SpasticPauserTask 14
Paused [13] from SpasticPauserTask 9
Paused [25] from SpasticPauserTask 7
Paused [2] from SpasticPauserTask 23
Paused [16] from SpasticPauserTask 26
(re?)Starting from StartCancellerTask 24
(re?)Started from StartCancellerTask 24
Resuming from StartResumerTask 23
Resume from StartResumerTask 23
15:32 began
15:32 finished
25:15 began
25:15 finished
24:33 began
24:33 finished
9:34 began
9:34 finished
26:16 began
26:16 finished
11:35 began
11:35 finished
30:36 began
30:36 finished
24:17 began
24:17 finished
22:37 began
22:37 finished
10:38 began
10:38 finished
10:18 began
10:18 finished
23:39 began
23:39 finished
11:40 began
11:40 finished
14:41 began
14:41 finished
12:19 began
12:19 finished
10:42 began
10:42 finished
21:43 began
21:43 finished
29:20 began
29:20 finished
21:44 began
21:44 finished
21:45 began
21:45 finished
24:21 began
24:21 finished
16:46 began
16:46 finished
4:47 began
4:47 finished
21:22 began
21:22 finished
24:48 began
24:48 finished
15:49 began
15:49 finished
31:23 began
31:23 finished
20:50 began
20:50 finished
26:51 began
26:51 finished
7:52 began
7:52 finished
4:24 began
4:24 finished
33:53 began
33:53 finished
16:54 began
16:54 finished
4:25 began
4:25 finished
29:55 began
29:55 finished
12:56 began
12:56 finished
31:26 began

...etc.
```