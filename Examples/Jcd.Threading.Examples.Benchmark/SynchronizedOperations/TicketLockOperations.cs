using BenchmarkDotNet.Attributes;

using Jcd.Threading.SynchronizedValues;

namespace Jcd.Threading.Examples.Benchmark.SynchronizedOperations;

public class TicketLockOperations
{
   public           int                  RawValue = 14;
   private readonly TicketLockValue<int> tlv      = new(17);
   private readonly TicketLock           tl       = new();

   [Benchmark]
   public int DirectCallsToTicket_ReadValue()
   {
      using var t = tl.GetResourceLock();

      t.Wait();

      return RawValue;
   }

   [Benchmark]
   public int DirectCallsToTicket_WriteValue()
   {
      using var t = tl.GetResourceLock();

      t.Wait();

      return RawValue = 1234;
   }

   [Benchmark]
   public async Task<int> DirectCallsToTicket_ReadValueAsync()
   {
      using var t = tl.GetResourceLock();

      await t.WaitAsync();

      return RawValue;
   }

   [Benchmark]
   public async Task<int> DirectCallsToTicket_WriteValueAsync()
   {
      using var t = tl.GetResourceLock();

      await t.WaitAsync();

      return RawValue = 1234;
   }

   [Benchmark]
   public int DirectCallsToLock_ReadValue()
   {
      using var t = tl.Lock();

      return RawValue;
   }

   [Benchmark]
   public int DirectCallsToLock_WriteValue()
   {
      using var t = tl.Lock();

      return RawValue = 1234;
   }

   [Benchmark]
   public async Task<int> DirectCallsToLock_ReadValueAsync()
   {
      using var t = await tl.LockAsync();

      return RawValue;
   }

   [Benchmark]
   public async Task<int> DirectCallsToLock_WriteValueAsync()
   {
      using var t = await tl.LockAsync();

      return RawValue = 1234;
   }

   [Benchmark]
   public int UsingTicketLockedValue_ReadValue() { return tlv.Value; }

   [Benchmark]
   public int UsingTicketLockedValue_WriteValue()
   {
      tlv.Value = RawValue;

      return RawValue;
   }

   [Benchmark]
   public Task<int> UsingTicketLockedValue_ReadValueAsync() { return tlv.GetValueAsync(); }

   [Benchmark]
   public Task<int> UsingTicketLockedValue_WriteValueAsync() { return tlv.SetValueAsync(RawValue); }
}