// ReSharper disable UnusedType.Global

using Jcd.Threading.Tasks;

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses one STA thread per CPUs to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="IdleTaskScheduler"/>
/// for details.
/// </summary>
public class OneMtaThreadPerCpuTaskScheduler : IdleTaskScheduler
{
   /// <inheritdoc />
   public OneMtaThreadPerCpuTaskScheduler() : base(Environment.ProcessorCount) { }
}