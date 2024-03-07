using System.Diagnostics;

using Jcd.Threading;
using Jcd.Threading.Tasks;
using Jcd.Threading.Examples;
// ReSharper disable ArrangeRedundantParentheses

// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable InlineTemporaryVariable
// ReSharper disable HeapView.ClosureAllocation

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

var       cpuCount  = Environment.ProcessorCount;
const int delay     = 125;
var       taskCount = cpuCount;
var       q         = 0;
const int count     = 5000;

await RunTicketLock();
Console.ReadLine();
await RunSemaphoreLock();
RunItemProcessorExample();
await RunTaskSchedulerExamples();

return;

async Task RunSemaphoreLock()
{
   var semaphore = new SemaphoreSlim(1, 1);

   var tasks = new List<Task>();

   //var svsb  = new MutexValue<List<string>>(new List<string>());
   Console.WriteLine("Enqueuing tasks.");
   var sw = Stopwatch.StartNew();

   for (var i = 0; i < taskCount; i++)
   {
      _ = i;
      AddNewSemaphoreTask(tasks, i, semaphore);
   }

   await Task.WhenAll(tasks);
   sw.Stop();
   Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
}

void AddNewSemaphoreTask(ICollection<Task> list, int n, SemaphoreSlim semaphore)
{
   list.Add(Task.Run(async () =>
                     {
                        Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] started.");
                        Console.Out.Flush();
                        await Task.Delay(delay);

                        try
                        {
                           long tid;

                           using (var _ = await semaphore.LockAsync())
                           {
                              q++;
                              tid = q;
                              Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} in critical section."
                                               );
                              Console.Out.Flush();
                              await Task.Delay(delay);
                           }

                           Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} exited critical section."
                                            );
                           Console.Out.Flush();
                           await Task.Delay(delay);
                           Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} ended.");
                           Console.Out.Flush();
                        }
                        catch
                        {
                           // intentionally ignored.
                        }
                     }
                    )
           );
}

async Task RunTicketLock()
{
   var tl = new TicketLock();

   var tasks = new List<Task>();

   //var svsb  = new MutexValue<List<string>>(new List<string>());
   Console.WriteLine("Enqueuing tasks.");
   var sw = Stopwatch.StartNew();

   for (var i = 0; i < taskCount; i++)
   {
      var n = i;
      tasks.Add(Task.Run(async () =>
                         {
                            long tid;

                            Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] started.");
                            Console.Out.Flush();
                            await Task.Delay(delay);

                            using (var t = await tl.LockAsync())
                            {
                               tid = t.TicketId;
                               Console
                                 .WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} in critical section.");
                               Console.Out.Flush();
                               await Task.Delay(delay);
                            }

                            Console
                              .WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} exited critical section.");
                            Console.Out.Flush();
                            await Task.Delay(delay);
                            Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} ended.");
                            Console.Out.Flush();
                         }
                        )
               );
   }

   await Task.WhenAll(tasks);
   sw.Stop();
   Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
}

async Task RunTaskSchedulerExamples()
{
   StartBlock("TaskSchedulerExtensionsExample Example");
   await TaskSchedulerExtensionsExample.Run();

   StartBlock("SynchronizedValue Example");
   await SynchronizedValueExample.Run();

   StartBlock("CustomTaskRunner Example");
   var scheduler = new IdleTaskScheduler(13);

   Log(-999, TaskScheduler.Current, "App Started");

   await scheduler.Run(Main);

   Log(-999, TaskScheduler.Current, "CustomTaskRunner Ending");
}

void StartBlock(string s)
{
   Console.WriteLine("--------------------");
   Console.WriteLine(s);
   Console.WriteLine("--------------------");
}

async Task Main()
{
   await LogAsync(-111, TaskScheduler.Current, "started");
   var tasks = new List<Task>();

   for (var i = 0; i < count; i++)
   {
      var x = i;
      tasks.Add(ReportScheduler(x));
   }

   await Task.WhenAll(tasks.ToArray());
   await LogAsync(-111, TaskScheduler.Current, "finished");
   await Console.Out.FlushAsync();
}

