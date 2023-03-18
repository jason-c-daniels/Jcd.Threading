using Nito.AsyncEx;

namespace Jcd.Tasks.Examples.BlockingTaskProcessor;

public class FakeServerProxy
{
    private readonly AsyncLock _lock = new ();
    public readonly SynchronizedValue<int> BacklogCounter = new();
    private readonly Random _random = new ();
    private int _minLatencyInMs;
    private int _maxAdditionalLatencyInMs;

    /// <summary>
    /// Creates a <see cref="FakeServerProxy"/> with configurable random latency injection. Set both to 0 if you want to simulate near-zero latency.
    /// </summary>
    /// <param name="minLatencyInMs">the minimum amount of time before a message is considered sent and acknowledged, allowing the caller to resume.</param>
    /// <param name="maxAdditionalLatencyInMs">the minimum amount of time before a message is considered sent and acknowledged, allowing the caller to resume.</param>
    public FakeServerProxy(int minLatencyInMs = 10,int maxAdditionalLatencyInMs = 15, bool log=false)
    {
        _minLatencyInMs = minLatencyInMs;
        _maxAdditionalLatencyInMs = maxAdditionalLatencyInMs;
        _log = log;
    }

    public void SetLatency(int minLatencyInMs, int maxAdditionalLatencyInMs)
    {
        _minLatencyInMs = minLatencyInMs;
        _maxAdditionalLatencyInMs = maxAdditionalLatencyInMs;
    }
    
    private readonly bool _log;
    public async Task SendRequest(int bufferType, byte[] buffer)
    {
        if (_log) Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.FFFF} {nameof(FakeServerProxy)}{nameof(SendRequest)} started. {BacklogCounter.Value} calls from other tasks are already waiting.");
        await BacklogCounter.ChangeValueAsync(x => x+1);
        
        // The former developers decided to alleviate server load with client side locking.
        // it works for the server side and Nito.AsyncEx is a great choice for this, in fact.
        // But as you'll see when running it, given the rate of requests, we've only moved the
        // deadlock/excessive load to the client side and not eliminated it.
        using (await _lock.LockAsync())
        {
            var backlog=await BacklogCounter.ChangeValueAsync(x => x-1);
            if (_log) Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.FFFF} {nameof(FakeServerProxy)}{nameof(SendRequest)} lock acquired with {backlog} other tasks waiting for this call to complete.");
            
            // pretend to do something useful with this buffer.
            var reversed = buffer.Reverse().ToArray();
            
            // the response is processed... somehow... and returned to the rest of the app
            // via some other channel. That's not represented here as this is a minimal example.
            await SendBufferAndWaitForAck(reversed);
        }
    }
    
    private async Task SendBufferAndWaitForAck(byte[] buffer)
    {
        // randomly generate the latency for the ack. By default this is 10 to 25 ms.
        var delay = _random.Next(_maxAdditionalLatencyInMs) + _minLatencyInMs;
        await Task.Delay(delay); // simulated communications/processing delay.
    }
}