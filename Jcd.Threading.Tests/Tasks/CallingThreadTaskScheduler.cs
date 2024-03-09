// ReSharper disable HeapView.ObjectAllocation.Evident

namespace Jcd.Threading.Tests.Tasks;

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