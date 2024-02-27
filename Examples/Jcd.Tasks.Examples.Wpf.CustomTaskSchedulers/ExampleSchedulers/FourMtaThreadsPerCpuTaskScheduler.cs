namespace Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses four MTA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details. 
/// </summary>
public class FourMtaThreadsPerCpuTaskScheduler : QueuedThreadedTaskScheduler
{
   /// <inheritdoc />
   public FourMtaThreadsPerCpuTaskScheduler() : base(1000, 100)
   {
      // intentionally empty.
   }
}