using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Threading;

/// <summary>
/// Provides a mechanism for establishing and releasing locks on a <see cref="ReaderWriterLockSlim"/>.
/// </summary>
/// <param name="internalLock">The <see cref="ReaderWriterLockSlim"/> to lock and release. </param>
/// <param name="intent">The intent of the lock (Read, UpgradeableRead, Write)</param>
/// <remarks>
/// <para>
/// Do not share instances of this type across threads or synchronization contexts.
/// Behavior can be unpredictable. These are provided and meant to be used in conjunction
/// with the extension classes to create a more consistent experience when using
/// synchronization primitives.
/// </para> 
/// </remarks>
public class ReaderWriterLockSlimResourceLock
   (ReaderWriterLockSlim internalLock, ReaderWriterLockSlimIntent intent) : ResourceLockBase
{
   /// <summary>
   /// Acquires a lock on the ReaderWriterLockSlim according to the intent it was created with.
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override bool Wait()
   {
      BeginWait();

      switch (intent)
      {
         case ReaderWriterLockSlimIntent.Write:
            internalLock.TryEnterWriteLock(-1);

            break;
         case ReaderWriterLockSlimIntent.UpgradeableRead:
            internalLock.TryEnterUpgradeableReadLock(-1);

            break;
         case ReaderWriterLockSlimIntent.Read:
            internalLock.TryEnterReadLock(-1);

            break;
         default:
            throw new ArgumentOutOfRangeException(nameof(intent), intent, "Unknown value");
      }

      EndWait();

      return true;
   }

   /// <inheritdoc />
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override bool Wait(CancellationToken token)
   {
      if (token.IsCancellationRequested) return false;
      Wait();

      return true;
   }

   /// <inheritdoc />
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override Task<bool> WaitAsync() { return Task.FromResult(Wait()); }

   /// <inheritdoc />
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override Task<bool> WaitAsync(CancellationToken token) { return Task.FromResult(Wait(token)); }

   /// <inheritdoc/>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override void Release()
   {
      if (internalLock.IsWriteLockHeld)
         internalLock.ExitWriteLock();
      if (internalLock.IsUpgradeableReadLockHeld)
         internalLock.ExitUpgradeableReadLock();
      if (internalLock.IsReadLockHeld)
         internalLock.ExitReadLock();
      ReleaseLock();
   }

   /// <summary>
   /// Releases any locks held.
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   #pragma warning disable CA1816
   public override void Dispose() { Release(); }
   #pragma warning restore CA1816
}