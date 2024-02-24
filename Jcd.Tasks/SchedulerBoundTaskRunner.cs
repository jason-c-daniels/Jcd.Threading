using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A TaskScheduler bound task runner. It ensures all tasks it creates are registered with either its own,
/// or a user provided TaskScheduler.
/// </summary>
public static class SchedulerBoundTaskRunner<TScheduler>
   where TScheduler : TaskScheduler, new()
{
   public static TScheduler Scheduler { get; } = new();

   /// <summary>
   /// 
   /// </summary>
   /// <param name="action"></param>
   /// <param name="scheduler"></param>
   /// <returns></returns>
   public static async Task Run(Action action, TaskScheduler scheduler = null) =>
      await CurrentSchedulerTaskRunner.Run(action, scheduler ?? Scheduler);

   public static async Task Run(Action action, CancellationToken cancellationToken, TaskScheduler scheduler = null) =>
      await CurrentSchedulerTaskRunner.Run(action, cancellationToken, scheduler ?? Scheduler);

   public static async Task Run(Func<Task?> function, TaskScheduler scheduler = null) =>
      await await CurrentSchedulerTaskRunner.Run(function, CancellationToken.None, scheduler ?? Scheduler);

   public static async Task Run(Func<Task?> function, CancellationToken cancellationToken) =>
      await await CurrentSchedulerTaskRunner.Run(function, cancellationToken, Scheduler);

   public static async Task<TResult> Run<TResult>(Func<TResult> function, TaskScheduler scheduler = null) =>
      await CurrentSchedulerTaskRunner.Run(function, CancellationToken.None, scheduler ?? Scheduler);

   public static async Task<TResult> Run<TResult>(
      Func<TResult>     function
    , CancellationToken cancellationToken
    , TaskScheduler     scheduler = null
   ) =>
      await CurrentSchedulerTaskRunner.Run(function, cancellationToken, scheduler ?? Scheduler);

   public static async Task<TResult> Run<TResult>(Func<Task<TResult>?> function, TaskScheduler scheduler = null) =>
      await Run(function, CancellationToken.None, scheduler ?? Scheduler);

   public static async Task<TResult> Run<TResult>(
      Func<Task<TResult>?> function
    , CancellationToken    cancellationToken
    , TaskScheduler        scheduler = null
   ) =>
      await CurrentSchedulerTaskRunner.Run(function, cancellationToken, scheduler ?? Scheduler);
}
