using Jcd.Threading.Tasks;

namespace Jcd.Threading.Examples;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses one Thread per CPU to schedule <see cref="Task"/>
/// instances. Inlining is not honored. See <see cref="IdleTaskScheduler"/>
/// for details.
/// </summary>
public class CustomTaskScheduler : IdleTaskScheduler
{
   /// <inheritdoc />
   public CustomTaskScheduler() : base(Environment.ProcessorCount) { }
}