// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Jcd.Tasks;
using Jcd.Tasks.Examples;

Console.WriteLine("Hello, World!");
Debug.WriteLine($"Main Thread {Environment.CurrentManagedThreadId}");
var q = new AsyncSerialCommandProcessor();
var q2 = new AsyncSerialCommandProcessor();
var d = new FakeDevice();
var ctsDB = DeviceBlasterTask();
var ctsDP = DevicePingTask();

//var ctsResumer1 = StartResumerTask(6.0);
//var ctsPauser1 = StartPauserTask(3.0);
//var ctsQueuer1 = StartQueuerTask();

//var ctsQueuer2 = StartQueuerTask(0.01,90);
//var ctsSpastic = SpasticPauserTask(Math.PI*(1+1d/3d),60);

while (//!ctsPauser1.IsCancellationRequested ||
       //!ctsQueuer1.IsCancellationRequested ||
       //!ctsQueuer2.IsCancellationRequested ||
       //!ctsResumer1.IsCancellationRequested ||
       !ctsDP.IsCancellationRequested ||
       !ctsDB.IsCancellationRequested
    ) await Task.Yield();

CancellationTokenSource StartQueuerTask(double busyWorkDelayInSeconds=Math.PI/100.0,double enqueueDelayInSeconds=0.2, double lifeSpanInSeconds=120)
{
    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
    Task.Run(async () =>
        {
            void Enqueue(long item, long thId)
            {
                Debug.WriteLine($"{thId}:{item} enqueuing : q.Length= {q.QueueLength}");
                Debug.Flush();
                q.Enqueue(async () =>
                {
                    Console.WriteLine($"{thId}:{item} began");
                    Console.Out.Flush();
                    await Task.Delay(TimeSpan.FromSeconds(busyWorkDelayInSeconds));
                    Console.WriteLine($"{thId}:{item} finished");
                    Console.Out.Flush();
                });
                Debug.WriteLine($"{thId}:{item} enqueued");
                Debug.Flush();
            }

            long i = 0;
            while (!cts.IsCancellationRequested)
            {
                Enqueue(i++, Environment.CurrentManagedThreadId);
                await Task.Delay(TimeSpan.FromSeconds(enqueueDelayInSeconds));
            }
        })
        ;//.Start();
    return cts;
}

CancellationTokenSource StartPauserTask(double delayInSeconds=Math.PI-0.1,double lifeSpanInSeconds=120)
{
    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
    Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                if (!q.IsPaused)
                {
                    await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
                    Console.WriteLine($"Pausing from {nameof(StartPauserTask)} {Environment.CurrentManagedThreadId}");
                    Console.Out.Flush();
                    await q.PauseAsync();
                    Console.WriteLine($"Paused from {nameof(StartPauserTask)} {Environment.CurrentManagedThreadId}");
                    Console.Out.Flush();
                }
            }
        })
        ;//.Start();
    return cts;
}

CancellationTokenSource StartResumerTask(double delayInSeconds=Math.PI,double lifeSpanInSeconds=120)
{
    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
    Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                if (q.IsPaused)
                {
                    await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
                    Console.WriteLine($"Resuming from {nameof(StartResumerTask)} {Environment.CurrentManagedThreadId}");
                    Console.Out.Flush();
                    await q.ResumeAsync();
                    Console.WriteLine($"Resume from {nameof(StartResumerTask)} {Environment.CurrentManagedThreadId}");
                    Console.Out.Flush();
                }
            }
        })
        ;//.Start();
    return cts;
}

CancellationTokenSource SpasticPauserTask(double delayInSeconds=Math.PI*3,double lifeSpanInSeconds=120,int numberOfThreads=100)
{
    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
    Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
                await Task.WhenAll(
                    Enumerable.Range(0,numberOfThreads).Select(x=>
                        Task.Run(async () =>
                        {
                            await Task.Delay(TimeSpan.FromSeconds(delayInSeconds/2));
                            Console.WriteLine($"Pausing [{x}] from {nameof(SpasticPauserTask)} {Environment.CurrentManagedThreadId}");
                            Console.Out.Flush();
                            await q.PauseAsync();
                            Console.WriteLine($"Paused [{x}] from {nameof(SpasticPauserTask)} {Environment.CurrentManagedThreadId}");
                            Console.Out.Flush();
                        })
                    ));
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
            }
        })
        ;//.Start();
    return cts;
}

CancellationTokenSource DeviceBlasterTask(double delayInMs=Math.PI*3,double lifeSpanInSeconds=120,int numberOfThreads=300)
{
    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
    Task.Run(async () =>
        {
            Console.WriteLine($"{nameof(DeviceBlasterTask)}");
            await Console.Out.FlushAsync();

            while (!cts.IsCancellationRequested)
            {
                var rnd = new Random();
                await Task.Delay(TimeSpan.FromMilliseconds(delayInMs*5));
                await Task.WhenAll(
                    Enumerable.Range(0,numberOfThreads).Select(x=>
                        q.EnqueueAsync(async () =>
                        {
                            //Console.WriteLine($"Sending bytes for instance: {x}");
                            //await Console.Out.FlushAsync();
                            var buff = new byte[20];
                            rnd.NextBytes(buff);
                            await d.SendMessage(x, buff);
                        })
                    ));
            }
        })
        ;//.Start();
    return cts;
}

