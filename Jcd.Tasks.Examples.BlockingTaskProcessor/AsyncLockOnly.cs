using Nito.AsyncEx;

namespace Jcd.Tasks.Examples.BlockingTaskProcessor;

public static class AsyncLockOnly
{
    private static readonly Type MyType = typeof(AsyncLockOnly);
    public static readonly SynchronizedValue<int> PingCount = new (0);

    /// <summary>
    /// Runs the simulated calls relying solely on <see cref="AsyncLock"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A lot of times people will forget to make their code "play nicely" with low throughput or high latency
    /// servers or devices they're communicating with. Other times they make mistakes when trying to play nicely.
    /// </para>
    /// <para>
    /// This example demonstrates a common naïve usage of <see cref="AsyncLock"/> to mitigate overloading a server.
    /// or device. It is the starting point on which a couple of potential solutions involving <see cref="BlockingTaskProcessor"/>
    /// may be based.
    /// </para>
    /// </remarks>
    public static async Task Run(int lifespanInSeconds=60, int pingFrequencyInMs=1000, int maxTasks=50, int taskSchedulingFrequencyInMs=100, int minLatencyInMs=10,int maxAdditionalLatencyInMs=15,bool logRequestScheduling = true)
    {
        Server.SetLatency(minLatencyInMs,maxAdditionalLatencyInMs);
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("No queues. Massive deadlocking.");
        Console.WriteLine("-----------------------------------------------");
        await Console.Out.FlushAsync();
        
        var makeCallsTask = CreateMakeLotsOfCallsTask(taskSchedulingFrequencyInMs,lifespanInSeconds,maxTasks,logRequestScheduling);
        var pingTask = CreatePingTask(pingFrequencyInMs,lifespanInSeconds,logRequestScheduling);

        // wait for the tasks to finish regardless if their completion status.
        await Task.WhenAll(makeCallsTask.TryWaitAsync(),
            pingTask.TryWaitAsync()
        );
        
        // cancellation token expired. Cancel pending tasks.
        Server.CancelAllRequests();
    }

    private static readonly FakeServerProxy Server = new();
    
    private static Task CreateMakeLotsOfCallsTask(double scheduleDelayInMs = 100, double lifeSpanInSeconds = 120,
                                                  int numberOfMakeRequestTasks = 50, bool log=true)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        return Task.Run(async () =>
        {
            Console.WriteLine($"{nameof(CreateMakeLotsOfCallsTask)} running, scheduling {numberOfMakeRequestTasks} {nameof(FakeServerProxy.SendRequest)} tasks every {scheduleDelayInMs:n2} ms");
            await Console.Out.FlushAsync();

            while (!cts.IsCancellationRequested)
            {
                var rnd = new Random();
                await Task.Delay(TimeSpan.FromMilliseconds(scheduleDelayInMs * 5), cts.Token);
                if (cts.IsCancellationRequested) throw new OperationCanceledException();
                
                if (log) Console.WriteLine(
                    $"Scheduling {numberOfMakeRequestTasks} concurrent {nameof(FakeServerProxy.SendRequest)} calls. Current {nameof(FakeServerProxy.SendRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value}");
                Task.WhenAll(
                    Enumerable.Range(0, numberOfMakeRequestTasks).Select(x =>
                        Task.Run(async () =>
                        {
                            var buff = new byte[20];
                            rnd.NextBytes(buff);
                            if (cts.IsCancellationRequested) throw new OperationCanceledException();
                            await Server.SendRequest(x, buff);
                            await Task.Yield();
                        }, cts.Token)
                    ));
                await Task.Yield();
            }
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
        });
    }
    private static Task CreatePingTask(double scheduleDelayInMs = 1000, double lifeSpanInSeconds = 120, bool logRequestScheduling=true)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));

        async Task ExecutePing(SynchronizedValue<int> pingBacklog, Random rnd, DateTime scheduledAt)
        {
            try
            {
                if (logRequestScheduling)
                    Console.WriteLine(
                        $"{DateTime.Now:O} - {MyType.Name}: Starting to ping... concurrent ping backlog {pingBacklog.Value}");
                await Console.Out.FlushAsync();
                var myPosition = await pingBacklog.ChangeValueAsync((v) => v + 1); // increment the value
                var startedAt = DateTime.Now;
                var buff = new byte[20];
                rnd.NextBytes(buff);
                var buff2 = new byte[20];
                rnd.NextBytes(buff2);
                // let's read two values from the server but don't care about the order they're returned in.
                // yes our two calls introduce unwanted locking... but some programmers actually do this.
                if (cts.IsCancellationRequested) throw new OperationCanceledException();
                await Task.WhenAll(new[]
                {
                    Server.SendRequest(314159, buff),
                    Server.SendRequest(314160, buff2)
                });
                if (cts.IsCancellationRequested) throw new OperationCanceledException();
                var finishedAt = DateTime.Now;
                var sinceStarted = finishedAt - startedAt;
                var sinceScheduled = finishedAt - scheduledAt;
                await pingBacklog.ChangeValueAsync((v) => v - 1); // decrement the value
                var backlog = pingBacklog.Value;
                Console.WriteLine(
                    $"{DateTime.Now:O} - {MyType.Name}: Ping completed {sinceScheduled.TotalMilliseconds:n2}ms after scheduling, and {sinceStarted.TotalMilliseconds:n2}ms after starting. Concurrent ping backlog {backlog}");
                await Console.Out.FlushAsync();
                await Task.Yield();
            }
            catch (OperationCanceledException)
            {
                // Decrement the count so its accurate.
                await pingBacklog.ChangeValueAsync((v) => v - 1); // decrement the value
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{MyType.Name}: Error during {nameof(ExecutePing)} : {ex.Message}");
                await pingBacklog.ChangeValueAsync((v) => v - 1); // decrement the value
            }
        }

        void SchedulePing(SynchronizedValue<int> pingBacklog, Random rnd, DateTime scheduledAt,
                          CancellationTokenSource cancellationTokenSource)
        {
            if (logRequestScheduling) Console.WriteLine($"{DateTime.Now:O} Scheduling Ping Request. Current {nameof(FakeServerProxy.SendRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value}");
            if (logRequestScheduling) Console.Out.Flush();
            // run the ping in a background thread. This is to simulate a UI or other
            // separate thread of a program periodically telling the communications
            // layer to get a status update. Usually we want these to preempt other traffic.
            // it will not for this example. In fact we'll see them start stacking up.
            Task.Run(async () => { await ExecutePing(pingBacklog, rnd, scheduledAt); }, cancellationTokenSource.Token);
        }

        return Task.Run(async () =>
        {
            Console.WriteLine($"{nameof(CreatePingTask)} running, scheduling {nameof(FakeServerProxy.SendRequest)} tasks every {scheduleDelayInMs:n2} ms");
            await Console.Out.FlushAsync();
            var rnd = new Random();

            while (!cts.IsCancellationRequested)
            {
                if (cts.IsCancellationRequested) throw new OperationCanceledException();
                await Task.Delay(TimeSpan.FromMilliseconds(scheduleDelayInMs),cts.Token);
                SchedulePing(PingCount, rnd, DateTime.Now, cts);
                await Task.Yield();
            }
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
        }, cts.Token);
    }
}