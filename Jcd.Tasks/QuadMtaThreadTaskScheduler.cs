using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly four MTA threads to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class QuadMtaThreadTaskScheduler : MtaThreadTaskScheduler
{
   /// <inheritdoc />
   public QuadMtaThreadTaskScheduler() : base(4)
   {
      
   }
}