using System;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace Jcd.Tasks;

/// <summary>
/// Adds various `Run` as an extension method off of any <see cref="TaskScheduler"/>.
/// This allows tasks to be scheduled with the desired <see cref="TaskScheduler"/>
/// in a manner similar to `Task.Run` 
/// </summary>
public static class TaskSchedulerExtensions
{
   /// <summary>
   /// 
   /// </summary>
   /// <param name="action"></param>
   /// <param name="scheduler"></param>
   /// <returns></returns>
   public static async Task Run(this TaskScheduler scheduler, Action action)
   {
      await Task.Factory.StartNew(action
                                , CancellationToken.None
                                , TaskCreationOptions.DenyChildAttach
                                , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                 );
   }

   public static async Task Run(this TaskScheduler scheduler, Action action, CancellationToken cancellationToken)
   {
      await Task.Factory.StartNew(action
                                , cancellationToken
                                , TaskCreationOptions.DenyChildAttach
                                , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                 );
   }

   public static async Task Run(this TaskScheduler scheduler, Func<Task?> function)
   {
      await await Task.Factory.StartNew(function
                                      , CancellationToken.None
                                      , TaskCreationOptions.DenyChildAttach
                                      , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                       );
   }

   public static async Task Run(this TaskScheduler scheduler, Func<Task?> function, CancellationToken cancellationToken)
   {
      await await Task.Factory.StartNew(function
                                      , cancellationToken
                                      , TaskCreationOptions.DenyChildAttach
                                      , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                       );
   }

   public static async Task<TResult> Run<TResult>(this TaskScheduler scheduler, Func<TResult> function)
   {
      return await Task.Factory.StartNew(function
                                       , CancellationToken.None
                                       , TaskCreationOptions.DenyChildAttach
                                       , scheduler ?? throw new ArgumentNullException(nameof(scheduler))
                                        );
   }

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

   public static async Task<TResult> Run<TResult>(this TaskScheduler scheduler, Func<Task<TResult>?> function)
   {
      return await scheduler.Run(function, CancellationToken.None);
   }

   public static async Task<TResult> Run<TResult>(
      this TaskScheduler   scheduler
    , Func<Task<TResult>?> function
    , CancellationToken    cancellationToken
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