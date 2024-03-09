using System.Diagnostics.CodeAnalysis;

using Jcd.Threading.Tasks;

namespace Jcd.Threading.Tests.Helpers;

[SuppressMessage("Performance", "CA1822:Mark members as static")]
public class IdleTaskSchedulerTaskSchedulerHarness(int threadCount, ApartmentState state = ApartmentState.Unknown)
   : IdleTaskScheduler(threadCount, state)
{
   public bool PublicTryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
   {
      return TryExecuteTaskInline(task, taskWasPreviouslyQueued);
   }

   public IEnumerable<Task> PublicGetScheduledTasks() { return GetScheduledTasks(); }
}