using BenchmarkDotNet.Attributes;

using Jcd.Threading.SynchronizedValues;

// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ClosureAllocation

namespace Jcd.Threading.Examples.Benchmark.SynchronizedOperations;

public sealed class SemaphoreSlimOperations : IDisposable
{
   private readonly SemaphoreSlimValue<int> mv       = new(12);
   private readonly SemaphoreSlim           sem      = new(1, 1);
   public           int                     RawValue = 13;

   [Benchmark]
   public int UsingMutexValue_ReadValue() { return mv.Value; }

   [Benchmark]
   public int UsingMutexValue_WriteValue()
   {
      mv.Value = RawValue;

      return RawValue;
   }

   [Benchmark]
   public int UsingSemaphoreDirectly_ReadValue()
   {
      try
      {
         sem.Wait();

         return RawValue;
      }
      finally
      {
         sem.Release();
      }
   }

   [Benchmark]
   public int UsingSemaphoreDirectly_WriteValue()
   {
      try
      {
         sem.Wait();

         RawValue = 171;
      }
      finally
      {
         sem.Release();
      }

      return RawValue;
   }

   [Benchmark]
   public async Task<int> UsingSemaphoreDirectly_ReadValueAsync()
   {
      try
      {
         await sem.WaitAsync();

         return RawValue;
      }
      finally
      {
         sem.Release();
      }
   }

   [Benchmark]
   public async Task<int> UsingSemaphoreDirectly_WriteValueAsync()
   {
      try
      {
         await sem.WaitAsync();

         RawValue = 171;
      }
      finally
      {
         sem.Release();
      }

      return RawValue;
   }

   [Benchmark]
   public int UsingExtensions_ReadValue()
   {
      using (sem.Lock())
         return RawValue;
   }

   [Benchmark]
   public int UsingExtensions_WriteValue()
   {
      using (sem.Lock())
         RawValue = 311;

      return RawValue;
   }

   [Benchmark]
   public async Task<int> UsingExtensions_ReadValueAsync()
   {
      using (await sem.LockAsync())
         return RawValue;
   }

   [Benchmark]
   public async Task<int> UsingExtensions_WriteValueAsync()
   {
      using (await sem.LockAsync())
         RawValue = 311;

      return RawValue;
   }

   public void Dispose()
   {
      mv.Dispose();
      sem.Dispose();
   }
}