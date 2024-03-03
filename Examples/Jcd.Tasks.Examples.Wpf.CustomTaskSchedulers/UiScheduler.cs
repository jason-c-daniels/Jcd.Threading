using Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

namespace Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers;

internal class UiScheduler() : IdleTaskScheduler(4, ApartmentState.STA);