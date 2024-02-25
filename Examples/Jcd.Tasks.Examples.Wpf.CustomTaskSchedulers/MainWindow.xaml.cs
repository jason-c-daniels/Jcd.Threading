using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace Jcd.Examples.Wpf.CustomTaskSchedulers;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow //: Window
{
   public MainWindow() { InitializeComponent(); }

   private async void RunWithMTA_OnClick(object sender, RoutedEventArgs e)
   {
      RunWithMta.IsEnabled = false;
      ReportSchedulerName(nameof(RunWithMTA_OnClick)
                        , RunWithMta
                        , "Executed"
                        , await MTAScheduler.Run(GetExecutingSchedulerAndThreadInfo)
                         );
   }

   private static void ReportSchedulerName(
      string                                   method
    , UIElement                                button
    , string                                   message
    , (TaskScheduler scheduler, Thread thread) ts
   )
   {
      MessageBox.Show($"{method} - {ts.thread.Name} : {message}");
      button.Dispatcher.Invoke(() => button.IsEnabled = true);
   }

   private async void RunWithSTA_OnClick(object sender, RoutedEventArgs e)
   {
      RunWithSta.IsEnabled = false;
      ReportSchedulerName(nameof(RunWithSTA_OnClick)
                        , RunWithSta
                        , "Executed"
                        , await STAScheduler.Run(GetExecutingSchedulerAndThreadInfo)
                         );
   }

   private void RunInHandler_OnClick(object sender, RoutedEventArgs e)
   {
      RunInHandler.IsEnabled = false;
      ReportSchedulerName(nameof(RunInHandler_OnClick), RunInHandler, "Executed", GetExecutingSchedulerAndThreadInfo());
   }

   private static (TaskScheduler scheduler, Thread thread) GetExecutingSchedulerAndThreadInfo()
   {
      var scheduler = TaskScheduler.Current;
      var thread    = Thread.CurrentThread;

      return (scheduler, thread);
   }

   private async void RunWithCurrent_OnClick(object sender, RoutedEventArgs e)
   {
      RunWithCurrent.IsEnabled = false;
      ReportSchedulerName(nameof(RunWithSTA_OnClick)
                        , RunWithCurrent
                        , "Executed"
                        , await CurrentScheduler.Run(GetExecutingSchedulerAndThreadInfo)
                         );
   }

   private async void STAViaMTA_OnClick(object sender, RoutedEventArgs e)
   {
      StaViaMta.IsEnabled = false;
      ReportSchedulerName(nameof(STAViaMTA_OnClick)
                        , StaViaMta
                        , "Executed"
                        , await MTAScheduler.Run(() => STAScheduler.Run(GetExecutingSchedulerAndThreadInfo))
                         );
   }

   private async void UiViaMTA_OnClick(object sender, RoutedEventArgs e)
   {
      UiViaMta.IsEnabled = false;
      await MTAScheduler.Run(() => Ui.Invoke(() => ReportSchedulerName(nameof(UiViaMTA_OnClick)
                                                                     , UiViaMta
                                                                     , "Executed"
                                                                     , GetExecutingSchedulerAndThreadInfo()
                                                                      )
                                            )
                            );
   }

   private async void UiViaCurrent_OnClick(object sender, RoutedEventArgs e)
   {
      UiViaCurrent.IsEnabled = false;
      await CurrentScheduler.Run(() => Ui.Invoke(() => ReportSchedulerName(nameof(UiViaCurrent_OnClick)
                                                                         , UiViaCurrent
                                                                         , "Executed"
                                                                         , GetExecutingSchedulerAndThreadInfo()
                                                                          )
                                                )
                                );
   }

   private async void UiViaSTA_OnClick(object sender, RoutedEventArgs e)
   {
      UiViaSta.IsEnabled = false;
      await STAScheduler.Run(() => Ui.Invoke(() => ReportSchedulerName(nameof(UiViaSTA_OnClick)
                                                                     , UiViaSta
                                                                     , "Executed"
                                                                     , GetExecutingSchedulerAndThreadInfo()
                                                                      )
                                            )
                            );
   }

   private async void LongRunningMTATask_OnClick(object sender, RoutedEventArgs e)
   {
      LongRunningMtaTask.IsEnabled = false;
      var sw = Stopwatch.StartNew();
      await MTAScheduler.Run(async () => await LongRunningTask(nameof(LongRunningMTATask_OnClick)
                                                             , LongRunningMtaTask
                                                             , sw
                                                              )
                            );
   }

   private async Task LongRunningTask(
      string    method
    , Button    button
    , Stopwatch scheduledStopwatch
    , int       taskCount    = 20
    , int       durationInMs = 5000
    , int       delay        = 1
   )
   {
      var taskSw = Stopwatch.StartNew();
      var tasks  = new List<Task>();

      for (var i = 0; i < taskCount; i++)
      {
         tasks.Add(MTAScheduler.Run(async () =>
                                    {
                                       var       randomWait = new Random().Next() % 7;
                                       using var waiter     = new AutoResetEvent(false);
                                       waiter.WaitOne(1);
                                       var waitSw = Stopwatch.StartNew();
                                       var z      = 0;

                                       // do some CPU intensive busywork, yielding every 100 times
                                       // We modify a and return value outside the loop to prevent the compiler
                                       // from optimizing out the operations.
                                       while (waitSw.ElapsedMilliseconds < durationInMs)
                                       {
                                          z++;
                                          z %= int.MaxValue / 10;
                                          if (z             % 100 == 0) waiter.WaitOne(randomWait);
                                       }

                                       waitSw.Stop();
                                       await Task.Delay(delay);

                                       return z;
                                    }
                                   )
                  );
      }

      await Task.WhenAll(tasks);
      taskSw.Stop();
      scheduledStopwatch.Stop();
      var elapsedMs     = taskSw.ElapsedMilliseconds;
      var scheduleDelay = scheduledStopwatch.ElapsedMilliseconds - elapsedMs;
      var ts            = GetExecutingSchedulerAndThreadInfo();
      Ui.Invoke(() => ReportSchedulerName(method
                                        , button
                                        , $"Executed in {elapsedMs} ms after a {scheduleDelay} ms delay"
                                        , ts
                                         )
               );
   }

   private async void LongRunningSTATask_OnClick(object sender, RoutedEventArgs e)
   {
      LongRunningStaTask.IsEnabled = false;
      var sw = Stopwatch.StartNew();
      await STAScheduler.Run(async () => await LongRunningTask(nameof(LongRunningSTATask_OnClick)
                                                             , LongRunningStaTask
                                                             , sw
                                                              )
                            );
   }

   private void LongRunningUIAction_OnClick(object sender, RoutedEventArgs e)
   {
      var sw = Stopwatch.StartNew();
      LongRunningUiAction.IsEnabled = false;
      Ui.Invoke(async () => await LongRunningTask(nameof(LongRunningUIAction_OnClick), LongRunningUiAction, sw));
   }
}