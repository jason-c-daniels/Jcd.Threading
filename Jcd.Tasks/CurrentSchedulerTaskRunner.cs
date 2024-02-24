using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A TaskRunner that schedules tasks on the current TaskScheduler or a user provided TaskScheduler.
/// </summary>
public static class CurrentSchedulerTaskRunner
{
   public static TaskScheduler Scheduler => TaskScheduler.Current;
   
   /// <summary>
   /// 
   /// </summary>
   /// <param name="action"></param>
   /// <param name="scheduler"></param>
   /// <returns></returns>
   public static async Task Run(Action action, TaskScheduler scheduler=null) => 
      await Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.DenyChildAttach, scheduler ?? Scheduler);

   public static async Task Run(Action action, CancellationToken cancellationToken, TaskScheduler scheduler =null) =>
      await Task.Factory.StartNew(action, cancellationToken, TaskCreationOptions.DenyChildAttach, scheduler ?? Scheduler);

   public static async Task Run(Func<Task?> function, TaskScheduler scheduler =null) =>
      await await Task.Factory.StartNew(function, CancellationToken.None, TaskCreationOptions.DenyChildAttach, scheduler ?? Scheduler);

   public static async Task Run(Func<Task?> function, CancellationToken cancellationToken) =>
      await await Task.Factory.StartNew(function, cancellationToken, TaskCreationOptions.DenyChildAttach, Scheduler);

   public static async Task<TResult> Run<TResult>(Func<TResult> function, TaskScheduler scheduler =null) =>
      await Task.Factory.StartNew(function, CancellationToken.None, TaskCreationOptions.DenyChildAttach, scheduler ?? Scheduler);

   public static async Task<TResult> Run<TResult>(
      Func<TResult>     function
    , CancellationToken cancellationToken
    , TaskScheduler     scheduler =null
   ) =>
      await Task.Factory.StartNew(function, cancellationToken, TaskCreationOptions.DenyChildAttach, scheduler ?? Scheduler);

   public static async Task<TResult> Run<TResult>(Func<Task<TResult>?> function, TaskScheduler scheduler =null) =>
      await Run(function, CancellationToken.None, scheduler ?? Scheduler);
   
   public static async Task<TResult> Run<TResult>(
      Func<Task<TResult>?> function
    , CancellationToken    cancellationToken
    , TaskScheduler        scheduler =null
   )
   {
      if (function == null) throw new ArgumentNullException(nameof(function));

      // Short-circuit if we are given a pre-canceled token
      if (cancellationToken.IsCancellationRequested) return await Task.FromCanceled<TResult>(cancellationToken);

      // Kick off initial Task, which will call the user-supplied function and yield a Task.
      Task<Task<TResult>?> task1 =
         Task<Task<TResult>?>.Factory.StartNew(function
                                             , cancellationToken
                                             , TaskCreationOptions.DenyChildAttach,
                                               scheduler ?? Scheduler
                                              );
      return await task1.Unwrap();
   }
}