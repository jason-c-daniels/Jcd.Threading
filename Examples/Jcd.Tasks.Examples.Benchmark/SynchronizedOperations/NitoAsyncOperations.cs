using BenchmarkDotNet.Attributes;

using Nito.AsyncEx;

namespace Jcd.Tasks.Examples.Benchmark.SynchronizedOperations;

public class NitoAsyncOperations : IDisposable
{
   private readonly AsyncLock     nito   = new();
   private readonly SemaphoreSlim sem    = new(1, 1);
   public          int           RawValue = 11;
   
   [Benchmark]
   public int UsingAsyncLock_ReadValue()
   {
      using (nito.Lock())
         return RawValue;
;
   }

   [Benchmark]
   public int UsingAsyncLock_WriteValue()
   {
      using (nito.Lock()) 
         RawValue = 12;
      
      return RawValue;
   }

   [Benchmark]
   public int UsingSemaphoreSlimExtensions_ReadValue()
   {
      using (sem.Lock())
         return RawValue;
   }

   [Benchmark]
   public int UsingSemaphoreSlimExtensions_WriteValue()
   {
      using (sem.Lock()) 
         RawValue = 15;

      return RawValue;
   }

   public void Dispose() { sem.Dispose(); }
}