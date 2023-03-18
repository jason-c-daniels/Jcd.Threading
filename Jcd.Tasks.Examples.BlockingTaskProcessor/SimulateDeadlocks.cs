namespace Jcd.Tasks.Examples.BlockingTaskProcessor;

public static class SimulateDeadlocks
{
    /// <summary>
    /// Runs the deadlock simulation.
    /// </summary>
    /// <remarks>
    /// A lot of times people will forget to make their code "play nicely" with low throughput or high latency
    /// servers or devices they're communicating with. This example demonstrates a common naïve usage and
    /// doesn't use <see cref="BlockingTaskProcessor"/>. It shows the starting point on which a couple of potential
    /// solutions involving <see cref="BlockingTaskProcessor"/> may be based. This is by no means the only way to
    /// solve this problem. It's merely a use case which *might* be useful under some circumstances.
    /// </remarks>
    public static async Task Run(int lifespanInSeconds=60)
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("No queues. Massive deadlocking.");
        Console.WriteLine("-----------------------------------------------");
        await Console.Out.FlushAsync();
        
        var makeCallsTask = CreateMakeLotsOfCallsTask(lifeSpanInSeconds: lifespanInSeconds);
        var pingTask = CreatePingTask(lifeSpanInSeconds: lifespanInSeconds);

        // wait for the tasks to finish regardless if their completion status.
        await Task.WhenAll(makeCallsTask.TryWaitAsync(),
            pingTask.TryWaitAsync()
        );
    }

    private static readonly FakeServerProxy Server = new();
    
    private static Task CreateMakeLotsOfCallsTask(double scheduleDelayInMs = 100, double lifeSpanInSeconds = 120,
                                                  int numberOfMakeRequestTasks = 50)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        return Task.Run(async () =>
        {
            Console.WriteLine($"{nameof(CreateMakeLotsOfCallsTask)} running, scheduling {numberOfMakeRequestTasks} {nameof(FakeServerProxy.MakeRequest)} tasks every {scheduleDelayInMs:n2} ms");
            await Console.Out.FlushAsync();

            while (!cts.IsCancellationRequested)
            {
                var rnd = new Random();
                await Task.Delay(TimeSpan.FromMilliseconds(scheduleDelayInMs * 5), cts.Token);
                if (cts.IsCancellationRequested) throw new OperationCanceledException();
                
                Console.WriteLine(
                    $"Scheduling {numberOfMakeRequestTasks} concurrent {nameof(FakeServerProxy.MakeRequest)} calls. Current {nameof(FakeServerProxy.MakeRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value}");
                Task.WhenAll(
                    Enumerable.Range(0, numberOfMakeRequestTasks).Select(x =>
                        Task.Run(async () =>
                        {
                            var buff = new byte[20];
                            rnd.NextBytes(buff);
                            if (cts.IsCancellationRequested) throw new OperationCanceledException();
                            await Server.MakeRequest(x, buff);
                        }, cts.Token)
                    ));
            }
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
        });
    }
    private static Task CreatePingTask(double scheduleDelayInMs = 1000, double lifeSpanInSeconds = 120)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        var pingCount = new SynchronizedValue<int>(0);
        return Task.Run(async () =>
        {
            Console.WriteLine($"{nameof(CreatePingTask)} running, scheduling {nameof(FakeServerProxy.MakeRequest)} tasks every {scheduleDelayInMs:n2} ms");
            await Console.Out.FlushAsync();
            var rnd = new Random();

            while (!cts.IsCancellationRequested)
            {
                Console.WriteLine(
                    $"Scheduling Ping Request. Current {nameof(FakeServerProxy.MakeRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value}");
                await Console.Out.FlushAsync();
                await Task.Delay(TimeSpan.FromMilliseconds(scheduleDelayInMs),cts.Token);
                var buff = new byte[20];
                rnd.NextBytes(buff);
                var buff2 = new byte[20];
                rnd.NextBytes(buff2);
                var scheduledAt = DateTime.Now;
                // run the ping in a background thread. This is to simulate a UI or other
                // separate thread of a program periodically telling the communications
                // layer to get a status update. Usually we want these to preempt other traffic.
                // it will not for this example. In fact we'll see them start stacking up.
                Task.Run(async () =>
                {
                    Console.WriteLine($"Waiting to ping... concurrent ping backlog {pingCount.Value}");
                    await Console.Out.FlushAsync();
                    await pingCount.ChangeValueAsync((v) => v + 1); // increment the value
                    if (cts.IsCancellationRequested) throw new OperationCanceledException();
                    await Server.MakeRequest(314159, buff);
                    if (cts.IsCancellationRequested) throw new OperationCanceledException();
                    await Server.MakeRequest(314160, buff2);
                    await pingCount.ChangeValueAsync((v) => v - 1); // decrement the value
                    var backlog = pingCount.Value;
                    var finishedAt = DateTime.Now;
                    var elapsed = finishedAt - scheduledAt;
                    Console.WriteLine($"Pinged after {elapsed.TotalMilliseconds:n2}ms! concurrent ping backlog {backlog}");
                    await Console.Out.FlushAsync();
                }, cts.Token);
                await Console.Out.FlushAsync();
            }
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
        });
    }
}