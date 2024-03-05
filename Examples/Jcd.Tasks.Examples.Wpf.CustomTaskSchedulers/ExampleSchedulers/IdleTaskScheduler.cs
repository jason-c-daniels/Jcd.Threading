using Jcd.Threading;

// ReSharper disable once HeapView.ObjectAllocation.Evident
using System.Diagnostics;

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

public abstract class IdleTaskScheduler
   : TaskScheduler
   , IDisposable
{
   private readonly ApartmentState            apartmentState;
   private readonly List<ItemProcessor<Task>> processorList;
   private readonly ItemProcessor<Task>       taskQueuer;
   private readonly SemaphoreSlim             taskQueueSem = new(1, 1);

   protected IdleTaskScheduler(int threadCount = 0, ApartmentState apartmentState = ApartmentState.Unknown)
   {
      if (threadCount < 1) threadCount = Environment.ProcessorCount - 2;
      if (threadCount < 1) threadCount = 2;
      this.apartmentState = apartmentState;
      processorList       = new List<ItemProcessor<Task>>(threadCount);
      taskQueuer          = CreateTaskProcessor(TaskQueuerProc, $"{GetType().Name}_TaskQueuer");
      foreach (var i in Enumerable.Range(0, threadCount))
         processorList.Add(CreateTaskProcessor(i));
   }

   private ItemProcessor<Task> CreateTaskProcessor(int i)
   {
      return CreateTaskProcessor(t =>
                                 {
                                    if (t != null)
                                       TryExecuteTask(t);
                                 }
                               , $"{GetType().Name}[{i}]"
                                );
   }

   private ItemProcessor<Task> CreateTaskProcessor(Action<Task?> action, string name)
   {
      return new ItemProcessor<Task>(action
                                   , name: name
                                   , yieldEachCpuCycle: true
                                   , timeToYieldInMs: 15
                                   , apartmentState: apartmentState
                                    );
   }

   protected override IEnumerable<Task> GetScheduledTasks()
   {
      return processorList.SelectMany(x => x.Items)
                          .Concat(taskQueuer.Items)
                          .ToArray();
   }

   private void TaskQueuerProc(Task? task)
   {
      if (task == null) return;
      GetNextIdleProcessor().Enqueue(task);
   }

   private int nextProcessorIndex;

   private ItemProcessor<Task> GetNextIdleProcessor()
   {
      // idle or not, the tasks will all end up processed by this task processor.
      // so we return it without waiting for it to be idle.
      if (processorList.Count == 1) return processorList[0];
      using var wait = new AutoResetEvent(false);

      for (var i = nextProcessorIndex;;)
      {
         i                  %= processorList.Count; // ensure we don't go out of bounds.
         nextProcessorIndex =  i + 1;               // advance the next processor index.
         var proc = processorList[i];               // retrieve the processor.

         if (proc.IsIdle) return proc;
         i++;
         if (i == processorList.Count)
            wait.WaitOne(5);
      }
   }

   protected override void QueueTask(Task task)
   {
      if (Current is not IdleTaskScheduler)
      {
         StackTrace t = new();
         Log($"Task queued from a {Current.GetType().Name}{Environment.NewLine}{t}{Environment.NewLine}{Thread.CurrentThread.Name}"
            );
         Log("");
      }

      using (taskQueueSem.Lock())
         taskQueuer.Enqueue(task);
   }

   private static void Log(string message)
   {
      Debug.WriteLine(message);
      Console.WriteLine(message);
   }

   protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) { return false; }

   private void Dispose(bool disposing)
   {
      if (!disposing) return;

      foreach (var processor in processorList) processor.Dispose();
      taskQueuer.Dispose();
      taskQueueSem.Dispose();
   }

   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   ~IdleTaskScheduler() { Dispose(false); }
}