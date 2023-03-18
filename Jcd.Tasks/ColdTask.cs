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
    /// <param name="options">Task <see cref="TaskCreationOptions"/> for the task. The default is <see cref="TaskCreationOptions.None"/></param>
    /// <returns>The created task.</returns>
    public static Task From(Action action, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.None)
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
    public static Task<TResult> From<TResult>(Func<TResult> function, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
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
    public static Task FromAsync(Func<Task> action, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
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
    public static Task<TResult> FromAsync<TResult>(Func<Task<TResult>> function, CancellationToken? cancellationToken=null, TaskCreationOptions options=TaskCreationOptions.RunContinuationsAsynchronously)
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
    /// Starts an unstarted (cold) task and waits for its completion. This does nothing if the task was already started.
    /// </summary>
    /// <param name="task">the task.</param>
    /// <param name="cancellationToken">The optional <see cref="CancellationToken"/> to use.</param>
    /// <remarks>WARNING: This method potentially calls Task.Wait(). Be sure you understand the risks before using it.</remarks>
    public static void StartThenWait(this Task task, CancellationToken? cancellationToken=null)
    {
        if (!task.IsCold())
        {
            return;
        }
        task.Start();
        if (cancellationToken.HasValue && !task.IsCompleted)
        {
            task.Wait(cancellationToken.Value);
        }
        else if (!task.IsCompleted)
        {
            task.Wait();
        }
    }

    /// <summary>
    /// Starts an unstarted (cold) task and waits for its completion. This does nothing if the task was already started.
    /// </summary>
    /// <param name="task">the task.</param>
    /// <param name="cancellationToken">The optional <see cref="CancellationToken"/> to use.</param>
    /// <remarks>WARNING: This method potentially calls Task.Wait(). Be sure you understand the risks before using it.</remarks>
    public static TResult StartThenWaitForResult<TResult>(this Task<TResult> task, CancellationToken? cancellationToken=null)
    {
        if (!task.IsCold()) return task.Result;
        task.Start();
        if (!cancellationToken.HasValue || task.IsCompleted) return task.Result;
        task.Wait(cancellationToken.Value);
        return task.Result;
    }

    /// <summary>
    /// Starts an unstarted (cold) task and waits for its completion. It does nothing if the task was already started.
    /// </summary>
    /// <param name="task">the task.</param>
    /// <param name="cancellationToken">The optional <see cref="CancellationToken"/> to use.</param>
    /// <remarks>WARNING: This method potentially calls Task.Wait(). Be sure you understand the risks before using it.</remarks>
    public static async Task StartThenWaitAsync(this Task task, CancellationToken? cancellationToken=null)
    {
        if (!task.IsCold())
        {
            return;
        }

        task.Start();
        if (cancellationToken.HasValue && !task.IsCompleted)
        {
            await Task.Run<Task>(()=>
            {
                task.Wait(cancellationToken.Value);
                return Task.CompletedTask;
            });
        }
        else if (!task.IsCompleted)
        {
            await task;
        }
    }
}