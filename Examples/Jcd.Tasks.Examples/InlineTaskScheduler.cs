namespace Jcd.Tasks.Examples;

/// <summary>
/// Executes all tasks inline, without queuing or scheduling.
/// As a result this executes work in the .Net ThreadPool.
/// So, consequently, it can hardly be called a TaskScheduler.
/// </summary>
public class InlineTaskScheduler : TaskScheduler
{
   protected override void QueueTask(Task task) => TryExecuteTask(task);

   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) => TryExecuteTask(task);

   protected override IEnumerable<Task> GetScheduledTasks() => Enumerable.Empty<Task>();
}