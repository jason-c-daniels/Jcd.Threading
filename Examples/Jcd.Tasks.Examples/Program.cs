// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident

using Jcd.Tasks;
using Jcd.Tasks.Examples;

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