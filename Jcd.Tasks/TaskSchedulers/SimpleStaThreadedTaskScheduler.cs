using System.Threading;

namespace Jcd.Tasks.TaskSchedulers;

/// <summary>
/// An ease of use wrapper on top of <see cref="SimpleThreadedTaskScheduler"/> that uses STA threads. Inlining is not honored. 
/// </summary>
public abstract class SimpleStaThreadedTaskScheduler : SimpleThreadedTaskScheduler
{
   /// <summary>
   /// Creates an instance of the type.
   /// </summary>
   /// <param name="threadCount">The number of threads to use for executing <see cref="Tasks"/> instances. </param>
   protected SimpleStaThreadedTaskScheduler(int threadCount) : base(threadCount, ApartmentState.STA) { }
}