using Jcd.Tasks;

namespace Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses one STA thread per CPUs to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details.
/// </summary>
public class OneStaThreadPerCpuTaskScheduler : QueuedThreadedTaskScheduler
{
   /// <inheritdoc />
   public OneStaThreadPerCpuTaskScheduler() : base(Environment.ProcessorCount, Environment.ProcessorCount, ApartmentState.STA) { }
}