using BenchmarkDotNet.Attributes;

using Jcd.Threading.SynchronizedValues;

// ReSharper disable ConvertToConstant.Global

namespace Jcd.Threading.Examples.Benchmark.SynchronizedOperations;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class ReaderWriterLockSlimValueOperations : IDisposable
{
   public readonly  int                            RawValue = 333;
   private readonly ReaderWriterLockSlimValue<int> sv       = new(11);

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

   protected virtual void Dispose(bool disposing)
   {
      // doing this pattern to make SonarCloud shut up ... it's good, but lots LOTS of false positives.

      if (disposing) sv.Dispose();
   }

   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   ~ReaderWriterLockSlimValueOperations() { Dispose(false); }
}