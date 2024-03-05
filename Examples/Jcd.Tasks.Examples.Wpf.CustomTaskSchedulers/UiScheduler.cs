using Jcd.Threading.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers;

internal class UiScheduler() : IdleTaskScheduler(4, ApartmentState.STA);