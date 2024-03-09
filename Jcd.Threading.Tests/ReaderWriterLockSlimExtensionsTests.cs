namespace Jcd.Threading.Tests;

public class ReaderWriterLockSlimExtensionsTests
{
   [Theory]
   [InlineData(ReaderWriterLockSlimIntent.Read)]
   [InlineData(ReaderWriterLockSlimIntent.Write)]
   [InlineData(ReaderWriterLockSlimIntent.UpgradeableRead)]
   public void Lock_Holds_The_Lock_With_The_Provided_Method_And_Releases_It(ReaderWriterLockSlimIntent intent)
   {
      ReaderWriterLockSlim        rwls = new();
      ReaderWriterLockSlimIntent? lockType;
      ReaderWriterLockSlimIntent? expectedLockType = intent;
      using (rwls.Lock(intent)) lockType           = GetIntent(rwls);

      Assert.NotNull(lockType);
      Assert.Equal(expectedLockType, lockType);
   }

   [Theory]
   [InlineData(ReaderWriterLockSlimIntent.Read)]
   [InlineData(ReaderWriterLockSlimIntent.Write)]
   [InlineData(ReaderWriterLockSlimIntent.UpgradeableRead)]
   public async Task LockAsync_Holds_The_Lock_With_The_Provided_Method_And_Releases_It(
      ReaderWriterLockSlimIntent intent
   )
   {
      ReaderWriterLockSlim        rwls = new();
      ReaderWriterLockSlimIntent? lockType;
      ReaderWriterLockSlimIntent? expectedLockType  = intent;
      using (await rwls.LockAsync(intent)) lockType = GetIntent(rwls);

      Assert.NotNull(lockType);
      Assert.Equal(expectedLockType, lockType);
   }

   private static ReaderWriterLockSlimIntent? GetIntent(ReaderWriterLockSlim rwls)
   {
      if (rwls.IsUpgradeableReadLockHeld) return ReaderWriterLockSlimIntent.UpgradeableRead;
      if (rwls.IsWriteLockHeld) return ReaderWriterLockSlimIntent.Write;
      if (rwls.IsReadLockHeld) return ReaderWriterLockSlimIntent.Read;

      return null;
   }
}