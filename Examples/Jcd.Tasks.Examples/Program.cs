// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident

using System.Diagnostics;

using Hardware.Info;

using Jcd.Tasks;
using Jcd.Tasks.Examples;

int       cpuCount = Environment.ProcessorCount;
const int delay    = 125;
int       taskCount  = cpuCount;
int       q          = 0;


await RunTicketLock();
Console.ReadLine();
await RunSemaphoreLock();

async Task RunSemaphoreLock()
{
   var            semaphore        = new SemaphoreSlim(1, 1);

   var tasks = new List<Task>();

   //var svsb  = new MutexValue<List<string>>(new List<string>());
   Console.WriteLine("Enqueuing tasks.");
   var sw = Stopwatch.StartNew();
   for (var i = 0; i < taskCount; i++)
   {
      var n = i;
      AddNewSemaphoreTask(tasks, i, semaphore);
   }
   
   await Task.WhenAll(tasks);
   sw.Stop();
   Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
}

void AddNewSemaphoreTask(List<Task> list, int n, SemaphoreSlim semaphore)
{
   list.Add(Task.Run(async () =>
                     {
                        long tid = n;
                        Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] started.");
                        Console.Out.Flush();
                        await Task.Delay(delay);
                        try
                        {
                           using (var t = await semaphore.LockAsync())
                           {
                              q++;
                              tid = q;
                              Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} in critical section.");
                              Console.Out.Flush();
                              await Task.Delay(delay);
                           }

                           Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} exited critical section.");
                           Console.Out.Flush();
                           await Task.Delay(delay);
                           Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} ended.");
                           Console.Out.Flush();
                        }
                        catch
                        {
                           
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
                            long tid = n;

                            Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] started.");
                            Console.Out.Flush();
                            await Task.Delay(delay);
                            using (var t = await tl.LockAsync())
                            {
                               tid = t.TicketId;
                               Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} in critical section.");
                               Console.Out.Flush();
                               await Task.Delay(delay);
                            }
                            Console.WriteLine($"[{DateTime.Now.TimeOfDay}] Task[{n:D4}] {tid:D4} exited critical section.");
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

return;
var tlv = new TicketLockedValue<int>(12);
var tlvV   = tlv.Value;

var mres = new ManualResetEventSlim(true);
var                    sv         = new SynchronizedValue<int>(10);
const int              iterations = 10_000_000;
var                    syncRoot   = new object();
var                    asyncLock  = new Nito.AsyncEx.AsyncLock();
int                    t          = 10;
SynchronizedValue<int> svT        = new(10);
var                    hwi        = new HardwareInfo();
hwi.RefreshCPUList(false);
var    cpuHz = hwi.CpuList.First().MaxClockSpeed;
double d     = 1.1;
var    cpu   =hwi.CpuList.First();

for (var i=0;i<1000;i++)
{
   d /= 1.0001;
   for (var j = 0; j < iterations; j++)
      d *= 1.001;
   d     /= 1.01;
}
cpuHz = Math.Max(cpuHz, cpu.CurrentClockSpeed);
var dz = cpuHz;

cpuHz *= 1_000_000;

Console.WriteLine($"CPU Hz,{cpuHz}");
Console.WriteLine($"Iterations,{iterations}");
Console.WriteLine($"Test,duration (ms),Ops/ms,ops/s,cycles/op,Op Time in µs");

TimeIt("Raw Set", () => { for (var i = 0; i < iterations; i++) t = i;});

int x = t;

TimeIt("Raw Get"
     , () =>
       {
          var r = 0;
          for (var i = 0; i < iterations; i++)
          {
             r = t;
          }

          t = r;
       }
      );

x   += t;
var rwls = new ReaderWriterLockSlim();
TimeIt("RWLSExt Set", () => { for (var i = 0; i < iterations; i++)
                         {
                            using (rwls.Lock(ReaderWriterLockSlimIntent.Write))
                            {
                               t = i;
                            }
                         }
                      });
x += t;

TimeIt("RWLSExt Get"
     , () =>
       {
          var r = 0;
          for (var i = 0; i < iterations; i++)
          {
             using (rwls.Lock())
             {
                r = t;
             }
          }
       }
      );
x += t;

TimeIt("RWLS Set"
     , () =>
       {
          for (var i = 0; i < iterations; i++)
          {
             rwls.EnterWriteLock();
             t = i;
             rwls.ExitWriteLock();
          }
       }
      );
x += t;

