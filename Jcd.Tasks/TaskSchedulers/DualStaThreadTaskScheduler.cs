using System.Threading.Tasks;

namespace Jcd.Tasks.TaskSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly two  STA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class DualStaThreadTaskScheduler : StaThreadTaskScheduler
{
   /// <inheritdoc />
   public DualStaThreadTaskScheduler() : base(2) { }
}