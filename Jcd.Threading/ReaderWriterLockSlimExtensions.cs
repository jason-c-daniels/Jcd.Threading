using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace Jcd.Threading;

/// <summary>
/// Provides extension methods to simplify using a <see cref="ReaderWriterLockSlim"/>
/// to ensure the correct pair of EnterRead plus ExitRead, EnterUpgradeableRead plus ExitUpgradeableRead,
/// and EnterWrite plus ExitWrite are called.
/// </summary>
/// <remarks>
/// <para>
/// These methods are intended to be used with a using block as illustrated below. 
/// This will ensure the lock is held for no more time than necessary.
/// 
/// Contrast this with a using declaration where an method may grow in length over time,
/// and and execution time. Usually most of the lines in those methods shouldn't hold
/// the lock. The reason is the longer a lock is held, the more contention there will be.
/// And large scale contention for resources adversely impacts performance application
/// performance.
/// </para>
/// <code>
/// // problem illustration:
/// void DoNotDoThis()
/// {
///    using _ = rwls.Lock(ReaderWriterLockSlimIntent.Write); // acquire the lock. But don't use the value. Just dispose it.
///    AShortActionRequiringSynchronization();   // very fast: done in 10 microseconds.
///    AShortActionRequiringSynchronization();   // fast: done in 75 microseconds.
///    AShortActionRequiringNoSynchronization(); // reasonable but unwanted: done in 5 milliseconds.
///    ALongActionRequiringNoSynchronization();  // slow: done in 500 milliseconds.    
/// } // the lock is disposed (and released) here. 
/// </code>
/// <para>
/// The reason the above code is problematic is the lock is held until disposal. 
/// The result of Lock is an <see cref="IDisposable"/> bound to the <see cref="ReaderWriterLockSlim"/>
/// which exits the lock when `Dispose` is called. `Dispose` won't be called until
/// the method is exited, the very nature of a using declaration.
/// </para>
/// <para>
/// Instead, use a traditional using block. Below is the corrected code.
/// </para>
/// <para>
/// <code>
/// // problem resolution:
/// void DefinitelyDoThis()
/// {
///    using (rwls.Lock(ReaderWriterLockSlimIntent.Write)) // acquire the lock. But don't use the value.
///    { 
///       AShortActionRequiringSynchronization();   // very fast: done in 10 microseconds.
///       AShortActionRequiringSynchronization();   // fast: done in 75 microseconds.
///    } 
///    AShortActionRequiringNoSynchronization();    // the lock is no longer held. This won't cause contention.
///    ALongActionRequiringNoSynchronization();     // the lock is no longer held. This won't cause contention.
/// } 
/// </code>
/// </para>
/// <para>
/// As you can see, a using block clearly describes the scope for which
/// the lock needs to be held.
/// </para>
/// </remarks>
public static class ReaderWriterLockSlimExtensions
{
   /// <summary>
   /// Waits on a <see cref="ReaderWriterLockSlim"/> and returns a <see cref="ReaderWriterLockSlimResourceLock"/> that
   /// calls the appropriate exit method on the lock during disposal. 
   /// </summary>
   /// <param name="rwls">The lock to acquire and release.</param>
   /// <param name="intent">The type of lock being acquired. By default this is a Read</param>
   /// <returns>the <see cref="ReaderWriterLockSlimResourceLock"/> to release the resources.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static ReaderWriterLockSlimResourceLock Lock(
      this ReaderWriterLockSlim  rwls
    , ReaderWriterLockSlimIntent intent = ReaderWriterLockSlimIntent.Read
   )
   {
      var rl = rwls.GetResourceLock(intent);
      rl.Wait();

      return rl;
   }

   /// <summary>
   /// Waits on a <see cref="ReaderWriterLockSlim"/> and returns a <see cref="ReaderWriterLockSlimResourceLock"/> that
   /// calls the appropriate exit method on the lock during disposal. 
   /// </summary>
   /// <param name="rwls">The lock to acquire and release.</param>
   /// <param name="intent">The type of lock being acquired. By default this is a Read</param>
   /// <param name="token">The <see cref="CancellationToken"/> to inspect for cancellation requests</param>
   /// <returns>the <see cref="ReaderWriterLockSlimResourceLock"/> to release the resources.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static ReaderWriterLockSlimResourceLock Lock(
      this ReaderWriterLockSlim  rwls
    , ReaderWriterLockSlimIntent intent
    , CancellationToken          token
   )
   {
      var rl = rwls.GetResourceLock(intent);
      rl.Wait(token);

      return rl;
   }

   /// <summary>
   /// Waits on a <see cref="ReaderWriterLockSlim"/> and returns a <see cref="ReaderWriterLockSlimResourceLock"/> that
   /// calls the appropriate exit method on the lock during disposal. 
   /// </summary>
   /// <param name="rwls">The lock to acquire and release.</param>
   /// <param name="intent">The type of lock being acquired. By default this is a Read</param>
   /// <returns>the <see cref="ReaderWriterLockSlimResourceLock"/> to release the resources.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static async Task<ReaderWriterLockSlimResourceLock> LockAsync(
      this ReaderWriterLockSlim  rwls
    , ReaderWriterLockSlimIntent intent = ReaderWriterLockSlimIntent.Read
   )
   {
      var rl = rwls.GetResourceLock(intent);
      await rl.WaitAsync();

      return rl;
   }

   /// <summary>
   /// Waits on a <see cref="ReaderWriterLockSlim"/> and returns a <see cref="ReaderWriterLockSlimResourceLock"/> that
   /// calls the appropriate exit method on the lock during disposal. 
   /// </summary>
   /// <param name="rwls">The lock to acquire and release.</param>
   /// <param name="token">the <see cref="CancellationToken"/> to inspect for cancellation requests.</param>
   /// <param name="intent">The type of lock being acquired. By default this is a Read</param>
   /// <returns>the <see cref="ReaderWriterLockSlimResourceLock"/> to release the resources.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static async Task<ReaderWriterLockSlimResourceLock> LockAsync(
      this ReaderWriterLockSlim  rwls
    , ReaderWriterLockSlimIntent intent
    , CancellationToken          token
   )
   {
      var rl = rwls.GetResourceLock(intent);

      await rl.WaitAsync(token);

      return rl;
   }

   /// <summary>
   /// Gets a resource lock bound to the instance of a <see cref="ReaderWriterLockSlim"/>
   /// </summary>
   /// <param name="rwls">The <see cref="ReaderWriterLockSlim"/> to create the resource lock for.</param>
   /// <param name="intent">The intended purpose of the lock.</param>
   /// <returns>A resource lock bound to the instance of a <see cref="ReaderWriterLockSlim"/></returns>
   /// <remarks>
   /// <para>
   /// This method is intended for advanced use cases. While the return type is <see cref="IDisposable"/>
   /// immediate disposal is effectively a very expensive no-op. This method merely creates the binding
   /// which provides the uniform Wait/Release calls.
   /// </para>
   /// </remarks>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static ReaderWriterLockSlimResourceLock GetResourceLock(
      this ReaderWriterLockSlim  rwls
    , ReaderWriterLockSlimIntent intent
   )
   {
      return new ReaderWriterLockSlimResourceLock(rwls, intent);
   }
}