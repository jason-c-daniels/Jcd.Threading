using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace Jcd.Threading;

/// <summary>
/// Provides extension methods to simplify using a <see cref="ReaderWriterLockSlim"/>
/// to ensure the correct pair of EnterRead+ExitRead, EnterUpgradeableRead+ExitUpgradeableRead,
/// and EnterWrite+ExitWrite are called.
/// </summary>
public static class ReaderWriterLockSlimExtensions
{
   /// <summary>
   /// Waits on a <see cref="ReaderWriterLockSlim"/> and returns a <see cref="ReaderWriterLockSlimResourceLock"/> that
   /// calls the appropriate exit method on the lock during disposal. 
   /// </summary>
   /// <param name="rwls">The lock to acquire and release.</param>
   /// <param name="intent">The type of lock being acquired. By default this is a Read</param>
   /// <returns>the <see cref="ReaderWriterLockSlimResourceLock"/> to release the resources.</returns>
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
   /// <remarks>
   /// <para>
   /// This method is intended to be used with a using block.
   /// There is little value in using it otherwise.
   /// </para>
   /// <code>
   /// // example usage.
   /// var rwls = new ReaderWriterLockSlim();
   /// var cts = new CancellationTokenSource();
   /// 
   /// using (rwls.Lock(ReaderWriterLockSlimIntent.Write, cts.Token))
   /// {
   ///    // write to a critical set of values here.
   ///    // ..
   /// }
   /// </code>
   /// </remarks>
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
   /// <remarks>
   /// <para>
   /// This method is intended to be used with a using block.
   /// There is little value in using it otherwise.
   /// </para>
   /// <code>
   /// // example usage.
   /// var rwls = new ReaderWriterLockSlim();
   /// var cts = new CancellationTokenSource();
   /// 
   /// using (await rwls.LockAsync(ReaderWriterLockSlimIntent.Write, cts.Token))
   /// {
   ///    // write to a critical set of values here.
   ///    // ..
   /// }
   /// </code>
   /// </remarks>
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
   /// Gets a resource lock bound to the instance of a <see cref="SemaphoreSlim"/>
   /// </summary>
   /// <param name="rwls">The <see cref="SemaphoreSlim"/> to create the resource lock for.</param>
   /// <param name="intent">The intended purpose of the lock.</param>
   /// <returns>A resource lock bound to the instance of a <see cref="SemaphoreSlim"/></returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static ReaderWriterLockSlimResourceLock GetResourceLock(
      this ReaderWriterLockSlim  rwls
    , ReaderWriterLockSlimIntent intent
   )
   {
      return new ReaderWriterLockSlimResourceLock(rwls, intent);
   }
}