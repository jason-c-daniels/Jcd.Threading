using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly four STA threads to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class QuadStaThreadTaskScheduler : StaThreadTaskScheduler
{
   /// <inheritdoc />
   public QuadStaThreadTaskScheduler() : base(4)
   {
      
   }
}