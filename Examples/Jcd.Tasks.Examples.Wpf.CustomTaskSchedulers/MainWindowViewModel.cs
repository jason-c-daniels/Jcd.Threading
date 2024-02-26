using System.Collections.ObjectModel;

namespace Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers;

public class MainWindowViewModel
{
   public ObservableCollection<string> Items { get; } = new();
   public ObservableCollection<string> Results  { get; } = new();
}