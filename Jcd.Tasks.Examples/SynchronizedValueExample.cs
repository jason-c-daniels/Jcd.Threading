﻿namespace Jcd.Tasks.Examples;

/// <summary>
/// Demonstrates some of the uses for <see cref="SynchronizedValue{T}"/>
/// </summary>
public class SynchronizedValueExample
{
    /// <summary>
    /// Runs the example code. Returns 0 if successful. Throws an exception otherwise.
    /// </summary>
    /// <returns>0</returns>
    /// <exception cref="TaskCanceledException"></exception>
    public static async Task<int> Run()
    {
        var counter = new SynchronizedValue<int>();
        using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(0.11)); // set a total run time of 0.11 minutes

        // create a hot-task that starts incrementing the value by 1 every 100 ms;
        var incrementTask = Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                await Task.Delay(100, cts.Token);
                await counter.ChangeValueAsync(x => x + 1);
            }

            if (cts.IsCancellationRequested) throw new TaskCanceledException();
        }, cts.Token);

        // create a hot-task that starts decrements the value by 3 every 420 ms;
        var decBy4Task = Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                await Task.Delay(420, cts.Token);
                await counter.ChangeValueAsync(x => x - 3);
            }

            if (cts.IsCancellationRequested) throw new TaskCanceledException();
        }, cts.Token);

        // create a hot-task that sets the to 10 every 5 seconds;
        var setTo20Task = Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                await Task.Delay(5000, cts.Token);
                await counter.SetValueAsync(10);
                Console.WriteLine($"{DateTime.Now:O} : Reset to 10!");
                await Console.Out.FlushAsync();
            }

            if (cts.IsCancellationRequested) throw new TaskCanceledException();
        }, cts.Token);

        // create a hot-task that reports the value and a timestamp every 100ms
        var reportValue = Task.Run(async () =>
        {
            while (!cts.IsCancellationRequested)
            {
                await Task.Delay(100, cts.Token);
                Console.WriteLine($"{DateTime.Now:O} : counter.Value = {counter.Value}");
            }

            if (cts.IsCancellationRequested) throw new TaskCanceledException();
        }, cts.Token);

        // Now ensure the tasks have completed. The TryAwait(Async) extension method can be used 
        // if there's any question as to the faulted/canceled state, and your application won't 
        // care/knows how to recover.
        //
        // In this case, since the Task.Delay is using the cancellation token, and we directly 
        // raise the TaskCanceledException we are expecting the tasks to be cancelled.
        // And this application is merely reporting statuses on completion.
        //
        // NOTE: Only use this method if your application knows how to recover from cancelled or 
        // faulted tasks.
        //

        await Task.WhenAll(
            reportValue.TryWaitAsync(),
            setTo20Task.TryWaitAsync(),
            decBy4Task.TryWaitAsync(),
            incrementTask.TryWaitAsync());

        // now report their statuses.
        Console.WriteLine($"reportValue.Status {reportValue.Status}");
        Console.WriteLine($"setTo20Task.Status {setTo20Task.Status}");
        Console.WriteLine($"decBy4Task.Status {decBy4Task.Status}");
        Console.WriteLine($"incrementTask.Status {incrementTask.Status}");

        return 0;
    }
}