using System;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable OutParameterValueIsAlwaysDiscarded.Global

namespace Jcd.Tasks;

/// <summary>
/// A set of helpers for <see cref="Task"/> objects.
/// </summary>
public static class TaskExtensions
{
    /// <summary>
    /// Checks if a task is unstarted and startable. (Status==Created)
    /// </summary>
    /// <param name="task">the task to inspect</param>
    /// <returns>True if unstarted. False otherwise.</returns>
    public static bool IsUnstarted(this Task task) =>
        task.Status == TaskStatus.Created;

    /// <summary>
    /// Calls <see cref="TryStart"/> on a task then returns the task, discarding exceptions.
    /// </summary>
    /// <param name="task">the task to start</param>
    /// <returns>the original task</returns>
    /// <remarks>
    /// While this returns the original task, it doesn't guarantee it's awaitable. Only call
    /// this method if you've got 100% control over the lifecycle of the task. Otherwise call
    /// <see cref="TryStart"/> instead and inspect the results before calling await.
    /// </remarks>
    public static Task Run(this Task task)
    {
        task.TryStart(out _);
        return task;
    }

    /// <summary>
    /// Calls <see cref="TryStart"/> on a task then returns the task, discarding exceptions.
    /// </summary>
    /// <param name="task">the task to start</param>
    /// <param name="taskScheduler">
    /// The <see cref="TaskScheduler"/> to use for executing the task. If not provided the
    /// current <see cref="TaskScheduler"/> is used.
    /// </param>
    /// <typeparam name="TResult">The type of data returned from the task.</typeparam>
    /// <returns>the original task</returns>
    /// <remarks>
    /// While this returns the original task, it doesn't guarantee it's awaitable. Only call
    /// this method if you've got 100% control over the lifecycle of the task. Otherwise call
    /// <see cref="TryStart"/> instead and inspect the results before calling await.
    /// </remarks>
    public static Task<TResult> Run<TResult>(this Task<TResult> task, TaskScheduler taskScheduler=null)
    {
        task.TryStart(out _, taskScheduler);
        return task;
    }

    /// <summary>
    /// Tries to successfully call start. 
    /// </summary>
    /// <param name="task">The task to call Start on.</param>
    /// <param name="taskScheduler">
    /// The <see cref="TaskScheduler"/> to use for executing the task. If not provided the
    /// current <see cref="TaskScheduler"/> is used.
    /// </param>
    /// <param name="exception">The exception resulting from calling Start.</param>
    /// <returns>
    /// <see cref="TryStartResult.SuccessfullyStarted"/> when the Start was called and no exception occurred.
    /// <see cref="TryStartResult.AlreadyStarted"/> When the task was already in a started state. Start was not called.
    /// <see cref="TryStartResult.ErrorDuringStart"/> When start was called and an exception occurred during the call to start. Check the exception parameter for details.
    /// </returns>
    public static TryStartResult TryStart(this Task task, out Exception exception, TaskScheduler taskScheduler=null)
    {
        exception = null;
        if (!task.IsUnstarted()) return TryStartResult.AlreadyStarted;
        try
        {
            if (taskScheduler == null)
                task.Start();
            else
                task.Start(taskScheduler);
            
            return TryStartResult.SuccessfullyStarted;
        }
        catch (Exception ex)
        {
            exception = ex;
            return TryStartResult.ErrorDuringStart;
        }
    }

    #region TryWait Overloads

    /// <summary>
    /// Waits on a running task until it completes, is cancelled, faults or times out.
    /// </summary>
    /// <param name="task">the task to wait on.</param>
    /// <param name="cancellationToken">An optional cancellation token.</param>
    /// <returns><see langword="true"/> if it ran to completion. <see langword="false"/> otherwise.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the task is unstarted.</exception>
    public static bool TryWait(this Task task,
                               CancellationToken cancellationToken)
    {
        return TryWait(task, null, cancellationToken);
    }

    /// <summary>
    /// Waits on a running task until it completes, is cancelled, faults or times out.
    /// </summary>
    /// <param name="task">the task to wait on.</param>
    /// <param name="timeout">the amount of time to wait. Must be a value between -1 (infinite) and  <see cref="int.MaxValue"/></param>
    /// <param name="cancellationToken">An optional cancellation token.</param>
    /// <returns><see langword="true"/> if ran to completion. <see langword="false"/> otherwise.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the task is unstarted.</exception>
    public static bool TryWait(this Task task,
                               TimeSpan timeout,
                               CancellationToken? cancellationToken = null)
    {
        if (timeout.TotalMilliseconds > int.MaxValue)
            throw new ArgumentOutOfRangeException(nameof(timeout),
                $"The value must be between -1 ms (infinite) and {int.MaxValue:n} ms");
        var millisecondsTimeout = (int)timeout.TotalMilliseconds;

        return TryWait(task, millisecondsTimeout, cancellationToken);
    }

    /// <summary>
    /// Waits on a running task until it completes, is cancelled, faults or times out.
    /// This extension method swallows exceptions. The exception should be available on
    /// the Task.Exception property
    /// </summary>
    /// <param name="task">the task to wait on.</param>
    /// <param name="millisecondsTimeout">the amount of time to wait. Must be a value between -1 (infinite) and  <see cref="int.MaxValue"/></param>
    /// <param name="cancellationToken">An optional cancellation token.</param>
    /// <returns><see langword="true"/> if ran to completion. <see langword="false"/> otherwise.</returns>
    public static bool TryWait(this Task task,
                               int? millisecondsTimeout = null,
                               CancellationToken? cancellationToken = null)
    {
        if (millisecondsTimeout is < -1)
            throw new ArgumentOutOfRangeException(nameof(millisecondsTimeout),
                $"The value must be between -1 (infinite) and {int.MaxValue}");

        try
        {
            if (!task.IsCompleted) PerformWait(task, millisecondsTimeout, cancellationToken);
        }
        catch (Exception)
        {
            // do nothing. task.Status has the answer, and task.Exception has the root level
            // exception for faulted tasks.
        }

        return task.Status == TaskStatus.RanToCompletion;
    }

    #endregion
    
    private static void PerformWait(Task task, int? millisecondsTimeout, CancellationToken? cancellationToken)
    {
        if (millisecondsTimeout.HasValue && cancellationToken.HasValue)
            task.Wait(millisecondsTimeout.Value, cancellationToken.Value);
        else if (millisecondsTimeout.HasValue)
            task.Wait(millisecondsTimeout.Value);
        else if (cancellationToken.HasValue)
            task.Wait(cancellationToken.Value);
        else
            task.Wait();
    }
}