using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jcd.Threading.Tasks;

/// <summary>
/// Executes all tasks inline, without queuing or scheduling.
/// As a result this executes work in the .Net ThreadPool.
/// So, consequently, it can hardly be called a TaskScheduler.
/// </summary>
public class InlineTaskScheduler : TaskScheduler
{
   /// <inheritdoc />
   protected override void QueueTask(Task task) { TryExecuteTask(task); }

   /// <inheritdoc />
   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
   {
      return TryExecuteTask(task);
   }

   /// <inheritdoc />
   protected override IEnumerable<Task> GetScheduledTasks() { return Enumerable.Empty<Task>(); }
}