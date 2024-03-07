using BenchmarkDotNet.Attributes;

using Nito.AsyncEx;

namespace Jcd.Threading.Examples.Benchmark.SynchronizedOperations;

public sealed class NitoAsyncOperations : IDisposable
{
   private readonly AsyncLock     nito     = new();
   private readonly SemaphoreSlim sem      = new(1, 1);
   public           int           RawValue = 11;

   [Benchmark]
   public int UsingAsyncLock_Lock_ReadValue()
   {
      using (nito.Lock())
         return RawValue;
   }

   [Benchmark]
   public int UsingAsyncLock_Lock_WriteValue()
   {
      using (nito.Lock())
         RawValue = 12;

      return RawValue;
   }

   [Benchmark]
   public async Task<int> UsingAsyncLock_LockAsync_ReadValue()
   {
      using (await nito.LockAsync())
         return RawValue;
   }

   [Benchmark]
   public async Task<int> UsingAsyncLock_LockAsync_WriteValue()
   {
      using (await nito.LockAsync())
         RawValue = 12;

      return RawValue;
   }

   [Benchmark]
   public int UsingSemaphoreSlimExtensions_ReadValue()
   {
      using (Nito.AsyncEx.SemaphoreSlimExtensions.Lock(sem))
         return RawValue;
   }

   [Benchmark]
   public int UsingSemaphoreSlimExtensions_WriteValue()
   {
      using (Nito.AsyncEx.SemaphoreSlimExtensions.Lock(sem))
         RawValue = 15;

      return RawValue;
   }

   public void Dispose() { sem.Dispose(); }
}