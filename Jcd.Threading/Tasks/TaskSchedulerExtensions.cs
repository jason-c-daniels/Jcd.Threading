using System;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace Jcd.Threading.Tasks;

/// <summary>
/// Adds various `Run` extension for any <see cref="TaskScheduler"/> derived type.
/// This allows tasks to be scheduled with the desired <see cref="TaskScheduler"/>
/// in a manner similar to `Task.Run` 
/// </summary>
public static class TaskSchedulerExtensions
{
   /// <summary>
   /// Schedules work with the provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="action">the action to execute.</param>
   /// <param name="scheduler">The scheduler to execute the action with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(this TaskScheduler scheduler, Action action)
   {
      await Task.Factory.StartNew(action
                                , CancellationToken.None
                                , TaskCreationOptions.DenyChildAttach
                                , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                 );
   }

   /// <summary>
   /// Schedules work with the provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="action">the action to execute.</param>
   /// <param name="scheduler">The scheduler to execute the action with.</param>
   /// <param name="cancellationToken">the token to check for cancellation</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(this TaskScheduler scheduler, Action action, CancellationToken cancellationToken)
   {
      await Task.Factory.StartNew(action
                                , cancellationToken
                                , TaskCreationOptions.DenyChildAttach
                                , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                 );
   }

   /// <summary>
   /// Schedules work with the provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="scheduler">The scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(this TaskScheduler scheduler, Func<Task?> function)
   {
      await (await Task.Factory.StartNew(function
                                       , CancellationToken.None
                                       , TaskCreationOptions.DenyChildAttach
                                       , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                        ))!;
   }

   /// <summary>
   /// Schedules work with the provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the action to execute.</param>
   /// <param name="scheduler">The scheduler to execute the function with.</param>
   /// <param name="cancellationToken">the token to check for cancellation</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task Run(this TaskScheduler scheduler, Func<Task?> function, CancellationToken cancellationToken)
   {
      await (await Task.Factory.StartNew(function
                                       , cancellationToken
                                       , TaskCreationOptions.DenyChildAttach
                                       , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                        ))!;
   }

   /// <summary>
   /// Schedules work with the provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="scheduler">The scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(this TaskScheduler scheduler, Func<TResult> function)
   {
      return await Task.Factory.StartNew(function
                                       , CancellationToken.None
                                       , TaskCreationOptions.DenyChildAttach
                                       , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                        );
   }

   /// <summary>
   /// Schedules work with the provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="scheduler">The scheduler to execute the function with.</param>
   /// <param name="cancellationToken">the token to check for cancellation</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(
      this TaskScheduler scheduler
    , Func<TResult>      function
    , CancellationToken  cancellationToken
   )
   {
      return await Task.Factory.StartNew(function
                                       , cancellationToken
                                       , TaskCreationOptions.DenyChildAttach
                                       , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                        );
   }

   /// <summary>
   /// Schedules work with the provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="scheduler">The scheduler to execute the function with.</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(this TaskScheduler scheduler, Func<Task<TResult>?>? function)
   {
      return await scheduler.Run(function, CancellationToken.None);
   }

   /// <summary>
   /// Schedules work with the provided <see cref="TaskScheduler"/>
   /// </summary>
   /// <param name="function">the function to execute.</param>
   /// <param name="scheduler">The scheduler to execute the function with.</param>
   /// <param name="cancellationToken">the token to check for cancellation</param>
   /// <returns>The <see cref="Task"/> representing the result of the execution.</returns>
   public static async Task<TResult> Run<TResult>(
      this TaskScheduler?   scheduler
    , Func<Task<TResult>?>? function
    , CancellationToken     cancellationToken
   )
   {
      if (function == null) throw new ArgumentNullException(nameof(function));

      // Short-circuit if we are given a pre-canceled token
      if (cancellationToken.IsCancellationRequested) return await Task.FromCanceled<TResult>(cancellationToken);

      // Kick off initial Task, which will call the user-supplied function and yield a Task.
      var task1 =
         Task<Task<TResult>?>.Factory.StartNew(function
                                             , cancellationToken
                                             , TaskCreationOptions.DenyChildAttach
                                             , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                              );

      return await task1.Unwrap();
   }
}