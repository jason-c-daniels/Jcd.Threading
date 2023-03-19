using Nito.AsyncEx;

namespace Jcd.Tasks.Examples.BlockingTaskProcessor;


public static class SingleBlockingTaskProcessor2
{
    private static readonly Type MyType = typeof(SingleBlockingTaskProcessor2);

    /// <summary>
    /// Runs the same simulation as in <see cref="AsyncLockOnly"/> using a single <see cref="BlockingTaskProcessor"/>
    /// to queue up only the non-ping calls. <see cref="BlockingTaskProcessor"/> executes them sequentially blocking until
    /// completion. The pings are executed as soon as the <see cref="AsyncLock"/> is released.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For systems with servers that must handle only one call at a time, and for which the client (this app)
    /// needs certain information in an expedient manner, this is one approach that will work.
    ///</para>
    /// </remarks>
    public static async Task Run(int lifespanInSeconds=60, int pingFrequencyInMs=1000, int maxTasks=50, int taskSchedulingFrequencyInMs=100, int minLatencyInMs=10,int maxAdditionalLatencyInMs=15,bool logRequestScheduling = true)
    {
        Server.SetLatency(minLatencyInMs,maxAdditionalLatencyInMs);
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("One queue. No excessive locking. Pings sent nearly immediately.");
        Console.WriteLine("-----------------------------------------------");
        await Console.Out.FlushAsync();
        
        var makeCallsTask = CreateMakeLotsOfCallsTask(taskSchedulingFrequencyInMs,lifespanInSeconds,maxTasks,logRequestScheduling);
        var pingTask = CreatePingTask(pingFrequencyInMs,lifespanInSeconds,logRequestScheduling);

        // wait for the tasks to finish regardless if their completion status.
        await Task.WhenAll(makeCallsTask.TryWaitAsync(),
            pingTask.TryWaitAsync()
            );
        
        // cancellation token expired. Cancel pending tasks.
        CommandProcessor.Cancel();
        Server.CancelAllRequests();
    }

    private static readonly Tasks.BlockingTaskProcessor CommandProcessor = new();
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
                if (log) Console.WriteLine($"Scheduling {numberOfMakeRequestTasks} concurrent {nameof(FakeServerProxy.SendRequest)} calls. Current {nameof(FakeServerProxy.SendRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value} and Command Queue Length of {CommandProcessor.QueueLength}");
                if (cts.IsCancellationRequested) throw new OperationCanceledException();
                // not awaiting as this forces the scheduling thread to wait until all requests are finished. 
                // we want to simulate multiple threads making excessive demands on the system.
                Task.WhenAll(
                    Enumerable.Range(0, numberOfMakeRequestTasks).Select(x =>
                        CommandProcessor.EnqueueAsyncActionAsync(async () =>
                        {
                            var buff = new byte[20];
                            rnd.NextBytes(buff);
                            if (cts.IsCancellationRequested) throw new OperationCanceledException();
                            await Server.SendRequest(x, buff);
                            await Task.Yield();
                        })
                    ));
                await Task.Yield();
            }
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
        });
    }
    private static Task CreatePingTask(double scheduleDelayInMs = 1000, double lifeSpanInSeconds = 120, bool logRequestScheduling=true)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        var pingCount = new SynchronizedValue<int>(0);

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

        void SchedulePing(SynchronizedValue<int> synchronizedValue, Random rnd, DateTime scheduledAt)
        {
            if (logRequestScheduling) Console.WriteLine($"{DateTime.Now:O} Scheduling Ping Request. Current {nameof(FakeServerProxy.SendRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value} and Command Queue Length of {CommandProcessor.QueueLength}");
            if (logRequestScheduling) Console.Out.Flush();
            // Schedule a ping. We won't await the result here as that'll
            // block the ping scheduler. This is to simulate a ping whose
            // returned data is received and handled in another thread.
            // this is just the scheduler.
            Task.Run(async () => { await ExecutePing(synchronizedValue, rnd, scheduledAt); }, cts.Token);
        }

        return Task.Run(async () =>
        {
            Console.WriteLine($"{nameof(CreatePingTask)} running, scheduling {nameof(FakeServerProxy.SendRequest)} tasks every {scheduleDelayInMs:n2} ms");
            await Console.Out.FlushAsync();
            var rnd = new Random();

            while (!cts.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(scheduleDelayInMs),cts.Token);
                if (cts.IsCancellationRequested) throw new OperationCanceledException();
                SchedulePing(pingCount, rnd, DateTime.Now);
                await Task.Yield();
            }
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
        });
    }
}