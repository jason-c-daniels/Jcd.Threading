// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation

// ReSharper disable HeapView.BoxingAllocation
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
        var t1 = new Task(() => { },
            cts.Token); // tasks created directly from the constructor have a Status of Unstarted
        cts.Cancel();
        Assert.False(t1.IsUnstarted());
    }

    [Fact]
    public void IsUnstarted_Returns_False_For_A_Task_With_Status_Of_Faulted()
    {
        using var cts = new CancellationTokenSource();
        var t1 = new Task(() => throw new Exception("fake fault"),
            cts.Token); // tasks created directly from the constructor have a Status of Unstarted
        t1.TryStart(out _);
        Assert.False(t1.IsUnstarted());
    }

    [Fact]
    public async Task IsUnstarted_Returns_False_For_A_Task_With_Status_Of_Running()
    {
        // ReSharper disable once AccessToDisposedClosure
        async void Action() => await Task.Delay(20);

        var t1 = new Task(Action);
        t1.TryStart(out _);
        await Task.Delay(2);
        Assert.False(t1.IsUnstarted());
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
        var t1 = Task.Run(async () => await Task.Delay(20));
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
        void Action()
        {
        }

        var t = UnstartedTask.Create(Action);
        Assert.Same(t, t.Run());
    }

    [Fact]
    public void Run_Task_Of_TResult_Returns_Passed_In_Task()
    {
        bool Action() => false;
        var t = UnstartedTask.Create(Action);
        Assert.Same(t, t.Run());
    }

    [Fact]
    public void TryRun_Returns_SuccessfullyCalled_When_Task_Is_Unstarted_And_The_Task_Doesnt_Immediately_Fault()
    {
        void Action()
        {
        }

        var t = UnstartedTask.Create(Action);
        Assert.Equal(TryStartResult.SuccessfullyStarted, t.TryStart(out _));
    }

    [Fact]
    public void TryRun_Returns_AlreadyStarted_When_Task_Is_Not_Unstarted()
    {
        void Action()
        {
        }

        var t = Task.Run(Action);
        Assert.Equal(TryStartResult.AlreadyStarted, t.TryStart(out _));
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
        var t = Task.Run(async () => await Task.Delay(20));
        Assert.True(t.TryWait());
    }

    [Fact]
    public void TryWait_Waits_On_A_Completed_Task_Returns_True()
    {
        var t = Task.Run(() => { });
        while (!t.IsCompleted)
        {
            /* wait for the status to change.*/
        }

        Assert.True(t.TryWait());
    }

    [Fact]
    public async Task TryWaitAsync_Waits_On_A_Running_Task_Until_It_Completes_And_Returns_True()
    {
        var t = Task.Run(async () => await Task.Delay(20));
        Assert.True(await t.TryWaitAsync());
    }

    [Fact]
    public async Task TryWaitAsync_Waits_On_A_Completed_Task_Returns_True()
    {
        var t = Task.Run(() => { });
        while (!t.IsCompleted)
        {
            /* wait for the status to change.*/
        }

        Assert.True(await t.TryWaitAsync());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void TryWait_Waits_On_A_Task_That_Faults_Returns_False(bool cancel)
    {
        var t = Task.Run(async () =>
        {
            await Task.Delay(20);
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
            await Task.Delay(20);
            if (cancel) throw new OperationCanceledException();
            throw new Exception();
        });
        Assert.False(await t.TryWaitAsync());
    }

    [Theory]
    [InlineData(-2d)]
    [InlineData(-3d)]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue+1d)]
    public void TryWait_With_Timeout_Timespan_Less_Than_Negative_One_Ms_Or_Greater_Than_MaxInt_Throws(double timeoutInMilliseconds)
    {
        var t = Task.Run(async () => {  await Task.Delay(100); });
        Assert.Throws<ArgumentOutOfRangeException>(()=>t.TryWait(TimeSpan.FromMilliseconds(timeoutInMilliseconds)));
        using var cts = new CancellationTokenSource(30);
        Assert.Throws<ArgumentOutOfRangeException>(()=>t.TryWait(TimeSpan.FromMilliseconds(timeoutInMilliseconds),cts.Token));
    }
    
    [Theory]
    [InlineData(-2)]
    [InlineData(-3)]
    [InlineData(int.MinValue)]
    public void TryWait_With_Timeout_Int_Less_Than_Negative_One_Throws(int timeoutInMilliseconds)
    {
        var t = Task.Run(async () => { await Task.Delay(100); });
        Assert.Throws<ArgumentOutOfRangeException>(()=>t.TryWait(timeoutInMilliseconds));
        using var cts = new CancellationTokenSource(30);
        Assert.Throws<ArgumentOutOfRangeException>(()=>t.TryWait(timeoutInMilliseconds,cts.Token));
    }
    
    [Theory]
    [InlineData(70d)]
    [InlineData(80d)]
    [InlineData(90d)]
    public void TryWait_With_Valid_Timeout_Timespan_Waits_For_Completion(double waitTimeoutInMilliseconds)
    {
        var delayTimeout=TimeSpan.FromMilliseconds(waitTimeoutInMilliseconds);
        var waitTimeout = delayTimeout * 5;
        var t = Task.Run(async () => {  await Task.Delay(delayTimeout); });
        Assert.True(t.TryWait(waitTimeout));
        using var cts = new CancellationTokenSource(delayTimeout*2);
        var token = cts.Token;
        t = Task.Run(async () => { await Task.Delay(delayTimeout, token); }, cts.Token);
        Assert.True(t.TryWait(waitTimeout,cts.Token));
    }
    
    [Theory]
