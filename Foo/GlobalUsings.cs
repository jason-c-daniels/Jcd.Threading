global using MTAScheduler = Jcd.Tasks.SchedulerBoundTaskRunner<Jcd.Tasks.FourMtaThreadsPerCpuTaskScheduler>;
global using STAScheduler = Jcd.Tasks.SchedulerBoundTaskRunner<Jcd.Tasks.OneStaThreadPerCpuTaskScheduler>;
global using CurrentScheduler = Jcd.Tasks.CurrentSchedulerTaskRunner;
