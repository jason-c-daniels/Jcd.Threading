// for readability we alias the various custom TaskScheduler based task runners

global using BackgroundTask = Jcd.Threading.Tasks.CustomSchedulerTaskRunner<
   Jcd.Threading.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers.DefaultMtaTaskScheduler>;
global using STAScheduler = Jcd.Threading.Tasks.CustomSchedulerTaskRunner<
   Jcd.Threading.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers.DefaultStaTaskScheduler>;
global using CurrentScheduler = Jcd.Threading.Tasks.CurrentTaskSchedulerRunner;