namespace Jcd.Tasks.Tests.Helpers;

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