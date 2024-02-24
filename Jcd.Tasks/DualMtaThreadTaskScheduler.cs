using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly two  STA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. <see cref="ThreadTaskScheduler"/>
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