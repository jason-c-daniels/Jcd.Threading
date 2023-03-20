using System.Diagnostics;
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable UnusedMethodReturnValue.Global

namespace Jcd.Tasks.Examples;

/// <summary>
/// Demonstrates some of the uses of <see cref="Tasks.BlockingTaskProcessor"/>
/// </summary>
public static class BlockingTaskProcessorExample
{
    private static readonly BlockingTaskProcessor TaskProcessor = new(false); // don't start right away.

    /// <summary>
    /// Runs the example code. Returns 0 if successful. Throws an exception otherwise.
    /// </summary>
    /// <returns>0</returns>
    /// <exception cref="TaskCanceledException"></exception>
    public static async Task<int> Run()
    {
        // Start up the enqueued task processing. The queue should be empty.
        // We start up here because some of the tasks will manipulate the queue status.
        // Ensuring task processing has already begun nearly ensures something gets processed
        // before the first pause occurs.
        TaskProcessor.StartProcessing();

        // This example starts up five tasks that manipulate the queue in various ways and which will last for 
        // differing amounts of time.
        
        // create a task that enqueues work every 0.2 seconds with a lifespan of 120 seconds.. Each enqueued task delays for PI/100 seconds.
        var ctsQueuer1 = StartQueuerTask();
        
        // create another task that enqueues work every 90ms with a lifespan of 120 seconds.. Each enqueued task delays for 100ms
        var ctsQueuer2 = StartQueuerTask(10d/1000d,90d/1000d);
        
        // create a task that periodically resumes the queue (every 6 seconds) with a lifespan of 120 seconds.
        var ctsResumer1 = StartResumerTask(6.0);
        
        // create a task that periodically pauses the queue (every 3 seconds)  with a lifespan of 120 seconds.
        var ctsPauser1 = StartPauserTask(3.0);
        
        // create a task that spams calls to TaskProcessor.Pause. This is done for... reasons.
        var ctsSpastic = SpasticPauserTask(Math.PI*(1+1d/3d),60);
        
        // create a task that periodically calls TaskProcessor.Cancel every 10 seconds for one minute.
        var ctsCanceler = StartCancellerTask(); 
        
        // create a task that periodically calls TaskProcessor.StartProcessing every 8 seconds for one minute.
        var ctsStarter = StartStarterTask();
        
        // wait, yielding CPU time, until all tasks have been cancelled by their cancellation tokens
        while (!ctsPauser1.IsCancellationRequested ||
               !ctsQueuer1.IsCancellationRequested ||
               !ctsQueuer2.IsCancellationRequested ||
               !ctsResumer1.IsCancellationRequested ||
               !ctsSpastic.IsCancellationRequested ||
               !ctsCanceler.IsCancellationRequested ||
               !ctsStarter.IsCancellationRequested
              ) await Task.Yield(); 

        // cancel all pending tasks (there should be a lot of them)
        TaskProcessor.Cancel();
        
        // NOTE: interpreting the output is a bit messy.
        
        // wait two seconds to give already executing tasks time to finish their work.
        // ideally tasks will directly check the status of the cancellation token in order
        // to exit expeditiously.
        // ReSharper disable once MethodSupportsCancellation
        await Task.Delay(2000);
        return 0;
    }

    private static CancellationTokenSource StartQueuerTask(double busyWorkDelayInSeconds=Math.PI/100.0,double enqueueDelayInSeconds=0.2, double lifeSpanInSeconds=120)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
        {
            // enqueue an async action when called.
            void Enqueue(long item, long thId)
            {
                Debug.WriteLine($"{thId}:{item} enqueuing : q.Length= {TaskProcessor.QueueLength}");
                Debug.Flush();
                TaskProcessor.Enqueue(async () =>
                {
                    Console.WriteLine($"{thId}:{item} began");
                    await Console.Out.FlushAsync();
                    await Task.Delay(TimeSpan.FromSeconds(busyWorkDelayInSeconds), cts.Token);
                    Console.WriteLine($"{thId}:{item} finished");
                    await Console.Out.FlushAsync();
                });
                Debug.WriteLine($"{thId}:{item} enqueued");
                Debug.Flush();
            }

            long i = 0;
            while (!cts.IsCancellationRequested)
            {
                Enqueue(i++, Environment.CurrentManagedThreadId);
                await Task.Delay(TimeSpan.FromSeconds(enqueueDelayInSeconds), cts.Token);
            }
        },cts.Token);
        return cts;
    }

    private static CancellationTokenSource StartPauserTask(double delayInSeconds=Math.PI-0.1,double lifeSpanInSeconds=120)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                if (TaskProcessor.IsPaused) continue;
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                Console.WriteLine($"Pausing from {nameof(StartPauserTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
                await TaskProcessor.PauseAsync();
                Console.WriteLine($"Paused from {nameof(StartPauserTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
            }
        }, cts.Token);
        return cts;
    }
    
    private static CancellationTokenSource StartCancellerTask(double delayInSeconds=30,double lifeSpanInSeconds=60)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                if (TaskProcessor.IsPaused) continue;
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                Console.WriteLine($"Cancelling from {nameof(StartCancellerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
                TaskProcessor.Cancel();
                Console.WriteLine($"Canceled from {nameof(StartCancellerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
            }
        }, cts.Token);
        return cts;
    }

    private static CancellationTokenSource StartStarterTask(double delayInSeconds = 8, double lifeSpanInSeconds = 60)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                if (TaskProcessor.IsPaused) continue;
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                Console.WriteLine($"(re?)Starting from {nameof(StartCancellerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
                TaskProcessor.StartProcessing();
                Console.WriteLine($"(re?)Started from {nameof(StartCancellerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
            }
        }, cts.Token);
        return cts;
    }

    private static CancellationTokenSource StartResumerTask(double delayInSeconds=Math.PI,double lifeSpanInSeconds=120)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                if (!TaskProcessor.IsPaused) continue; // do nothing until the queue is paused.
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                Console.WriteLine($"Resuming from {nameof(StartResumerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
                await TaskProcessor.ResumeAsync();
                Console.WriteLine($"Resume from {nameof(StartResumerTask)} {Environment.CurrentManagedThreadId}");
                await Console.Out.FlushAsync();
            }
        }, cts.Token);
        return cts;
    }

    private static CancellationTokenSource SpasticPauserTask(double delayInSeconds=Math.PI*3,double lifeSpanInSeconds=120,int numberOfThreads=100)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(lifeSpanInSeconds));
        Task.Run(async () =>
            {
                while (!cts.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                    await Task.WhenAll(
                        Enumerable.Range(0,numberOfThreads).Select(x=>
                            Task.Run(async () =>
                            {
                                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds/2), cts.Token);
                                Console.WriteLine($"Pausing [{x}] from {nameof(SpasticPauserTask)} {Environment.CurrentManagedThreadId}");
                                await Console.Out.FlushAsync();
                                await TaskProcessor.PauseAsync();
                                Console.WriteLine($"Paused [{x}] from {nameof(SpasticPauserTask)} {Environment.CurrentManagedThreadId}");
                                await Console.Out.FlushAsync();
                            }, cts.Token)
                        ));
                    await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), cts.Token);
                }
            }, cts.Token);
        return cts;
    }

}