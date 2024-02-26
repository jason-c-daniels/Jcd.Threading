using System.Collections.Concurrent;

// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable UnusedMember.Global
// ReSharper disable HeapView.DelegateAllocation

namespace Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;
using TaskQueue = ConcurrentQueue<Task>;

/// <summary>
/// A <see cref="TaskScheduler"/> derived base type that runs <see cref="Task"/> instances
/// in a fixed size pool of threads. Inlining is disabled by default to ensure only
/// the threads managed by this <see cref="TaskScheduler"/> will process the tasks.
/// </summary>
public class QueuedThreadedTaskScheduler
   : TaskScheduler
   , IDisposable
{
   private readonly ConcurrentQueue<TaskQueue>         queues = new();
   private readonly CancellationTokenSource cts   = new();
   
   /// <inheritdoc />
   protected override IEnumerable<Task> GetScheduledTasks()
   {
      return queues.SelectMany(q=>q.ToList()).ToList().AsReadOnly();
   }

   private readonly List<Thread> internalThreads = [];

   /// <summary>
   /// The set of threads that will process Tasks. This is provided for
   /// advanced use cases where an action needs to be taken on the entire
   /// pool of threads.
   /// </summary>
   public IReadOnlyList<Thread> Threads => internalThreads;

   private void ThreadProc(TaskQueue queue)
   {
      using var waitHandle = new AutoResetEvent(false);

      while (true)
      {
         try
         {
            if (cts.IsCancellationRequested) return;
            waitHandle.WaitOne(13);

            if (cts.IsCancellationRequested) return;
            if (queue.IsEmpty || !queue.TryDequeue(out var task))
               continue;

            TryExecuteTask(task);
         }
         catch (Exception)
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
   /// <param name="queueCount">THe number of queues for tasks.</param>
   /// <param name="apartmentState">the thread apartment state setting for all threads.</param>
   public QueuedThreadedTaskScheduler(int threadCount = 0, int queueCount = 0, ApartmentState apartmentState = ApartmentState.Unknown)
   {
      if (apartmentState       == ApartmentState.Unknown) apartmentState           = ApartmentState.MTA;
      if (threadCount < 1) threadCount                           = Environment.ProcessorCount;
      if (queueCount < 1) queueCount = threadCount / 2;
      if (queueCount < 1) queueCount = 1;
      if (queueCount > 1 && queueCount >= threadCount/2) queueCount = threadCount / 2;
      
      
      // first initialize the queues.
      for(var qn=0;qn<queueCount;qn++)
         queues.Enqueue(new TaskQueue());

      var queueList = queues.ToList();
      
      for (var i = 0; i < threadCount; i++)
      {
         var thread = new Thread(()=>ThreadProc(queueList[i % queueCount]))
                      {
                         IsBackground = true, Name = $"{GetType().Name}.Threads[{internalThreads.Count:D4}]"
                      };
         thread.TrySetApartmentState(apartmentState);
         internalThreads.Add(thread);
         thread.Start();
      }
   }

   /// <inheritdoc />
   protected override void QueueTask(Task task)
   {
      // round robin task queuing.
      TaskQueue queue;
      while (!queues.TryDequeue(out queue))
      {
         // do a sleep here?
      }
      queue.Enqueue(task);
      queues.Enqueue(queue);
   }

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

   /// <summary>
   /// Disposes unmanaged resources  
   /// </summary>
   /// <param name="disposing">indicates if it's disposing.</param>
   protected virtual void Dispose(bool disposing)
   {
      // Release Unmanaged Resources here if you ever add them.
      // this change was made to make SonarCloud shut up.

      if (disposing)
      {
         Shutdown();
         //foreach(var q in queues) q.Dispose();
         cts.Dispose();
      }
   }

   /// <inheritdoc />
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ~QueuedThreadedTaskScheduler() { Dispose(false); }
}