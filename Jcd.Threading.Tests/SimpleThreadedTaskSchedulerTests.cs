using Jcd.Threading.Tests.Helpers;
using Jcd.Threading.Tasks;

// ReSharper disable HeapView.ObjectAllocation.Possible

// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation

namespace Jcd.Threading.Tests;

public class SimpleThreadedTaskSchedulerTests
{
   [Theory]
   [InlineData(1,  ApartmentState.STA)]
   [InlineData(3,  ApartmentState.MTA)]
   [InlineData(5,  ApartmentState.STA)]
   [InlineData(7,  ApartmentState.MTA)]
   [InlineData(0,  ApartmentState.MTA)]
   [InlineData(-1, ApartmentState.STA)]
   public void Constructor_Creates_The_Expected_Thread_Count_And_ApartmentState_And_All_Threads_Are_Alive(
      int            threadCount
    , ApartmentState expectedState
   )
   {
      var       expectedThreadCount = threadCount > 0 ? threadCount : Environment.ProcessorCount - 2;
      using var scheduler           = new IdleTaskScheduler(threadCount, expectedState);
      Assert.Equal(expectedThreadCount, scheduler.Threads.Count);

      foreach (var thread in scheduler.Threads)
      {
         if (OsSupportsThreadingApartmentModel() && thread !=null)
            Assert.Equal(expectedState, thread.GetApartmentState());
         Assert.True(thread?.IsAlive);
      }
   }

   private static bool OsSupportsThreadingApartmentModel()
   {
      var osVer = Environment.OSVersion;

      return osVer.Platform == PlatformID.Win32NT;
   }

   [Fact]
   public async Task Scheduled_Work_Executes_On_Thread_Owned_By_Scheduler()
   {
      // ensure we have only one thread. This will make our verification trivial.
      using var scheduler      = new IdleTaskScheduler(1);
      Thread?   capturedThread = null;
      await scheduler.Run(() =>
                          {
                             capturedThread = Thread.CurrentThread;

                             return Task.CompletedTask;
                          }
                         );
      Assert.Same(scheduler.Threads[0], capturedThread);
   }

   [Fact]
   public async Task Scheduled_Work_That_Throws_An_Exception_Does_Not_Kill_The_Thread()
   {
      // ensure we have only one thread. This will make our verification trivial.
      using var scheduler = new IdleTaskScheduler(1);

      // run some faulting tasks.
      for (var i = 0; i < 1; i++)
         await RunAFaultingTaskAndWait(scheduler);
      var workRan = false;
      await scheduler.Run(() => { workRan = true; });
      Assert.True(workRan);
   }

   [Theory]
   [InlineData(false)]
   [InlineData(true)]
   public void TryExecuteTaskInline_Always_Returns_False(bool wasPreviouslyQueued)
   {
      using var scheduler = new IdleTaskSchedulerTaskSchedulerHarness(1, ApartmentState.MTA);
      Assert.False(scheduler.PublicTryExecuteTaskInline(Task.CompletedTask, wasPreviouslyQueued));
   }

   [Fact]
   public void GetScheduledTasks_Does_Not_Return_Null()
   {
      using var scheduler = new IdleTaskSchedulerTaskSchedulerHarness(1, ApartmentState.MTA);
      Assert.NotNull(scheduler.PublicGetScheduledTasks());
   }

   private static async Task RunAFaultingTaskAndWait(TaskScheduler scheduler)
   {
      var task = scheduler.Run(() => throw new ArgumentException("dummy exception"));

      // wait for task to end, this ignores the exception we're throwing.
      while (!task.IsCompleted) await Task.Yield();
   }
}