TimeIt("RWLS Get"
     , () =>
       {
          for (var i = 0; i < iterations; i++)
          {
             rwls.EnterReadLock();
             var r= t;
             rwls.ExitReadLock();
          }
       }
      );
x += t;

var sem = new SemaphoreSlim(1, 1);
TimeIt("SemSlimExt Synchronized Set", () => { for (var i = 0; i < iterations; i++)
{
   using (sem.Lock())
      t = i;
}});
x += t;

TimeIt("SemSlimExt Synchronized Get"
     , () =>
       {
          var r = 0;

          for (var i = 0; i < iterations; i++)
          {
             using (sem.Lock())
             {
                r = t;
             }
          }
       }
      );

TimeIt("SemSlim Synchronized Set"
     , () =>
       {
          for (var i = 0; i < iterations; i++)
          {
             sem.Wait();
             t = i;
             sem.Release();
          }
       }
      );
x += t;

TimeIt("SemSlim Synchronized Get"
     , () =>
       {
          var r = 0;
          for (var i = 0; i < iterations; i++)
          {
             sem.Wait();
             r = t;
             sem.Release();
          }

          //var x = r;
       }
      );

TimeIt("Nito.AsyncEx.AsyncLock Set", () => { for (var i = 0; i < iterations; i++)
{
   using(Nito.AsyncEx.SemaphoreSlimExtensions.Lock(sem))
      t = i;
}});
x += t;

TimeItAsync("Nito.AsyncEx.AsyncLock Get", async () =>
                                   {
                                      var r = 0;
                                      for (var i = 0; i < iterations; i++)
                                      {
                                         using (await Nito.AsyncEx.SemaphoreSlimExtensions.LockAsync(sem))
                                         {
                                            r = t;
                                         }
                                      }
                                   }
      );

TimeIt("Nito.AsyncEx.SemaphoreSlimExtensions.Lock Set", () => { for (var i = 0; i < iterations; i++)
{
   using(Nito.AsyncEx.SemaphoreSlimExtensions.Lock(sem))
      t = i;
}});
x += t;

TimeIt("Nito.AsyncEx.SemaphoreSlimExtensions.Lock Get"
     , () =>
       {
          var r = 0;

          for (var i = 0; i < iterations; i++)
          {
             using (Nito.AsyncEx.SemaphoreSlimExtensions.Lock(sem))
             {
                r = t;
             }
          }
       }
      );



TimeIt("lock(syncRoot) Set"
     , () =>
       {
          for (var i = 0; i < iterations; i++)
          {
             lock (syncRoot)
                t = i;
          }
       }
      );
x += t;

TimeIt("lock(syncRoot) Get"
     , () =>
       {
          var r = 0;
          for (var i = 0; i < iterations; i++)
          {
             lock (syncRoot)
             {
                r = t;
             }
          }
       }
      );

TimeIt("SynchronizedValue Set"
     , () =>
       {
          for (var i = 0; i < iterations; i++)
          {
             sv.Value = i;
          }
       }
      );
x += sv.Value;

TimeIt("SynchronizedValue Get"
     , () =>
       {
          var r = 0;

          for (var i = 0; i < iterations; i++)
          {
             r = sv.Value;
          }
       }
      );

x += sv.Value;

await TimeItAsync("SynchronizedValue SetAsync"
          , async () =>
            {
               for (var i = 0; i < iterations; i++)
               {
                  await sv.SetValueAsync(i);
               }
            }
           );
x += sv.Value;

await TimeItAsync("SynchronizedValue GetAsync"
                , async () =>
                  {
                     var r = 0;

                     for (var i = 0; i < iterations; i++)
                     {
                        r = await sv.GetValueAsync();
                     }
                  }
                 );

x += sv.Value;

await TimeItAsync("RWLSExt SetAsync"
                , async () =>
                  {
                     for (var i = 0; i < iterations; i++)
                     {
                        using (await rwls.LockAsync(ReaderWriterLockSlimIntent.Write))
                        {
                           t = i;
                        }
                     }
                  }
                 );
x += sv.Value;

await TimeItAsync("RWLSExt GetAsync"
                , async () =>
                  {
                     var r = 0;

                     for (var i = 0; i < iterations; i++)
                     {
                        using (await rwls.LockAsync())
                        {
                           r = t;
                        }
                     }
                  }
                 );

x += sv.Value;

if (!mres.IsSet) mres.Set();
TimeIt("MRES Set"
     ,  () =>
       {
          for (var i = 0; i < iterations; i++)
          {
             mres.Wait();
             mres.Reset();
             t = i;
             mres.Set();
          }
       }
      );
