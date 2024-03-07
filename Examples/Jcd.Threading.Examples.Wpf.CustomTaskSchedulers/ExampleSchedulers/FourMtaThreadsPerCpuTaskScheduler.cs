using Jcd.Threading.Tasks;

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses four MTA threads per CPU to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="IdleTaskScheduler"/>
/// for details. 
/// </summary>
public class FourMtaThreadsPerCpuTaskScheduler() : IdleTaskScheduler(Environment.ProcessorCount * 4);