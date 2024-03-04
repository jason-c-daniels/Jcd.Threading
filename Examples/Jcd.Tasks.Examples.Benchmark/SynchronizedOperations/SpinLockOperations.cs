﻿using BenchmarkDotNet.Attributes;

namespace Jcd.Tasks.Examples.Benchmark.SynchronizedOperations;

public class SpinLockOperations
{
   public int ReadMe = 10;

   private readonly SpinLockedValue<int> spinLockValue = new(17);
   private          SpinLock             sl;

   [Benchmark(Baseline = true)]
   public int DirectSpinLockCalls_ReadValue_NoMemoryBarrier()
   {
      bool lockTaken = false;

      try
      {
         sl.Enter(ref lockTaken);
         return ReadMe;
      }
      finally
      {
         if (lockTaken)
            sl.Exit(false);
      }
   }

   [Benchmark]
   public int DirectSpinLockCalls_WriteValue_NoMemoryBarrier()
   {
      bool lockTaken = false;

      try
      {
         sl.Enter(ref lockTaken);
         return ReadMe = 999;
      }
      finally
      {
         if (lockTaken)
            sl.Exit(false);
      }
   }

   [Benchmark]
   public int DirectSpinLockCalls_ReadValue_WithMemoryBarrier()
   {
      bool lockTaken = false;

      try
      {
         sl.Enter(ref lockTaken);
         return ReadMe;
      }
      finally
      {
         if (lockTaken)
            sl.Exit(true);
      }
   }

   [Benchmark]
   public int DirectSpinLockCalls_WriteValue_WithMemoryBarrier()
   {
      bool lockTaken = false;

      try
      {
         sl.Enter(ref lockTaken);
         return ReadMe = 999;
      }
      finally
      {
         if (lockTaken)
            sl.Exit(true);
      }
   }

   [Benchmark]
   public int UsingExtensions_ReadValue()
   {
      var result = 0;
      sl.Lock(() => { result=ReadMe;});
      return result;
   }

   [Benchmark]
   public int UsingExtensions_WriteValue()
   {
      sl.Lock(() => { ReadMe = 9991;});
      return ReadMe;
   }

   [Benchmark]
   public int UsingSpinLockValue_ReadValue() { return spinLockValue.Value; }

   [Benchmark]
   public int UsingSpinLockValue_WriteValue()
   {
      spinLockValue.Value = ReadMe;

      return ReadMe;
   }
}