using System;
using System.Threading.Tasks;

namespace Jcd.Tasks.TaskSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses two MTA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public class TwoStaThreadsPerCpuTaskScheduler : StaThreadTaskScheduler
{
   /// <inheritdoc />
   public TwoStaThreadsPerCpuTaskScheduler() : base(Environment.ProcessorCount * 2) { }
}