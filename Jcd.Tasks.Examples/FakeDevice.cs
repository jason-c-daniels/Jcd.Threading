using System.Collections.Concurrent;
using Nito.AsyncEx;

namespace Jcd.Tasks.Examples;

public class FakeDevice
{
    private readonly AsyncLock _lock = new ();
    private readonly SynchronizedValue<int> _backlogCounter = new();
    private int _backlogCount = 0;
    public async Task SendMessage(int messageType, byte[] buffer)
    {
        //Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.FFFF}:Entered FakeDevice.SendMessage {messageType} Thd:{Environment.CurrentManagedThreadId}");
        //await Console.Out.FlushAsync();
        Interlocked.Increment(ref _backlogCount);
        await _backlogCounter.ChangeValueAsync(x => x+1);
        using (await _lock.LockAsync())
        {
            var count=await _backlogCounter.ChangeValueAsync(x => x-1);
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.FFFF} FakeDevice.SendMessage {count}");
            //Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.FFFF}:Entered FakeDevice.SendMessage-Locked Region {messageType} Thd:{Environment.CurrentManagedThreadId} FakeDevice.SendMessage");
            //await Console.Out.FlushAsync();
            await Task.Delay((messageType % 16 + 15));
            var reversed = buffer.Reverse().ToArray();
            //Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss.FFFF}:Exited FakeDevice.SendMessage-Locked Region {messageType} Thd:{Environment.CurrentManagedThreadId} FakeDevice.SendMessage");
            //await Console.Out.FlushAsync();
        }
    }
}