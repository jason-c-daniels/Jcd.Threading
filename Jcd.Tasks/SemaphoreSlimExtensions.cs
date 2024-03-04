﻿using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A set of extension methods to simplify using a <see cref="SemaphoreSlim"/>
/// to ensure that Release is called for every Wait or WaitAsync. Useful for
/// ensuring synchronized access to data for short lived operations.
/// </summary>
public static class SemaphoreSlimExtensions
{
   private sealed class SemLock : IDisposable
   {
      private readonly SemaphoreSlim sem;
      internal SemLock(SemaphoreSlim sem) { this.sem = sem; }

      public void Dispose() { sem.Release(); }
   }

   /// <summary>
   /// Waits on the semaphore, and returns an <see cref="IDisposable"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <returns>an <see cref="IDisposable"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static IDisposable Lock(this SemaphoreSlim sem) { return sem.Lock(CancellationToken.None); }

   /// <summary>
   /// Waits on the semaphore, and returns an <see cref="IDisposable"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <param name="token">A cancellation token to use during the wait.</param>
   /// <returns>an <see cref="IDisposable"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static IDisposable Lock(this SemaphoreSlim sem, CancellationToken token)
   {
      sem.Wait(token);

      return new SemLock(sem);
   }

   /// <summary>
   /// Waits on the semaphore, and returns an <see cref="IDisposable"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <param name="token">A cancellation token to use during the wait.</param>
   /// <returns>an <see cref="IDisposable"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static void Lock(this SemaphoreSlim sem, Action action)
   {
      try
      {
         sem.Wait();
         action();
      }
      finally
      {
         sem.Release();
      }

   }
   /// <summary>
   /// Asynchronously waits on the semaphore, and returns an <see cref="IDisposable"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <returns>A <see cref="Task{T}"/> for an <see cref="IDisposable"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static Task<IDisposable> LockAsync(this SemaphoreSlim sem) { return sem.LockAsync(CancellationToken.None); }

   /// <summary>
   /// Asynchronously waits on the semaphore, and returns an <see cref="IDisposable"/> that calls Release.
   /// </summary>
   /// <param name="sem">the semaphore to use.</param>
   /// <param name="token">A cancellation token to use during the wait.</param>
   /// <returns>A <see cref="Task{T}"/> for an <see cref="IDisposable"/> that calls Release in its Dispose method.</returns>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static async Task<IDisposable> LockAsync(this SemaphoreSlim sem, CancellationToken token)
   {
      await sem.WaitAsync(token);

      return new SemLock(sem);
   }
}