using BenchmarkDotNet.Attributes;

using Jcd.Threading.SynchronizedValues;

namespace Jcd.Threading.Examples.Benchmark.SynchronizedOperations;

public class SynchronizedValueOperations : IDisposable
{
   public  int                            RawValue = 333;
   private ReaderWriterLockSlimValue<int> sv       = new(11);

   [Benchmark]
   public int UsingSynchronizedValue_ReadValue()
   {
      var foo = sv.Value;

      return foo;
   }

   [Benchmark]
   public int UsingSynchronizedValue_WriteValue()
   {
      sv.Value = RawValue;

      return RawValue;
   }

   [Benchmark]
   public Task<int> UsingSynchronizedValue_ReadValueAsync() { return sv.GetValueAsync(); }

   [Benchmark]
   public Task<int> UsingSynchronizedValue_WriteValueAsync() { return sv.SetValueAsync(RawValue); }

   public void Dispose() { sv.Dispose(); }
}