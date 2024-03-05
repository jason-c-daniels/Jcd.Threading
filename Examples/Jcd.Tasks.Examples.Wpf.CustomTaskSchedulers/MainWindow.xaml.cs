using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

using Jcd.Threading.Tasks;

// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow //: Window
{
   private readonly MainWindowViewModel mainWindowViewModel = new();
   private          DispatcherTimer     scrollResultsTimer  = new();
   private          DispatcherTimer     scrollItemsTimer    = new();

   public MainWindow()
   {
      InitializeComponent();
      DataContext                 =  mainWindowViewModel;
      scrollItemsTimer.Tick       += ScrollItemsTimerOnTick;
      scrollItemsTimer.Interval   =  TimeSpan.FromMilliseconds(250);
      scrollResultsTimer.Tick     += ScrollResultsTimerOnTick;
      scrollResultsTimer.Interval =  TimeSpan.FromMilliseconds(250);
      scrollItemsTimer.Start();
      scrollResultsTimer.Start();
   }

   private int lastResultCount = 0;

   private void ScrollResultsTimerOnTick(object sender, EventArgs e)
   {
      if (lastResultCount == ResultsList.Items.Count) return;
      lastResultCount = ScrollToEnd(ResultsList);
   }

   private int lastItemCount = 0;

   private void ScrollItemsTimerOnTick(object sender, EventArgs e)
   {
      if (lastItemCount == ItemsList.Items.Count) return;
      lastItemCount = ScrollToEnd(ItemsList);
   }

   private static int ScrollToEnd(ListBox list)
   {
      if (list.Items.Count > 0)
      {
         var border       = (Border) VisualTreeHelper.GetChild(list,         0);
         var scrollViewer = (ScrollViewer) VisualTreeHelper.GetChild(border, 0);
         scrollViewer.ScrollToEnd();
      }

      return list.Items.Count;
   }

   private async void RunWithMTA_OnClick(object sender, RoutedEventArgs e)
   {
      RunWithMta.IsEnabled = false;
      await ReportSchedulerName(nameof(RunWithMTA_OnClick)
                              , RunWithMta
                              , Stopwatch.StartNew()
                              , "Executed"
                              , await BackgroundTask.Run(GetExecutingSchedulerAndThreadInfo)
                               );
   }

   private Task ReportSchedulerName(
      string                                   method
    , UIElement                                button
    , Stopwatch                                sw
    , string                                   message
    , (TaskScheduler scheduler, Thread thread) ts
   )
   {
      var scheduler = TaskScheduler.Current;
      Ui.Invoke(() =>
                {
                   sw.Stop();
                   var item =
                      $"[{sw.ElapsedMilliseconds:D8}][{scheduler.Id}:{scheduler.GetType().Name}] {method} - Thread Name: {ts.thread.Name}({ts.thread.ManagedThreadId}; {ts.thread.GetApartmentState()}) : {message}";
                   mainWindowViewModel.Results
                                      .Add(item);
                   ResultsList.SelectedItem = item;
                }
               );
      Ui.Invoke(() => button.IsEnabled = true);

      return Task.CompletedTask;
   }

   private async void RunWithSTA_OnClick(object sender, RoutedEventArgs e)
   {
      RunWithSta.IsEnabled = false;
      await ReportSchedulerName(nameof(RunWithSTA_OnClick)
                              , RunWithSta
                              , Stopwatch.StartNew()
                              , "Executed"
                              , await STAScheduler.Run(GetExecutingSchedulerAndThreadInfo)
                               );
   }

   private async void RunInHandler_OnClick(object sender, RoutedEventArgs e)
   {
      RunInHandler.IsEnabled = false;
      await ReportSchedulerName(nameof(RunInHandler_OnClick)
                              , RunInHandler
                              , Stopwatch.StartNew()
                              , "Executed"
                              , GetExecutingSchedulerAndThreadInfo()
                               );
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
      await ReportSchedulerName(nameof(RunWithCurrent_OnClick)
                              , RunWithCurrent
                              , Stopwatch.StartNew()
                              , "Executed"
                              , await CurrentScheduler.Run(GetExecutingSchedulerAndThreadInfo)
                               );
   }

   private async void STAViaMTA_OnClick(object sender, RoutedEventArgs e)
   {
      StaViaMta.IsEnabled = false;
      await ReportSchedulerName(nameof(STAViaMTA_OnClick)
                              , StaViaMta
                              , Stopwatch.StartNew()
                              , "Executed"
                              , await BackgroundTask.Run(() => STAScheduler.Run(GetExecutingSchedulerAndThreadInfo))
                               );
   }

   private async void UiViaMTA_OnClick(object sender, RoutedEventArgs e)
   {
      UiViaMta.IsEnabled = false;
      await BackgroundTask.Run(() => Ui.Invoke(() => ReportSchedulerName(nameof(UiViaMTA_OnClick)
                                                                       , UiViaMta
                                                                       , Stopwatch.StartNew()
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
                                                                         , Stopwatch.StartNew()
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
                                                                     , Stopwatch.StartNew()
                                                                     , "Executed"
                                                                     , GetExecutingSchedulerAndThreadInfo()
                                                                      )
                                            )
                            );
   }

   private async void RunWithTaskRun_OnClick(object sender, RoutedEventArgs e)
   {
      var button = RunWithTaskRun;
      button.IsEnabled = false;
      await Task.Run(() => Ui.Invoke(() => ReportSchedulerName(nameof(RunWithTaskRun_OnClick)
                                                             , button
                                                             , Stopwatch.StartNew()
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
      await BackgroundTask.Run(() => LongRunningTask(nameof(LongRunningMTATask_OnClick)
                                                   , LongRunningMtaTask
                                                   , sw
                                                    )
                              );
   }

   // ReSharper disable once CognitiveComplexity
   private async Task LongRunningTask(
      string    method
    , UIElement button
    , Stopwatch scheduledStopwatch
    , int       taskCount    = 0
    , int       durationInMs = 4000
    , int       delay        = 1
   )
   {
      if (taskCount == 0) taskCount = Environment.ProcessorCount * 8;
      var taskSw                    = Stopwatch.StartNew();
      var tasks                     = new List<Task>();

      var scheduler = TaskScheduler.Current;
      Debug.WriteLine($"Starting to enqueue tasks on Scheduler {TaskScheduler.Current.GetType().Name}");

      for (var i = 0; i < taskCount; i++)
      {
         var xxx = i;
         tasks.Add(scheduler.Run(async () =>
                                 {
                                    using var waiter = new AutoResetEvent(false);
                                    waiter.WaitOne(1);
                                    var waitSw = Stopwatch.StartNew();
                                    var z      = 0L;

                                    // do some CPU intensive busywork, yielding every 100 times
                                    // We modify a and return value outside the loop to prevent the compiler
                                    // from optimizing out the operations.
                                    while (waitSw.ElapsedMilliseconds < durationInMs)
                                    {
                                       z++;

                                       if (z % 5731 == 0) waiter.WaitOne(5);

                                       if (z % 57310 == 0)
                                       {
                                          var t           = Thread.CurrentThread;
                                          var elapsed     = waitSw.ElapsedMilliseconds;
                                          var taskElapsed = taskSw.ElapsedMilliseconds;
                                          Ui.Invoke(() =>
                                                    {
                                                       var ct = Thread.CurrentThread;
                                                       var item =
                                                          $"[{scheduler.Id}:{scheduler.GetType().Name}] Executing Thread:{t.Name}({t.ManagedThreadId}; {t.GetApartmentState()}); UI Thread:{ct.Name}({ct.ManagedThreadId}; {ct.GetApartmentState()}); - Task[{xxx}] task @ {taskElapsed} ms; loop @ {elapsed} ms";
                                                       mainWindowViewModel.Items.Add(item);
                                                       ItemsList.SelectedItem = item;
                                                    }
                                                   );
                                       }
                                    }

                                    waitSw.Stop();
                                    await Task.Delay(delay);

                                    return z;
                                 }
                                )
                  );
      }

      Debug.WriteLine($"Finished enqueuing tasks on Scheduler {TaskScheduler.Current.GetType().Name}");

      await Task.WhenAll(tasks);
      taskSw.Stop();
      scheduledStopwatch.Stop();
      var elapsedMs     = taskSw.ElapsedMilliseconds;
      var scheduleDelay = scheduledStopwatch.ElapsedMilliseconds - elapsedMs;
      var ts            = GetExecutingSchedulerAndThreadInfo();
      await Ui.Invoke(async () =>
                      {
                         var result = $"Executed in {elapsedMs} ms after a {scheduleDelay} ms delay";
                         await ReportSchedulerName(method
                                                 , button
                                                 , Stopwatch.StartNew()
                                                 , result
                                                 , ts
                                                  );
                      }
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

   private void Clear_OnClick(object sender, RoutedEventArgs e)
   {
      mainWindowViewModel.Items.Clear();
      mainWindowViewModel.Results.Clear();
   }
}