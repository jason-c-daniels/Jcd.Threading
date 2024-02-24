using System;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses two MTA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class TwoMtaThreadsPerCpuTaskScheduler : MtaThreadTaskScheduler
{
   /// <inheritdoc />
   public TwoMtaThreadsPerCpuTaskScheduler():base(Environment.ProcessorCount *2){}
}