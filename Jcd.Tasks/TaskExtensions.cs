using System;
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
    /// Tries to await a task regardless of status. 
    /// </summary>
    /// <param name="task">The task to try awaiting.</param>
    /// <returns>true if awaited without exception. false otherwise.</returns>
    public static async Task<bool> TryWaitAsync(this Task task)
    {
        try
        {
            if (!task.IsCompleted) await task;
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Tries to await a task regardless of status. 
    /// </summary>
    /// <param name="task">The task to try awaiting.</param>
    /// <returns>true if awaited without exception. false otherwise.</returns>
    public static bool TryWait(this Task task)
    {
        try
        {
            if (!task.IsCompleted) task.Wait();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Calls <see cref="TryStart"/> on a task then returns the task, discarding exceptions.
    /// </summary>
    /// <param name="task">the task to start</param>
    /// <returns>the original task</returns>
    public static Task StartEx(this Task task)
    {
        task.TryStart(out _);
        return task;
    }

    /// <summary>
    /// Tries to successfully call start. 
    /// </summary>
    /// <param name="task">The </param>
    /// <param name="exception"></param>
    /// <returns>
    /// <see cref="TryStartResult.SuccessfullyCalled"/> when the Start was called and no exception occurred.
    /// <see cref="TryStartResult.AlreadyStarted"/> When the task was already in a started state. Start was not called.
    /// <see cref="TryStartResult.ErrorDuringStart"/> When start was called and an exception occurred during the call to start. Check the exception parameter for details.
    /// </returns>
    public static TryStartResult TryStart(this Task task, out Exception exception)
    {
        exception = null;
        if (!task.IsUnstarted()) return TryStartResult.AlreadyStarted;
        try
        {
            task.Start();
            return TryStartResult.SuccessfullyCalled;
        }
        catch(Exception ex)
        {
            exception = ex;
            return TryStartResult.ErrorDuringStart;
        }
    }
}