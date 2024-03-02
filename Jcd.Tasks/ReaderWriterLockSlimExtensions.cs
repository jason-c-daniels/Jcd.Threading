using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A set of extension methods to simplify using a <see cref="ReaderWriterLockSlim"/>
/// to ensure the correct pair of EnterRead+ExitRead, EnterUpgradeableRead+ExitUpgradeableRead,
/// and EnterWrite+ExitWrite are called.
/// </summary>
public static class ReaderWriterLockSlimExtensions
{

   private sealed class ReadLock : IDisposable
   {
      private readonly ReaderWriterLockSlim rwls;

      internal ReadLock(ReaderWriterLockSlim rwls)
      {
         this.rwls = rwls;
         this.rwls.EnterReadLock();
      }

      public void Dispose() => rwls.ExitReadLock();
   }

   private sealed class UpgradeableReadLock : IDisposable
   {
      private readonly ReaderWriterLockSlim rwls;

      internal UpgradeableReadLock(ReaderWriterLockSlim rwls)
      {
         this.rwls = rwls;
         this.rwls.EnterUpgradeableReadLock();
      }

      public void Dispose() => rwls.ExitUpgradeableReadLock();
   }

   private sealed class WriteLock : IDisposable
   {
      private readonly ReaderWriterLockSlim rwls;

      internal WriteLock(ReaderWriterLockSlim rwls)
      {
         this.rwls = rwls;
         this.rwls.EnterUpgradeableReadLock();
      }

      public void Dispose() => rwls.ExitUpgradeableReadLock();
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static IDisposable Read(this ReaderWriterLockSlim rwls, bool isUpgradeable = false)
   {
      if (isUpgradeable)
         return new UpgradeableReadLock(rwls);

      return new ReadLock(rwls);
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static IDisposable Write(this ReaderWriterLockSlim rwls) { return new WriteLock(rwls); }
   
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static Task<IDisposable> ReadAsync(this ReaderWriterLockSlim rwls, bool isUpgradeable = false)
   {
      if (isUpgradeable)
         return Task.FromResult<IDisposable>(new UpgradeableReadLock(rwls));

      return Task.FromResult<IDisposable>(new ReadLock(rwls)); 
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public static Task<IDisposable> WriteAsync(this ReaderWriterLockSlim rwls)
   {
      return Task.FromResult<IDisposable>(new WriteLock(rwls)); 
   }   
}