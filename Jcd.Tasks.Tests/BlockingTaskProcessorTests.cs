// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ClosureAllocation

namespace Jcd.Tasks.Tests;

public class BlockingTaskProcessorTests
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task Constructor_Automatically_Starts_When_Expected(bool autostart)
    {
        using var btp = new BlockingTaskProcessor(autostart);
        await Task.Delay(100);
        Assert.Equal(autostart, btp.IsStarted);
        btp.Cancel();
    }

    [Fact]
    public async Task Enqueue_Action_Enqueues_And_Executes_The_Action()
    {
        using var btp = new BlockingTaskProcessor();
        var actionRan = false;

        void Action()
        {
            actionRan = true;
        }

        btp.Enqueue(Action);
        await Task.Delay(100);
        Assert.True(actionRan);
        btp.Cancel();
    }

    [Fact]
    public async Task Enqueue_Function_Enqueues_And_Executes_The_Function()
    {
        using var btp = new BlockingTaskProcessor();
        var funcRan = false;
        bool Func() => funcRan = true;
        btp.Enqueue(Func);
        await Task.Delay(100);
        Assert.True(funcRan);
        btp.Cancel();
    }

    [Fact]
    public async Task Enqueue_Async_Action_Enqueues_And_Executes_The_Action()
    {
        using var btp = new BlockingTaskProcessor();
        var actionRan = false;

        Task Action()
        {
            actionRan = true;
            return Task.CompletedTask;
        }

        btp.Enqueue(Action);
        await Task.Delay(100);
        Assert.True(actionRan);
        btp.Cancel();
    }

    [Fact]
    public async Task Enqueue_Async_Function_Enqueues_And_Executes_The_Function()
    {
        using var btp = new BlockingTaskProcessor();
        var funcRan = false;
        Task<bool> Func() => Task.FromResult(funcRan = true);
        btp.Enqueue(Func);
        await Task.Delay(100);
        Assert.True(funcRan);
        btp.Cancel();
    }

    [Fact]
    public async Task EnqueueAndGetProxy_Action_Enqueues_Returns_A_Proxy_And_Executes_The_Action()
    {
        using var btp = new BlockingTaskProcessor();
        var actionRan = false;

        void Action()
        {
            actionRan = true;
        }

        var t = btp.EnqueueAndGetProxy(Action);
        await Task.Delay(100);
        Assert.True(actionRan);
        Assert.NotNull(t);
        btp.Cancel();
    }

    [Fact]
    public async Task EnqueueAndGetProxy_Function_Enqueues_Returns_A_Proxy_And_Executes_The_Function()
    {
        using var btp = new BlockingTaskProcessor();
        var funcRan = false;
        bool Func() => funcRan = true;
        var t = btp.EnqueueAndGetProxy(Func);
        await Task.Delay(100);
        Assert.True(funcRan);
        Assert.NotNull(t);
        Assert.True(t.Result);
        btp.Cancel();
    }

    [Fact]
    public async Task EnqueueAndGetProxy_Async_Action_Enqueues_Returns_A_Proxy_And_Executes_The_Action()
    {
        using var btp = new BlockingTaskProcessor();
        var actionRan = false;

        Task Action()
        {
            actionRan = true;
            return Task.CompletedTask;
        }

        var t = btp.EnqueueAndGetProxy(Action);
        await Task.Delay(100);
        Assert.True(actionRan);
        Assert.NotNull(t);
        btp.Cancel();
    }

    [Fact]
    public async Task EnqueueAndGetProxy_Async_Function_Enqueues_Returns_A_Proxy_And_Executes_The_Function()
    {
        using var btp = new BlockingTaskProcessor();
        var funcRan = false;
        Task<bool> Func() => Task.FromResult(funcRan = true);
        var t = btp.EnqueueAndGetProxy(Func);
        await Task.Delay(100);
        Assert.True(funcRan);
        Assert.NotNull(t);
        Assert.True(t.Result);
        btp.Cancel();
    }

    [Fact]
    public void Cancel_Can_Be_Called_Twice_In_A_Row_Without_Error()
    {
        using var btp = new BlockingTaskProcessor();
        btp.Cancel();
        btp.Cancel();
    }

    [Fact]
    public void StartProcessing_Can_Be_Called_Multiple_Times_In_A_Row_Without_Error()
    {
        using var btp = new BlockingTaskProcessor(false);
        btp.StartProcessing();
        Thread.Sleep(50);
        btp.StartProcessing();
        Thread.Sleep(50);
        btp.StartProcessing();
        Thread.Sleep(50);
        btp.StartProcessing();
        btp.Cancel();
    }

    [Fact]
    public void Pause_Can_Be_Called_Twice_In_A_Row_Without_Error()
    {
        using var btp = new BlockingTaskProcessor();
        btp.Pause();
        btp.Pause();
        btp.Cancel();
    }

    [Fact]
    public async Task PauseAsync_Can_Be_Called_Twice_In_A_Row_Without_Error()
    {
        using var btp = new BlockingTaskProcessor();
        await btp.PauseAsync();
        await btp.PauseAsync();
        btp.Cancel();
    }

    [Fact]
    public void Resume_Can_Be_Called_Twice_In_A_Row_Without_Error()
    {
        using var btp = new BlockingTaskProcessor();
        btp.Resume();
        btp.Resume();
        btp.Cancel();
    }

    [Fact]
    public async Task ResumeAsync_Can_Be_Called_Twice_In_A_Row_Without_Error()
    {
        using var btp = new BlockingTaskProcessor();
        await btp.ResumeAsync();
        await btp.ResumeAsync();
        btp.Cancel();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(3)]
    public void QueueLength_Returns_The_Expected_Value_And_Has(int tasksToCreate)
    {
        using var btp = new BlockingTaskProcessor(false);
        for (var i = 0; i < tasksToCreate; i++)
        {
            btp.Enqueue(() => { });
        }

        Assert.Equal(tasksToCreate, btp.QueueLength);
        Assert.Equal(tasksToCreate > 0, btp.HasTasks);
        btp.Cancel();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(3)]
    public void Tasks_Externally_Cancelled_Are_Discarded_Without_Error(int tasksToCreate)
    {
        using var btp = new BlockingTaskProcessor(false);
        var cts = new CancellationTokenSource();
        for (var i = 0; i < tasksToCreate; i++)
        {
            btp.TryEnqueueTask(UnstartedTask.Create(() => { }, cts.Token), out _);
        }

        btp.StartProcessing();
        cts.Cancel();
        while (btp.HasTasks)
        {
        }

        btp.Cancel();
    }

    [Fact]
    public void TryEnqueueTask_Called_With_Null_Task_Throws_ArgumentNullException()
    {
        using var btp = new BlockingTaskProcessor();
        Task? t1 = null;
        Task<bool>? t2 = null;
        Assert.ThrowsAsync<ArgumentNullException>(() => btp.TryEnqueueTask(t1, out _));
        Assert.ThrowsAsync<ArgumentNullException>(() => btp.TryEnqueueTask(t2, out _));
    }

    [Fact]
    public void TryEnqueueTask_Called_With_Running_Task_Returns_The_Task_Without_Enqueuing()
    {
        var btp = new BlockingTaskProcessor(false);
        var t1 = Task.Run(() => Thread.Sleep(100));
        var t2 = Task.Run(() =>
        {
            Thread.Sleep(100);
            return true;
        });
        var rt1 = btp.TryEnqueueTask(t1, out _);
        Assert.Same(t1, rt1);
        Assert.Equal(0, btp.QueueLength);
        var rt2 = btp.TryEnqueueTask(t2, out _);
        Assert.Same(t2, rt2);
        Assert.Equal(0, btp.QueueLength);
    }

    [Fact]
    public void TryEnqueueTask_Called_With_Unstarted_Task_Returns_The_Task_After_Enqueuing()
    {
        var btp = new BlockingTaskProcessor(false);
        var t1 = UnstartedTask.Create(() => Thread.Sleep(100));
        var t2 = UnstartedTask.Create(() =>
        {
            Thread.Sleep(100);
            return true;
        });
        var rt1 = btp.TryEnqueueTask(t1, out _);
        Assert.Same(t1, rt1);
        Assert.Equal(1, btp.QueueLength);
        var rt2 = btp.TryEnqueueTask(t2, out _);
        Assert.Same(t2, rt2);
        Assert.Equal(2, btp.QueueLength);
    }
}