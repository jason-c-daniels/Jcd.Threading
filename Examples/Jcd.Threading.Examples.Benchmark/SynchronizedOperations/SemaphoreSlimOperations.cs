using BenchmarkDotNet.Attributes;

using Jcd.Threading.SynchronizedValues;

// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ClosureAllocation

namespace Jcd.Threading.Examples.Benchmark.SynchronizedOperations;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class SemaphoreSlimOperations : IDisposable
{
   private readonly SemaphoreSlimValue<int> sv       = new(12);
   private readonly SemaphoreSlim           sem      = new(1, 1);
   public           int                     RawValue = 13;

   [Benchmark]
   public int UsingMutexValue_ReadValue() { return sv.Value; }

   [Benchmark]
   public int UsingMutexValue_WriteValue()
   {
      sv.Value = RawValue;

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

   private void ReleaseUnmanagedResources()
   {
      // TODO release unmanaged resources here
   }

   protected virtual void Dispose(bool disposing)
   {
      ReleaseUnmanagedResources();

      if (disposing)
      {
         sv.Dispose();
         sem.Dispose();
      }
   }

   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   ~SemaphoreSlimOperations() { Dispose(false); }
}