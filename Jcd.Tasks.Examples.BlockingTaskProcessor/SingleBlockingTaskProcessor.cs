using Nito.AsyncEx;

// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Jcd.Tasks.Examples.BlockingTaskProcessor;

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
public class SingleBlockingTaskProcessor : ProcessExecutionBase<SingleBlockingTaskProcessor>
{
    protected readonly Tasks.BlockingTaskProcessor TaskProcessor = new();

    #region Overrides

    /// <inheritdoc />
    public override async Task Run(int lifespanInSeconds = 60, int pingFrequencyInMs = 1000, int maxTasks = 50,
                                   int taskSchedulingFrequencyInMs = 100, int minLatencyInMs = 10,
                                   int maxAdditionalLatencyInMs = 15,
                                   bool logRequestScheduling = true)
    {
        await base.Run(lifespanInSeconds, pingFrequencyInMs, maxTasks, taskSchedulingFrequencyInMs, minLatencyInMs,
            maxAdditionalLatencyInMs, logRequestScheduling);
        TaskProcessor.StopProcessingAndClearQueue();
    }

    protected override void ScheduleASingleCall(Random rnd, CancellationTokenSource cts, int fakeBufferType)
    {
        TaskProcessor.EnqueueAndGetProxy(async () =>
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
        if (logRequestScheduling)
            Console.WriteLine(
                $"{DateTime.Now:O} Scheduling Ping Request. Current {nameof(FakeServerProxy.SendRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value} and Command Queue Length of {TaskProcessor.QueueLength}");
        if (logRequestScheduling) Console.Out.Flush();
        // run the ping in a background thread. This is to simulate a UI or other
        // separate thread of a program periodically telling the communications
        // layer to get a status update. Usually we want these to preempt other traffic.
        // it will not for this example. In fact we'll see them start stacking up.
        TaskProcessor.Enqueue(() => ExecutePing(pingBacklog, rnd, scheduledAt, cts, logRequestScheduling));
    }

    protected override void ReportRunType()
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("One queue. No deadlocking. Pings still delayed.");
        Console.WriteLine("-----------------------------------------------");
        Console.Out.Flush();
    }

    #endregion
}