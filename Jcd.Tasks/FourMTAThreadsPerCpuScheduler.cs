using System;

namespace Jcd.Tasks;

public class FourMTAThreadsPerCpuScheduler : MTAThreadScheduler
{

   public FourMTAThreadsPerCpuScheduler() : base(Environment.ProcessorCount *4)
   {
      // intentionally empty.
   }
}