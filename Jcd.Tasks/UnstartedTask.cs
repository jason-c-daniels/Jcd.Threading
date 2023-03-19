using System;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.DelegateAllocation

namespace Jcd.Tasks;

/// <summary>
/// A Task factory that wraps the constructor with a tiny bit of logic, simplifying the process
/// of directly creating unstarted <see cref="Task"/>s.
/// </summary>
public static class UnstartedTask
{
    /// <summary>
    /// Creates an unstarted <see cref="Task"/> as a proxy for an action. Once started the task will execute the action.
    /// </summary>
    /// <param name="action">The work to execute.</param>
    /// <param name="cancellationToken">The optional cancellation token for the task. The default is <see langword="null"/>.</param>
    /// <param name="options">Task <see cref="TaskCreationOptions"/> for the task. The default is <see cref="TaskCreationOptions.RunContinuationsAsynchronously"/></param>
    /// <returns>An unstarted <see cref="Task"/> proxy for the action.</returns>
    public static Task Create(Action action, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
    {
        var task = cancellationToken.HasValue
            ? new Task(action, cancellationToken.Value, options)
            : new Task(action, options);
        return task;
    }

    /// <summary>
    /// Creates an unstarted <see cref="Task"/> as a proxy for an asynchronous action. Once started the task will execute the action. 
    /// </summary>
    /// <param name="action"></param>
    /// <param name="cancellationToken">The optional cancellation token for the task. The default is <see langword="null"/>.</param>
    /// <param name="options">Task <see cref="TaskCreationOptions"/> for the task. The default is <see cref="TaskCreationOptions.RunContinuationsAsynchronously"/></param>
    /// <returns>An unstarted <see cref="Task"/> proxy for the asynchronous action.</returns>
    public static Task Create(Func<Task> action, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
    {
        var task = cancellationToken.HasValue
            ? new Task(()=>action().Wait(), cancellationToken.Value, options)
            : new Task(()=>action().Wait(), options);
        return task;
    }

    /// <summary>
    /// Creates an unstarted <see cref="Task{TResult}"/> as a proxy for a function. Once started the task will execute the function.
    /// </summary>
    /// <param name="function">The function to execute.</param>
    /// <param name="cancellationToken">The optional cancellation token for the task. The default is <see langword="null"/>.</param>
    /// <param name="options">Task <see cref="TaskCreationOptions"/> for the task. The default is <see cref="TaskCreationOptions.RunContinuationsAsynchronously"/></param>
    /// <returns>An unstarted <see cref="Task{TResult}"/> proxy for the function.</returns>
    /// <typeparam name="TResult">The type of the data returned.</typeparam>
    public static Task<TResult> Create<TResult>(Func<TResult> function, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
    {
        var task = cancellationToken.HasValue
            ? new Task<TResult>(function, cancellationToken.Value, options)
            : new Task<TResult>(function, options);
        return task;
    }

    /// <summary>
    /// Creates an unstarted <see cref="Task{TResult}"/> as a proxy for an asynchronous function. Once started the task will execute the function.
    /// </summary>
    /// <param name="function"></param>
    /// <param name="cancellationToken">The optional cancellation token for the task. The default is <see langword="null"/>.</param>
    /// <param name="options">Task <see cref="TaskCreationOptions"/> for the task. The default is <see cref="TaskCreationOptions.RunContinuationsAsynchronously"/></param>
    /// <returns>An unstarted <see cref="Task{TResult}"/> proxy for the asynchronous function.</returns>
    /// <typeparam name="TResult">The type of the data returned.</typeparam>
    public static Task<TResult> Create<TResult>(Func<Task<TResult>> function, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
    {
        var task = cancellationToken.HasValue
            ? new Task<TResult>(()=>function().Result, cancellationToken.Value, options)
            : new Task<TResult>(()=>function().Result, options);

        
        
        return task;
    }
}