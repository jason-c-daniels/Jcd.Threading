global using MTAScheduler = Jcd.Tasks.SchedulerBoundTaskRunner<Jcd.Tasks.OneMTAThreadPerCpuScheduler>;
global using STAScheduler = Jcd.Tasks.SchedulerBoundTaskRunner<Jcd.Tasks.OneSTAThreadPerCpuScheduler>;
global using CurrentScheduler = Jcd.Tasks.CurrentSchedulerTaskRunner;
