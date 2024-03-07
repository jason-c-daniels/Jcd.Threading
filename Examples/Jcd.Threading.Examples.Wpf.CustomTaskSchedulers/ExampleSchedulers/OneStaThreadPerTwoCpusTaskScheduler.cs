// ReSharper disable UnusedType.Global

using Jcd.Threading.Tasks;

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses one STA thread for every two CPUs to execute
/// <see cref="Task"/> instances. At a minimum one thread is created. Inlining is not honored. See <see cref="IdleTaskScheduler"/>
/// for details.
/// </summary>
public class OneStaThreadPerTwoCpusTaskScheduler : IdleTaskScheduler
{
   /// <inheritdoc />
   public OneStaThreadPerTwoCpusTaskScheduler() : base(Environment.ProcessorCount / 2 == 0
                                                          ? 1
                                                          : Environment.ProcessorCount / 2
                                                     , ApartmentState.STA
                                                      )
   {
   }
}