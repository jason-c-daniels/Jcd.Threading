using System.Diagnostics;
using Jcd.Tasks.Examples.BlockingTaskProcessor;
// system/test parameters
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable UnusedVariable
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.DelegateAllocation
#pragma warning disable CS8321
#pragma warning disable CS0219
const int runTimeInSeconds = 60,
    pingFrequencyInMs = 1000,
    tasksScheduledAtTheSameTime = 4, // the number of calls to schedule each time calls are scheduled.
    taskSchedulingFrequencyInMs = 20,
    minServerLatencyInMs = 10,
    additionalLatencyInMs = 15;
const double cpuLoadPercentage = 1; // NOTE: this may actually load your machine more than expected. Try lower numbers first.
const bool logRequestScheduling = false; // set to true for detailed logging. Things will get noisy.

var pretendUiCts = new CancellationTokenSource();
//LoadAllCores(cpuLoadPercentage);

// The baseline use of AsyncLocks meant to eliminate concurrent calls to a limited capacity server.
// It certainly limits the calls to one at a time. However, it doesn't perform well under stress.
await AsyncLockOnly.Instance.Run(runTimeInSeconds,pingFrequencyInMs,tasksScheduledAtTheSameTime,taskSchedulingFrequencyInMs,minServerLatencyInMs,additionalLatencyInMs,logRequestScheduling);
if (AsyncLockOnly.Instance.PingCount.Value > 1)
{
    Console.WriteLine($"{AsyncLockOnly.Instance.PingCount.Value} scheduled pings remain. Waiting for completion.");
}
while (AsyncLockOnly.Instance.PingCount.Value > 0)
{
    await Task.Delay(100*AsyncLockOnly.Instance.PingCount.Value/10);
}


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

// a subpar attempt at solving the problem which actually made pings worse.
await SingleBlockingTaskProcessor.Instance.Run(runTimeInSeconds,pingFrequencyInMs,tasksScheduledAtTheSameTime,taskSchedulingFrequencyInMs,minServerLatencyInMs,additionalLatencyInMs,logRequestScheduling);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

// A reasonable approach, with caveats is a queue for normal priority and non-queued for high/critical
// priority requests. You must intentionally limit the frequency and concurrency of high priority calls,
// otherwise you're back at square one. If this isn't sufficient then having a communications throttled
// server isn't going to work for your application. See if you can change *that.*
await SingleBlockingTaskProcessor2.Instance.Run(runTimeInSeconds,pingFrequencyInMs,tasksScheduledAtTheSameTime,taskSchedulingFrequencyInMs,minServerLatencyInMs,additionalLatencyInMs,logRequestScheduling);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

pretendUiCts.Cancel();

Console.WriteLine("Done executing.");

void LoadAllCores(double percentage)
{
    for (var i = 0; i < Environment.ProcessorCount;i++)
    {
        Task.Run(async () => await ConsumeCpu(percentage));
    }
}

async Task ConsumeCpu(double percentage)
{
    if (percentage is < 0 or > 100)
        throw new ArgumentNullException( nameof(percentage));
    var watch = new Stopwatch();
    watch.Start();
    while (pretendUiCts is { IsCancellationRequested: false })
    {
        // Make the loop go on for "percentage" milliseconds then sleep the 
        // remaining percentage milliseconds. So 40% utilization means work 40ms and sleep 60ms
        if (watch.ElapsedMilliseconds <= percentage) continue;
        
        var delay = TimeSpan.FromMilliseconds(100 - percentage);
        await Task.Delay(delay);
        watch.Reset();
        watch.Start();
    }
}

// Q: Can I use two queues/task processors, one for high, but not critical priority, one for normal
// priority, and doing critical communications outside of queued communications?
//
// Yes. This would certainly be useful for circumstances where you actually have three different
// priorities of communication, but comes with its own risks:
// 
// 1) Critical communications could now have to wait for TWO preceding calls to finish before i
// ts allowed to execute, causing unnecessary delays.
//
// 2) You've just introduced more for yourself and your peers to consider when making the calls.
//
// You know your situation best. Weigh the pros and cons, and SIMULATE IT first. Tweak the run
// parameters like you can do in this app. Set them to observed and expected real world usage.
// AND put in values that represent expected and/or observed misuse. Get familiar with the behavior
// so you can help diagnose it. You will be called upon to assist if anything goes wrong.


// Q: I see the two queues possibly stopping traffic that I want to have happen first.
// How can I mitigate it?
//
// A: Reduce the number of queues. In the single queue strategy you will have a single call
// blocking before your critical call can be made. The risk, of course, is that if too many
// calls are made at a critical priority you'll end up with a lot of blocking, causing 
// the very problems that inspired this experiment.

// Q: Could a concurrent priority queue work?
// 
// Yes, and (there's always an "and") you'd still have
// to educate and persuade developers on correct usage for it to work. Such is the nature of
// scheduling work with competing priorities.


// Q: Does a solution that doesn't use any queues exist?
// 
// Yes. I suppose one could cleverly arrange locks to enforce execution priority. Establishing execution
// priority with clever lock usage seems easy to misuse and harder to diagnose once things go wrong.
// And it's not as easy for most developers to understand versus queues. So I would advise you avoid
// this approach if you can.
//
// Why? Basically, you still need to properly educate peers on proper execution priority selection.
// (After all that is the crux of this problem) and now, on top of that, you have all of risk of
// fragile and easy to misunderstand code.
// 
// To be clear: **I** would rather rewrite the guts of a program to make it easier to maintain and to
// establish correct execution priority with implicit or explicit queues, such as with BlockingTaskProcessor
// than implement something seemingly fragile and easily misunderstood.
