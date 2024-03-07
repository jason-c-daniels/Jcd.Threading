﻿// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident

// ReSharper disable HeapView.ClosureAllocation

using Jcd.Threading.SynchronizedValues;

namespace Jcd.Threading.Tests;

public class ReaderWriterLockSlimValueTests
{
   [Theory]
   [InlineData(1)]
   [InlineData(-1)]
   [InlineData(2)]
   public void Constructor_Creates_With_The_Provided_Value(int expectedValue)
   {
      using var sv = new ReaderWriterLockSlimValue<int>(expectedValue);
      Assert.Equal(expectedValue, sv.Value);
   }

   [Theory]
   [InlineData(1)]
   [InlineData(-1)]
   [InlineData(2)]
   public void SetValue_Sets_And_Returns_The_Provided_Value(int expectedValue)
   {
      using var sv     = new ReaderWriterLockSlimValue<int>();
      var       result = sv.SetValue(expectedValue);
      Assert.Equal(expectedValue, sv.Value);
      Assert.Equal(expectedValue, result);
   }

   [Theory]
   [InlineData(1)]
   [InlineData(-1)]
   [InlineData(2)]
   public async Task SetValueAsync_Sets_And_Returns_The_Provided_Value(int expectedValue)
   {
      using var sv     = new ReaderWriterLockSlimValue<int>();
      var       result = await sv.SetValueAsync(expectedValue);
      Assert.Equal(expectedValue, sv.Value);
      Assert.Equal(expectedValue, result);
   }

   [Theory]
   [InlineData(1)]
   [InlineData(-1)]
   [InlineData(2)]
   public void GetValue_Sets_And_Returns_The_Provided_Value(int expectedValue)
   {
      using var sv = new ReaderWriterLockSlimValue<int>();
      sv.SetValue(expectedValue);
      Assert.Equal(expectedValue, sv.GetValue());
   }

   [Theory]
   [InlineData(1)]
   [InlineData(-1)]
   [InlineData(2)]
   public async Task GetValueAsync_Sets_And_Returns_The_Provided_Value(int expectedValue)
   {
      using var sv = new ReaderWriterLockSlimValue<int>();
      await sv.SetValueAsync(expectedValue);
      Assert.Equal(expectedValue, await sv.GetValueAsync());
   }

   [Theory]
   [InlineData(1)]
   [InlineData(-1)]
   [InlineData(2)]
   public async Task ChangeValueAsync_Sets_And_Returns_The_Provided_Value(int value)
   {
      var       expectedValue = await MultiplyByTenAsync(value);
      using var sv            = new ReaderWriterLockSlimValue<int>(value);
      var       result        = await sv.ChangeValueAsync(MultiplyByTenAsync);
      Assert.Equal(expectedValue, sv.Value);
      Assert.Equal(expectedValue, result);

      return;

      Task<int> MultiplyByTenAsync(int i) { return Task.FromResult(i * 10); }
   }
}