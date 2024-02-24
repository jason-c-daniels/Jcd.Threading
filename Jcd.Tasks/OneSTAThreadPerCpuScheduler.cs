using System;
using System.Threading;

namespace Jcd.Tasks;

public class OneSTAThreadPerCpuScheduler : STAThreadScheduler
{
   public OneSTAThreadPerCpuScheduler() : base(Environment.ProcessorCount)
   {
      
   }
}