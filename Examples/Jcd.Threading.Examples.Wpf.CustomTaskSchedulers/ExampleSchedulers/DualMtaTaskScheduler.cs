// ReSharper disable UnusedType.Global

using Jcd.Threading.Tasks;

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly two  MTA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details.
/// </summary>
public class DualMtaTaskScheduler : SimpleThreadedTaskScheduler
{
   /// <inheritdoc />
   public DualMtaTaskScheduler() : base(2)
   {
      // intentionally empty.
   }
}