using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

public abstract class ThreadScheduler : TaskScheduler
{
   private readonly  int                      _threadCount;
   private readonly  ApartmentState           _state;
   private  readonly BlockingCollection<Task> _tasks = new ();
    
   protected override IEnumerable<Task> GetScheduledTasks() => _tasks.ToList().AsReadOnly();

   protected readonly List<Thread>          InternalThreads = new ();
   
   public             IReadOnlyList<Thread> Threads => InternalThreads;
   
   private void ThreadProc()
   {
      //using var waitHandle = new  AutoResetEvent(false);
      while (true)
      {
         if (!_tasks.TryTake(out var task,10)) continue;
         // TODO: Add cancellation token.
         try
         {
            string taskID = $"[{GetType().Name}] Task[{task.Id}] Dequeued By {Thread.CurrentThread.Name}";
            Debug.WriteLine(taskID);
            var result=TryExecuteTask(task);
            Debug.WriteLine($"{taskID} - TryExecuteTask Result: {result}");
         }
         catch
         {
            // intentionally ignored.
         }
      }
   }
   
   protected ThreadScheduler(int threadCount, ApartmentState state)
   {
      _threadCount = threadCount;
      _state  = state;
      if (state       == ApartmentState.Unknown) state = ApartmentState.MTA;
      if (threadCount < 1) threadCount                 = Environment.ProcessorCount;

      for (var i = 0; i < threadCount; i++) 
         AddThread();

   }

   private readonly SemaphoreSlim addThreadLock = new SemaphoreSlim(1, 1);
   private void AddThreadIfNeeded()
   {
      addThreadLock.Wait();
      
      var staleThreads=InternalThreads.Where(x => !x.IsAlive).ToArray();

      foreach (var staleThread in staleThreads)
         InternalThreads.Remove(staleThread);

      if (InternalThreads.Count >= _threadCount) return; 
      AddThread();

      addThreadLock.Release();
   }

   private void AddThread()
   {
      var thread = new Thread(ThreadProc) { IsBackground = true, Name = $"{GetType().Name}.Threads[{InternalThreads.Count:D4}]", ApartmentState = _state};
      InternalThreads.Add(thread);
      thread.Start();
   }

   protected override void QueueTask(Task task)
   {
      _tasks.Add(task);
      //AddThreadIfNeeded();
   }

   /// <summary>
   /// This the default implementation for this scheduler guarantees only its threads are processing tasks, so we cannot
   /// inline operations as inlining executes the task on the ThreadPool, which may not meet the same requirements as our
   /// dedicated threads.
   /// </summary>
   /// <param name="task">the task to try inlining</param>
   /// <param name="taskWasPreviouslyQueued">indicates if it was previously queued with this scheduler</param>
   /// <returns>true if it was executed inline.</returns>
   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) => false;

}