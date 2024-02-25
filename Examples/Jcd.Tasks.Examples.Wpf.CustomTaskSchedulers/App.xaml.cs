// WPF Apps need two STA threads, one for event processing and one for rendering.
// a Single STA Thread is not sufficient.

using MainScheduler =
   Jcd.Tasks.CustomSchedulerTaskRunner<
      Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers.QuadStaThreadTaskScheduler>;

// ReSharper disable HeapView.ObjectAllocation.Evident

namespace Jcd.Examples.Wpf.CustomTaskSchedulers;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App //: Application
{
   [STAThread]
   public static int Main() { return MainScheduler.Run(AsyncMain).Result; }

   [STAThread]
   private static Task<int> AsyncMain()
   {
      var mainWindow = new MainWindow();
      var app        = new App();

      app.Run(mainWindow);

      return Task.FromResult(0);
   }
}