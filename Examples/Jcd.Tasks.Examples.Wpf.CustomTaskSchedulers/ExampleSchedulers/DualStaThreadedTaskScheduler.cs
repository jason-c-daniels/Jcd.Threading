using Jcd.Tasks.TaskSchedulers;

namespace Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly two  STA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details.
/// </summary>
public class DualStaThreadedTaskScheduler : SimpleStaThreadedTaskScheduler
{
   /// <inheritdoc />
   public DualStaThreadedTaskScheduler() : base(2) { }
}