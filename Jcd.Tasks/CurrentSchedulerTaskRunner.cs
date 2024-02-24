using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A TaskRunner that schedules tasks on the current <see cref="TaskScheduler"/> or
/// a user provided <see cref="TaskScheduler"/>.
/// </summary>
public static class CurrentSchedulerTaskRunner
{
   /// <summary>
   /// The current <see cref="TaskScheduler"/>
   /// </summary>
   public static TaskScheduler Scheduler => TaskScheduler.Current;

   /// <summary>
   /// Runs an action on the current or provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="action">the action to run</param>
   /// <param name="scheduler">The scheduler to use, pass null to use the the current one. </param>
   /// <returns></returns>
   public static async Task Run(Action action, TaskScheduler scheduler = null)
   {
      await (scheduler ?? Scheduler).Run(action);
   }

   public static async Task Run(Action action, CancellationToken cancellationToken, TaskScheduler scheduler = null)
   {
      await (scheduler ?? Scheduler).Run(action, cancellationToken);
   }

   public static async Task Run(Func<Task?> function, TaskScheduler scheduler = null)
   {
      await (scheduler ?? Scheduler).Run(function);
   }

   public static async Task Run(
      Func<Task?>       function
    , CancellationToken cancellationToken
    , TaskScheduler     scheduler = null
   )
   {
      await (scheduler ?? Scheduler).Run(function, cancellationToken);
   }

   public static async Task<TResult> Run<TResult>(Func<TResult> function, TaskScheduler scheduler = null)
   {
      return await (scheduler ?? Scheduler).Run(function);
   }

   public static async Task<TResult> Run<TResult>(
      Func<TResult>     function
    , CancellationToken cancellationToken
    , TaskScheduler     scheduler = null
   )
   {
      return await (scheduler ?? Scheduler).Run(function, cancellationToken);
   }

   public static async Task<TResult> Run<TResult>(Func<Task<TResult>?> function, TaskScheduler scheduler = null)
   {
      return await (scheduler ?? Scheduler).Run(function);
   }

   public static async Task<TResult> Run<TResult>(
      Func<Task<TResult>?> function
    , CancellationToken    cancellationToken
    , TaskScheduler        scheduler = null
   )
   {
      return await (scheduler ?? Scheduler).Run(function, cancellationToken);
   }
}