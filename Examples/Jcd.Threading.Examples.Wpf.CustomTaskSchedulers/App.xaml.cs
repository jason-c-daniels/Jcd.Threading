using Jcd.Threading.Tasks;

// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App //: Application
{
   [STAThread]
   public static int Main()
   {
      Thread.CurrentThread.Name = "Main Thread";
      using var scheduler = new UiScheduler();

      return scheduler.Run(AsyncMain).Result;
   }

   [STAThread]
   private static Task<int> AsyncMain()
   {
      var cT = Thread.CurrentThread;
      Console.WriteLine($"The Current thread is: {cT.Name}[{cT.ManagedThreadId}]");
      var mainWindow = new MainWindow();
      var app        = new App();

      app.Run(mainWindow);

      return Task.FromResult(0);
   }
}