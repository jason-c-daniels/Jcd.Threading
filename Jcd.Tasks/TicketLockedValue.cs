using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A value wrapper for a <see cref="TicketLock"/> to block access during reads
/// and writes. It guarantees FIFO order of execution.
/// </summary>
/// <typeparam name="T">The data type to synchronize access to.</typeparam>
public sealed class TicketLockedValue<T> 
{
   private readonly TicketLock mutex = new();
   private          T          val;

   // ReSharper disable once NullableWarningSuppressionIsUsed
   /// <summary>
   /// Constructs an instance of <see cref="TicketLockedValue{T}"/>
   /// </summary>
   /// <param name="initialValue"the initial value to store></param>
   public TicketLockedValue(T initialValue = default!) { val = initialValue; }

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
      using (mutex.Lock())
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
      using (await mutex.LockAsync())
         return val;
   }

   /// <summary>
   /// Sets the current value to the provided value.
   /// </summary>
   /// <param name="value">The provided value.</param>
   /// <returns>The provided value.</returns>
   /// <example>
   /// <code>
   /// var sv = new SingleWriterMultipleReaderValue&lt;int&gt;();
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
      using (mutex.Lock())
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
      using (await mutex.LockAsync())
         return val = value;
   }

   #endregion
}