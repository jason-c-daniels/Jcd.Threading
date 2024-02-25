// for readability we alias the various custom TaskScheduler based task runners

global using MTAScheduler =
   Jcd.Tasks.CustomSchedulerTaskRunner<Jcd.Tasks.TaskSchedulers.FourMtaThreadsPerCpuTaskScheduler>;
global using STAScheduler =
   Jcd.Tasks.CustomSchedulerTaskRunner<Jcd.Tasks.TaskSchedulers.OneStaThreadPerCpuTaskScheduler>;
global using CurrentScheduler = Jcd.Tasks.CurrentSchedulerTaskRunner;