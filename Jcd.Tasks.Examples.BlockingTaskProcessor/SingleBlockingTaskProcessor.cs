﻿using Nito.AsyncEx;

namespace Jcd.Tasks.Examples.BlockingTaskProcessor;

public static class SingleBlockingTaskProcessor
{
    private static readonly Type MyType = typeof(SingleBlockingTaskProcessor);

    /// <summary>
    /// Runs the same simulation as in <see cref="AsyncLockOnly"/> using a single <see cref="BlockingTaskProcessor"/>
    /// to queue up all of the calls. <see cref="BlockingTaskProcessor"/> executes them sequentially blocking until
    /// completion.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A possible solution a developer might consider is just queuing ALL request without thought as to the
    /// intention behind the request. This simulates that attempt with a <see cref="BlockingTaskProcessor"/>
    /// acting as the queue and queue item processor. With this attempt we see that the <see cref="AsyncLock"/>
    /// high lock counts are certainly gone. Also we're no longer abusing the thread pool (which is also a
    /// problem in <see cref="AsyncLockOnly"/>). And both of those facts are very good!
    ///</para>
    /// <para>
    /// But, when we look at the number of pending request in the command processor's queue versus number of
    /// established locks we actually see similar numbers. So we've offloaded the backlog but we haven't eliminated it.
    /// And when we look at the stats emitted for how long pings are taking to complete from the point of scheduling,
    /// they're taking roughly the same amount of time. Their individual times AFTER execution has begun
    /// shows much lower time spent waiting, which is good, but doesn't help the end goal.
    /// </para>
    /// <para>
    /// So, that means this doesn't solve the ping problem. We do pings because we want to know if there's a
    /// potential problem. This is either communicated in a returned status, or our attempt at communication
    /// timing out. And in this solution they're still significantly delayed for processing. For a system that
    /// has to make decisions such as "do I restart the server? it's not replied to a ping yet." this is a
    /// huge problem because we don't know why we've not yet gotten the response. Is **the server** laggy?
    /// Is the server down? Have **we** swamped the command queue? We don't know without monitoring our task
    /// processor, and even then there's not much we can do about it without taking other measures.
    ///</para>
    /// <para>
    /// So, while this is better, and possibly suitable for some circumstances, it won't work for the
    /// *"near real time"* communications and monitoring just described. Don't fret though, this is the
    /// *almost* the solution we're looking for!
    ///</para>
    /// </remarks>
    public static async Task Run(int lifespanInSeconds=60, int pingFrequencyInMs=1000, int maxTasks=50, int taskSchedulingFrequencyInMs=100, int minLatencyInMs=10,int maxAdditionalLatencyInMs=15,bool logRequestScheduling = true)
    {
        Server.SetLatency(minLatencyInMs,maxAdditionalLatencyInMs);
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("One queue. No deadlocking. Pings still delayed.");
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
                await Console.Out.FlushAsync();
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

        void SchedulePing(SynchronizedValue<int> pingBacklog, Random rnd, DateTime scheduledAt)
        {
            if (logRequestScheduling) Console.WriteLine($"{DateTime.Now:O} Scheduling Ping Request. Current {nameof(FakeServerProxy.SendRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value} and Command Queue Length of {CommandProcessor.QueueLength}");
            if (logRequestScheduling) Console.Out.Flush();
            // Schedule a ping. We won't await the result here as that'll
            // block the ping scheduler. This is to simulate a ping whose
            // returned data is received and handled in another thread.
            // this is just the scheduler.
            CommandProcessor.EnqueueAsyncAction(async () => { await ExecutePing(pingBacklog, rnd, scheduledAt); });
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