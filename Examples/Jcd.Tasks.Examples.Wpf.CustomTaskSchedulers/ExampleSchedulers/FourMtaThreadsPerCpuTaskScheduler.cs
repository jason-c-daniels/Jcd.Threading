using Jcd.Tasks;

namespace Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses four MTA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details. 
/// </summary>
public class FourMtaThreadsPerCpuTaskScheduler : SimpleThreadedTaskScheduler
{
   /// <inheritdoc />
   public FourMtaThreadsPerCpuTaskScheduler() : base(Environment.ProcessorCount * 4)
   {
      // intentionally empty.
   }
}