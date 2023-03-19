// See https://aka.ms/new-console-template for more information

using Jcd.Tasks.Examples;

// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation
await SynchronizedValueExample.Run();
await SynchronizedValueExample.Run();
await BlockingTaskProcessorExample.Run();
return await UnstartedTaskExample.Run(); // this won't actually finish. You'll need to press CTRL-C.