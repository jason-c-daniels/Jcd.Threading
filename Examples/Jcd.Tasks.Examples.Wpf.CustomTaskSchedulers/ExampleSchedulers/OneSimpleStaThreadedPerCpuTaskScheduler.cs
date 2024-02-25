using Jcd.Tasks.TaskSchedulers;

namespace Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses one STA thread per CPUs to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details.
/// </summary>
public class OneSimpleStaThreadedPerCpuTaskScheduler : SimpleStaThreadedTaskScheduler
{
   /// <inheritdoc />
   public OneSimpleStaThreadedPerCpuTaskScheduler() : base(Environment.ProcessorCount) { }
}