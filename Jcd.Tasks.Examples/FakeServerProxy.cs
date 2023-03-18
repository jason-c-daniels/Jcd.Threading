using Nito.AsyncEx;

namespace Jcd.Tasks.Examples;

public class FakeServerProxy
{
    private readonly AsyncLock _lock = new ();
    private readonly SynchronizedValue<int> _backlogCounter = new();
    private readonly Random _random = new ();
    
    public async Task SendBuffer(int bufferType, byte[] buffer)
    {
        Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.FFFF} {nameof(FakeServerProxy)}{nameof(SendBuffer)} started. {_backlogCounter.Value} calls from other threads are already waiting.");
        await _backlogCounter.ChangeValueAsync(x => x+1);
        using (await _lock.LockAsync())
        {
            var backlog=await _backlogCounter.ChangeValueAsync(x => x-1);
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.FFFF} {nameof(FakeServerProxy)}{nameof(SendBuffer)} lock acquired with {backlog} other threads waiting for this call to complete.");
            
            // pretend to do something useful with this buffer.
            var reversed = buffer.Reverse().ToArray();
            var delay = _random.Next(16) + 10;
            
            // inject a random delay anywhere from 10 to 25ms to simulate slightly laggy communication.
            await Task.Delay(delay); // simulated processing delay. Perhaps waiting on a response from the device
        }
    }
}