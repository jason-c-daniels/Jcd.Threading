using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Threading;

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
      internal ReadLock(ReaderWriterLockSlim @lock) : base(@lock) { Lock.TryEnterReadLock(-1); }
   }

   private sealed class UpgradeableReadLock : LockBase
   {
      internal UpgradeableReadLock(ReaderWriterLockSlim @lock) : base(@lock) { Lock.TryEnterUpgradeableReadLock(-1); }
   }

   private sealed class WriteLock : LockBase
   {
      internal WriteLock(ReaderWriterLockSlim @lock) : base(@lock) { Lock.TryEnterWriteLock(-1); }
   }

   /// <summary>
   /// Waits on a <see cref="ReaderWriterLockSlim"/> and returns an IDisposable that
   /// calls the appropriate exit method on the lock during disposal. 
   /// </summary>
   /// <param name="lock">The lock to acquire and release.</param>
   /// <param name="intent">The type of lock being acquired. By default this is a Read</param>
   /// <returns>the IDisposable to release the resources.</returns>
   /// <remarks>
   /// <para>
   /// This method is intended to be used with a using block.
   /// There is little value in using it otherwise.
   /// </para>
   /// <code>
   /// // example usage.
   /// var rwls = new ReaderWriterLockSlim();
   ///
   /// using (rwls.Lock(ReaderWriterLockSlimIntent.Write))
   /// {
   ///    // write to a critical set of values here.
   ///    // ..
   /// }
   /// </code>
   /// </remarks>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static IDisposable Lock(
      this ReaderWriterLockSlim  @lock
    , ReaderWriterLockSlimIntent intent = ReaderWriterLockSlimIntent.Read
   )
   {
      return intent switch
             {
                ReaderWriterLockSlimIntent.UpgradeableRead => new UpgradeableReadLock(@lock)
              , ReaderWriterLockSlimIntent.Write           => new WriteLock(@lock)
              , _                                          => new ReadLock(@lock)
             };
   }


   /// <summary>
   /// Waits on a <see cref="ReaderWriterLockSlim"/> and returns an IDisposable that
   /// calls the appropriate exit method on the lock during disposal. 
   /// </summary>
   /// <param name="lock">The lock to acquire and release.</param>
   /// <param name="intent">The type of lock being acquired. By default this is a Read</param>
   /// <returns>the IDisposable to release the resources.</returns>
   /// <remarks>
   /// <para>
   /// This method is intended to be used with a using block.
   /// There is little value in using it otherwise.
   /// </para>
   /// <code>
   /// // example usage.
   /// var rwls = new ReaderWriterLockSlim();
   ///
   /// using (await rwls.LockAsync(ReaderWriterLockSlimIntent.Write))
   /// {
   ///    // write to a critical set of values here.
   ///    // ..
   /// }
   /// </code>
   /// </remarks>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static Task<IDisposable> LockAsync(
      this ReaderWriterLockSlim  @lock
    , ReaderWriterLockSlimIntent intent = ReaderWriterLockSlimIntent.Read
   )
   {
      return Task.FromResult<IDisposable>(intent switch
                                          {
                                             ReaderWriterLockSlimIntent.UpgradeableRead =>
                                                new UpgradeableReadLock(@lock)
                                           , ReaderWriterLockSlimIntent.Write => new WriteLock(@lock)
                                           , _                                => new ReadLock(@lock)
                                          }
                                         );
   }
}