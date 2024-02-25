using CustomSchedulerTaskRunner =
   Jcd.Tasks.CustomSchedulerTaskRunner<Jcd.Tasks.Tests.Helpers.CallingThreadTaskScheduler>;

using Jcd.Tasks.Tests.Helpers;

// ReSharper disable InlineTemporaryVariable
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable MethodSupportsCancellation

namespace Jcd.Tasks.Tests;

public class CustomSchedulerTaskRunnerTests
{
   [Fact]
   public async Task Run_With_Action_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = CustomSchedulerTaskRunner.Scheduler;
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;
                                                                          }
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Async_Action_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = CustomSchedulerTaskRunner.Scheduler;
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return Task.CompletedTask;
                                                                          }
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Action_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = CustomSchedulerTaskRunner.Scheduler;
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async () =>
                             await CustomSchedulerTaskRunner.Run(() => { capturedScheduler = TaskScheduler.Current; }
                                                               , cts.Token
                                                                )
                         );

      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Async_Action_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = CustomSchedulerTaskRunner.Scheduler;
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return Task.CompletedTask;
                                                                          }
                                                                        , cts.Token
                                                                         )
                         );

      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Function_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = CustomSchedulerTaskRunner.Scheduler;
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return 10;
                                                                          }
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Async_Function_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = CustomSchedulerTaskRunner.Scheduler;
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return Task.FromResult(10);
                                                                          }
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Function_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = CustomSchedulerTaskRunner.Scheduler;
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return 10;
                                                                          }
                                                                        , cts.Token
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Async_Function_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = CustomSchedulerTaskRunner.Scheduler;
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return Task.FromResult(10);
                                                                          }
                                                                        , cts.Token
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Action_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = scheduler;
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async () =>
                             await CustomSchedulerTaskRunner.Run(() => { capturedScheduler = TaskScheduler.Current; }
                                                               , scheduler
                                                                )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Async_Action_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = scheduler;
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return Task.CompletedTask;
                                                                          }
                                                                        , scheduler
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Action_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = scheduler;
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async () =>
                             await CustomSchedulerTaskRunner.Run(() => { capturedScheduler = TaskScheduler.Current; }
                                                               , cts.Token
                                                               , scheduler
                                                                )
                         );

      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Async_Action_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = scheduler;
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return Task.CompletedTask;
                                                                          }
                                                                        , cts.Token
                                                                        , scheduler
                                                                         )
                         );

      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Function_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = scheduler;
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return 10;
                                                                          }
                                                                        , scheduler
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Async_Function_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = scheduler;
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return Task.FromResult(10);
                                                                          }
                                                                        , scheduler
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Function_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = scheduler;
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return 10;
                                                                          }
                                                                        , cts.Token
                                                                        , scheduler
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Scheduler_And_Async_Function_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      var            expectedScheduler = scheduler;
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(async () => await CustomSchedulerTaskRunner.Run(() =>
                                                                          {
                                                                             capturedScheduler = TaskScheduler.Current;

                                                                             return Task.FromResult(10);
                                                                          }
                                                                        , cts.Token
                                                                        , scheduler
                                                                         )
                         );
      Assert.True(ReferenceEquals(expectedScheduler, capturedScheduler));
   }
}