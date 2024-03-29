using Jcd.Threading.Tasks;

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly four MTA threads to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="IdleTaskScheduler"/>
/// for details.
/// </summary>
public class QuadMtaThreadTaskScheduler() : IdleTaskScheduler(4);