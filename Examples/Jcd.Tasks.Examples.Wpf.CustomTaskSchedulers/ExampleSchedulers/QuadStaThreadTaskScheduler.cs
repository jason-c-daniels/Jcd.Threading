namespace Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> that uses exactly four STA threads to execute
/// <see cref="Task"/> instances. Inlining is not honored. See <see cref="SimpleThreadedTaskScheduler"/>
/// for details.
/// </summary>
public class QuadStaThreadTaskScheduler() : IdleTaskScheduler(4, ApartmentState.STA);