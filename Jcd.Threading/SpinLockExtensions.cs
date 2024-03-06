using System;
using System.Threading;
using System.Threading.Tasks;

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
   public static void Lock(this ref SpinLock spinLock, Action action, bool useMemoryBarrierOnExit = false)
   {
      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);
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
   public static Task LockAsync(this ref SpinLock spinLock, Action action, bool useMemoryBarrierOnExit = false)
   {
      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);
         action();

         return Task.CompletedTask;
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrierOnExit);
      }
   }
}