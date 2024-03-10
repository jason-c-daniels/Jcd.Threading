using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Threading;

/// <summary>
/// Provides extension methods to simplify using a <see cref="SemaphoreSlim"/>
/// to ensure the correct pairing of calls to of Enter and Exit.
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
///    using _ = sem.Lock();                     // acquire the lock. But don't use the value. Just dispose it.
///    AShortActionRequiringSynchronization();   // very fast: done in 10 microseconds.
///    AShortActionRequiringSynchronization();   // fast: done in 75 microseconds.
///    AShortActionRequiringNoSynchronization(); // reasonable but unwanted: done in 5 milliseconds.
///    ALongActionRequiringNoSynchronization();  // slow: done in 500 milliseconds.    
/// } // the lock is disposed (and released) here. 
/// </code>
/// <para>
/// The reason the above code is problematic is the lock is held until disposal. 
/// The result of Lock is an <see cref="IDisposable"/> bound to the <see cref="SemaphoreSlim"/>
/// which exits the lock when `Dispose` is called. `Dispose` won't be called until
/// the method is exited, which is the very nature of a using declaration.
/// </para>
/// <para>
/// Instead, use a traditional using block. Below is the corrected code.
/// </para>
/// <para>
/// <code>
/// // problem resolution:
/// void DefinitelyDoThis()
/// {
///    using (sem.Lock())                           // acquire the lock. But don't use the value.
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
public static class SemaphoreSlimExtensions
{
   /// <summary>
   /// Waits on the semaphore, and returns an <see cref="SemaphoreSlimResourceLock"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <returns>an <see cref="SemaphoreSlimResourceLock"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static SemaphoreSlimResourceLock Lock(this SemaphoreSlim sem)
   {
      var rl = GetResourceLock(sem);
      rl.Wait();

      return rl;
   }

   /// <summary>
   /// Waits on the semaphore, and returns an <see cref="SemaphoreSlimResourceLock"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <param name="token">A cancellation token to use during the wait.</param>
   /// <returns>an <see cref="SemaphoreSlimResourceLock"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static SemaphoreSlimResourceLock Lock(this SemaphoreSlim sem, CancellationToken token)
   {
      var rl = GetResourceLock(sem);
      rl.Wait(token);

      return rl;
   }

   /// <summary>
   /// Asynchronously waits on the semaphore, and returns an <see cref="SemaphoreSlimResourceLock"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <returns>A <see cref="Task{T}"/> for an <see cref="SemaphoreSlimResourceLock"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static async Task<SemaphoreSlimResourceLock> LockAsync(this SemaphoreSlim sem)
   {
      var rl = GetResourceLock(sem);
      await rl.WaitAsync();

      return rl;
   }

   /// <summary>
   /// Asynchronously waits on the semaphore, and returns an <see cref="SemaphoreSlimResourceLock"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <param name="token">A cancellation token to use during the wait.</param>
   /// <returns>A <see cref="Task{T}"/> for an <see cref="SemaphoreSlimResourceLock"/> that calls Release in its Dispose method.</returns>
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