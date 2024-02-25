using Jcd.Tasks.Tests.Helpers;

namespace Jcd.Tasks.Tests;

public class TaskSchedulerExtensionsTests
{
   [Fact]
   public async Task Run_With_Action_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(() =>{capturedScheduler = TaskScheduler.Current;});
      Assert.True(ReferenceEquals(scheduler,capturedScheduler));
   }
   
   [Fact]
   public async Task Run_With_Async_Action_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(() =>
                          {
                             capturedScheduler = TaskScheduler.Current;
                             return Task.CompletedTask;
                          });
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Action_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var               scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler?    capturedScheduler = null;
      using var         cts               = new CancellationTokenSource();
      await scheduler.Run(() =>
                              {
                                 capturedScheduler = TaskScheduler.Current;
                              },cts.Token);
      
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }
   
   [Fact]
   public async Task Run_With_Async_Action_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(() =>
                          {
                             capturedScheduler = TaskScheduler.Current;
                             return Task.CompletedTask;
                          },cts.Token);
      
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Function_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(() =>
                          {
                             capturedScheduler = TaskScheduler.Current;
                             return 10;
                          });
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Async_Function_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(() =>
                          {
                             capturedScheduler = TaskScheduler.Current;
                             return Task.FromResult(10);
                          });
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }
   [Fact]
   public async Task Run_With_Function_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(() =>
                          {
                             capturedScheduler = TaskScheduler.Current;

                             return 10;
                          },cts.Token);
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Async_Function_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(() =>
                          {
                             capturedScheduler = TaskScheduler.Current;

                             return Task.FromResult(10);
                          },cts.Token);
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }
}