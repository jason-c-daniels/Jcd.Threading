using System;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses one STA thread per CPUs to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class OneMtaThreadPerCpuTaskScheduler : MtaThreadTaskScheduler
{
   /// <inheritdoc />
   public OneMtaThreadPerCpuTaskScheduler() : base(Environment.ProcessorCount) { }
}