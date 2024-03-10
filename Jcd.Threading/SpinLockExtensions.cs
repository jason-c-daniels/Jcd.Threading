using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace Jcd.Threading;

/// <summary>
/// Provides extension methods to simplify using a <see cref="SpinLock"/>
/// to ensure the correct pairing of calls to of Wait and Release.
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
/// <para>
/// NB: The following examples are for .net7.0 and up. This is because `ref struct`s
/// were released with .net7.0. Since <see cref="SpinLock"/> is a struct, the only
/// way to track a reference to it is to use a `ref struct`.
/// </para>
/// <code>
/// // problem illustration:
/// void DoNotDoThis()
/// {
///    using _ = sl.Lock();                     // acquire the lock. But don't use the value. Just dispose it.
///    AShortActionRequiringSynchronization();   // very fast: done in 10 microseconds.
///    AShortActionRequiringSynchronization();   // fast: done in 75 microseconds.
///    AShortActionRequiringNoSynchronization(); // reasonable but unwanted: done in 5 milliseconds.
///    ALongActionRequiringNoSynchronization();  // slow: done in 500 milliseconds.    
/// } // the lock is disposed (and released) here. 
/// </code>
/// <para>
/// The reason the above code is problematic is the lock is held until disposal. 
/// The result of Lock is an <see cref="IDisposable"/> bound to the <see cref="SpinLock"/>
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
///    using (sl.Lock()) // acquire the lock. But don't use the value.
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
internal static class SpinLockExtensions
{
   /// <summary>
   /// Acquires exclusive access to the spinLock and executes the provided action.
   /// </summary>
   /// <param name="spinLock">The <see cref="SpinLock"/> to use for locking.</param>
   /// <param name="action">The action to perform</param>
   /// <param name="useMemoryBarrierOnExit">Passed to `Exit` when releasing the lock.</param>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static void Lock(this ref SpinLock spinLock, Action action, bool useMemoryBarrierOnExit = false)
   {
      var lockTaken = false;

      try
      {
         spinLock.Enter(ref lockTaken);
         action();
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrierOnExit);
      }
   }

   /// <summary>
   /// Acquires exclusive access to the spinLock and executes the provided action.
   /// </summary>
   /// <param name="spinLock">The <see cref="SpinLock"/> to use for locking.</param>
   /// <param name="action">The action to perform</param>
   /// <param name="useMemoryBarrierOnExit">Passed to `Exit` when releasing the lock.</param>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static Task LockAsync(this ref SpinLock spinLock, Action action, bool useMemoryBarrierOnExit = false)
   {
      var lockTaken = false;

      try
      {
         spinLock.Enter(ref lockTaken);
         action();

         return Task.CompletedTask;
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrierOnExit);
      }
   }

   #region requires ref struct support

   #if REF_STRUCT_SUPPORT
   /// <summary>
   /// Waits on the semaphore, and returns an <see cref="SpinLockResourceLock"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <returns>an <see cref="SpinLockResourceLock"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static SpinLockResourceLock Lock(this ref SpinLock sem) { return sem.Lock(CancellationToken.None); }

   /// <summary>
   /// Waits on the semaphore, and returns an <see cref="SpinLockResourceLock"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <param name="token">A cancellation token to use during the wait.</param>
   /// <returns>an <see cref="SpinLockResourceLock"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static SpinLockResourceLock Lock(this ref SpinLock sem, CancellationToken token)
   {
      var rl = GetResourceLock(ref sem);
      rl.Wait(token);

      return rl;
   }

   /// <summary>
   /// Gets a resource lock bound to the instance of a <see cref="SpinLock"/>
   /// </summary>
   /// <param name="sem">The <see cref="SpinLock"/> to create the resource lock for.</param>
   /// <returns>A resource lock bound to the instance of a <see cref="SpinLock"/></returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static SpinLockResourceLock GetResourceLock(this ref SpinLock sem)
   {
      return new SpinLockResourceLock(ref sem);
   }

   #endif

   #endregion
}