x += sv.Value;

if (!mres.IsSet) mres.Set();
TimeIt("MRES Get"
     , () =>
       {
          var r = 0;

          for (var i = 0; i < iterations; i++)
          {
             mres.Wait();
             r = t;
          }
       }
      );

x += sv.Value;

var swmr = new MutexValue<int>(15);

TimeIt("SWMR Set"
     , () =>
       {
          for (var i = 0; i < iterations; i++)
          {
             swmr.Value = i;
          }
       }
      );
x += sv.Value;

TimeIt("SWMR Get"
     , () =>
       {
          var r = 0;

          for (var i = 0; i < iterations; i++)
          {
             r = swmr.Value;
          }
       }
      );

x += sv.Value;

await TimeItAsync("SWMR SetAsync"
     , async () =>
       {
          for (var i = 0; i < iterations; i++)
          {
             await swmr.SetValueAsync(i);
          }
       }
      );
x += sv.Value;

await TimeItAsync("SWMR GetAsync"
          , async () =>
            {
               var r = 0;

               for (var i = 0; i < iterations; i++)
               {
                  r = await swmr.GetValueAsync();
               }
            }
           );

x += sv.Value;

var cde = new CountdownEvent(0);
 
TimeIt("Presignaled CDE with RWLS Set"
                , () =>
                  {
                     for (var i = 0; i < iterations; i++)
                     {
                        cde.Reset(1);
                        rwls.EnterWriteLock(); 
                        t = i;
                        rwls.ExitWriteLock();
                        cde.Signal();
                     }
                  }
                 );
x += sv.Value;
// ensure its unsignaled.
//cde.Reset(0);
TimeIt("Presignaled CDE Get"
     ,  () =>
       {
          var r = 0;

          for (var i = 0; i < iterations; i++)
          {
             cde.Wait();
             r = t;
          }
       }
      );

x += sv.Value;

Console.WriteLine($"x={x}");

void TimeIt(string name, Action action)
{
   var sw = Stopwatch.StartNew();
   action();
   sw.Stop();
   var el = sw.Elapsed.TotalMilliseconds;
   Console.WriteLine($"{name},{el:0.###},{(iterations/el):0.###}");
}

async Task TimeItAsync(string name, Func<Task> action)
{
   var sw = Stopwatch.StartNew();
   await action();
   sw.Stop();
   var el = sw.Elapsed.TotalMilliseconds;
   Console.WriteLine($"{name},{el:0.###},{(iterations /el):0.###}");
}
x += t;
// by doing this we ensure the compiler doesn't optimize out the raw value operation loops.

return;

const int count = 5000;
StartBlock("TaskSchedulerExtensionsExample Example");
await TaskSchedulerExtensionsExample.Run();

StartBlock("SynchronizedValue Example");
await SynchronizedValueExample.Run();

StartBlock("CustomTaskRunner Example");
var scheduler = new SimpleThreadedTaskScheduler(13);

Log(-999, TaskScheduler.Current, "App Started");

await scheduler.Run(Main);

Log(-999, TaskScheduler.Current, "CustomTaskRunner Ending");

return;

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

int JitteredMs(int baseDelay) { return Random.Shared.Next(baseDelay * 11) * 7 % (baseDelay / 2) + baseDelay; }

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

void RunItemProcessorExample(int iterations = 5000, int processors = 0, int delayInMs = 5)
{
   if (processors < 1) processors = Environment.ProcessorCount * 20;
   var cde                        = new CountdownEvent(processors * iterations);
   var procs = Enumerable.Range(0, processors)
                         .Select(i => new ItemProcessor<int>(x =>
                                                             {
                                                                //using var are = new AutoResetEvent(false);
                                                                //are.WaitOne(delayInMs);
                                                                //var thread = Thread.CurrentThread;
                                                                //Console.WriteLine($"Item {x} from {thread.Name}({thread.ManagedThreadId})");
                                                                var z = 0;
                                                                for (; z < iterations * 10; z++) ;
                                                                var t = z;
                                                                var a = t * 13;
                                                                var j = a / 23;
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
      for (var iter = 1; iter <= iterations; iter++) proc.Enqueue(iter + iterations * 10);
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
      for (var iter = 1; iter <= iterations; iter++) proc.Enqueue(iter + iterations * 20);
   }

   Console.WriteLine("Finished enqueuing third batch");

   cde.Wait();
}