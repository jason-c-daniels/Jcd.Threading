namespace Jcd.Threading.Tests.Helpers;

public class ThreadWrapperHarness
(
   Func<bool>?    performWorkHook          = null
 , bool           autoStart                = true
 , string?        name                     = null
 , bool           useBackgroundThread      = true
 , bool           yieldEachCycle           = true
 , int            timeToYieldInMs          = 15
 , int            idleAfterNoWorkDoneCount = 15
 , ThreadPriority priority                 = ThreadPriority.Normal
 , ApartmentState apartmentState           = ApartmentState.Unknown
) : ThreadWrapper(autoStart
                , name
                , useBackgroundThread
                , yieldEachCycle
                , timeToYieldInMs
                , idleAfterNoWorkDoneCount
                , priority
                , apartmentState
                 )
{
   protected override bool PerformWork(CancellationToken token)
   {
      return performWorkHook?.Invoke() ?? base.PerformWork(token);
   }
}