using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace Jcd.Threading;

/// <summary>
/// Provides extension methods to aid in working with SpinLocks
/// </summary>
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