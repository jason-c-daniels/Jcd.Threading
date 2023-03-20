// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ClosureAllocation

namespace Jcd.Tasks.Tests;

public class UnstartedTaskTests
{
    [Theory]
    [InlineData(TaskCreationOptions.None)]
    [InlineData(TaskCreationOptions.HideScheduler)]
    [InlineData(TaskCreationOptions.LongRunning)]
    [InlineData(TaskCreationOptions.DenyChildAttach)]
    [InlineData(TaskCreationOptions.PreferFairness)]
    [InlineData(TaskCreationOptions.AttachedToParent)]
    [InlineData(TaskCreationOptions.RunContinuationsAsynchronously)]
    public async Task
        Create_Called_With_Action_And_Options_Creates_A_Task_Which_Executes_The_Provided_Action_When_Start_Is_Called(
            TaskCreationOptions options)
    {
        var actionWasCalled = false;

        void LocalAction()
        {
            actionWasCalled = true;
        }

        var task = UnstartedTask.Create(LocalAction, null, options);
        Assert.Equal(options, task.CreationOptions);
        // now run then await the action.
        await task.Run();
        Assert.True(actionWasCalled);
    }

    [Theory]
    [InlineData(TaskCreationOptions.None, true)]
    [InlineData(TaskCreationOptions.HideScheduler, false)]
    [InlineData(TaskCreationOptions.LongRunning, true)]
    [InlineData(TaskCreationOptions.DenyChildAttach, false)]
    [InlineData(TaskCreationOptions.PreferFairness, true)]
    [InlineData(TaskCreationOptions.AttachedToParent, false)]
    [InlineData(TaskCreationOptions.RunContinuationsAsynchronously, true)]
    public async Task
        Create_Called_With_Func_And_Options_Creates_A_Task_Which_Executes_The_Provided_Action_When_Start_Is_Called(
            TaskCreationOptions options, bool funcInput)
    {
        bool Invert(bool x) => !x;
        var expectedResult = Invert(funcInput);
        var task = UnstartedTask.Create(() => Invert(funcInput), null, options);
        Assert.Equal(options, task.CreationOptions);
        // now run then await the action.
        var result = await task.Run();
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(TaskCreationOptions.None)]
    [InlineData(TaskCreationOptions.HideScheduler)]
    [InlineData(TaskCreationOptions.LongRunning)]
    [InlineData(TaskCreationOptions.DenyChildAttach)]
    [InlineData(TaskCreationOptions.PreferFairness)]
    [InlineData(TaskCreationOptions.AttachedToParent)]
    [InlineData(TaskCreationOptions.RunContinuationsAsynchronously)]
    public async Task
        Create_Called_With_Async_Action_And_Options_Creates_A_Task_Which_Executes_The_Provided_Action_When_Start_Is_Called(
            TaskCreationOptions options)
    {
        var actionWasCalled = false;

        Task LocalAsyncAction()
        {
            actionWasCalled = true;
            return Task.CompletedTask;
        }

        var task = UnstartedTask.Create((Func<Task>)LocalAsyncAction, null, options);
        Assert.Equal(options, task.CreationOptions);
        // now run then await the action.
        await task.Run();
        Assert.True(actionWasCalled);
    }

    [Theory]
    [InlineData(TaskCreationOptions.None, true)]
    [InlineData(TaskCreationOptions.HideScheduler, false)]
    [InlineData(TaskCreationOptions.LongRunning, true)]
    [InlineData(TaskCreationOptions.DenyChildAttach, false)]
    [InlineData(TaskCreationOptions.PreferFairness, true)]
    [InlineData(TaskCreationOptions.AttachedToParent, false)]
    [InlineData(TaskCreationOptions.RunContinuationsAsynchronously, true)]
    public async Task
        Create_Called_With_Async_Func_And_Options_Creates_A_Task_Which_Executes_The_Provided_Action_When_Start_Is_Called(
            TaskCreationOptions options, bool funcInput)
    {
        Task<bool> Invert(bool x) => Task.FromResult(!x);
        var expectedResult = await Invert(funcInput);
        var task = UnstartedTask.Create(() => Invert(funcInput), null, options);
        Assert.Equal(options, task.CreationOptions);
        // now run then await the action.
        var result = await task.Run();
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Create_Called_With_Action_And_CancellationToken_Which_Gets_Canceled_Task_Then_Has_Status_Of_Canceled()
    {
        void LocalAction()
        {
        }

        var cts = new CancellationTokenSource();
        var task = UnstartedTask.Create(LocalAction, cts.Token);
        cts.Cancel();
        Assert.Equal(TaskStatus.Canceled, task.Status);
    }

    [Fact]
    public void
        Create_Called_With_An_Async_Action_And_CancellationToken_Which_Gets_Canceled_Task_Then_Has_Status_Of_Canceled()
    {
        Task LocalAction()
        {
            return Task.CompletedTask;
        }

        var cts = new CancellationTokenSource();
        var task = UnstartedTask.Create(LocalAction, cts.Token);
        cts.Cancel();
        Assert.Equal(TaskStatus.Canceled, task.Status);
    }

    [Fact]
    public void Create_Called_With_A_Func_And_CancellationToken_Which_Gets_Canceled_Task_Then_Has_Status_Of_Canceled()
    {
        bool Invert(bool x) => !x;
        var cts = new CancellationTokenSource();
        var task = UnstartedTask.Create(() => Invert(true), cts.Token);
        cts.Cancel();
        Assert.Equal(TaskStatus.Canceled, task.Status);
    }

    [Fact]
    public void
        Create_Called_With_An_Async_Func_And_CancellationToken_Which_Gets_Canceled_Task_Then_Has_Status_Of_Canceled()
    {
        Task<bool> Invert(bool x) => Task.FromResult(!x);
        var cts = new CancellationTokenSource();
        var task = UnstartedTask.Create(() => Invert(true), cts.Token);
        cts.Cancel();
        Assert.Equal(TaskStatus.Canceled, task.Status);
    }
}