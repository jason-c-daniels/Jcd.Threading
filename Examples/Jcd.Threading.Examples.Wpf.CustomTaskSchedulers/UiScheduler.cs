using Jcd.Threading.Tasks;

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers;

internal class UiScheduler() : IdleTaskScheduler(4, ApartmentState.STA);