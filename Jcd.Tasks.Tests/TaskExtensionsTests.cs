// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation

namespace Jcd.Tasks.Tests;

public class TaskExtensionsTests
{
    #region IsUnstarted Tests

    [Fact]
    public void IsUnstarted_Returns_True_For_A_Task_With_Status_Of_Created()
    {
        var t1 = new Task(() => { }); // tasks created directly from the constructor have a Status of Unstarted
        Assert.True(t1.IsUnstarted());
    }
    
    [Fact]
    public void IsUnstarted_Returns_False_For_A_Task_With_Status_Of_Canceled()
    {
        using var cts = new CancellationTokenSource();
        var t1 = new Task(() => { },cts.Token); // tasks created directly from the constructor have a Status of Unstarted
        cts.Cancel();
        Assert.False(t1.IsUnstarted());
    }

    [Fact]
    public void IsUnstarted_Returns_False_For_A_Task_With_Status_Of_Faulted()
    {
        using var cts = new CancellationTokenSource();
        var t1 = new Task(() => throw new Exception("fake fault"),cts.Token); // tasks created directly from the constructor have a Status of Unstarted
        t1.TryRun(out _);
        Assert.False(t1.IsUnstarted());
    }
    
    [Fact]
    public async Task IsUnstarted_Returns_False_For_A_Task_With_Status_Of_Running()
    {
        using var cts = new CancellationTokenSource();
        // ReSharper disable once AccessToDisposedClosure
        async void Action() => await Task.Delay(1000, cts.Token);

        var t1 = new Task(Action,cts.Token); 
        t1.TryRun(out _);
        await Task.Delay(2, cts.Token);
        Assert.False(t1.IsUnstarted());
        cts.Cancel();
    }

    [Fact]
    public async Task IsUnstarted_Returns_False_For_A_Task_With_Status_Of_RanToCompletion()
    {
        var t1 = new Task(() => { });
        await t1.Run();
        Assert.False(t1.IsUnstarted());
    }
    
    [Fact]
    public async Task IsUnstarted_Returns_False_For_A_Task_Created_By_Task_Run()
    {
        var t1 = Task.Run(async () => await Task.Delay(2));
        while (t1.Status == TaskStatus.Created)
        {
            // wait for the status to transition to one of the 
            // internal task management states.
            await Task.Yield();
        }

        Assert.False(t1.IsUnstarted());
    }
    
    #endregion
    
    #region Run and TryRun Tests

    [Fact]
    public void Run_Task_Returns_Passed_In_Task()
    {
        void Action() {}
        var t = UnstartedTask.Create(Action);
        Assert.Same(t,t.Run());
    }

    [Fact]
    public void Run_Task_Of_TResult_Returns_Passed_In_Task()
    {
        bool Action() => false;
        var t = UnstartedTask.Create(Action);
        Assert.Same(t,t.Run());
    }

    [Fact]
    public void TryRun_Returns_SuccessfullyCalled_When_Task_Is_Unstarted_And_The_Task_Doesnt_Immediately_Fault()
    {
        void Action() {}
        var t = UnstartedTask.Create(Action);
        Assert.Equal(TryRunResult.SuccessfullyCalled,t.TryRun(out _));
    }
    
    [Fact]
    public void TryRun_Returns_AlreadyStarted_When_Task_Is_Not_Unstarted()
    {
        void Action() {}
        var t = Task.Run(Action);
        Assert.Equal(TryRunResult.AlreadyStarted,t.TryRun(out _));
    }
    
    /* I can't seem to make this happen in a UT. But there is code for this case as I think I've encountered it in the wild.
    [Fact]
    public void TryRun_Returns_ErrorDuringStart_When_Task_IsCanceled_During_Call_To_Start()
    {
        void Action() => throw new Exception();
        var t = UnstartedTask.Create(Action);
        Assert.Equal(TryRunResult.ErrorDuringStart,t.TryRun(out _));
    }
    */
    
    #endregion

    #region TryWait and TryWaitAsync Tests

    [Fact]
    public void TryWait_Waits_On_A_Running_Task_Until_It_Completes_And_Returns_True()
    {
        var t = Task.Run(async () => await Task.Delay(2));
        Assert.True(t.TryWait());
    }

    [Fact]
    public void TryWait_Waits_On_A_Completed_Task_Returns_True()
    {
        var t = Task.Run(() => { });
        while (!t.IsCompleted){ /* wait for the status to change.*/ }
        Assert.True(t.TryWait());
    }

    [Fact]
    public async Task TryWaitAsync_Waits_On_A_Running_Task_Until_It_Completes_And_Returns_True()
    {
        var t = Task.Run(async () => await Task.Delay(2));
        Assert.True(await t.TryWaitAsync());
    }

    [Fact]
    public async Task TryWaitAsync_Waits_On_A_Completed_Task_Returns_True()
    {
        var t = Task.Run(() => { });
        while (!t.IsCompleted){ /* wait for the status to change.*/ }
        Assert.True(await t.TryWaitAsync());
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void TryWait_Waits_On_A_Task_That_Faults_Returns_False(bool cancel)
    {
        var t = Task.Run(async () =>
        {
            await Task.Delay(2);
            if (cancel) throw new OperationCanceledException();
            throw new Exception();
        });
        Assert.False(t.TryWait());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TryWaitAsync_Waits_On_A_Task_That_Faults_Returns_False(bool cancel)
    {
        var t = Task.Run(async () =>
        {
            await Task.Delay(2);
            if (cancel) throw new OperationCanceledException();
            throw new Exception();
        });
        Assert.False(await t.TryWaitAsync());
    }


    #endregion
    
}