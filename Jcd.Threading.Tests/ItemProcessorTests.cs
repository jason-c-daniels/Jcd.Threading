// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation

namespace Jcd.Threading.Tests;

public class ItemProcessorTests
{
   [Theory]
   [InlineData(true
             , "Name"
             , false
             , 20
             , ThreadPriority.Highest
             , ApartmentState.MTA
              )]
   [InlineData(false
             , "anotherName"
             , true
             , 30
             , ThreadPriority.Lowest
             , ApartmentState.STA
              )]
   public void Constructor_Creates_The_Instance_With_The_Provided_Parameters(
      bool           autoStart
    , string?        name
    , bool           useBackgroundThread
    , int            timeToYieldInMs
    , ThreadPriority priority
    , ApartmentState apartmentState
   )
   {
      using var ip = new ItemProcessor<int>(_ => { }
                                          , autoStart
                                          , name
                                          , useBackgroundThread
                                          , timeToYieldInMs
                                          , priority: priority
                                          , apartmentState: apartmentState
                                           );

      Assert.Equal(autoStart,           ip.AutoStart);
      Assert.Equal(name,                ip.Name);
      Assert.Equal(useBackgroundThread, ip.UseBackgroundThread);
      Assert.Equal(timeToYieldInMs > 0, ip.YieldEachCycle);
      Assert.Equal(timeToYieldInMs,     ip.TimeToYieldInMs);
      Assert.Equal(priority,            ip.Priority);
      Assert.Equal(apartmentState,      ip.ApartmentState);
      Thread.Sleep(100);
      Assert.Equal(autoStart, ip.IsStarted);

      if (!autoStart) return;
      ip.Stop();
      while (ip.IsStarted || (ip.Thread?.IsAlive ?? false))
         Thread.Sleep(100);
   }

   [Fact]
   public void Constructor_With_Custom_Action_Calls_Custom_Action_When_Items_Are_Enqueued()
   {
      var       wasCalled = false;
      var       spinWait  = new SpinWait();
      using var ip        = new ItemProcessor<int>(_ => { wasCalled = true; }, false);
      Assert.False(wasCalled);
      ip.Enqueue(10);
      ip.Enqueue(11);
      ip.Enqueue(4);
      ip.Start();
      while (ip.HasItems) spinWait.SpinOnce();
      Assert.True(wasCalled);
   }

   [Fact]
   public void Enqueue_Increases_The_Number_Of_Items_In_The_Queue()
   {
      var       wasCalled = false;
      using var ip        = new ItemProcessor<int>(_ => { wasCalled = true; }, false);
      Assert.False(wasCalled);
      ip.Enqueue(10);
      ip.Enqueue(11);
      ip.Enqueue(4);
      Assert.True(ip.HasItems);
      Assert.Equal(3, ip.Count);
   }

   [Fact]
   public async Task EnqueueAsync_Increases_The_Number_Of_Items_In_The_Queue()
   {
      var       wasCalled = false;
      using var ip        = new ItemProcessor<int>(_ => { wasCalled = true; }, false);
      Assert.False(wasCalled);
      await ip.EnqueueAsync(10);
      await ip.EnqueueAsync(11);
      await ip.EnqueueAsync(4);
      Assert.True(ip.HasItems);
      Assert.Equal(3, ip.Count);
   }

   [Fact]
   public void Clear_Removes_All_Items_In_The_Queue()
   {
      var       wasCalled = false;
      using var ip        = new ItemProcessor<int>(_ => { wasCalled = true; }, false);
      Assert.False(wasCalled);
      ip.Enqueue(10);
      ip.Enqueue(11);
      ip.Enqueue(4);
      Assert.True(ip.HasItems);
      Assert.Equal(3, ip.Count);
      ip.Clear();
      Assert.False(ip.HasItems);
      Assert.Equal(0, ip.Count);
   }

   [Fact]
   public async Task ClearAsync_Removes_All_Items_In_The_Queue()
   {
      var       wasCalled = false;
      using var ip        = new ItemProcessor<int>(_ => { wasCalled = true; }, false);
      Assert.False(wasCalled);
      await ip.EnqueueAsync(10);
      await ip.EnqueueAsync(11);
      await ip.EnqueueAsync(4);
      Assert.True(ip.HasItems);
      Assert.Equal(3, ip.Count);
      await ip.ClearAsync();
      Assert.False(ip.HasItems);
      Assert.Equal(0, ip.Count);
   }
}