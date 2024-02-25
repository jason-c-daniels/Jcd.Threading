using Jcd.Tasks.TaskSchedulers;

namespace Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses four MTA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details.
/// </summary>
public class FourSimpleMtaPerCpuTaskScheduler : SimpleMtaTaskScheduler
{
   /// <inheritdoc />
   public FourSimpleMtaPerCpuTaskScheduler() : base(Environment.ProcessorCount * 4)
   {
      // intentionally empty.
   }
}