// See https://aka.ms/new-console-template for more information
using Jcd.Tasks.Examples.BlockingTaskProcessor;


await SimulateDeadlocks.Run(30);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
await SingleBlockingTaskProcessor.Run(30);
