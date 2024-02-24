using System;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable UnusedMember.Global
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable MemberCanBePrivate.Global

namespace Jcd.Tasks;

/// <summary>
/// A <see cref="TaskScheduler"/> bound task runner. It ensures all tasks it creates are registered
/// with either its own, or a user provided <see cref="TaskScheduler"/>.
/// </summary>
public static class SchedulerBoundTaskRunner<TScheduler>
   where TScheduler : TaskScheduler, new()
{
   /// <summary>
   /// The <see cref="TaskScheduler"/> used to schedule and execute tasks.
   /// </summary>
   public static TScheduler Scheduler { get; } = new();

   /// <summary>
   /// 
   /// </summary>
   /// <param name="action"></param>
   /// <param name="scheduler"></param>
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