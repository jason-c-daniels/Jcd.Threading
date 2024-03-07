namespace Jcd.Threading.Tests;

public class SemaphoreSlimExtensionsTests
{
   [Fact]
   public void Lock_Holds_And_Releases_The_Lock()
   {
      SemaphoreSlim sem     = new(1, 1);
      var           wasHeld = false;

      using (sem.Lock()) wasHeld = sem.CurrentCount == 0;

      Assert.Equal(1, sem.CurrentCount);
      Assert.True(wasHeld);
   }

   [Fact]
   public async Task LockAsync_Holds_And_Releases_The_Lock()
   {
      SemaphoreSlim sem     = new(1, 1);
      var           wasHeld = false;

      using (await sem.LockAsync()) wasHeld = sem.CurrentCount == 0;

      Assert.Equal(1, sem.CurrentCount);
      Assert.True(wasHeld);
   }
}