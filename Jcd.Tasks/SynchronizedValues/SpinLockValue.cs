using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8601 // Possible null reference assignment.

namespace Jcd.Threading.SynchronizedValues;

/// <summary>
/// Provides synchronization to an underlying value through a <see cref="SpinLock"/>.
/// </summary>
/// <typeparam name="T">The type of the data being stored.</typeparam>
internal class SpinLockValue<T>
{
   // ReSharper disable once FieldCanBeMadeReadOnly.Local
   private          SpinLock spinLock;
   private          T        value;
   private readonly bool     useMemoryBarrier;

   /// <summary>
   /// Creates an instance of a <see cref="SpinLockValue{T}"/>
   /// </summary>
   /// <param name="initialValue">The initial value</param>
   /// <param name="useMemoryBarrier">Indicates if the call to Exit should use a memory barrier to notify other threads the lock has been freed(much slower!).</param>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public SpinLockValue(T initialValue = default, bool useMemoryBarrier = false)
   {
      this.useMemoryBarrier = useMemoryBarrier;
      value                 = initialValue;
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

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T GetValue()
   {
      T result = default;

      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);
         result = value;
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrier);
      }

      return result;
   }

   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public Task<T> GetValueAsync()
   {
      T result;

      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);
         result = value;

         return Task.FromResult(result);
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrier);
      }
   }

   public T SetValue(T value)
   {
      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);

         return this.value = value;
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrier);
      }
   }

   public Task<T> SetValueAsync(T value)
   {
      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);

         return Task.FromResult(this.value = value);
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
      if (func == null) return value;

      var lockTaken = false;

      try
      {
         spinLock.TryEnter(-1, ref lockTaken);
         var result = value = func(value);

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

         return value = await func(value);
      }
      finally
      {
         if (lockTaken)
            spinLock.Exit(useMemoryBarrier);
      }
   }
}