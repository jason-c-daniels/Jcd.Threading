using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A set of extension methods to simplify using a <see cref="ReaderWriterLockSlim"/>
/// to ensure the correct pair of EnterRead+ExitRead, EnterUpgradeableRead+ExitUpgradeableRead,
/// and EnterWrite+ExitWrite are called.
/// </summary>
public static class ReaderWriterLockSlimExtensions
{
   private abstract class LockBase(ReaderWriterLockSlim @lock) : IDisposable
   {
      protected readonly ReaderWriterLockSlim Lock = @lock;

      public void Dispose()
      {
         if (Lock.IsWriteLockHeld)
            Lock.ExitWriteLock();
         else if (Lock.IsUpgradeableReadLockHeld)
            Lock.ExitUpgradeableReadLock();
         else if (Lock.IsReadLockHeld)
            Lock.ExitReadLock();
      }
   }

   private sealed class ReadLock : LockBase
   {
      internal ReadLock(ReaderWriterLockSlim @lock) : base(@lock) { Lock.EnterReadLock(); }
   }

   private sealed class UpgradeableReadLock : LockBase
   {
      internal UpgradeableReadLock(ReaderWriterLockSlim @lock) : base(@lock) { Lock.EnterUpgradeableReadLock(); }
   }

   private sealed class WriteLock : LockBase
   {
      internal WriteLock(ReaderWriterLockSlim @lock) : base(@lock) { Lock.EnterUpgradeableReadLock(); }
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static IDisposable Lock(this ReaderWriterLockSlim @lock, ReaderWriterLockSlimIntent intent=ReaderWriterLockSlimIntent.Read)
   {
      return intent switch
             {
                ReaderWriterLockSlimIntent.UpgradeableRead => new UpgradeableReadLock(@lock)
              , ReaderWriterLockSlimIntent.Write           => new WriteLock(@lock)
              , _                                          => new ReadLock(@lock)
             };
   }
   
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static Task<IDisposable> LockAsync(this ReaderWriterLockSlim @lock, ReaderWriterLockSlimIntent intent=ReaderWriterLockSlimIntent.Read)
   {
      return Task.FromResult<IDisposable>(intent switch
                                          {
                                             ReaderWriterLockSlimIntent.UpgradeableRead => new UpgradeableReadLock(@lock)
                                           , ReaderWriterLockSlimIntent.Write           => new WriteLock(@lock)
                                           , _                                          => new ReadLock(@lock)
                                          });
   }

}

public enum ReaderWriterLockSlimIntent
{
   Read,
   UpgradeableRead,
   Write
}