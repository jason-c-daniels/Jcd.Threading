using System;

namespace Jcd.Tasks;

public class OneMTAThreadPerCpuScheduler : MTAThreadScheduler
{
   
   public OneMTAThreadPerCpuScheduler() : base(Environment.ProcessorCount){}

}