﻿using System;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMemberInSuper.Global

namespace Jcd.Threading;

/// <summary>
/// Provides an interface for establishing and releasing locks on a resource.
/// </summary>
public interface IResourceLock : IDisposable
{
   /// <summary>
   /// Indicates if the lock is currently waiting to be acquired.
   /// </summary>
   bool IsWaiting { get; }

   /// <summary>
   /// Indicates if the lock was acquired by this <see cref="IResourceLock"/>
   /// </summary>
   bool IsLocked { get; }

   /// <summary>
   /// Indicates if the lock was released.
   /// </summary>
   bool IsReleased { get; }

   /// <summary>
   /// Locks the resource. Blocks other calls to Lock until Release is called.
   /// </summary>
   bool Wait();

   /// <summary>
   /// Locks the resource. Blocks other calls to Lock until Release is called.
   /// </summary>
   /// <param name="token">The token to inspect for cancellation.</param>
   bool Wait(CancellationToken token);

   /// <summary>
   /// Asynchronously Locks the resource. Blocks other calls to Lock until Release is called.
   /// </summary>
   Task<bool> WaitAsync();

   /// <summary>
   /// Asynchronously Locks the resource. Blocks other calls to Lock until Release is called.
   /// </summary>
   /// <param name="token">The token to inspect for cancellation.</param>
   Task<bool> WaitAsync(CancellationToken token);

   /// <summary>
   /// Releases the lock on the resource.
   /// </summary>
   void Release();
}

/// <summary>
/// Provides a mechanism for acquiring resource locks bound to a specific instance of a synchronization primitive.
/// </summary>
/// <typeparam name="T">The type of the resource lock.</typeparam>
public interface IResourceLockFactory<out T>
   where T : IResourceLock
{
   /// <summary>
   /// Acquires a resource lock bound to a synchronization primitive instance.
   /// </summary>
   /// <returns>A resource lock bound to a synchronization primitive instance.</returns>
   T GetResourceLock();
}