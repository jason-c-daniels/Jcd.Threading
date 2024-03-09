using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable VirtualMemberNeverOverridden.Global
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Jcd.Threading.Tasks;

/// <summary>
/// Provides a mechanism for task scheduling using a round robin mechanism for a pool
/// of privately managed threads. Derive from this type to implement your own specialization.
/// </summary>
public class IdleTaskScheduler
   : TaskScheduler
   , IDisposable
{
   private readonly ApartmentState      apartmentState;
   private readonly ItemProcessor<Task> taskQueuer;
   private readonly SemaphoreSlim       taskQueueSem = new(1, 1);
   private          int                 nextProcessorIndex;

   /// <summary>
   /// The list of underlying queue+thread task processors.
   /// This is provided for advanced use cases.
   /// </summary>
   protected internal readonly List<ItemProcessor<Task>> ProcessorList;

   /// <summary>
   /// The name of the instance of the task scheduler.
   /// </summary>
   public string Name { get; }

   /// <summary>
   /// Provides access to the underlying threads.
   /// </summary>
   protected internal IReadOnlyList<Thread?> Threads { get; private set; }

   /// <summary>
   /// Creates an instance of <see cref="IdleTaskScheduler"/>
   /// </summary>
   /// <param name="threadCount">the number of threads to use for scheduling tasks.</param>
   /// <param name="apartmentState">The <see cref="ApartmentState"/> of the threads to create.</param>
   /// <param name="name">The name of this TaskScheduler instance. Useful for debugging.</param>
   public IdleTaskScheduler(
      int            threadCount    = 0
    , ApartmentState apartmentState = ApartmentState.Unknown
    , string         name           = ""
   )
   {
      if (threadCount < 1) threadCount = Environment.ProcessorCount - 2;
      if (threadCount < 1) threadCount = 1;
      this.apartmentState = apartmentState;
      Name                = string.IsNullOrWhiteSpace(name) ? GetType().Name : name;
      ProcessorList       = new List<ItemProcessor<Task>>(threadCount);
      taskQueuer          = CreateTaskProcessor(TaskQueuerProc, $"{Name}_TaskQueuer");
      for (var i = 0; i < threadCount; i++)
         ProcessorList.Add(CreateTaskProcessor(i));
      Threads = ProcessorList.Select(x => x.Thread).ToArray();
   }

   private ItemProcessor<Task> CreateTaskProcessor(int i)
   {
      return CreateTaskProcessor(t =>
                                 {
                                    if (t != null)
                                       TryExecuteTask(t);
                                 }
                               , $"{Name}[{i.ToString()}]"
                                );
   }

   private ItemProcessor<Task> CreateTaskProcessor(Action<Task?> action, string name, int timeToYieldInMs = 5)
   {
      // NOTE: NEVER EVER TURN OFF AUTO-IDLING FOR THREADS IN THIS CLASS!
      // IDLING IS NEEDED TO DO ROUND ROBIN SCHEDULING!
      return new ItemProcessor<Task>(action
                                   , name: name
                                   , timeToYieldInMs: timeToYieldInMs
                                   , apartmentState: apartmentState
                                    );
   }

   #region Task Scheduling

   private void TaskQueuerProc(Task? task)
   {
      if (task == null) return;
      GetNextIdleProcessor().Enqueue(task);
   }

   private ItemProcessor<Task> GetNextIdleProcessor()
   {
      // with only one thread to schedule on the tasks will all end up processed by it.
      // so we return it without waiting for it to be idle.
      if (ProcessorList.Count == 1) return ProcessorList[0];

      // otherwise we do round-robin inspection until we find an idle thread.
      using var wait = new AutoResetEvent(false);

      for (var i = nextProcessorIndex;;)
      {
         i                  %= ProcessorList.Count; // ensure we don't go out of bounds.
         nextProcessorIndex =  i + 1;               // advance the next processor index.
         var proc = ProcessorList[i];               // retrieve the processor.

         if (proc.IsIdle) return proc;
         i++;
         if (i == ProcessorList.Count)
            wait.WaitOne(5); // yield a little CPU time each pass through the list. 
      }
   }

   /// <inheritdoc />
   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) { return false; }

   /// <inheritdoc />
   protected override IEnumerable<Task> GetScheduledTasks()
   {
      return ProcessorList.SelectMany(x => x.Items)
                          .Concat(taskQueuer.Items)
                          .ToArray();
   }

   /// <inheritdoc />
   protected override void QueueTask(Task task)
   {
      #if DEBUG
      if (Current is not IdleTaskScheduler)
      {
         StackTrace t = new();
         Log($"Task queued from a {Current.GetType().Name}{Environment.NewLine}{t}{Environment.NewLine}{Thread.CurrentThread.Name}"
            );
         Log("");
      }
      #endif

      using (taskQueueSem.Lock())
         taskQueuer.Enqueue(task);
   }

   #if DEBUG
   private static void Log(string message)
   {
      Debug.WriteLine(message);
      Console.WriteLine(message);
   }
   #endif
   
   #endregion

   #region Dispose pattern

   /// <summary>
   /// Cleans up resources and shuts down background threads.
   /// </summary>
   /// <param name="disposing">false indicates this is finalizer cleanup.</param>
   protected virtual void Dispose(bool disposing)
   {
      if (!disposing) return;

      foreach (var processor in ProcessorList)
         processor.Stop();

      foreach (var processor in ProcessorList)
         processor.Dispose();

      taskQueuer.Dispose();
      taskQueueSem.Dispose();
   }

   /// <inheritdoc />
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   /// <summary>
   /// Finalizes stuff.
   /// </summary>
   [ExcludeFromCodeCoverage]
   ~IdleTaskScheduler() { Dispose(false); }

   #endregion
}