using Jcd.Threading.Tests.Helpers;

// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation

namespace Jcd.Threading.Tests;

public class ThreadWrapperTests
{
   [Theory]
   [InlineData(true
             , "Name"
             , false
             , false
             , 0
             , 0
             , ThreadPriority.Highest
             , ApartmentState.MTA
              )]
   [InlineData(false
             , "anotherName"
             , true
             , true
             , 10
             , 10
             , ThreadPriority.Lowest
             , ApartmentState.STA
              )]
   public void Constructor_Creates_The_Instance_With_The_Provided_Parameters(
      bool           autoStart
    , string?        name
    , bool           useBackgroundThread
    , bool           yieldEachCycle
    , int            timeToYieldInMs
    , int            idleAfterNoWorkDoneCount
    , ThreadPriority priority
    , ApartmentState apartmentState
   )
   {
      using var t = new ThreadWrapperHarness(autoStart: autoStart
                                           , name: name
                                           , useBackgroundThread: useBackgroundThread
                                           , timeToYieldInMs: timeToYieldInMs
                                           , idleAfterNoWorkDoneCount: idleAfterNoWorkDoneCount
                                           , priority: priority
                                           , apartmentState: apartmentState
                                            );

      //      t.Stop();
      Assert.Equal(autoStart,                t.AutoStart);
      Assert.Equal(name,                     t.Name);
      Assert.Equal(useBackgroundThread,      t.UseBackgroundThread);
      Assert.Equal(yieldEachCycle,           t.YieldEachCycle);
      Assert.Equal(timeToYieldInMs,          t.TimeToYieldInMs);
      Assert.Equal(idleAfterNoWorkDoneCount, t.IdleAfterNoWorkDoneCount);
      Assert.Equal(priority,                 t.Priority);
      Assert.Equal(apartmentState,           t.ApartmentState);
      Thread.Sleep(50);
      Assert.Equal(autoStart, t.IsStarted);
      t.Stop();
   }

   [Fact]
   public void Start_Creates_And_Starts_The_Thread()
   {
      using var t = new ThreadWrapperHarness(autoStart: false);
      Assert.Null(t.Thread);
      t.Start();
      Assert.NotNull(t.Thread);
      Thread.Sleep(100);
      Assert.True(t.IsStarted);
   }

   [Fact]
   public void Start_Can_Be_Called_Multiple_Times_In_A_Row()
   {
      using var t = new ThreadWrapperHarness(autoStart: false);
      Assert.Null(t.Thread);
      t.Start();
      Assert.NotNull(t.Thread);
      Thread.Sleep(100);
      t.Start();
      t.Start();
      t.Start();
      Assert.True(t.IsStarted);
   }

   [Fact]
   public void Stop_Shuts_Down_The_Thread_Then_Start_Restarts_It_With_A_New_Thread()
   {
      SpinWait  sw = new();
      using var t  = new ThreadWrapperHarness(autoStart: false);
      Assert.Null(t.Thread);
      t.Start();
      Thread.Sleep(100);
      var thd = t.Thread;
      Assert.NotNull(thd);
      while (!t.IsStarted) sw.SpinOnce();
      t.Stop();
      Thread.Sleep(100);
      Assert.False(t.IsStarted);
      t.Start();
      Thread.Sleep(100);
      Assert.True(t.IsStarted);
      Assert.NotSame(thd, t.Thread);
   }

   [Fact]
   public void Pause_Causes_Thread_To_Become_Paused_And_Resume_Resumes_It()
   {
      SpinWait  sw = new();
      using var t  = new ThreadWrapperHarness(timeToYieldInMs: 0);
      while (!t.IsStarted) sw.SpinOnce();
      t.Pause();
      t.Pause(); // ensure it behaves fine with multiple successive calls.
      t.Pause();
      Thread.Sleep(100);
      Assert.True(t.IsPaused);
      t.Resume();
      Thread.Sleep(100);
      Assert.False(t.IsPaused);
   }

   [Fact]
   public void IsIdle_Gets_Set_After_No_Work_Is_Done()
   {
      SpinWait sw        = new();
      var      callCount = 0;
      using var t = new ThreadWrapperHarness(() =>
                                             {
                                                callCount++;

                                                return callCount % 5 != 0;
                                             }
                                           , idleAfterNoWorkDoneCount: 0
                                            );
      while (!t.IsStarted) sw.SpinOnce();
      t.Pause();
      Thread.Sleep(100);
      Assert.True(t.IsPaused);
      t.Resume();
      Thread.Sleep(100);
      Assert.False(t.IsPaused);
   }
}