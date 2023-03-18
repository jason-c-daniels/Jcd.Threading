using Nito.AsyncEx;

namespace Jcd.Tasks.Examples.BlockingTaskProcessor;

public static class SingleBlockingTaskProcessor
{
    /// <summary>
    /// Runs the same simulation as in <see cref="SimulateDeadlocks"/> using a single <see cref="BlockingTaskProcessor"/>
    /// to queue up the calls and execute in sequence.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A possible solution a developer might consider is just queuing ALL request without thought as to the
    /// intention behind the request. This simulates that attempt with a <see cref="BlockingTaskProcessor"/>
    /// We see that the <see cref="AsyncLock"/> deadlocks are certainly gone. Also we're no longer abusing
    /// the thread pool (which is also a problem in <see cref="SimulateDeadlocks"/>). And both of those facts
    /// very good!
    ///</para>
    /// <para>
    /// But, it doesn't solve the ping problem. We do pings because we want to know if there's a potential problem.
    /// This is either communicated in a returned status, or our attempt at communication timing out. And in this
    /// solution they're still significantly delayed for processing. For a system that has to make decisions such
    /// as "do I restart the server? it's not replied to a ping yet." this is a huge problem because we don't
    /// know why we've not yet gotten the response. Is **the server** laggy? Is the server down? Have **we**
    /// swamped the command queue? We don't know without monitoring our task processor, and even then there's
    /// not much we can do about it without taking other measures.
    ///</para>
    /// <para>
    /// So, while this is better, and possibly suitable for some circumstances, it won't work for the
    /// *"near real time"* communications and monitoring just described.
    ///</para>
    /// </remarks>
    public static async Task Run(int lifespanInSeconds=60)
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("One queue. No deadlocking. Pings severely delayed.");
        Console.WriteLine("-----------------------------------------------");
        await Console.Out.FlushAsync();
        
        var makeCallsTask = CreateMakeLotsOfCallsTask(lifeSpanInSeconds: lifespanInSeconds);
        var pingTask = CreatePingTask(lifeSpanInSeconds: lifespanInSeconds);

        // wait for the tasks to finish regardless if their completion status.
        await Task.WhenAll(makeCallsTask.TryWaitAsync(),
            pingTask.TryWaitAsync()
            );
        
        // cancellation token expired. Cancel pending tasks.
        CommandProcessor.Cancel();
    }

    private static readonly Tasks.BlockingTaskProcessor CommandProcessor = new();
    private static readonly FakeServerProxy Server = new();
    
    private static Task CreateMakeLotsOfCallsTask(double scheduleDelayInMs = Math.PI * 300, double lifeSpanInSeconds = 120,
                                                  int numberOfMakeRequestTasks = 300)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        return Task.Run(async () =>
        {
            Console.WriteLine($"{nameof(CreateMakeLotsOfCallsTask)}");
            await Console.Out.FlushAsync();

            while (!cts.IsCancellationRequested)
            {
                var rnd = new Random();
                await Task.Delay(TimeSpan.FromMilliseconds(scheduleDelayInMs * 5), cts.Token);
                Console.WriteLine(
                    $"Scheduling {numberOfMakeRequestTasks} concurrent {nameof(FakeServerProxy.MakeRequest)} calls. Current {nameof(FakeServerProxy.MakeRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value}");
                await Task.WhenAll(
                    Enumerable.Range(0, numberOfMakeRequestTasks).Select(x =>
                        CommandProcessor.EnqueueActionAsync(async () =>
                        {
                            var buff = new byte[20];
                            rnd.NextBytes(buff);
                            await Server.MakeRequest(x, buff);
                        })
                    ));
            }
        });
    }
    private static Task CreatePingTask(double delayInMs = 1000, double lifeSpanInSeconds = 120)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        var pingCount = new SynchronizedValue<int>(0);
        return Task.Run(async () =>
        {
            Console.WriteLine($"{nameof(CreatePingTask)}");
            await Console.Out.FlushAsync();
            var rnd = new Random();

            while (!cts.IsCancellationRequested)
            {
                Console.WriteLine(
                    $"Scheduling Ping Request. Current {nameof(FakeServerProxy.MakeRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value}");
                await Console.Out.FlushAsync();
                await Task.Delay(TimeSpan.FromMilliseconds(delayInMs));
                var buff = new byte[20];
                rnd.NextBytes(buff);
                var buff2 = new byte[20];
                rnd.NextBytes(buff2);
                
                // Schedule a ping. We won't await the result here as that'll
                // block the ping scheduler. This is to simulate a ping whose
                // returned data is received and handled in another thread.
                // this is just the scheduler.
                CommandProcessor.EnqueueAction(async () =>
                {
                    Console.WriteLine($"Waiting to ping... concurrent ping backlog {pingCount.Value}");
                    await Console.Out.FlushAsync();
                    await pingCount.ChangeValueAsync((v) => v + 1); // increment the value
                    await Server.MakeRequest(314159, buff);
                    await Server.MakeRequest(314160, buff2);
                    await pingCount.ChangeValueAsync((v) => v - 1); // decrement the value
                    Console.WriteLine($"Pinged! concurrent ping backlog {pingCount.Value}");
                    await Console.Out.FlushAsync();
                });
                await Console.Out.FlushAsync();
            }
        });
    }
}