CancellationTokenSource DevicePingTask(double delayInMs=1000,double lifeSpanInSeconds=120)
{
    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
    SynchronizedValue<int> pingCount = new SynchronizedValue<int>(0);
    Task.Run(async () =>
        {
            Console.WriteLine($"{nameof(DevicePingTask)}");
            await Console.Out.FlushAsync();
            var rnd = new Random();

            while (!cts.IsCancellationRequested)
            {
                Console.WriteLine($"Enqueuing Ping TaskQueueLength {q.QueueLength}");
                await Console.Out.FlushAsync();
                await Task.Delay(TimeSpan.FromMilliseconds(delayInMs));
                var buff = new byte[20];
                rnd.NextBytes(buff);
                var buff2 = new byte[20];
                rnd.NextBytes(buff2);
                q2.Enqueue(async () =>
                {
                    Console.WriteLine($"Waiting to ping... ping backlog {pingCount.Value}");
                    pingCount.ChangeValue((v)=> v+1); // increment the value
                    await Console.Out.FlushAsync();
                    await d.SendMessage(314159, buff);
                    await d.SendMessage(314160, buff2);
                    pingCount.ChangeValue((v)=> v-1); // decrement the value
                    Console.WriteLine($"Pinged! ping backlog {pingCount.Value}");
                    await Console.Out.FlushAsync();
                });
                await Console.Out.FlushAsync();
            }
        })
        ;//.Start();
    return cts;
}


async Task SomeTests()
{
// cannot await these tasks until the queue processor has started!
    q.Enqueue(() => Foo2(-1));
    q.Enqueue(() => Foo2(-2));
    q.Enqueue(() => Foo2(-3));
    q.Enqueue(Foo);
    var foo = new SynchronizedValue<int>(1);

    q.StartProcessing();
    var sw = Stopwatch.StartNew();
    const int countToAdd = 10000;
    for (var i = 0; i < countToAdd; i++)
    {
        var x = i;
        q.Enqueue(() => Foo2(x));
    }

    sw.Stop();
    Console.WriteLine($"Adding {countToAdd} tasks took {sw.ElapsedMilliseconds:n2}ms");
    var waitCount = 0;
    while (q is { IsStarted: true } && waitCount < 100)
    {
        waitCount++;
        if (waitCount == 10)
        {
            q.Pause();
            Console.WriteLine("Pausing");
        }

        if (waitCount is > 10 and <= 12) q.Enqueue(() => Console.WriteLine("I was injected during the pause."));
        if (waitCount == 12)
        {
            q.Resume();
            Console.WriteLine("Resuming");
        }

        if (waitCount > 15) q.Enqueue(() => Console.WriteLine("I was injected after the first resume."));
        if (waitCount == 20)
        {
            // restart everything after the purge.
            Console.WriteLine("Canceling all tasks");
            q.Cancel();
            Console.WriteLine($"Setting the processing to paused.");
            q.Pause();
            Console.WriteLine("Restarting processing thread (paused though).");
            q.StartProcessing();
            Console.WriteLine($"Queue status: N={q.QueueLength}; Started:{q.IsStarted}; Paused:{q.IsPaused} ");
            q.Enqueue(() => Console.WriteLine("I was injected after the second pause."));
        }

        if (waitCount > 20) q.Enqueue(() => Console.WriteLine("I was injected after the second pause."));
        if (waitCount == 25)
        {
            Console.WriteLine($"Resuming with {q.QueueLength} items in the queue.");
            Console.WriteLine($"Queue status: N={q.QueueLength}; Started:{q.IsStarted}; Paused:{q.IsPaused} ");
            Console.Out.Flush();
            q.Resume();
            q.Enqueue(() => Console.WriteLine("I was injected after the second resume."));

            Console.WriteLine($"Queue status: N={q.QueueLength}; Started:{q.IsStarted}; Paused:{q.IsPaused} ");
            Console.WriteLine($"Waiting for the thread to startup.");
            await Task.Delay(300);
            Console.WriteLine($"Queue status: N={q.QueueLength}; Started:{q.IsStarted}; Paused:{q.IsPaused} ");
        }

        if (waitCount > 25)
        {
            for (var z = 0; z < 10; z++)
            {
                var title = $"{waitCount}+{z} injected.";
                q.Enqueue(() => Console.WriteLine(title));
            }
        }

        if (waitCount > 75)
        {
            Console.WriteLine($"Pass {waitCount} completed! Exiting the loop!");
            break;
        }
    }

    if (q.HasTasks) q.Pause();
    Console.WriteLine(!q.HasTasks ? $"All tasks consumed" : $"Items remaining {q.QueueLength}");
    Console.WriteLine($"Shutting down.");
    q.Cancel();
}

//q.Dispose();
return 0;


Task<int> Foo()
{
    return Task.FromResult(12);
}

async Task<int> Foo2(int i)
{
    var ai = Math.Abs(i);
    Console.WriteLine($"{i} Starting");
    await Task.Delay(100+((ai*7) % 5));
    Console.WriteLine($"{i} Returning");
    return i*10;
}
