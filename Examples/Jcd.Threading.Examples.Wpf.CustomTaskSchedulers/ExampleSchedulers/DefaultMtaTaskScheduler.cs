using Jcd.Threading.Tasks;

namespace Jcd.Threading.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers;

public class DefaultMtaTaskScheduler() : IdleTaskScheduler(apartmentState: ApartmentState.MTA);

public class DefaultStaTaskScheduler() : IdleTaskScheduler(apartmentState: ApartmentState.STA);