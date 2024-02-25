using System;
using System.Threading.Tasks;

namespace Jcd.Tasks.TaskSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses one STA thread for every two CPUs to execute
/// <see cref="Task"/> instances. At a minimum one thread is created. Inlining is not honored. See <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class OneStaThreadPerTwoCpusTaskScheduler : StaThreadTaskScheduler
{
   /// <inheritdoc />
   public OneStaThreadPerTwoCpusTaskScheduler() : base(Environment.ProcessorCount / 2 == 0
                                                          ? 1
                                                          : Environment.ProcessorCount / 2
                                                      )
   {
   }
}