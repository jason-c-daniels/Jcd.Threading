using System.Windows;
using System.Windows.Threading;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable MethodCanBePrivate.Global

namespace Foo;

/// <summary>
/// A lightweight wrapper to Application.Current.Dispatcher exposing its methods as static methods.
/// </summary>
public static class Ui
{
   public static Dispatcher Dispatcher                                        => Application.Current.Dispatcher;
   public static void       Invoke(Action callback)                              => Dispatcher.Invoke(callback);
   public static void       Invoke(Action callback, DispatcherPriority priority) => Dispatcher.Invoke(callback, priority);

   public static void Invoke(
      Action             callback
    , DispatcherPriority priority
    , CancellationToken  cancellationToken
   ) =>
      Dispatcher.Invoke(callback, priority, cancellationToken);

   public static void Invoke(
      Action             callback
    , DispatcherPriority priority
    , CancellationToken  cancellationToken
    , TimeSpan           timeout
   ) =>
      Dispatcher.Invoke(callback, priority, cancellationToken, timeout);

   public static TResult Invoke<TResult>(Func<TResult> callback) => Dispatcher.Invoke(callback);

   public static TResult Invoke<TResult>(Func<TResult> callback, DispatcherPriority priority) =>
      Dispatcher.Invoke(callback, priority);

   public static TResult Invoke<TResult>(
      Func<TResult>      callback
    , DispatcherPriority priority
    , CancellationToken  cancellationToken
   ) =>
      Dispatcher.Invoke(callback, priority,cancellationToken);

   public static TResult Invoke<TResult>(
      Func<TResult>      callback
    , DispatcherPriority priority
    , CancellationToken  cancellationToken,
      TimeSpan           timeout
   ) =>
      Dispatcher.Invoke(callback, priority, cancellationToken,timeout);
   
   public static DispatcherOperation InvokeAsync(
      Action             callback,
      DispatcherPriority priority,
      CancellationToken  cancellationToken) =>
      Dispatcher.InvokeAsync(callback, priority, cancellationToken);

   public static DispatcherOperation<TResult> InvokeAsync<TResult>(Func<TResult> callback) => 
      InvokeAsync(callback, DispatcherPriority.Normal, CancellationToken.None);

   public static DispatcherOperation<TResult> InvokeAsync<TResult>(
      Func<TResult>      callback,
      DispatcherPriority priority) =>
      InvokeAsync(callback, priority, CancellationToken.None);

   public static DispatcherOperation<TResult> InvokeAsync<TResult>(
      Func<TResult>      callback,
      DispatcherPriority priority,
      CancellationToken  cancellationToken ) =>
      Dispatcher.InvokeAsync(callback, priority, cancellationToken);
   
}