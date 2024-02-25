using Jcd.Tasks.TaskSchedulers;

// ReSharper disable UnusedType.Global

namespace Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses two MTA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details.
/// </summary>
public class TwoStaThreadsPerCpuTaskScheduler : SimpleStaThreadedTaskScheduler
{
   /// <inheritdoc />
   public TwoStaThreadsPerCpuTaskScheduler() : base(Environment.ProcessorCount * 2) { }
}