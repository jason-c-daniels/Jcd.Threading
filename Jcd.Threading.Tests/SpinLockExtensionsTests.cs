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

   #if REF_STRUCT_SUPPORT
   [Fact]
   public void Lock_Holds_And_Releases_The_Lock()
   {
      SpinLock sl = new(false);

      // ReSharper disable once RedundantAssignment
      var wasHeld = false;

      using (sl.Lock()) wasHeld = sl.IsHeld;

      Assert.True(wasHeld);
   }

   [Fact]
   public void Lock_With_Cancellation_Token_Holds_And_Releases_The_Lock()
   {
      SpinLock sl = new(false);
      var      cts = new CancellationTokenSource();

      // ReSharper disable once RedundantAssignment
      var wasHeld = false;

      using (sl.Lock(cts.Token)) wasHeld = sl.IsHeld;

      Assert.True(wasHeld);
   }

   [Fact]
   public void Lock_With_Canceled_Token_Does_Not_Acquire_The_Lock()
   {
      SpinLock sl = new(false);
      var      cts = new CancellationTokenSource();
      cts.Cancel();
      bool wasHeld;

      using (sl.Lock(cts.Token)) wasHeld = sl.IsHeld;

      Assert.False(wasHeld);
   }

   #endif
}