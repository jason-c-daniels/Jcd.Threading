namespace Jcd.Tasks;

public class DualMTAThreadScheduler : MTAThreadScheduler
{

   public DualMTAThreadScheduler() : base(2)
   {
      // intentionally empty.
   }
}