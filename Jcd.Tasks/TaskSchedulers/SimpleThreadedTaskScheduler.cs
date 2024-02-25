using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable UnusedMember.Global
// ReSharper disable HeapView.DelegateAllocation

namespace Jcd.Tasks.TaskSchedulers;

/// <summary>
/// A <see cref="TaskScheduler"/> derived base type that runs <see cref="Task"/> instances
/// in a fixed size pool of threads. Inlining is disabled by default to ensure only
/// the threads managed by this <see cref="TaskScheduler"/> will process the tasks.
/// </summary>
public abstract class SimpleThreadedTaskScheduler
   : TaskScheduler
   , IDisposable
{
   private readonly BlockingCollection<Task> tasks = new();
   private readonly CancellationTokenSource  cts   = new();

   /// <inheritdoc />
   protected override IEnumerable<Task> GetScheduledTasks() { return tasks.ToList().AsReadOnly(); }

   private readonly List<Thread> internalThreads = [];

   /// <summary>
   /// The set of threads that will process Tasks. This is provided for
   /// advanced use cases where an action needs to be taken on the entire
   /// pool of threads.
   /// </summary>
   public IReadOnlyList<Thread> Threads => internalThreads;

   private void ThreadProc()
   {
      while (true)
      {
         Thread.Sleep(10);

         if (cts.IsCancellationRequested) return;

         if (!tasks.TryTake(out var task, 100) && !cts.IsCancellationRequested)
            continue;

         try
         {
            TryExecuteTask(task);
         }
         catch
         {
            // intentionally ignored.
         }
      }
   }

   /// <summary>
   /// Signals the underlying threads that the <see cref="TaskScheduler"/>
   /// is being shutdown (i.e. disposed of). Threads should shortly thereafter. 
   /// </summary>
   private void Shutdown()
   {
      if (!cts.IsCancellationRequested) cts.Cancel();
   }

   /// <summary>
   /// Constructs an instance of the type.
   /// </summary>
   /// <param name="threadCount">The number of threads to create.</param>
   /// <param name="state">the thread apartment state setting for all threads.</param>
   protected SimpleThreadedTaskScheduler(int threadCount, ApartmentState state)
   {
      if (state       == ApartmentState.Unknown) state = ApartmentState.MTA;
      if (threadCount < 1) threadCount                 = Environment.ProcessorCount;

      for (var i = 0; i < threadCount; i++)
      {
         var thread = new Thread(ThreadProc)
                      {
                         IsBackground = true, Name = $"{GetType().Name}.Threads[{internalThreads.Count:D4}]"
                      };
         thread.TrySetApartmentState(state);
         internalThreads.Add(thread);
         thread.Start();
      }
   }

   /// <inheritdoc />
   protected override void QueueTask(Task task) { tasks.Add(task); }

   /// <summary>
   /// The method to attempt executing a Task in the calling thread's context.
   /// This is disabled by default. See remarks for discussion. 
   /// </summary>
   /// <param name="task">the task to try inlining</param>
   /// <param name="taskWasPreviouslyQueued">indicates if it was previously queued with this scheduler</param>
   /// <returns>false, by default, may be overridden in a derived type.</returns>
   /// <remarks>
   /// The default implementation for this scheduler guarantees only its threads are processing tasks, so we cannot
   /// inline operations as inlining executes the task on the ThreadPool, which may not meet the same requirements as our
   /// dedicated threads.
   /// </remarks>
   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) { return false; }

   /// <inheritdoc />
   public void Dispose()
   {
      try
      {
         Shutdown();
      }
      catch
      {
         /*ignore errors as we can't do anything about them during a dispose.*/
      }

      tasks.Dispose();
   }
}