namespace Jcd.Tasks.Examples;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly four MTA threads to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details.
/// </summary>
public class CustomTaskScheduler : SimpleThreadedTaskScheduler
{
   /// <inheritdoc />
   public CustomTaskScheduler() : base(Environment.ProcessorCount) { }
}