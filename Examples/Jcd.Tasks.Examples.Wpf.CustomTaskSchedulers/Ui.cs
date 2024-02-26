using System.Windows;
using System.Windows.Threading;

// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable MethodCanBePrivate.Global

namespace Jcd.Tasks.Examples.Wpf.CustomTaskSchedulers;

/// <summary>
/// A lightweight wrapper to Application.Current.Dispatcher exposing its methods as static methods.
/// </summary>
public static class Ui
{
   /// <summary>
   /// The UI Thread Dispatcher. This is syntactic sugar for `Application.Current.Dispatcher` 
   /// </summary>
   public static Dispatcher Dispatcher => Application.Current.Dispatcher;

   /// <summary>
   /// Executes an action on the UI Thread.
   /// </summary>
   /// <param name="action">the action to execute.</param>
   public static void Invoke(Action action) { Dispatcher.Invoke(action); }

   /// <summary>
   /// Executes an action on the UI Thread with a given priority.
   /// </summary>
   /// <param name="action">the action to execute.</param>
   /// <param name="priority">The priority to execute the action at.</param>
   public static void Invoke(Action action, DispatcherPriority priority) { Dispatcher.Invoke(action, priority); }

   /// <summary>
   /// Executes an action on the UI Thread with a given priority and cancellation token.
   /// </summary>
   /// <param name="action">the action to execute.</param>
   /// <param name="priority">The priority to execute the action at.</param>
   /// <param name="cancellationToken">the cancellation token.</param>
   public static void Invoke(
      Action             action
    , DispatcherPriority priority
    , CancellationToken  cancellationToken
   )
   {
      Dispatcher.Invoke(action, priority, cancellationToken);
   }

   /// <summary>
   /// Executes an action on the UI Thread with a given priority and cancellation token which
   /// aborting after a specified timeout.
   /// </summary>
   /// <param name="action">the action to execute.</param>
   /// <param name="priority">The priority to execute the action at.</param>
   /// <param name="cancellationToken">the cancellation token.</param>
   /// <param name="timeout">The maximum amount of time to wait for the operation to start.</param>
   public static void Invoke(
      Action             action
    , DispatcherPriority priority
    , CancellationToken  cancellationToken
    , TimeSpan           timeout
   )
   {
      Dispatcher.Invoke(action, priority, cancellationToken, timeout);
   }

   /// <summary>
   /// Executes a function on the UI thread and returns its result. 
   /// </summary>
   /// <param name="function">the function to execute</param>
   /// <typeparam name="TResult">The result data type</typeparam>
   /// <returns>The result of the function</returns>
   public static TResult Invoke<TResult>(Func<TResult> function) { return Dispatcher.Invoke(function); }

   /// <summary>
   /// Executes a function on the UI thread at a specified priority and returns its result. 
   /// </summary>
   /// <param name="function">the function to execute</param>
   /// <typeparam name="TResult">The result data type</typeparam>
   /// <param name="priority">The priority to execute the function at.</param>
   /// <returns>The result of the function</returns>
   public static TResult Invoke<TResult>(Func<TResult> function, DispatcherPriority priority)
   {
      return Dispatcher.Invoke(function, priority);
   }

   /// <summary>
   /// Executes a function on the UI thread at a specified priority, with a cancellation
   /// token and returns its result. 
   /// </summary>
   /// <param name="function">the function to execute</param>
   /// <typeparam name="TResult">The result data type</typeparam>
   /// <param name="priority">The priority to execute the function at.</param>
   /// <param name="cancellationToken">The token used to check for cancellation</param>
   /// <returns>The result of the function</returns>
   public static TResult Invoke<TResult>(
      Func<TResult>      function
    , DispatcherPriority priority
    , CancellationToken  cancellationToken
   )
   {
      return Dispatcher.Invoke(function, priority, cancellationToken);
   }

   /// <summary>
   /// Executes a function on the UI thread at a specified priority, with a cancellation
   /// token and returns its result. 
   /// </summary>
   /// <param name="function">the function to execute</param>
   /// <typeparam name="TResult">The result data type</typeparam>
   /// <param name="priority">The priority to execute the function at.</param>
   /// <param name="cancellationToken">The token used to check for cancellation</param>
   /// <param name="timeout">The maximum amount of time to wait for the operation to start</param>
   /// <returns>The result of the function</returns>
   public static TResult Invoke<TResult>(
      Func<TResult>      function
    , DispatcherPriority priority
    , CancellationToken  cancellationToken
    , TimeSpan           timeout
   )
   {
      return Dispatcher.Invoke(function, priority, cancellationToken, timeout);
   }

   /// <summary>
   /// Asynchronously executes an action at a specified priority and with a cancellation token..
   /// </summary>
   /// <param name="action">the action to execute</param>
   /// <param name="priority">the priority to execute the action at.</param>
   /// <param name="cancellationToken">The token to check for cancellation.</param>
   /// <returns>The <see cref="DispatcherOperation"/> associated with the operation.</returns>
   public static DispatcherOperation InvokeAsync(
      Action             action
    , DispatcherPriority priority
    , CancellationToken  cancellationToken
   )
   {
      return Dispatcher.InvokeAsync(action, priority, cancellationToken);
   }

   /// <summary>
   /// Asynchronously executes a function at a specified priority and with a cancellation token..
   /// </summary>
   /// <param name="function">the action to execute</param>
   /// <returns>The <see cref="DispatcherOperation"/> associated with the operation.</returns>
   public static DispatcherOperation<TResult> InvokeAsync<TResult>(Func<TResult> function)
   {
      return InvokeAsync(function, DispatcherPriority.Normal, CancellationToken.None);
   }

   /// <summary>
   /// Asynchronously executes a function at a specified priority.
   /// </summary>
   /// <param name="function">the action to execute</param>
   /// <param name="priority">The priority of the scheduled work.</param>
   /// <returns>The <see cref="DispatcherOperation"/> associated with the operation.</returns>
   public static DispatcherOperation<TResult> InvokeAsync<TResult>(
      Func<TResult>      function
    , DispatcherPriority priority
   )
   {
      return InvokeAsync(function, priority, CancellationToken.None);
   }

   /// <summary>
   /// Asynchronously executes a function at a specified priority and with a cancellation token..
   /// </summary>
   /// <param name="function">the action to execute</param>
   /// <param name="priority">The priority of the scheduled work.</param>
   /// <param name="cancellationToken">the token to check for cancellation</param>
   /// <returns>The <see cref="DispatcherOperation"/> associated with the operation.</returns>
   public static DispatcherOperation<TResult> InvokeAsync<TResult>(
      Func<TResult>      function
    , DispatcherPriority priority
    , CancellationToken  cancellationToken
   )
   {
      return Dispatcher.InvokeAsync(function, priority, cancellationToken);
   }
}