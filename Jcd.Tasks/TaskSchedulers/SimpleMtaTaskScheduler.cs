using System.Threading;

namespace Jcd.Tasks.TaskSchedulers;

/// <summary>
/// An ease of use wrapper on top of <see cref="SimpleThreadedTaskScheduler"/> that uses MTA threads. Inlining is not honored.
/// for details.
/// </summary>
public abstract class SimpleMtaTaskScheduler : SimpleThreadedTaskScheduler
{
   /// <summary>
   /// Creates an instance of the type.
   /// </summary>
   /// <param name="threadCount">The number of threads to use for executing <see cref="Tasks"/> instances. </param>
   protected SimpleMtaTaskScheduler(int threadCount) : base(threadCount, ApartmentState.MTA) { }
}