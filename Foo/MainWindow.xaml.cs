using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Foo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void RunWithMTA_OnClick(object sender, RoutedEventArgs e)
    {
        RunWithMTA.IsEnabled = false;
        ReportSchedulerName(nameof(RunWithMTA_OnClick), RunWithMTA ,"Executed", await MTAScheduler.Run(GetExecutingSchedulerAndThreadInfo));
    }

    private static void ReportSchedulerName(string method, Button button,string message, (TaskScheduler scheduler, Thread thread) ts)
    {
        var schedulerName = ts.scheduler == null ? "<unknown scheduler>" : ts.scheduler.GetType().Name;
        MessageBox.Show($"{method}[{ts.thread.ManagedThreadId}; {schedulerName}] : {message}");
        button.Dispatcher.Invoke(() => button.IsEnabled = true);
    }

    private async void RunWithSTA_OnClick(object sender, RoutedEventArgs e)
    {
        RunWithSTA.IsEnabled=false;
        ReportSchedulerName(nameof(RunWithSTA_OnClick), RunWithSTA,"Executed", await STAScheduler.Run(GetExecutingSchedulerAndThreadInfo));
    }

    private void RunInHandler_OnClick(object sender, RoutedEventArgs e)
    {
        RunInHandler.IsEnabled=false;
        ReportSchedulerName(nameof(RunInHandler_OnClick), RunInHandler,"Executed", GetExecutingSchedulerAndThreadInfo());
    }

    (TaskScheduler scheduler, Thread thread) GetExecutingSchedulerAndThreadInfo()
    {
        var scheduler = TaskScheduler.Current;
        var thread    = Thread.CurrentThread;
        return (scheduler,thread);
    }

    private async void RunWithCurrent_OnClick(object sender, RoutedEventArgs e)
    {
        RunWithCurrent.IsEnabled = false;
        ReportSchedulerName(nameof(RunWithSTA_OnClick), RunWithCurrent,"Executed", await CurrentScheduler.Run(GetExecutingSchedulerAndThreadInfo));
    }
    
    private async void STAViaMTA_OnClick(object sender, RoutedEventArgs e)
    {
        STAViaMTA.IsEnabled = false;
        ReportSchedulerName(nameof(STAViaMTA_OnClick), STAViaMTA, "Executed", await MTAScheduler.Run(()=>STAScheduler.Run(GetExecutingSchedulerAndThreadInfo)));
    }

    private async void UiViaMTA_OnClick(object sender, RoutedEventArgs e)
    {
        UiViaMTA.IsEnabled = false;
        await MTAScheduler.Run(() => Ui.Invoke(()=>ReportSchedulerName(nameof(UiViaMTA_OnClick), UiViaMTA,"Executed",GetExecutingSchedulerAndThreadInfo())));
    }

    private async void UiViaCurrent_OnClick(object sender, RoutedEventArgs e)
    {
        UiViaCurrent.IsEnabled = false;
        await CurrentScheduler.Run(() => Ui.Invoke(()=>ReportSchedulerName(nameof(UiViaCurrent_OnClick), UiViaCurrent,"Executed",GetExecutingSchedulerAndThreadInfo())));
    }

    private async void UiViaSTA_OnClick(object sender, RoutedEventArgs e)
    {
        UiViaSTA.IsEnabled = false;
        await STAScheduler.Run(() => Ui.Invoke(()=>ReportSchedulerName(nameof(UiViaSTA_OnClick),UiViaSTA,"Executed",GetExecutingSchedulerAndThreadInfo())));
    }

    private async void LongRunningMTATask_OnClick(object sender, RoutedEventArgs e)
    {
        LongRunningMTATask.IsEnabled = false;
        var sw = Stopwatch.StartNew();
        await MTAScheduler.Run(async () => await LongRunningTask(nameof(LongRunningMTATask_OnClick),LongRunningMTATask,sw));
    }

    private async Task LongRunningTask(string method, Button button, Stopwatch scheduledStopwatch, int taskCount=20, int durationInMs = 1000, int delay =100)
    {
        var sw    = Stopwatch.StartNew();
        var tasks = new List<Task>();

        for (int i = 0; i < taskCount; i++)
        {
            tasks.Add(MTAScheduler.Run(async () =>
                                       {
                                           using AutoResetEvent waiter = new AutoResetEvent(false);
                                           waiter.WaitOne(1);
                                           var sw = Stopwatch.StartNew();
                                           var i = 0;
                                           var lastElapsed = sw.ElapsedMilliseconds;
                                           while (sw.ElapsedMilliseconds < durationInMs*5)
                                           {
                                               i++;
                                               i %= int.MaxValue / 10;
                                               if (i%100==0) waiter.WaitOne(1);
                                           }

                                           sw.Stop();
                                           await Task.Delay(delay);
                                           return i;
                                       }));
        }

        await Task.WhenAll(tasks);
        sw.Stop();
        scheduledStopwatch.Stop();
        var elapsedMs     = sw.ElapsedMilliseconds;
        var scheduleDelay = scheduledStopwatch.ElapsedMilliseconds - elapsedMs;
        var ts            = GetExecutingSchedulerAndThreadInfo();
        Ui.Invoke(() => ReportSchedulerName(method, button, $"Executed in {elapsedMs} ms after a {scheduleDelay} ms delay",ts));
    }
    
    private async void LongRunningSTATask_OnClick(object sender, RoutedEventArgs e)
    {
        LongRunningSTATask.IsEnabled = false;
        var sw = Stopwatch.StartNew();
        await STAScheduler.Run(async () => await LongRunningTask(nameof(LongRunningSTATask_OnClick),LongRunningSTATask,sw));
    }

    private void LongRunningUIAction_OnClick(object sender, RoutedEventArgs e)
    {
        var sw = Stopwatch.StartNew();
        LongRunningUIAction.IsEnabled = false;
        Ui.Invoke(async () => await LongRunningTask(nameof(LongRunningUIAction_OnClick), LongRunningUIAction,sw));
    }
}