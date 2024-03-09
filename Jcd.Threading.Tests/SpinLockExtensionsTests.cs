// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation

namespace Jcd.Threading.Tests;

public class SpinLockExtensionsTests
{
   [Fact]
   public void Lock_Calls_The_Provided_Action_And_Holds_The_Lock()
   {
      SpinLock sl      = default;
      var      called  = false;
      var      wasHeld = false;
      sl.Lock(() =>
              {
                 called  = true;
                 wasHeld = sl.IsHeld;
              }
             );
      Assert.True(called);
      Assert.True(wasHeld);
   }

   [Fact]
   public async Task LockAsync_Calls_The_Provided_Action_And_Holds_The_Lock()
   {
      SpinLock sl      = default;
      var      called  = false;
      var      wasHeld = false;
      await sl.LockAsync(() =>
                         {
                            called  = true;
                            wasHeld = sl.IsHeld;
                         }
                        );
      Assert.True(called);
      Assert.True(wasHeld);
   }
}