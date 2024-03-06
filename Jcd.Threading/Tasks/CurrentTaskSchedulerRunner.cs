using System;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable MemberCanBePrivate.Global

namespace Jcd.Threading.Tasks;

/// <summary>
/// A static class that schedules tasks on the current <see cref="TaskScheduler"/> or
/// a user provided <see cref="TaskScheduler"/> if null is passed in or none is specified.
/// </summary>
public static class CurrentTaskSchedulerRunner
{
   /// <summary>
   /// The current <see cref="TaskScheduler"/>
   /// </summary>
   public static TaskScheduler Scheduler => TaskScheduler.Current;

   /// <summary>
   /// Schedules work with the current or user provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="action">the action to run</param>
   /// <param name="scheduler">The scheduler to use, pass null to use the the current one. </param>
   /// <returns></returns>
   public static async Task Run(Action action, TaskScheduler? scheduler = null)
   {
      await (scheduler ?? Scheduler).Run(action);
   }

   /// <summary>
   /// Schedules work with the current or user provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="action">the action to execute.</param>
   /// <param name="cancellationToken">the token to check for cancellation.</param>
   /// <param name="scheduler">The optional scheduler to execute the action with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(Action action, CancellationToken cancellationToken, TaskScheduler? scheduler = null)
   {
      await (scheduler ?? Scheduler).Run(action, cancellationToken);
   }

   /// <summary>
   /// Schedules work with the current or user provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="scheduler">The optional scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(Func<Task?> function, TaskScheduler? scheduler = null)
   {
      await (scheduler ?? Scheduler).Run(function);
   }

   /// <summary>
   /// Schedules work with the current or user provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="cancellationToken">the token to check for cancellation.</param>
   /// <param name="scheduler">The optional scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(
      Func<Task?>       function
    , CancellationToken cancellationToken
    , TaskScheduler?    scheduler = null
   )
   {
      await (scheduler ?? Scheduler).Run(function, cancellationToken);
   }

   /// <summary>
   /// Schedules work with the current or user provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="scheduler">The optional scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(Func<TResult> function, TaskScheduler? scheduler = null)
   {
      return await (scheduler ?? Scheduler).Run(function);
   }

   /// <summary>
   /// Schedules work with the current or user provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="cancellationToken">the token to check for cancellation.</param>
   /// <param name="scheduler">The optional scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(
      Func<TResult>     function
    , CancellationToken cancellationToken
    , TaskScheduler?    scheduler = null
   )
   {
      return await (scheduler ?? Scheduler).Run(function, cancellationToken);
   }

   /// <summary>
   /// Schedules work with the current or user provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="scheduler">The optional scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(Func<Task<TResult>?> function, TaskScheduler? scheduler = null)
   {
      return await (scheduler ?? Scheduler).Run(function);
   }

   /// <summary>
   /// Schedules work with the current or user provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="cancellationToken">the token to check for cancellation.</param>
   /// <param name="scheduler">The optional scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(
      Func<Task<TResult>?> function
    , CancellationToken    cancellationToken
    , TaskScheduler?       scheduler = null
   )
   {
      return await (scheduler ?? Scheduler).Run(function, cancellationToken);
   }
}