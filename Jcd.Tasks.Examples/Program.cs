// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ObjectAllocation

const int count = 10000;

Log(-999, TaskScheduler.Current, "App Started");

await STaskRunner.Run(Main);

Log(-999, TaskScheduler.Current, "App Ending");

return;

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
   await Console.Out.FlushAsync();
   await LogAsync(-111, TaskScheduler.Current, "finished");
}

async Task ReportScheduler(int i)
{
   var ts = TaskScheduler.Current;
   await LogAsync(i, ts, $"{nameof(ReportScheduler)}");
   await Task.Delay(500);
   await InnerReportScheduler(i);
}

async Task InnerReportScheduler(int i)
{
   var ts = TaskScheduler.Current;
   await LogAsync(i, ts, $"{nameof(InnerReportScheduler)}");
   await Task.Delay(250);
   await STaskRunner.Run(() => FinalInnerReportScheduler(i));
}

async Task FinalInnerReportScheduler(int i)
{
   var ts = TaskScheduler.Current;
   await LogAsync(i, ts, $"{nameof(FinalInnerReportScheduler)}");
   await Task.Delay(100);
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