namespace Jcd.Tasks.Examples.BlockingTaskProcessor;


public static class SingleBlockingTaskProcessor2
{
    /// <summary>
    /// Runs the same simulation as in <see cref="SimulateDeadlocks"/> using a single <see cref="BlockingTaskProcessor"/>
    /// to queue up only the non-ping calls, executing pings as they come in.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Another possible solution a developer might consider is queuing only non-ping calls.
    /// This has the advantage of making pings happen faster.
    ///</para>
    /// </remarks>
    public static async Task Run(int lifespanInSeconds=60, int pingFrequencyInMs=1000, int maxTasks=50, int taskSchedulingFrequencyInMs=100, int minLatencyInMs=10,int maxAdditionalLatencyInMs=15,bool logRequestScheduling = true)
    {
        Server.SetLatency(minLatencyInMs,maxAdditionalLatencyInMs);
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("One queue. No deadlocking. Pings sent nearly immediately.");
        Console.WriteLine("-----------------------------------------------");
        await Console.Out.FlushAsync();
        
        var makeCallsTask = CreateMakeLotsOfCallsTask(taskSchedulingFrequencyInMs,lifespanInSeconds,maxTasks,logRequestScheduling);
        var pingTask = CreatePingTask(pingFrequencyInMs,lifespanInSeconds);

        // wait for the tasks to finish regardless if their completion status.
        await Task.WhenAll(makeCallsTask.TryWaitAsync(),
            pingTask.TryWaitAsync()
            );
        
        // cancellation token expired. Cancel pending tasks.
        CommandProcessor.Cancel();
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
                        })
                    ));
            }
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
        });
    }
    private static Task CreatePingTask(double scheduleDelayInMs = 1000, double lifeSpanInSeconds = 120)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        var pingCount = new SynchronizedValue<int>(0);

        async Task ExecutePing(SynchronizedValue<int> synchronizedValue, Random rnd, DateTime scheduledAt)
        {
            Console.WriteLine($"Waiting to ping... concurrent ping backlog {synchronizedValue.Value}");
            await Console.Out.FlushAsync();
            var buff = new byte[20];
            rnd.NextBytes(buff);
            var buff2 = new byte[20];
            rnd.NextBytes(buff2);
            await synchronizedValue.ChangeValueAsync((v) => v + 1); // increment the value
            // let's read two values from the server but not care about the order they're returned in.
            // yes our two calls introduce unwanted locking... but some programmers actually do this.
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
            await Task.WhenAll(new[]
            {
                Server.SendRequest(314159, buff),
                Server.SendRequest(314160, buff2)
            });
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
            await synchronizedValue.ChangeValueAsync((v) => v - 1); // decrement the value
            var backlog = synchronizedValue.Value;
            var finishedAt = DateTime.Now;
            var elapsed = finishedAt - scheduledAt;
            Console.WriteLine($"Pinged after {elapsed.TotalMilliseconds:n2}ms! concurrent ping backlog {backlog}");
            await Console.Out.FlushAsync();
        }

        void SchedulePing(SynchronizedValue<int> synchronizedValue, Random rnd, DateTime scheduledAt)
        {
            // Schedule a ping. We won't await the result here as that'll
            // block the ping scheduler. This is to simulate a ping whose
            // returned data is received and handled in another thread.
            // this is just the scheduler.
            Task.Run(async () => { await ExecutePing(synchronizedValue, rnd, scheduledAt); });
        }

        return Task.Run(async () =>
        {
            Console.WriteLine($"{nameof(CreatePingTask)} running, scheduling {nameof(FakeServerProxy.SendRequest)} tasks every {scheduleDelayInMs:n2} ms");
            await Console.Out.FlushAsync();
            var rnd = new Random();

            while (!cts.IsCancellationRequested)
            {
                Console.WriteLine(
                    $"Scheduling Ping Request. Current {nameof(FakeServerProxy.SendRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value} and Command Queue Length of {CommandProcessor.QueueLength}");
                await Console.Out.FlushAsync();
                await Task.Delay(TimeSpan.FromMilliseconds(scheduleDelayInMs),cts.Token);
                if (cts.IsCancellationRequested) throw new OperationCanceledException();
                SchedulePing(pingCount, rnd, DateTime.Now);
                await Console.Out.FlushAsync();
            }
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
        });
    }
}