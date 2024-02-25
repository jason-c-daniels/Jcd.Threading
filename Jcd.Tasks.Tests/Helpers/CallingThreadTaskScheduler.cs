// ReSharper disable HeapView.ObjectAllocation.Evident

namespace Jcd.Tasks.Tests.Helpers;

/// <summary>
/// A non-queuing TaskScheduler that immediately executes its queued work on the calling
/// thread.
/// </summary>
public class CallingThreadTaskScheduler : TaskScheduler
{
   protected override IEnumerable<Task> GetScheduledTasks() { return new List<Task>(); }

   protected override void QueueTask(Task task) { TryExecuteTask(task); }

   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
   {
      return TryExecuteTask(task);
   }
}

public class SimpleThreadedTaskSchedulerHarness : SimpleThreadedTaskScheduler
{
   public SimpleThreadedTaskSchedulerHarness(int threadCount, ApartmentState state = ApartmentState.Unknown) :
      base(threadCount, state)
   {
   }

   public bool PublicTryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
   {
      return TryExecuteTaskInline(task, taskWasPreviouslyQueued);
   }

   public IEnumerable<Task> PublicGetScheduledTasks() { return GetScheduledTasks(); }
}