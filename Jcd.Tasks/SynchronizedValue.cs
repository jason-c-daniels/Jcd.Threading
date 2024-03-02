using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global

namespace Jcd.Tasks;

/// <summary>
/// Provides a simple async-safe and thread-safe method of setting, getting, acting on,
/// and altering values shared among tasks and threads.
/// </summary>
/// <param name="val">The value to initialize this to</param>
/// <typeparam name="T">The data type to synchronize access to.</typeparam>
/// <remarks>
/// <para>
/// While this provides a method of easily ensuring any one shared value is appropriately
/// locked during setting or getting, you still need to thoroughly understand your
/// use case. For example, having two <see cref="SynchronizedValue{T}"/> instances accessed
/// by two different threads, in rapid succession, in different orders can cause
/// potentially unexpected results.
/// </para>
/// <para>
/// In cases where the pair/tuple must be consistent at all times across all accesses,
/// consider creating a struct containing the necessary fields/properties and wrapping
/// that in a <see cref="SynchronizedValue{T}"/> instead of each individual field/property.
/// </para>
/// <para>
/// As well this implementation uses <see cref="SemaphoreSlim"/> and requires Dispose to be
/// called. Either implement <see cref="IDisposable"/> or call it directly at the appropriate
/// time. See the documentation for <see cref="ChangeValue"/>, <see cref="ChangeValueAsync"/>, <see cref="Do"/>, and <see cref="DoAsync"/>
/// for recursive reentrancy considerations. <i>(i.e. don't try it!)</i>
/// </para>
/// </remarks>
public sealed class SynchronizedValue<T>
(

   // ReSharper disable once NullableWarningSuppressionIsUsed
   T val = default!
) : IDisposable
{
   private readonly ReaderWriterLockSlim rwls = new (LockRecursionPolicy.NoRecursion);

   /// <inheritdoc />
   public void Dispose() { rwls.Dispose(); }

   #region properties and accessors

   /// <summary>
   /// Get or sets the synchronized value.
   /// </summary>
   /// <example>
   /// <code>
   /// var sv = new SynchronizedValue&lt;int&gt;(15);
   /// 
   /// // get the value
   /// var theValue = sv.Value;
   ///
   /// // set the value
   /// sv.Value = theValue + 10;
   /// 
   /// </code>
   /// </example>
   public T Value
   {
      get => GetValue();
      set => SetValue(value);
   }

   /// <summary>
   /// Retrieves the current value. If another thread edits the value, moment later a subsequent
   /// call will yield a different result. 
   /// </summary>
   /// <returns>The current value as of establishing the lock.</returns>
   /// <example>
   /// <code>
   /// var sv = new SynchronizedValue&lt;int&gt;(15);
   /// 
   /// // get the value
   /// setValue = sv.GetValue(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T GetValue()
   {
      try
      {
         rwls.EnterReadLock();
         var result = val;
         return result;
      }
      finally{ rwls.ExitReadLock();}
   }

   /// <summary>
   /// Gets the value in an async friendly manner.
   /// </summary>
   /// <returns>A <see cref="Task{T}"/> containing the retrieved value.</returns>
   /// <example>
   /// <code>
   /// var sv = new SynchronizedValue&lt;int&gt;(15);
   /// 
   /// // get the value
   /// await setValue = sv.GetValueAsync(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public Task<T> GetValueAsync()
   {
      try
      {
         rwls.EnterReadLock();
         var result = val;
         return Task.FromResult(result);
      }
      finally{ rwls.ExitReadLock();}
   }

   /// <summary>
   /// Sets the current value to the provided value.
   /// </summary>
   /// <param name="value">The provided value.</param>
   /// <returns>The provided value.</returns>
   /// <example>
   /// <code>
   /// var sv = new SynchronizedValue&lt;int&gt;();
   /// 
   /// // set the value to 10.
   /// setValue = sv.SetValue(10);
   /// 
   /// // set the value to 20.
   /// setValue = sv.SetValue(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T SetValue(T value)
   {
      try
      {
         rwls.EnterReadLock();
         return val=value;
      }
      finally{ rwls.ExitReadLock();}
   }

   /// <summary>
   /// Sets the current value to the provided value.
   /// </summary>
   /// <param name="value">The provided value.</param>
   /// <returns>A <see cref="Task{T}"/> containing the provided value.</returns>
   /// <example>
   /// <code>
   /// var sv = new SynchronizedValue&lt;int&gt;();
   /// 
   /// // set the value to 10.
   /// await setValue = sv.SetValueAsync(10);
   /// 
   /// // set the value to 20.
   /// await setValue = sv.SetValueAsync(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public Task<T> SetValueAsync(T value)
   {
      try
      {
         rwls.EnterWriteLock();
         return Task.FromResult(val = value);
      }
      finally{ rwls.ExitWriteLock();}
   }

   /// <summary>
   /// Calls the provided function, passing in the current value, and assigns the result
   /// of the function call, to the current value. <b>This is not recursively reentrant.
   /// see remarks for details.</b>
   /// </summary>
   /// <param name="func">
   /// A function to call which receives the current value, modifies it, and returns the
   /// modified result.
   /// </param>
   /// <returns>The modified value.</returns>
   /// <example>
   /// Standard usage: pass in a function to manipulate the current value.
   /// <code>
   /// var sv = new SynchronizedValue&lt;int&gt;();
   /// 
   /// // increment the value by one.
   /// var changedValue = sv.Do(x => x + 1);
   /// 
   /// // increment the value by two.
   /// changedValue = sv.Do(x => x + 2);
   /// 
   /// </code>
   /// </example>
   /// <remarks>
   /// <para>
   /// <b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like
   /// the following.
   /// </para>
   /// <code>
   /// var sv=new SynchronizedValue&lt;int&gt;(10);
   ///
   /// // deadlock yourself in a single line of code!
   /// var changedValue = sv.Do(x=>sv.Value+10);
   /// </code>
   /// </remarks>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T ChangeValue(Func<T, T>? func)
   {
      if (func == null) return Value;
      try
      {
         rwls.EnterWriteLock();
         var result = val = func(val);
         return result;
      }
      finally{ rwls.ExitWriteLock();}
   }

   /// <summary>
   /// Calls the provided function, passing in the current value, and assigns the result
   /// of the function call, to the current value. <b>This is not recursively reentrant.
   /// see remarks for details.</b>
   /// </summary>
   /// <param name="func">The function to call.</param>
   /// <returns>A <see cref="Task{T}"/> containing the modified value.</returns>
   /// <example>
   /// Standard usage: pass in a function to manipulate the current value.
   /// <code>
   /// var sv = new SynchronizedValue&lt;int&gt;();
   /// 
   /// // increment the value by one.
   /// var changedValue = await sv.ChangeValueAsync(x => x + 1);
   /// 
   /// // increment the value by two.
   /// changedValue = await sv.ChangeValueAsync(x => x + 2);
   /// 
   /// // Perform some operation that requires the value to remain unchanged during the operation.
   /// var sameValue = await sv.ChangeValueAsync(x => { DoSomething(x); return x;});
   /// </code>
   /// </example>
   /// <remarks>
   /// <para>
   /// <b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like
   /// the following.
   /// </para>
   /// <code>
   /// var sv=new SynchronizedValue&lt;int&gt;(10);
   ///
   /// // deadlock yourself in a single line of code!
   /// var changedValue = await sv.ChangeValueAsync(x=>sv.Value+10);
   /// </code>
   /// </remarks>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<T> ChangeValueAsync(Func<T, Task<T>>? func)
   {
      if (func == null) return Value;
      try
      {
         rwls.EnterWriteLock();
         var result= val = await func(val);
         return result;
      }
      finally{ rwls.ExitWriteLock();}
   }

   /// <summary>
   /// Executes an action on the synchronized value after locking it.
   /// <b>This is not recursively reentrant. See remarks for details.</b>
   /// </summary>
   /// <param name="action">The function to call.</param>
   /// <example>
   /// Standard usage: pass in an asynchronous action to action the current value.
   /// <code>
   /// var sv = new SynchronizedValue&lt;int&gt;();
   /// 
   /// // increment the value by one and discard the result.
   /// sv.Do(x => x + 1);
   /// 
   /// // increment the value by two and discard the result.
   /// sv.Do(x => x + 2);
   /// 
   /// // Perform some other operation that requires the value to
   /// remain unchanged during the operation.
   /// sv.Do(x => DoSomething(x));
   /// </code>
   /// </example>
   /// <remarks>
   /// <para>
   /// <b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like
   /// the following.
   /// </para>
   /// <code>
   /// var sv=new SynchronizedValue&lt;int&gt;(10);
   ///
   /// // deadlock yourself in a single line of code!
   /// sv.Do(x=>sv.Value+10);
   /// </code>
   /// </remarks>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public void Do(Action<T>? action)
   {
      if (action == null) return;
      using (rwls.Read())
         action(val);
   }

   /// <summary>
   /// Executes an asynchronous action on the synchronized value after locking it.
   /// <b>This is not recursively reentrant. See remarks for details.</b>
   /// </summary>
   /// <param name="asyncAction">The function to call.</param>
   /// <returns>A <see cref="Task"/> for the action.</returns>
   /// <example>
   /// Standard usage: pass in an asynchronous action to action the current value.
   /// <code>
   /// var sv = new SynchronizedValue&lt;int&gt;();
   /// 
   /// // increment the value by one and discard the result.
   /// var changedValue = await sv.DoAsync(x => x + 1);
   /// 
   /// // increment the value by two and discard the result.
   /// await sv.DoAsync(x => x + 2);
   /// 
   /// // Perform some other operation that requires the value to
   /// remain unchanged during the operation.
   /// await sv.DoAsync(x => DoSomething(x));
   /// </code>
   /// </example>
   /// <remarks>
   /// <para>
   /// <b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like
   /// the following.
   /// </para>
   /// <code>
   /// var sv=new SynchronizedValue&lt;int&gt;(10);
   ///
   /// // deadlock yourself in a single line of code!
   /// await sv.DoAsync(x=>sv.Value+10);
   /// </code>
   /// </remarks>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task DoAsync(Func<T, Task>? asyncAction)
   {
      if (asyncAction == null) return;
      using (await rwls.ReadAsync())
         await asyncAction(val);
   }

   #endregion
}