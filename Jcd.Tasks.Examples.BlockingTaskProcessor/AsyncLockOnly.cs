using Nito.AsyncEx;

// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation

namespace Jcd.Tasks.Examples.BlockingTaskProcessor;

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
public class AsyncLockOnly : ProcessExecutionBase<AsyncLockOnly>
{
   #region Overrides

   protected override void ScheduleASingleCall(Random rnd, CancellationTokenSource cts, int fakeBufferType)
   {
      Task.Run(async () =>
               {
                  var buff = new byte[20];
                  rnd.NextBytes(buff);

                  if (cts.IsCancellationRequested) throw new OperationCanceledException();
                  await Server.SendRequest(fakeBufferType, buff);
                  await Task.Yield();
               }
             , cts.Token
              ); // do nothing
   }

   protected override void SchedulePing(
      SynchronizedValue<int>  pingBacklog
    , Random                  rnd
    , DateTime                scheduledAt
    , CancellationTokenSource cts
    , bool                    logRequestScheduling
   )
   {
      if (logRequestScheduling)
         Console.WriteLine($"{DateTime.Now:O} Scheduling Ping Request. Current {nameof(FakeServerProxy.SendRequest)} Synchronization Lock Backlog = {Server.BacklogCounter.Value}"
                          );
      if (logRequestScheduling) Console.Out.Flush();

      // run the ping in a background thread. This is to simulate a UI or other
      // separate thread of a program periodically telling the communications
      // layer to get a status update. Usually we want these to preempt other traffic.
      // it will not for this example. In fact we'll see them start stacking up.
      Task.Run(() => ExecutePing(pingBacklog, rnd, scheduledAt, cts, logRequestScheduling), cts.Token);
   }

   protected override void ReportRunType()
   {
      Console.WriteLine("-----------------------------------------------");
      Console.WriteLine("No queues. Massive deadlocking.");
      Console.WriteLine("-----------------------------------------------");
      Console.Out.Flush();
   }

   #endregion
}