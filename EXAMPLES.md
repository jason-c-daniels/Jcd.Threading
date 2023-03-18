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

await Task.WhenAll(
    reportValue.TryWaitAsync(),
    setTo20Task.TryWaitAsync(),
    decBy4Task.TryWaitAsync(),
    incrementTask.TryWaitAsync());

// now report their statuses.
Console.WriteLine($"reportValue.Status {reportValue.Status}");
Console.WriteLine($"setTo20Task.Status {setTo20Task.Status}");
Console.WriteLine($"decBy4Task.Status {decBy4Task.Status}");
Console.WriteLine($"incrementTask.Status {incrementTask.Status}");

return 0;
```

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


## ColdTask

Below, in code are a variety of ways to use `ColdTask`. It also provides the extension method
`IsCold` as shown below.

```csharp
using Jcd.Tasks;
using Jcd.Tasks.Examples;

//--------------------------------------------
// create a cold task from an action.
//--------------------------------------------
var ctA = ColdTask.FromAction(() => Console.WriteLine("I'm a cold task from an action."));
Console.WriteLine($"ctA.Status = {ctA.Status} | Is it a cold task? {ctA.IsCold()}");

// start the cold task.
ctA.Start();
Console.WriteLine($"Is ctA a cold task? {ctA.IsCold()}");
await ctA; // wait for it to finish. Should do the output between ctA.Start() and here.
// don't do this though, starting it a second time gives an exception.
Console.Write("Try starting it again! (it won't work); ");
try {ctA.Start(); } catch(Exception ex){Console.WriteLine($"Bad Programmer Error: {ex.Message}");}
Console.WriteLine();

//--------------------------------------------
// create a cold task from an async action.
//--------------------------------------------
var ctaA = ColdTask.FromAsyncAction(async () =>
{
    await Task.Delay(1000);
    Console.WriteLine("I'm a cold task from an async action.");
});

// start the cold task.
ctaA.Start();
Console.WriteLine($"Is ctaA a cold task? {ctaA.IsCold()}");
await ctaA; // wait for it to finish. Should do the output between ctaA.Start() and here.

Console.WriteLine();

//--------------------------------------------
// create a cold task from a function
//--------------------------------------------
var ctF = ColdTask.FromFunc(() => TimesTen(10));
Console.WriteLine($"ctF.Status = {ctF.Status} | Is it a cold task? {ctF.IsCold()}");

// start the cold task.
ctF.Start();
Console.WriteLine($"Is ctF a cold task? {ctF.IsCold()}");
Console.WriteLine($"The result of the cold task is {await ctF}");

Console.WriteLine();

//--------------------------------------------
// create a cold task from an async function
//--------------------------------------------
var ctaF = ColdTask.FromAsyncFunc(async ()=>await TimesTenAsync(12));

Console.WriteLine($"ctaF.Status = {ctaF.Status} | Is it a cold task? {ctaF.IsCold()}");

// start the cold task.
ctaF.Start();
Console.WriteLine($"Is ctaF a cold task? {ctaF.IsCold()}");
Console.WriteLine($"The result of the cold task is {await ctaF}");

Console.WriteLine();


// another no-no, saved for the end. It'll hang the app.
var unstarted = ColdTask.FromAction(() => { /* This part is unimportant. */ });
Console.WriteLine($"unstarted.Status = {unstarted.Status} | Is it a cold task? {unstarted.IsCold()}");
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

### Output from the ColdTask Example
```text
ctA.Status = Created | Is it a cold task? True
Is ctA a cold task? False
I'm a cold task from an action.
Try starting it again! (it won't work); Bad Programmer Error: Start may not be c
alled on a task that has completed.
Is ctaA a cold task? False
I'm a cold task from an async action.

ctF.Status = Created | Is it a cold task? True
Is ctF a cold task? False
The result of the cold task is 100

ctaF.Status = Created | Is it a cold task? True
Is ctaF a cold task? False
The result of the cold task is 120

unstarted.Status = Created | Is it a cold task? True
Now we await the unstarted task and wait forever. (Press CTRL-C to end)
```

