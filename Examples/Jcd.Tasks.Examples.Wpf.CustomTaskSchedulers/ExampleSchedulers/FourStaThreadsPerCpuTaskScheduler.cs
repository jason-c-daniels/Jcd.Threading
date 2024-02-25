using Jcd.Tasks;

// ReSharper disable UnusedType.Global

namespace Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses four STA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details.
/// </summary>
public class FourStaThreadsPerCpuTaskScheduler : SimpleThreadedTaskScheduler
{
   /// <inheritdoc />
   public FourStaThreadsPerCpuTaskScheduler() : base(Environment.ProcessorCount * 4, ApartmentState.STA) { }
}