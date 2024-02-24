using System;
using System.Threading;

namespace Jcd.Tasks;

public class FourSTAThreadsPerCpuScheduler : STAThreadScheduler
{
   public FourSTAThreadsPerCpuScheduler():base(Environment.ProcessorCount*4){}

}