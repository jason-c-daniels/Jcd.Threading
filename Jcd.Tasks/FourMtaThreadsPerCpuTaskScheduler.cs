using System;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses four MTA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class FourMtaThreadsPerCpuTaskScheduler : MtaThreadTaskScheduler
{
   /// <inheritdoc />
   public FourMtaThreadsPerCpuTaskScheduler() : base(Environment.ProcessorCount *4)
   {
      // intentionally empty.
   }
}