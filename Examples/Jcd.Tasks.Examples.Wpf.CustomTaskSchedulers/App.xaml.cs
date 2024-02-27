// WPF Apps need two STA threads, one for event processing and one for rendering.
// a Single STA Thread is not sufficient.

using MainScheduler =
   Jcd.Tasks.CustomSchedulerTaskRunner<Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers.MainTaskScheduler>;

// ReSharper disable HeapView.ObjectAllocation.Evident

namespace Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App //: Application
{
   [STAThread]
   public static int Main()
   {
      Thread.CurrentThread.Name = "Main Thread";
      using var scheduler = new MainTaskScheduler();
      ThreadPool.SetMaxThreads(1, 1);

      return scheduler.Run(AsyncMain).Result;
   }

   [STAThread]
   private static Task<int> AsyncMain()
   {
      var mainWindow = new MainWindow();
      var app        = new App();

      app.Run(mainWindow);

      return Task.FromResult(0);
   }
}