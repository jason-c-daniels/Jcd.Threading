using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A value wrapper for a <see cref="ManualResetEventSlim"/> to block read access while
/// the sole owning thread is updating the value. Otherwise reads are not blocked.
/// </summary>
/// <remarks>
/// It is the consumers responsibility to use this class as intended.
/// Multiple writes are not blocked. Unpredictable behavior may result if multiple
/// threads set the value at the same time.
/// </remarks>
/// <typeparam name="T">The data type to synchronize access to.</typeparam>
public sealed class SingleWriterMultipleReaderValue<T>: IDisposable
{
   private readonly ManualResetEventSlim mres;
   private          T                    val;

   // ReSharper disable once NullableWarningSuppressionIsUsed
   public SingleWriterMultipleReaderValue(T value = default!, int spinCount = 1000)
   {
      val  = value;
      mres = spinCount > 0 ? new ManualResetEventSlim(true, spinCount) : new ManualResetEventSlim(true);
   }

   /// <inheritdoc />
   public void Dispose() { mres.Dispose(); }

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
      mres.Wait();
      var result = val;
      return result;
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
      mres.Wait();
      var result = val;
      return Task.FromResult(result);
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
         mres.Reset();

         return val = value;
      }
      finally
      {
         mres.Set();
      }
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
         mres.Reset();

         return Task.FromResult(val = value);
      }
      finally
      {
         mres.Set();
      }
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
         mres.Reset();
         var result = val = func(val);
         return result;
      }
      finally{ mres.Set();}
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
         mres.Set();
         var result = val = await func(val);
         return result;
      }
      finally{ mres.Reset();}
   }
   
   #endregion
}