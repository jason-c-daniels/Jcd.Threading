using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Jcd.Threading.SynchronizedValues;

/// <summary>
/// A value wrapper for a <see cref="TicketLock"/> to block access during reads
/// and writes. It guarantees in order execution of locks.
/// </summary>
/// <typeparam name="T">The data type to synchronize access to.</typeparam>
public sealed class TicketLockValue<T>
{
   private readonly TicketLock ticketLock = new();
   private          T          val;

   // ReSharper disable once NullableWarningSuppressionIsUsed
   /// <summary>
   /// Constructs an instance of <see cref="TicketLockValue{T}"/>
   /// </summary>
   /// <param name="initialValue">the initial value to store></param>
   public TicketLockValue(T initialValue = default!) { val = initialValue; }

   /// <inheritdoc />

   #region properties and accessors

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
   /// var sv = new TicketLockedValue&lt;int&gt;(15);
   /// 
   /// // get the value
   /// setValue = swmr.GetValue(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T GetValue()
   {
      using (ticketLock.Lock())
         return val;
   }

   /// <summary>
   /// Gets the value in an async friendly manner.
   /// </summary>
   /// <returns>A <see cref="Task"/> containing the retrieved value.</returns>
   /// <example>
   /// <code>
   /// var sv = new TicketLockedValue&lt;int&gt;(15);
   /// 
   /// // get the value
   /// await setValue = swmr.GetValueAsync(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<T> GetValueAsync()
   {
      using (await ticketLock.LockAsync())
         return val;
   }

   /// <summary>
   /// Sets the current value to the provided value.
   /// </summary>
   /// <param name="value">The provided value.</param>
   /// <returns>The provided value.</returns>
   /// <example>
   /// <code>
   /// var sv = new TicketLockValue&lt;int&gt;();
   /// 
   /// // set the value to 10.
   /// setValue = swmr.SetValue(10);
   /// 
   /// // set the value to 20.
   /// setValue = swmr.SetValue(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T SetValue(T value)
   {
      using (ticketLock.Lock())
         return val = value;
   }

   /// <summary>
   /// Sets the current value to the provided value.
   /// </summary>
   /// <param name="value">The provided value.</param>
   /// <returns>A <see cref="Task{T}"/> containing the provided value.</returns>
   /// <example>
   /// <code>
   /// var sv = new TicketLockedValue&lt;int&gt;();
   /// 
   /// // set the value to 10.
   /// await setValue = swmr.SetValueAsync(10);
   /// 
   /// // set the value to 20.
   /// await setValue = swmr.SetValueAsync(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<T> SetValueAsync(T value)
   {
      using (await ticketLock.LockAsync())
         return val = value;
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
   /// var sv = new TicketLockValue&lt;int&gt;();
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
   /// var sv=new TicketLockValue&lt;int&gt;(10);
   ///
   /// // deadlock yourself in a single line of code!
   /// var changedValue = sv.ChangeValue(x=>sv.Value+10);
   /// </code>
   /// </remarks>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T ChangeValue(Func<T, T>? func)
   {
      if (func == null) return Value;

      using (ticketLock.LockAsync())
         return val = func(val);
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
   /// var sv = new TicketLockValue&lt;int&gt;();
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
   /// var sv=new TicketLockValue&lt;int&gt;(10);
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
         using (await ticketLock.LockAsync())
            return val = await func(val);
      }
      finally
      {
         ticketLock.Release();
      }
   }

   #endregion
}