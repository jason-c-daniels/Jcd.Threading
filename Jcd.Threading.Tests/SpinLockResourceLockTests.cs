#if REF_STRUCT_SUPPORT

// ReSharper disable once RedundantUsingDirective
using Jcd.Threading.SynchronizedValues;

// ReSharper disable MethodHasAsyncOverload
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation

namespace Jcd.Threading.Tests;

public class SpinLockResourceLockTests
{
   [Fact]
   public void IsReleased_Returns_False_For_New_SpinLockResourceLock()
   {
      var       sl = new SpinLock(false);
      using var rl = sl.GetResourceLock();
      Assert.False(rl.IsReleased);
   }

   [Fact]
   public void IsLocked_Returns_False_For_New_SpinLockResourceLock()
   {
      var       sl = new SpinLock(false);
      using var rl = sl.GetResourceLock();
      Assert.False(rl.IsLocked);
   }

   [Fact]
   public void IsWaiting_Returns_False_For_New_SpinLockResourceLock()
   {
      var       sl = new SpinLock(false);
      using var rl = sl.GetResourceLock();
      Assert.False(rl.IsWaiting);
   }

   [Fact]
   public void Wait_Sets_IsHeld_To_True_On_SpinLock()
   {
      var sl   = new SpinLock(false);
      var cde1 = new AutoResetEvent(false);
      var cde2 = new AutoResetEvent(false);
      Task.Run(() =>
               {
                  using var rl = sl.GetResourceLock();

                  rl.Wait();
                  cde2.Set();
                  cde1.WaitOne();
               }
              );

      cde2.WaitOne();
      Assert.True(sl.IsHeld);
      cde1.Set();
   }

   [Fact]
   public void WaitAsync_Sets_IsHeld_To_True_On_SpinLock()
   {
      var       sl   = new SpinLock(false);
      var       cde1 = new AutoResetEvent(false);
      var       cde2 = new AutoResetEvent(false);
      using var rl   = sl.GetResourceLock();
      Task.Run(() =>
               {
                  cde2.WaitOne();
                  Assert.True(sl.IsHeld);
                  cde1.Set();
               }
              );

      #pragma warning disable xUnit1031
      rl.WaitAsync().Wait();
      #pragma warning restore xUnit1031
      cde2.Set();
      cde1.WaitOne();
   }

   [Fact]
   public void WaitAsync_With_CancellationToken_Sets_IsHeld_To_True_On_SpinLock()
   {
      var       sl   = new SpinLock(false);
      var       cde1 = new AutoResetEvent(false);
      var       cde2 = new AutoResetEvent(false);
      var       cts  = new CancellationTokenSource();
      using var rl   = sl.GetResourceLock();
      Task.Run(() =>
               {
                  cde2.WaitOne();
                  Assert.True(sl.IsHeld);
                  cde1.Set();
               }
             , cts.Token
              );

      #pragma warning disable xUnit1031
      rl.WaitAsync(cts.Token).Wait(cts.Token);
      #pragma warning restore xUnit1031
      cde2.Set();
      cde1.WaitOne();
   }
}
#endif