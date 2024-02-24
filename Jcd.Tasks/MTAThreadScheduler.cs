using System;
using System.Threading;

namespace Jcd.Tasks;

public abstract class MTAThreadScheduler : ThreadScheduler
{
   public MTAThreadScheduler(int threadCount) : base(threadCount,ApartmentState.MTA){}

}