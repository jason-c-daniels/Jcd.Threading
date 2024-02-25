// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident

using Jcd.Tasks.Examples;

const int count = 1000;
StartBlock("TaskSchedulerExtensionsExample Example");
await TaskSchedulerExtensionsExample.Run();

StartBlock("SynchronizedValue Example");
await SynchronizedValueExample.Run();

StartBlock("CustomTaskRunner Example");

Log(-999, TaskScheduler.Current, "App Started");

await CustomTaskRunner.Run(Main);

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
   await Task.Delay(100);
   await InnerReportScheduler(i);
}

// ReSharper disable once HeapView.ClosureAllocation
async Task InnerReportScheduler(int i)
{
   var ts = TaskScheduler.Current;
   await LogAsync(i, ts, $"{nameof(InnerReportScheduler)}");
   await Task.Delay(50);
   await CustomTaskRunner.Run(() => FinalInnerReportScheduler(i));
}

async Task FinalInnerReportScheduler(int i)
{
   var ts = TaskScheduler.Current;
   await LogAsync(i, ts, $"{nameof(FinalInnerReportScheduler)}");
   await Task.Delay(10);
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