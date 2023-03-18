using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A Task factory that wraps the constructor with a tiny bit of logic, simplifying the process
/// of directly creating unstarted <see cref="Task"/>s.
/// </summary>
public static class ColdTask
{
    /// <summary>
    /// Creates an unstarted <see cref="Task"/> from an action. Once started the task will execute the action. 
    /// </summary>
    /// <param name="action"></param>
    /// <param name="cancellationToken">The optional cancellation token for the task. The default is null/not provided.</param>
    /// <param name="options">Task <see cref="TaskCreationOptions"/> for the task. The default is <see cref="TaskCreationOptions.RunContinuationsAsynchronously"/></param>
    /// <returns>The created task.</returns>
    public static Task FromAction(Action action, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
    {
        var task = cancellationToken.HasValue
            ? new Task(action, cancellationToken.Value, options)
            : new Task(action, options);
        return task;
    }
        
    /// <summary>
    /// Creates an unstarted <see cref="Task{TResult}"/> from a function. Once started the task will execute the function.
    /// </summary>
    /// <param name="function">The function to execute.</param>
    /// <param name="cancellationToken">The optional cancellation token for the task. The default is null/not provided.</param>
    /// <param name="options">Task <see cref="TaskCreationOptions"/> for the task. The default is <see cref="TaskCreationOptions.RunContinuationsAsynchronously"/></param>
    /// <returns>The created task.</returns>
    /// <typeparam name="TResult">The type of the data returned.</typeparam>
    public static Task<TResult> FromFunc<TResult>(Func<TResult> function, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
    {
        var task = cancellationToken.HasValue
            ? new Task<TResult>(function, cancellationToken.Value, options)
            : new Task<TResult>(function, options);
        return task;
    }
        
    /// <summary>
    /// Creates an unstarted <see cref="Task"/> from an async action. Once started the task will execute the action. 
    /// </summary>
    /// <param name="action"></param>
    /// <param name="cancellationToken">The optional cancellation token for the task. The default is null/not provided.</param>
    /// <param name="options">Task <see cref="TaskCreationOptions"/> for the task. The default is <see cref="TaskCreationOptions.RunContinuationsAsynchronously"/></param>
    /// <returns>The created task.</returns>
    public static Task FromAsyncAction(Func<Task> action, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
    {
        var task = cancellationToken.HasValue
            ? new Task(()=>action().Wait(), cancellationToken.Value, options)
            : new Task(()=>action().Wait(), options);
        return task;
    }
    
    /// <summary>
    /// Creates an unstarted <see cref="Task{TResult}"/> from an asynchronous function. Once started the task will execute the function.
    /// </summary>
    /// <param name="function"></param>
    /// <param name="cancellationToken">The optional cancellation token for the task. The default is null/not provided.</param>
    /// <param name="options">Task <see cref="TaskCreationOptions"/> for the task. The default is <see cref="TaskCreationOptions.RunContinuationsAsynchronously"/></param>
    /// <returns>The created task.</returns>
    /// <typeparam name="TResult">The type of the data returned.</typeparam>
    public static Task<TResult> FromAsyncFunc<TResult>(Func<Task<TResult>> function, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
    {
        var task = cancellationToken.HasValue
            ? new Task<TResult>(()=>function().Result, cancellationToken.Value, options)
            : new Task<TResult>(()=>function().Result, options);

        return task;
    }

    /// <summary>
    /// Returns true if the task status indicates execution hasn't begun. (Status==Created)
    /// </summary>
    /// <param name="task">the task to inspect</param>
    /// <returns>True if unstarted. False otherwise.</returns>
    public static bool IsCold(this Task task) =>
        task.Status == TaskStatus.Created;
    
    /// <summary>
    /// Starts an unstarted task then returns the task. If the task isn't cold it isn't started, it's still returned.
    /// </summary>
    /// <param name="task">the task</param>
    /// <returns>the task</returns>
    public static Task StartEx(this Task task) 
    {
        if (!task.IsCold()) return task;
        try { task.Start(); } catch {/* Clearly it was started by another thread right after we checked the value. just carry on.*/}
        return task;
    }

    public static async Task<bool> TryWaitAsync(this Task task)
    {
        try
        {
            await task;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool TryWait(this Task task)
    {
        try
        {
            task.Wait();
            return true;
        }
        catch
        {
            return false;
        }
    }
}