using Jcd.Threading.Tasks;

// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable MethodSupportsCancellation

namespace Jcd.Threading.Tests.Tasks;

public class TaskSchedulerExtensionsTests
{
   [Fact]
   public async Task Run_With_Action_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      await scheduler.Run(() => { capturedScheduler = TaskScheduler.Current; });
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
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
                          }
                         );
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }

   [Fact]
   public async Task Run_With_Action_And_CancellationToken_Runs_From_Intended_TaskScheduler()
   {
      var            scheduler         = new CallingThreadTaskScheduler();
      TaskScheduler? capturedScheduler = null;
      using var      cts               = new CancellationTokenSource();
      await scheduler.Run(() => { capturedScheduler = TaskScheduler.Current; }, cts.Token);

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
                          }
                        , cts.Token
                         );

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
                          }
                         );
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
                          }
                         );
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
                          }
                        , cts.Token
                         );
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
                          }
                        , cts.Token
                         );
      Assert.True(ReferenceEquals(scheduler, capturedScheduler));
   }

   [Fact]
   public void Run_With_Async_Function_And_Cancelled_CancellationToken_Returns_A_Cancelled_Task()
   {
      var       scheduler = new CallingThreadTaskScheduler();
      using var cts       = new CancellationTokenSource();
      cts.Cancel();
      var task = scheduler.Run(() => Task.FromResult(10), cts.Token);
      Assert.True(task.IsCanceled);
   }

   [Fact]
   public async Task Run_With_Null_Function_And_Valid_CancellationToken_Throws_An_ArgumentNullException()
   {
      var              scheduler = new CallingThreadTaskScheduler();
      using var        cts       = new CancellationTokenSource();
      Func<Task<int>>? func      = null;
      await Assert.ThrowsAsync<ArgumentNullException>(async () => await scheduler.Run(func, cts.Token));
   }

   [Fact]
   public async Task Run_With_Null_Function_Throws_An_ArgumentNullException()
   {
      var              scheduler = new CallingThreadTaskScheduler();
      Func<Task<int>>? func      = null;
      #pragma warning disable CS8604 // Suppress null reference argument. Reason: intentional for unit testing. 
      await Assert.ThrowsAsync<ArgumentNullException>(async () => await scheduler.Run(func));
      #pragma warning restore CS8604 // Restore Possible null reference argument.
   }
}