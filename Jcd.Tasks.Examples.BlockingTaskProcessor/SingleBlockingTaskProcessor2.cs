namespace Jcd.Tasks.Examples.BlockingTaskProcessor;

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
public class SingleBlockingTaskProcessor2 : ProcessExecutionBase<SingleBlockingTaskProcessor2>
{
    protected readonly Tasks.BlockingTaskProcessor CommandProcessor = new();

    #region Overrides

    /// <inheritdoc />
    public override async Task Run(int lifespanInSeconds = 60, int pingFrequencyInMs = 1000, int maxTasks = 50,
                             int taskSchedulingFrequencyInMs = 100, int minLatencyInMs = 10, int maxAdditionalLatencyInMs = 15,
                             bool logRequestScheduling = true)
    {
        await base.Run(lifespanInSeconds, pingFrequencyInMs, maxTasks, taskSchedulingFrequencyInMs, minLatencyInMs, maxAdditionalLatencyInMs, logRequestScheduling);
        CommandProcessor.Cancel();
    }

    protected override void ScheduleASingleCall(Random rnd, CancellationTokenSource cts, int fakeBufferType)
    {
        CommandProcessor.EnqueueAsyncActionAsync(async () =>
        {
            var buff = new byte[20];
            rnd.NextBytes(buff);
            if (cts.IsCancellationRequested) throw new OperationCanceledException();
            await Server.SendRequest(fakeBufferType, buff);
            await Task.Yield();
        });
    }
    
    protected override void SchedulePing(SynchronizedValue<int> pingBacklog, 
                                         Random rnd, 
                                         DateTime scheduledAt,
                                         CancellationTokenSource cts, 
                                         bool logRequestScheduling)
    {
        if (logRequestScheduling) Console.WriteLine($"{DateTime.Now:O} Scheduling Ping Request. Current {nameof(FakeServerProxy.SendRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value} and Command Queue Length of {CommandProcessor.QueueLength}");
        if (logRequestScheduling) Console.Out.Flush();
        // run the ping in a background thread. This is to simulate a UI or other
        // separate thread of a program periodically telling the communications
        // layer to get a status update. Usually we want these to preempt other traffic.
        // it will not for this example. In fact we'll see them start stacking up.
        Task.Run(() => ExecutePing(pingBacklog, rnd, scheduledAt, cts, logRequestScheduling));
    }
    
    protected override void ReportRunType()
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("One queue. No deadlocking. Pings not delayed.");
        Console.WriteLine("-----------------------------------------------");
        Console.Out.Flush();
    }

    #endregion

}