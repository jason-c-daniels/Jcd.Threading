using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable EmptyNamespace
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

namespace Jcd.Threading;

#if REF_STRUCT_SUPPORT
/// <summary>
/// Acquires a lock on the <see cref="SpinLock"/> it was created with.
/// </summary>
public ref struct SpinLockResourceLock
{
   private ref SpinLock internalLock;

   /// <summary>
   /// Creates an instance of <see cref="SpinLockResourceLock"/> bound to a specific <see cref="SpinLock"/>
   /// </summary>
   /// <param name="internalLock">The <see cref="SpinLock"/> to bind to.</param>
   public SpinLockResourceLock(ref SpinLock internalLock) { this.internalLock = ref internalLock; }

   /// <summary>
   /// Indicates if the lock is currently waiting to acquire the resource.
   /// </summary>
   public bool IsWaiting { get; private set; }

   /// <summary>
   /// Indicates if the lock was acquired by this <see cref="SpinLockResourceLock"/>
   /// </summary>
   public bool IsLocked { get; private set; }

   /// <summary>
   /// Indicates if the lock was released.
   /// </summary>
   public bool IsReleased { get; private set; }

   /// <summary>
   /// Locks the resource. Blocks other calls to Lock until Release is called.
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public bool Wait()
   {
      BeginWait();
      var lockTaken = false;

      try
      {
         internalLock.Enter(ref lockTaken);

         return lockTaken && LockAcquired();
      }
      finally
      {
         EndWait();
      }
   }

   /// <summary>
   /// Locks the resource. Blocks other calls to Lock until Release is called.
   /// </summary>
   /// <param name="token">The token to inspect for cancellation.</param>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public bool Wait(CancellationToken token)
   {
      if (token.IsCancellationRequested) return false;

      BeginWait();
      var lockTaken = false;

      try
      {
         internalLock.Enter(ref lockTaken);

         return lockTaken && LockAcquired();
      }
      finally
      {
         EndWait();
      }
   }

   /// <summary>
   /// Asynchronously Locks the resource. Blocks other calls to Lock until Release is called.
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public Task<bool> WaitAsync()
   {
      BeginWait();

      var lockTaken = false;

      try
      {
         internalLock.Enter(ref lockTaken);

         return Task.FromResult(lockTaken && LockAcquired());
      }
      finally
      {
         EndWait();
      }
   }

   /// <summary>
   /// Asynchronously Locks the resource. Blocks other calls to Lock until Release is called.
   /// </summary>
   /// <param name="token">The token to inspect for cancellation.</param>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public Task<bool> WaitAsync(CancellationToken token)
   {
      if (token.IsCancellationRequested) return Task.FromResult(false);

      BeginWait();
      var lockTaken = false;

      try
      {
         internalLock.Enter(ref lockTaken);

         return Task.FromResult(lockTaken && LockAcquired());
      }
      finally
      {
         EndWait();
      }
   }

   /// <summary>
   /// Sets IsLocked to true and returns true.
   /// </summary>
   /// <returns>true</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   private bool LockAcquired()
   {
      if (IsLocked)
         throw new
            InvalidOperationException($"{nameof(LockAcquired)} may not called twice in a row without first calling Release"
                                     );

      return IsLocked = true;
   }

   /// <summary>
   /// Sets flags indicated the lock has been released.
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   private void ReleaseLock()
   {
      IsLocked = false;
      IsReleased = true;
   }

   /// <summary>
   /// Removes the lock from the IsWaiting state. Call at the end of your Release method.
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   private void EndWait()
   {
      if (!IsWaiting)
         throw new
            InvalidOperationException($"A {nameof(BeginWait)} was not called. {nameof(EndWait)} must always follow {nameof(BeginWait)}"
                                     );
      IsWaiting = false;
   }

   /// <summary>
   /// Removes the lock from the IsWaiting state. 
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   private void BeginWait()
   {
      if (IsLocked || IsWaiting)
         throw new
            InvalidOperationException($"{nameof(BeginWait)} may not be waited on twice in a row, without first calling Release."
                                     );
      IsWaiting = true;
      IsReleased = false;
   }

   /// <summary>
   /// Releases the lock on the resource.
   /// </summary>
   public void Release()
   {
      internalLock.Exit();
      ReleaseLock();
   }

   /// <summary>
   /// Releases the lock on the resource.
   /// </summary>
   public void Dispose() { Release(); }
}
#endif