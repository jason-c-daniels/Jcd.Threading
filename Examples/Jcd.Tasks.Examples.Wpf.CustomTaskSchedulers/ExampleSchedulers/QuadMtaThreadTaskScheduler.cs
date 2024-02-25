using Jcd.Tasks.TaskSchedulers;

namespace Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly four MTA threads to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details.
/// </summary>
public class QuadMtaThreadTaskScheduler : SimpleMtaThreadedTaskScheduler
{
   /// <inheritdoc />
   public QuadMtaThreadTaskScheduler() : base(4) { }
}