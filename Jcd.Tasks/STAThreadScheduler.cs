using System.Threading;

namespace Jcd.Tasks;

public abstract class STAThreadScheduler : ThreadScheduler
{

   protected STAThreadScheduler(int threadCount) : base(threadCount,ApartmentState.STA)
   {
      // intentionally empty.
   }
}