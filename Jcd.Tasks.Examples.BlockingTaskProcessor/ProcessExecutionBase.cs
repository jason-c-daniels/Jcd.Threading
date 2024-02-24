using System.Diagnostics.CodeAnalysis;
using Nito.AsyncEx;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable VirtualMemberNeverOverridden.Global
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable MemberCanBeMadeStatic.Local

namespace Jcd.Tasks.Examples.BlockingTaskProcessor;

[SuppressMessage("Performance", "CA1822:Mark members as static")]
public abstract class ProcessExecutionBase<T>
    where T : ProcessExecutionBase<T>, new()
{
    public static readonly T Instance = new();

    public readonly SynchronizedValue<int> PingCount = new();
    protected readonly FakeServerProxy Server = new();
    protected Type MyType => GetType();

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
    public virtual async Task Run(int lifespanInSeconds = 60,
                                  int pingFrequencyInMs = 1000,
                                  int maxTasks = 50,
                                  int taskSchedulingFrequencyInMs = 100,
                                  int minLatencyInMs = 10,
                                  int maxAdditionalLatencyInMs = 15,
                                  bool logRequestScheduling = true)
    {
        Server.SetLatency(minLatencyInMs, maxAdditionalLatencyInMs);
        ReportRunType();

        var makeCallsTask = CreateMakeLotsOfCallsTask(taskSchedulingFrequencyInMs, lifespanInSeconds, maxTasks,
            logRequestScheduling);
        var pingTask = CreatePingTask(pingFrequencyInMs, lifespanInSeconds, logRequestScheduling);

        // wait for the tasks to finish regardless if their completion status.
        while (!makeCallsTask.IsCompleted || !pingTask.IsCompleted) await Task.Yield();

        // cancellation token expired. Cancel pending tasks.
        Server.CancelAllRequests();
    }

    #region Private Implementation

    private Task CreateMakeLotsOfCallsTask(double scheduleDelayInMs = 100,
                                           double lifeSpanInSeconds = 120,
                                           int numberOfMakeRequestTasks = 50,
                                           bool logSchedulingRequests = true)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        return Task.Run(async () =>
        {
            Console.WriteLine(
                $"{nameof(CreateMakeLotsOfCallsTask)} running, scheduling {numberOfMakeRequestTasks} {nameof(FakeServerProxy.SendRequest)} tasks every {scheduleDelayInMs:n2} ms");
            await Console.Out.FlushAsync();

            var rnd = new Random();
            while (!cts.IsCancellationRequested)
            {
                await WaitToScheduleLotsOfCalls(scheduleDelayInMs, numberOfMakeRequestTasks, logSchedulingRequests,
                    cts);
                ScheduleLotsOfCalls(numberOfMakeRequestTasks, rnd, cts);
                await Task.Yield(); // be sort of CPU friendly.
            }

            if (cts.IsCancellationRequested) throw new OperationCanceledException();
        }, cts.Token);
    }

    private async Task WaitToScheduleLotsOfCalls(double scheduleDelayInMs,
                                                 int numberOfMakeRequestTasks,
                                                 bool logSchedulingRequests,
                                                 CancellationTokenSource cts)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(scheduleDelayInMs * 5), cts.Token);
        if (cts.IsCancellationRequested) throw new OperationCanceledException();
        LogSchedulingLotsOfTasks(numberOfMakeRequestTasks, logSchedulingRequests, scheduleDelayInMs);
    }

    private void ScheduleLotsOfCalls(int numberOfMakeRequestTasks, Random rnd, CancellationTokenSource cts)
    {
        // scheduling without awaiting the calls is intentional.
        // this represents a separate thread (such as different parts of an app/UI)
        // deciding they need to make a bunch of calls.
        for (var i = 0; i < numberOfMakeRequestTasks; i++)
        {
            ScheduleASingleCall(rnd, cts, i);
        }
    }

    private Task CreatePingTask(double scheduleDelayInMs = 1000, double lifeSpanInSeconds = 120,
                                bool logRequestScheduling = true)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        
        return Task.Run(async () =>
        {
            Console.WriteLine(
                $"{nameof(CreatePingTask)} running, scheduling {nameof(FakeServerProxy.SendRequest)} tasks every {scheduleDelayInMs:n2} ms");
            await Console.Out.FlushAsync();
            var rnd = new Random();

            while (!cts.IsCancellationRequested)
            {
                if (cts.IsCancellationRequested) throw new OperationCanceledException();
                await Task.Delay(TimeSpan.FromMilliseconds(scheduleDelayInMs), cts.Token);
                SchedulePing(PingCount, rnd, DateTime.Now, cts, logRequestScheduling);
                await Task.Yield();
            }

            if (cts.IsCancellationRequested) throw new OperationCanceledException();
        }, cts.Token);
    }

    protected async Task ExecutePing(SynchronizedValue<int> pingBacklog, Random rnd, DateTime scheduledAt,
                                     CancellationTokenSource cts, bool logRequestScheduling)
    {
        try
        {
            LogPingScheduled(logRequestScheduling, pingBacklog);
            await pingBacklog.ChangeValueAsync(v => Task.FromResult(v+1)); // increment the value
            var (startedAt, finishedAt) = await SendPingWrapper(rnd, cts);
            var backlog = await pingBacklog.ChangeValueAsync(v => Task.FromResult(v - 1)); // decrement the value
            await ReportPingResults(finishedAt, startedAt, scheduledAt, backlog);
        }
        catch (OperationCanceledException)
        {
            // Decrement the count so its accurate.
            await pingBacklog.ChangeValueAsync(v => Task.FromResult(v - 1)); // decrement the value
        }
        catch (Exception ex)
        {
            await LogPingException(ex, pingBacklog);
        }
    }
    
    private async Task LogPingException(Exception ex, SynchronizedValue<int> pingBacklog)
    {
        Console.WriteLine($"{MyType.Name}: Error during {nameof(ExecutePing)} : {ex.Message}");
        await pingBacklog.ChangeValueAsync(v => Task.FromResult(v - 1)); // decrement the value
    }

    private async Task ReportPingResults(DateTime finishedAt, DateTime startedAt, DateTime scheduledAt, int backlog)
    {
        var sinceStarted = finishedAt - startedAt;
        var sinceScheduled = finishedAt - scheduledAt;
        Console.WriteLine(
            $"{DateTime.Now:O} - {MyType.Name}: Ping completed {sinceScheduled.TotalMilliseconds:n2}ms after scheduling, and {sinceStarted.TotalMilliseconds:n2}ms after starting. Concurrent ping backlog {backlog}");
        await Console.Out.FlushAsync();
        await Task.Yield();
    }
    
    private async Task<(DateTime startedAt, DateTime finishedAt)> SendPingWrapper(
        Random rnd, CancellationTokenSource cts)
    {
        CreatePingBuffers(rnd, out var buff, out var buff2);
        // let's read two values from the server but don't care about the order they're returned in.
        // yes our two calls introduce unwanted locking... but some programmers actually do this.
        if (cts.IsCancellationRequested) throw new OperationCanceledException();
        var startedAt = DateTime.Now;
        await PerformPing(buff, buff2);
        var finishedAt = DateTime.Now;
        if (cts.IsCancellationRequested) throw new OperationCanceledException();
        return (startedAt, finishedAt);
    }

    private void CreatePingBuffers(Random rnd, out byte[] buff, out byte[] buff2)
    {
        buff = new byte[20];
        rnd.NextBytes(buff);
        buff2 = new byte[20];
        rnd.NextBytes(buff2);
    }

    #endregion

    #region Abstract/Virtual Members

    protected abstract void ScheduleASingleCall(Random rnd, CancellationTokenSource cts, int fakeBufferType);

    protected abstract void ReportRunType();

    protected virtual void LogPingScheduled(bool logRequestScheduling, SynchronizedValue<int> pingBacklog)
    {
        if (!logRequestScheduling) return;
        Console.WriteLine(
            $"{DateTime.Now:O} - {MyType.Name}: Starting to ping... concurrent ping backlog {pingBacklog.Value}");
        Console.Out.Flush();
    }

    protected void LogSchedulingLotsOfTasks(int numberOfMakeRequestTasks, bool logSchedulingRequests,
                                            double scheduleDelayInMs)
    {
        if (logSchedulingRequests)
            Console.WriteLine(
                $"{nameof(CreateMakeLotsOfCallsTask)} running, scheduling {numberOfMakeRequestTasks} {nameof(FakeServerProxy)}.{nameof(FakeServerProxy.SendRequest)} tasks every {scheduleDelayInMs:n2} ms");
    }

    protected virtual void SchedulePing(SynchronizedValue<int> pingBacklog, Random rnd, DateTime scheduledAt,
                                        CancellationTokenSource cts, bool logRequestScheduling)
    {
        if (logRequestScheduling)
            Console.WriteLine(
                $"{DateTime.Now:O} Scheduling Ping Request. Current {nameof(FakeServerProxy.SendRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value}");
        if (logRequestScheduling) Console.Out.Flush();
        // run the ping in a background thread. This is to simulate a UI or other
        // separate thread of a program periodically telling the communications
        // layer to get a status update. Usually we want these to preempt other traffic.
        // it will not for this example. In fact we'll see them start stacking up.
        Task.Run(() => ExecutePing(pingBacklog, rnd, scheduledAt, cts, logRequestScheduling), cts.Token);
    }

    protected virtual async Task PerformPing(byte[] buff, byte[] buff2)
    {
        await Task.WhenAll(Server.SendRequest(314159, buff), Server.SendRequest(314160, buff2));
    }

    #endregion
}