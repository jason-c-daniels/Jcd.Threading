using SUT=Jcd.Tasks.CustomSchedulerTaskRunner<Jcd.Tasks.Tests.Helpers.CallingThreadTaskScheduler>;
// ReSharper disable MethodSupportsCancellation

using Jcd.Tasks.Tests.Helpers;

namespace Jcd.Tasks.Tests;

public class CustomSchedulerTaskRunnerTests
{
   [Fact]
   public async Task Run_With_Scheduler_And_Action_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async ()=> await SUT.Run(() =>{capturedScheduler = TaskScheduler.Current;}, scheduler));
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }
   
   [Fact]
   public async Task Run_With_Scheduler_And_Async_Action_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async ()=> await SUT.Run(() =>
                                                   {
                                                      capturedScheduler = TaskScheduler.Current;
                                                      return Task.CompletedTask;
                                                   },scheduler));
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Action_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async ()=> await SUT.Run(() =>
                                                   {
                                                      capturedScheduler = TaskScheduler.Current;
                                                   },cts.Token,scheduler));
      
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }
   
   [Fact]
   public async Task Run_With_Scheduler_And_Async_Action_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async ()=> await SUT.Run(() =>
                                                   {
                                                      capturedScheduler = TaskScheduler.Current;
                                                      return Task.CompletedTask;
                                                   },cts.Token,scheduler));
      
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Function_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async ()=> await SUT.Run(() =>
                                                   {
                                                      capturedScheduler = TaskScheduler.Current;
                                                      return 10;
                                                   },scheduler));
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Async_Function_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async ()=> await SUT.Run(() =>
                                                   {
                                                      capturedScheduler = TaskScheduler.Current;
                                                      return Task.FromResult(10);
                                                   },scheduler));
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }
   [Fact]
   public async Task Run_With_Scheduler_And_Function_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async ()=> await SUT.Run(() =>
                                                   {
                                                      capturedScheduler = TaskScheduler.Current;

                                                      return 10;
                                                   },cts.Token,scheduler));
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Async_Function_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async ()=> await SUT.Run(() =>
                                                   {
                                                      capturedScheduler = TaskScheduler.Current;

                                                      return Task.FromResult(10);
                                                   },cts.Token,scheduler));
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }
}