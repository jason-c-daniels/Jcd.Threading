namespace Jcd.Tasks.Tests.Helpers;

public class CallingThreadTaskScheduler : TaskScheduler
{
   protected override IEnumerable<Task>? GetScheduledTasks() => new List<Task>();

   protected override void QueueTask(Task task) { TryExecuteTask(task); }

   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) =>
      TryExecuteTask(task);
}