//    [InlineData(70)]
//    [InlineData(80)]
    [InlineData(90)]
    public void TryWait_With_Valid_Timeout_Int_Waits_For_Completion(int waitTimeoutInMilliseconds)
    {
        var delayTimeout=waitTimeoutInMilliseconds;
        var waitTimeout = delayTimeout * 5;

        var t = Task.Run(async () => { await Task.Delay(delayTimeout); });
        Assert.True(t.TryWait(waitTimeout));
        using var cts = new CancellationTokenSource(delayTimeout*2);
        var token = cts.Token;
        t = Task.Run(async () => { await Task.Delay(delayTimeout, token); }, cts.Token);
        var r = t.TryWait(waitTimeout, cts.Token);
        Assert.True(r);
    }

    [Theory]
    [InlineData(50d)]
    [InlineData(60d)]
    [InlineData(70d)]
    public void TryWait_With_Valid_Timeout_Timespan_Times_Out_Returns_False(double waitTimeoutInMilliseconds)
    {
        var waitTimeout = TimeSpan.FromMilliseconds(waitTimeoutInMilliseconds);
        var delayTimeout = waitTimeout * 5;
        var t = Task.Run(async () => {  await Task.Delay(delayTimeout); });
        Assert.False(t.TryWait(waitTimeout));
        using var cts = new CancellationTokenSource(waitTimeout*2);
        var token = cts.Token;
        t = Task.Run(async () => { await Task.Delay(delayTimeout, token); }, cts.Token);
        Assert.False(t.TryWait(waitTimeout,cts.Token));
    }
    
    [Theory]
    [InlineData(50)]
    [InlineData(60)]
    [InlineData(70)]
    public void TryWait_With_Valid_Short_Timeout_Int_Times_Out_Returns_False(int waitTimeoutInMilliseconds)
    {
        var delayTimeout = waitTimeoutInMilliseconds * 5;

        var t = Task.Run(async () => { await Task.Delay(delayTimeout); });
        Assert.False(t.TryWait(waitTimeoutInMilliseconds));
        using var cts = new CancellationTokenSource(waitTimeoutInMilliseconds*2);
        var token = cts.Token;
        t = Task.Run(async () => { await Task.Delay(delayTimeout, token); }, cts.Token);
        Assert.False(t.TryWait(waitTimeoutInMilliseconds,cts.Token));
    }

    #endregion
}