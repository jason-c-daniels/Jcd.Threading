using Nito.AsyncEx;

// ReSharper disable HeapView.ObjectAllocation

namespace Jcd.Tasks.Examples.BlockingTaskProcessor;

public class FakeServerProxy
{
    private readonly AsyncLock _lock = new();
    public readonly SynchronizedValue<int> BacklogCounter = new();
    private readonly Random _random = new();
    private readonly CancellationTokenSource _cts = new();
    private readonly bool _logDetailedCallInformation;
    private int _minLatencyInMs;
    private int _maxAdditionalLatencyInMs;

    /// <summary>
    /// Creates a <see cref="FakeServerProxy"/> with configurable random latency injection. Set both to 0 if you want to simulate near-zero latency.
    /// </summary>
    /// <param name="minLatencyInMs">the minimum amount of time before a message is considered sent and acknowledged, allowing the caller to resume.</param>
    /// <param name="maxAdditionalLatencyInMs">the minimum amount of time before a message is considered sent and acknowledged, allowing the caller to resume.</param>
    /// <param name="logDetailedCallInformation">Log detailed call information</param>
    public FakeServerProxy(int minLatencyInMs = 10, int maxAdditionalLatencyInMs = 15,
                           bool logDetailedCallInformation = false)
    {
        _minLatencyInMs = minLatencyInMs;
        _maxAdditionalLatencyInMs = maxAdditionalLatencyInMs;
        _logDetailedCallInformation = logDetailedCallInformation;
    }

    public void SetLatency(int minLatencyInMs, int maxAdditionalLatencyInMs)
    {
        _minLatencyInMs = minLatencyInMs;
        _maxAdditionalLatencyInMs = maxAdditionalLatencyInMs;
    }

    public void CancelAllRequests() => _cts.Cancel();

    public async Task SendRequest(int bufferType, byte[] buffer)
    {
        if (_logDetailedCallInformation)
            Console.WriteLine(
                $"{DateTime.Now:yyyy-MM-dd hh:mm:ss.FFFF} {nameof(FakeServerProxy)}{nameof(SendRequest)} started. {BacklogCounter.Value} calls from other tasks are already waiting.");
        await BacklogCounter.ChangeValueAsync(x => x + 1);

        // The former developers decided to alleviate server load with client side locking.
        // it works for the server side and Nito.AsyncEx is a great choice for this, in fact.
        // But as you'll see when running it, given the rate of requests, we've only moved the
        // deadlock/excessive load to the client side and not eliminated it.
        using (await _lock.LockAsync(_cts.Token))
        {
            var backlog = await BacklogCounter.ChangeValueAsync(x => x - 1);
            if (_logDetailedCallInformation)
                Console.WriteLine(
                    $"{DateTime.Now:yyyy-MM-dd hh:mm:ss.FFFF} {nameof(FakeServerProxy)}{nameof(SendRequest)} lock acquired with {backlog} other tasks waiting for this call to complete.");

            // pretend to do something useful with this buffer.
            var manipulatedByType = bufferType % 2 == 0 ? buffer.Reverse().ToArray() : buffer;

            // the response is processed... somehow... and returned to the rest of the app
            // via some other channel. That's not represented here as this is a minimal example.
            await SendBufferAndWaitForAck(manipulatedByType);
        }
    }

    // ReSharper disable once UnusedParameter.Local
    private async Task SendBufferAndWaitForAck(byte[] buffer)
    {
        // randomly generate the simulated latency for the ack/response.
        var delay = _random.Next(_maxAdditionalLatencyInMs) + _minLatencyInMs;
        await Task.Delay(delay);
        // simulating the proper return of a response is unnecessary and not performed.
    }
}