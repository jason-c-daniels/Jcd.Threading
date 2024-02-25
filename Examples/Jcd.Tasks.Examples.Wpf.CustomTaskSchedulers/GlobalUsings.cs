// for readability we alias the various custom TaskScheduler based task runners

global using MTAScheduler =
   Jcd.Tasks.CustomSchedulerTaskRunner<
      Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers.FourMtaThreadsPerCpuTaskScheduler>;
global using STAScheduler =
   Jcd.Tasks.CustomSchedulerTaskRunner<
      Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers.OneStaThreadPerCpuTaskScheduler>;
global using CurrentScheduler = Jcd.Tasks.CurrentSchedulerTaskRunner;