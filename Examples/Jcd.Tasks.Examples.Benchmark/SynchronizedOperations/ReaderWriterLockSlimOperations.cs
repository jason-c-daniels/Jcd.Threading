using BenchmarkDotNet.Attributes;

using Jcd.Threading;

namespace Jcd.Threading.Examples.Benchmark.SynchronizedOperations;

public class ReaderWriterLockSlimOperations : IDisposable
{
   private readonly ReaderWriterLockSlim rwls = new();

   public int RawValue = 14;

   [Benchmark]
   public int DirectCalls_ReadValue()
   {
      try
      {
         rwls.EnterReadLock();

         return RawValue;
      }
      finally
      {
         rwls.ExitReadLock();
      }
   }

   [Benchmark]
   public int DirectCalls_WriteValue()
   {
      try
      {
         rwls.EnterWriteLock();

         RawValue = 17;
      }
      finally
      {
         rwls.ExitWriteLock();
      }

      return RawValue;
   }

   [Benchmark]
   public int UsingExtensions_ReadValue()
   {
      int foo;

      using (rwls.Lock())
         foo = RawValue;

      return foo;
   }

   [Benchmark]
   public int UsingExtensions_WriteValue()
   {
      int foo;

      using (rwls.Lock(ReaderWriterLockSlimIntent.Write))
         foo = RawValue;

      return foo;
   }

   [Benchmark]
   public async Task<int> UsingExtensions_ReadValueAsync()
   {
      int foo;

      using (await rwls.LockAsync())
         foo = RawValue;

      return foo;
   }

   [Benchmark]
   public async Task<int> UsingExtensions_WriteValueAsync()
   {
      int foo;

      using (await rwls.LockAsync(ReaderWriterLockSlimIntent.Write))
         foo = RawValue;

      return foo;
   }

   public void Dispose() { rwls.Dispose(); }
}