using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Threading;

/// <summary>
/// A set of extension methods to simplify using a <see cref="SemaphoreSlim"/>
/// to ensure that Release is called for every Wait or WaitAsync. Useful for
/// ensuring synchronized access to data for short lived operations.
/// </summary>
public static class SemaphoreSlimExtensions
{
   /// <summary>
   /// Waits on the semaphore, and returns an <see cref="IDisposable"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <returns>an <see cref="IDisposable"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static SemaphoreSlimResourceLock Lock(this SemaphoreSlim sem) { return sem.Lock(CancellationToken.None); }

   /// <summary>
   /// Waits on the semaphore, and returns an <see cref="IDisposable"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <param name="token">A cancellation token to use during the wait.</param>
   /// <returns>an <see cref="IDisposable"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static SemaphoreSlimResourceLock Lock(this SemaphoreSlim sem, CancellationToken token)
   {
      var rl = GetResourceLock(sem);
      rl.Wait(token);

      return rl;
   }

   /// <summary>
   /// Asynchronously waits on the semaphore, and returns an <see cref="IDisposable"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <returns>A <see cref="Task{T}"/> for an <see cref="IDisposable"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static Task<SemaphoreSlimResourceLock> LockAsync(this SemaphoreSlim sem)
   {
      return sem.LockAsync(CancellationToken.None);
   }

   /// <summary>
   /// Asynchronously waits on the semaphore, and returns an <see cref="IDisposable"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <param name="token">A cancellation token to use during the wait.</param>
   /// <returns>A <see cref="Task{T}"/> for an <see cref="IDisposable"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static async Task<SemaphoreSlimResourceLock> LockAsync(this SemaphoreSlim sem, CancellationToken token)
   {
      var rl = GetResourceLock(sem);
      await rl.WaitAsync(token);

      return rl;
   }

   /// <summary>
   /// Gets a resource lock bound to the instance of a <see cref="SemaphoreSlim"/>
   /// </summary>
   /// <param name="sem">The <see cref="SemaphoreSlim"/> to create the resource lock for.</param>
   /// <returns>A resource lock bound to the instance of a <see cref="SemaphoreSlim"/></returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static SemaphoreSlimResourceLock GetResourceLock(this SemaphoreSlim sem)
   {
      return new SemaphoreSlimResourceLock(sem);
   }
}