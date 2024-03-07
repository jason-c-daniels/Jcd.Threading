using Jcd.Threading.Tasks;

namespace Jcd.Threading.Tests.Helpers;

public class IdleTaskSchedulerTaskSchedulerHarness(int threadCount, ApartmentState state = ApartmentState.Unknown)
   : IdleTaskScheduler(threadCount, state)
{
   public bool PublicTryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
   {
      return TryExecuteTaskInline(task, taskWasPreviouslyQueued);
   }

   public IEnumerable<Task> PublicGetScheduledTasks() { return GetScheduledTasks(); }
}