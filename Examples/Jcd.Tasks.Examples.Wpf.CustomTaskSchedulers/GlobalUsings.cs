// for readability we alias the various custom TaskScheduler based task runners

global using BackgroundTask =
   Jcd.Tasks.CustomSchedulerTaskRunner<
      Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers.FourMtaThreadsPerCpuTaskScheduler>;
global using STAScheduler =
   Jcd.Tasks.CustomSchedulerTaskRunner<
      Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers.FourStaThreadsPerCpuTaskScheduler>;
global using CurrentScheduler = Jcd.Tasks.CurrentSchedulerTaskRunner;