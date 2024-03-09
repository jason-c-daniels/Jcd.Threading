using System;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable MemberCanBePrivate.Global

namespace Jcd.Threading.Tasks;

/// <summary>
/// A singleton <see cref="TaskScheduler"/> bound task runner. It ensures all tasks it creates
/// are registered with either its own, or a user provided <see cref="TaskScheduler"/>.
/// </summary>
public static class CustomSchedulerTaskRunner<TScheduler>
   where TScheduler : TaskScheduler, new()
{
   /// <summary>
   /// The <see cref="TaskScheduler"/> used to schedule and execute tasks.
   /// </summary>
   public static TScheduler Scheduler { get; } = new();

   /// <summary>
   /// Schedules work on either the <see cref="TaskScheduler"/> this type owns or the user provided one. 
   /// </summary>
   /// <param name="action">the action to execute.</param>
   /// <param name="scheduler">The optional scheduler to execute the action with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(Action action, TaskScheduler? scheduler = null)
   {
      await (scheduler ?? Scheduler).Run(action);
   }

   /// <summary>
   /// Schedules work on either the <see cref="TaskScheduler"/> this type owns or the user provided one. 
   /// </summary>
   /// <param name="action">the action to execute.</param>
   /// <param name="cancellationToken">The token to check for cancellation.</param>
   /// <param name="scheduler">The optional scheduler to execute the action with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(Action action, CancellationToken cancellationToken, TaskScheduler? scheduler = null)
   {
      await (scheduler ?? Scheduler).Run(action, cancellationToken);
   }

   /// <summary>
   /// Schedules work on either the <see cref="TaskScheduler"/> this type owns or the user provided one. 
   /// </summary>
   /// <param name="asyncAction">the function to execute.</param>
   /// <param name="scheduler">The optional scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(Func<Task?> asyncAction, TaskScheduler? scheduler = null)
   {
      await (scheduler ?? Scheduler).Run(asyncAction);
   }

   /// <summary>
   /// Schedules work on either the <see cref="TaskScheduler"/> this type owns or the user provided one. 
   /// </summary>
   /// <param name="asyncAction">the action to execute.</param>
   /// <param name="cancellationToken">The token to check for cancellation.</param>
   /// <param name="scheduler">The optional scheduler to execute the action with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(
      Func<Task?>       asyncAction
    , CancellationToken cancellationToken
    , TaskScheduler?    scheduler = null
   )
   {
      await (scheduler ?? Scheduler).Run(asyncAction, cancellationToken);
   }

   /// <summary>
   /// Schedules work on either the <see cref="TaskScheduler"/> this type owns or the user provided one. 
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="scheduler">The optional scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(Func<TResult> function, TaskScheduler? scheduler = null)
   {
      return await (scheduler ?? Scheduler).Run(function);
   }

   /// <summary>
   /// Schedules work on either the <see cref="TaskScheduler"/> this type owns or the user provided one. 
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="cancellationToken">The token to check for cancellation.</param>
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
   /// Schedules work on either the <see cref="TaskScheduler"/> this type owns or the user provided one. 
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="scheduler">The optional scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(Func<Task<TResult>> function, TaskScheduler? scheduler = null)
   {
      return await (scheduler ?? Scheduler).Run(function);
   }

   /// <summary>
   /// Schedules work on either the <see cref="TaskScheduler"/> this type owns or the user provided one. 
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="cancellationToken">The token to check for cancellation.</param>
   /// <param name="scheduler">The optional scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(
      Func<Task<TResult>> function
    , CancellationToken   cancellationToken
    , TaskScheduler?      scheduler = null
   )
   {
      return await (scheduler ?? Scheduler).Run(function, cancellationToken);
   }
}