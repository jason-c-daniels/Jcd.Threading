﻿using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Threading;

/// <summary>
/// Provides a single-use mechanism for establishing and releasing locks on a <see cref="SemaphoreSlim"/>.
/// </summary>
/// <param name="internalLock">The <see cref="SemaphoreSlim"/> to lock and release. </param>
/// <remarks>
/// <para>
/// Do not share instances of this type across threads or synchronization contexts.
/// Behavior can be unpredictable. This exists to be used in conjunction
/// with the .Lock extension method for <see cref="SemaphoreSlim"/> and
/// advanced use cases.
/// </para> 
/// </remarks>
public class SemaphoreSlimResourceLock(SemaphoreSlim internalLock) : ResourceLockBase
{
   /// <inheritdoc/>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override bool Wait()
   {
      BeginWait();

      try
      {
         internalLock.Wait();

         return LockAcquired();
      }
      finally
      {
         EndWait();
      }
   }

   /// <inheritdoc/>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override bool Wait(CancellationToken token)
   {
      if (token.IsCancellationRequested) return false;

      BeginWait();

      try
      {
         internalLock.Wait(token);

         return LockAcquired();
      }
      finally
      {
         EndWait();
      }
   }

   /// <inheritdoc/>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override async Task<bool> WaitAsync()
   {
      BeginWait();

      try
      {
         await internalLock.WaitAsync();

         return LockAcquired();
      }
      finally
      {
         EndWait();
      }
   }

   /// <inheritdoc/>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override async Task<bool> WaitAsync(CancellationToken token)
   {
      if (token.IsCancellationRequested) return false;

      BeginWait();

      try
      {
         await internalLock.WaitAsync(token);

         return LockAcquired();
      }
      finally
      {
         EndWait();
      }
   }

   /// <inheritdoc/>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public override void Release()
   {
      if (IsLocked)
         internalLock.Release();
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