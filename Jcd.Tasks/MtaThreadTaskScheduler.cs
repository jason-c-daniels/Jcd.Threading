using System.Threading;

namespace Jcd.Tasks;

/// <summary>
/// The base type for a <see cref="ThreadTaskScheduler"/> that uses MTA threads. Inlining is not honored. See <see cref="ThreadTaskScheduler"/>
/// for details.
/// </summary>
public abstract class MtaThreadTaskScheduler : ThreadTaskScheduler
{
   /// <summary>
   /// Creates an instance of the type.
   /// </summary>
   /// <param name="threadCount">The number of threads to use for executing <see cref="Tasks"/> instances. </param>
   protected MtaThreadTaskScheduler(int threadCount) : base(threadCount,ApartmentState.MTA){}

}