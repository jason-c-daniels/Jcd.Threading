using Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

namespace Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers;

internal class MainTaskScheduler : QueuedThreadedTaskScheduler
{
   public MainTaskScheduler() : base(apartmentState: ApartmentState.STA) { }
}