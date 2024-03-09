using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Threading;

/// <summary>
/// Provides a base mechanism for managing the state of an <see cref="IResourceLock"/>
/// </summary>
public abstract class ResourceLockBase : IResourceLock
{
   /// <inheritdoc />
   public bool IsWaiting { get; private set; }

   /// <inheritdoc />
   public bool IsLocked { get; private set; }

   /// <inheritdoc />
   public bool IsReleased { get; private set; }

   /// <inheritdoc />
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public abstract bool Wait();

   /// <inheritdoc />
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public abstract bool Wait(CancellationToken token);

   /// <inheritdoc />
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public abstract Task<bool> WaitAsync();

   /// <inheritdoc />
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public abstract Task<bool> WaitAsync(CancellationToken token);

   /// <summary>
   /// Sets IsLocked to true and returns true.
   /// </summary>
   /// <returns>true</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   protected bool LockAcquired()
   {
      if (IsLocked)
         throw new
            InvalidOperationException($"{nameof(LockAcquired)} may not called twice in a row without first calling Release"
                                     );

      return IsLocked = true;
   }

   /// <inheritdoc/>
   public abstract void Release();

   /// <summary>
   /// Sets flags indicated the lock has been released.
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   protected void ReleaseLock()
   {
      IsLocked   = false;
      IsReleased = true;
   }

   /// <summary>
   /// Removes the lock from the IsWaiting state. Call at the end of your Release method.
   /// </summary>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   protected void EndWait()
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
   protected void BeginWait()
   {
      if (IsLocked || IsWaiting)
         throw new
            InvalidOperationException($"{nameof(BeginWait)} may not be waited on twice in a row, without first calling Release.");
      IsWaiting  = true;
      IsReleased = false;
   }

   /// <inheritdoc />
   public abstract void Dispose();
}