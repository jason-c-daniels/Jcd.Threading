// for readability we alias the various custom TaskScheduler based task runners

global using MTAScheduler =
   Jcd.Tasks.CustomSchedulerTaskRunner<
      Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers.FourSimpleMtaPerCpuTaskScheduler>;
global using STAScheduler =
   Jcd.Tasks.CustomSchedulerTaskRunner<
      Jcd.Examples.Wpf.CustomTaskSchedulers.ExampleSchedulers.OneSimpleStaThreadedPerCpuTaskScheduler>;
global using CurrentScheduler = Jcd.Tasks.CurrentSchedulerTaskRunner;