async Task ReportScheduler(int i)
{
   var ts = TaskScheduler.Current;
   await LogAsync(i, ts, $"{nameof(ReportScheduler)}");
   await Task.Delay(JitteredMs(200));
   await InnerReportScheduler(i);
}

int JitteredMs(int baseDelay) { return (Random.Shared.Next(baseDelay * 11) * 7) % (baseDelay / 2) + baseDelay; }

// ReSharper disable once HeapView.ClosureAllocation
async Task InnerReportScheduler(int i)
{
   var ts = TaskScheduler.Current;
   await LogAsync(i, ts, $"{nameof(InnerReportScheduler)}");
   await Task.Delay(JitteredMs(150));
   await CustomTaskRunner.Run(() => FinalInnerReportScheduler(i));
}

async Task FinalInnerReportScheduler(int i)
{
   var ts = TaskScheduler.Current;
   await LogAsync(i, ts, $"{nameof(FinalInnerReportScheduler)}");
   await Task.Delay(JitteredMs(75));
}

Task LogAsync(int i, TaskScheduler ts, string text)
{
   var name                                  = Thread.CurrentThread.Name;
   if (string.IsNullOrWhiteSpace(name)) name = "<unnamed>";

   return
      Console.Out.WriteLineAsync($"[{i:D4}:{Environment.CurrentManagedThreadId:D10}; {name} ;{ts.GetType().Name}; {TaskScheduler.Current.GetType().Name}]  : {text}"
                                );
}

void Log(int i, TaskScheduler ts, string text)
{
   var name                                  = Thread.CurrentThread.Name;
   if (string.IsNullOrWhiteSpace(name)) name = "<unnamed>";
   Console.Out.WriteLine($"[{i:D4}:{Environment.CurrentManagedThreadId:D10};  {name}; {ts.GetType().Name};]  : {text}");
}

void RunItemProcessorExample(int iterations = 5000, int processors = 0)
{
   if (processors < 1) processors = Environment.ProcessorCount * 20;
   var cde                        = new CountdownEvent(processors * iterations);
   var procs = Enumerable.Range(0, processors)
                         .Select(i => new ItemProcessor<int>(x =>
                                                             {
                                                                int z;
                                                                for (z = 0; z < iterations * 10; z++) x *= z;
                                                                var t                                   = z;
                                                                var a                                   = t * 13;
                                                                _ = a / 23;
                                                                cde.Signal();
                                                             }
                                                           , name: $"Int Processor[{i}]"
                                                            )
                                )
                         .ToList();
   Console.WriteLine("Press ENTER to start item processing.");
   Console.ReadLine();
   Console.WriteLine("Enqueuing first batch");

   for (var qn = 0; qn < processors; qn++)
   {
      var proc = procs[qn];
      for (var iter = 1; iter <= iterations; iter++) proc.Enqueue(iter);
   }

   Console.WriteLine("Finished enqueuing first batch");
   cde.Wait();
   cde.Reset();
   Debug.WriteLine("Pausing all");
   procs.ForEach(p => p.Pause());
   Console.WriteLine("Enqueuing second batch");

   for (var qn = 0; qn < processors; qn++)
   {
      var proc = procs[qn];
      for (var iter = 1; iter <= iterations; iter++) proc.Enqueue(iter + (iterations * 10));
   }

   Console.WriteLine("Finished enqueuing second batch");

   Console.WriteLine("Press ENTER to resume item processing.");
   Console.ReadLine();
   Console.WriteLine("Resuming all");
   procs.ForEach(p => p.Resume());
   cde.Wait();
   cde.Reset();
   Console.WriteLine("Enqueuing third batch");

   for (var qn = 0; qn < processors; qn++)
   {
      var proc = procs[qn];
      for (var iter = 1; iter <= iterations; iter++) proc.Enqueue(iter + (iterations * 20));
   }

   Console.WriteLine("Finished enqueuing third batch");

   cde.Wait();
}