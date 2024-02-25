using System.Threading.Tasks;

namespace Jcd.Tasks.TaskSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly two  MTA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class DualMtaThreadTaskScheduler : MtaThreadTaskScheduler
{
   /// <inheritdoc />
   public DualMtaThreadTaskScheduler() : base(2)
   {
      // intentionally empty.
   }
}