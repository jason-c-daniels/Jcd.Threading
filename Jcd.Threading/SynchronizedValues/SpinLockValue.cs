using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8601 // Possible null reference assignment.

namespace Jcd.Threading.SynchronizedValues;

/// <summary>
/// Provides a generic mechanism for setting, getting, acting on, and altering values
/// shared among tasks and threads, utilizing a <see cref="SpinLock"/> for synchronization.
/// </summary>
/// <typeparam name="T">The data type to synchronize access to.</typeparam>
/// <remarks>
/// <para>
/// While this provides a method of easily ensuring any one shared value is appropriately
/// locked during setting or getting, you still need to thoroughly understand your
/// use case. For example, having two <see cref="SpinLockValue{T}"/> instances accessed
/// by two different threads, in rapid succession, in different orders can cause
/// potentially unexpected results.
/// </para>
/// <para>
/// In cases where the pair/tuple must be consistent at all times across all accesses,
/// consider creating a struct containing the necessary fields/properties and wrapping
/// that in a <see cref="SpinLockValue{T}"/> instead of each individual field/property.
/// </para>
/// <para>
/// As well this implementation uses <see cref="SpinLock"/> and requires `Dispose` to be
/// called. Either implement <see cref="IDisposable"/> or call it directly at the appropriate
/// time. See the documentation for <see cref="ChangeValue"/>, <see cref="ChangeValueAsync"/>,
/// for recursive reentrancy considerations. <i>(i.e. don't try it!)</i>
/// </para>
/// <para>
/// NB: If using a reference type for the underlying value, ensure your reference
/// type appropriately synchronizes access to its own data. In this case these
/// types only restrict access to the reference, not the data contained within
/// the reference type.
/// </para>
/// </remarks>
public class SpinLockValue<T>
{
   // ReSharper disable once FieldCanBeMadeReadOnly.Local
   private          SpinLock spinLock;
   private          T        val;
   private readonly bool     useMemoryBarrier;

   /// <summary>
   /// Creates an instance of a <see cref="SpinLockValue{T}"/>
   /// </summary>
   /// <param name="initialVal">The initial value</param>
   /// <param name="useMemoryBarrier">Indicates if the call to Exit should use a memory barrier to notify other threads the lock has been freed(much slower!).</param>
   /// <param name="useThreadTracking">Indicates if the <see cref="SpinLock"/> uses thread tracking.</param>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public SpinLockValue(T initialVal = default, bool useMemoryBarrier = false, bool useThreadTracking = false)
   {
      this.useMemoryBarrier = useMemoryBarrier;
      val                   = initialVal;
      spinLock              = new SpinLock(useThreadTracking);
   }

   /// <summary>
   /// Sets or gets the value. This will block.
   /// </summary>
   public T Value
   {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => GetValue();

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => SetValue(value);
   }

   /// <summary>
   /// Retrieves the current value. If another thread edits the value, moment later a subsequent
   /// call will yield a different result. 
   /// </summary>
   /// <returns>The current value as of establishing the lock.</returns>
   /// <example>
   /// <code>
   /// var sv = new SpinLockValue&lt;int&gt;(15);
   /// 
   /// // get the value
   /// setValue = sv.GetValue(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T GetValue()
   {
      T result;

      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);
         result = val;
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrier);
      }

      return result;
   }

   /// <summary>
   /// Gets the value in an async friendly manner.
   /// </summary>
   /// <returns>A <see cref="Task{T}"/> containing the retrieved value.</returns>
   /// <example>
   /// <code>
   /// var sv = new SpinLockValue&lt;int&gt;(15);
   /// 
   /// // get the value
   /// var result = await sv.GetValueAsync(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public Task<T> GetValueAsync()
   {
      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);

         return Task.FromResult(val);
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrier);
      }
   }

   /// <summary>
   /// Sets the current value to the provided value.
   /// </summary>
   /// <param name="value">The provided value.</param>
   /// <returns>The provided value.</returns>
   /// <example>
   /// <code>
   /// var sv = new SpinLockValue&lt;int&gt;();
   /// 
   /// // set the value to 10.
   /// var result = sv.SetValue(10);
   /// 
   /// // set the value to 20.
   /// setValue = sv.SetValue(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T SetValue(T value)
   {
      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);

         return val = value;
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrier);
      }
   }

   /// <summary>
   /// Sets the current value to the provided value.
   /// </summary>
   /// <param name="value">The provided value.</param>
   /// <returns>A <see cref="Task{T}"/> containing the provided value.</returns>
   /// <example>
   /// <code>
   /// var sv = new SpinLockValue&lt;int&gt;();
   /// 
   /// // set the value to 10.
   /// var result = await sv.SetValueAsync(10);
   /// 
   /// // set the value to 20.
   /// result = await sv.SetValueAsync(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public Task<T> SetValueAsync(T value)
   {
      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);

         return Task.FromResult(val = value);
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrier);
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
   /// var sv = new SpinLockValue&lt;int&gt;();
   /// 
   /// // increment the value by one.
   /// var changedValue = sv.ChangeValue(x => x + 1);
   /// 
   /// // increment the value by two.
   /// changedValue = sv.ChangeValue(x => x + 2);
   /// 
   /// </code>
   /// </example>
   /// <remarks>
   /// <para>
   /// <b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like
   /// the following.
   /// </para>
   /// <code>
   /// var sv=new SpinLockValue&lt;int&gt;(10);
   ///
   /// // deadlock yourself in a single line of code!
   /// var changedValue = sv.ChangeValue(x=>sv.Value+10);
   /// </code>
   /// </remarks>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T ChangeValue(Func<T, T>? func)
   {
      if (func == null) return val;

      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);
         var result = val = func(val);

         return result;
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrier);
      }
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
   /// var sv = new SpinLockValue&lt;int&gt;();
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
   /// var sv=new SpinLockValue&lt;int&gt;(10);
   ///
   /// // deadlock yourself in a single line of code!
   /// var changedValue = await sv.ChangeValueAsync(x=>sv.Value+10);
   /// </code>
   /// </remarks>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public async Task<T> ChangeValueAsync(Func<T, Task<T>>? func)
   {
      if (func == null) return Value;

      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);

         return val = await func(val);
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrier);
      }
   }
}