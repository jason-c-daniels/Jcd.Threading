using System;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly four STA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class FourStaThreadsPerCpuTaskScheduler : StaThreadTaskScheduler
{
   /// <inheritdoc />
   public FourStaThreadsPerCpuTaskScheduler():base(Environment.ProcessorCount*4){}

}