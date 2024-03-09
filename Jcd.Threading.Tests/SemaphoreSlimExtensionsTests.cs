namespace Jcd.Threading.Tests;
// ReSharper disable MethodHasAsyncOverload
// ReSharper disable RedundantAssignment

public class SemaphoreSlimExtensionsTests
{
   [Fact]
   public void Lock_Holds_And_Releases_The_Lock()
   {
      SemaphoreSlim sem = new(1, 1);

      // ReSharper disable once RedundantAssignment
      var wasHeld = false;

      using (sem.Lock()) wasHeld = sem.CurrentCount == 0;

      Assert.Equal(1, sem.CurrentCount);
      Assert.True(wasHeld);
   }

   [Fact]
   public async Task LockAsync_Holds_And_Releases_The_Lock()
   {
      SemaphoreSlim sem = new(1, 1);

      // ReSharper disable once RedundantAssignment
      var wasHeld = false;

      using (await sem.LockAsync()) wasHeld = sem.CurrentCount == 0;

      Assert.Equal(1, sem.CurrentCount);
      Assert.True(wasHeld);
   }
   
   [Fact]
   public void Lock_With_Cancellation_Token_Holds_And_Releases_The_Lock()
   {
      SemaphoreSlim           sem = new(1, 1);
      CancellationTokenSource cts = new CancellationTokenSource();
      // ReSharper disable once RedundantAssignment
      var wasHeld = false;

      using (sem.Lock(cts.Token)) wasHeld = sem.CurrentCount == 0;

      Assert.Equal(1, sem.CurrentCount);
      Assert.True(wasHeld);
   }

   [Fact]
   public async Task LockAsync_With_Cancellation_Token_Holds_And_Releases_The_Lock()
   {
      SemaphoreSlim           sem = new(1, 1);
      CancellationTokenSource cts = new CancellationTokenSource();

      // ReSharper disable once RedundantAssignment
      var wasHeld = false;

      using (await sem.LockAsync(cts.Token)) wasHeld = sem.CurrentCount == 0;

      Assert.Equal(1, sem.CurrentCount);
      Assert.True(wasHeld);
   }
   
   [Fact]
   public void Lock_With_Canceled_Token_Does_Not_Acquire_The_Lock()
   {
      SemaphoreSlim           sem = new(1, 1);
      CancellationTokenSource cts = new CancellationTokenSource();
      cts.Cancel();
      var wasHeld = false;

      using (sem.Lock(cts.Token)) wasHeld = sem.CurrentCount == 0;

      Assert.Equal(1, sem.CurrentCount);
      Assert.False(wasHeld);
   }

   [Fact]
   public async Task LockAsync_With_Canceled_Token_Does_Not_Acquire_The_Lock()
   {
      SemaphoreSlim           sem = new(1, 1);
      CancellationTokenSource cts = new CancellationTokenSource();
      cts.Cancel();
      var wasHeld = false;

      using (await sem.LockAsync(cts.Token)) wasHeld = sem.CurrentCount == 0;

      Assert.Equal(1, sem.CurrentCount);
      Assert.False(wasHeld);
   }   
}