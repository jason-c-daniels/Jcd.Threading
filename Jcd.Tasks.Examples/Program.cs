using Jcd.Tasks.Examples;

await SynchronizedValueExample.Run();
await BlockingTaskProcessorExample.Run();
return await UnstartedTaskExample.Run(); // this won't actually finish. You'll need to press CTRL-C.