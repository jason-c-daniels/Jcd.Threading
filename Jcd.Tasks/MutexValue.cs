using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// A value wrapper for a <see cref="SemaphoreSlim"/> to block access during reads and writes.
/// This results in singler writer or single reader access to the data.  
/// </summary>
/// <typeparam name="T">The data type to synchronize access to.</typeparam>
public sealed class MutexValue<T>: IDisposable
{
   private readonly SemaphoreSlim mutex=new SemaphoreSlim(1,1);
   private          T                    val;

   // ReSharper disable once NullableWarningSuppressionIsUsed
   /// <summary>
   /// Constructs an instance of <see cref="MutexValue{T}"/>
   /// </summary>
   /// <param name="value"the initial value to store></param>
   public MutexValue(T value = default!)
   {
      val   = value;
   }

   /// <inheritdoc />
   public void Dispose() { mutex.Dispose(); }

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
   /// var sv = new SingleWriterMultipleReaderValue&lt;int&gt;(15);
   /// 
   /// // get the value
   /// setValue = swmr.GetValue(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public T GetValue()
   {
      try
      {
         mutex.Wait();
         var result = val;

         return result;
      }
      finally
      {
         mutex.Release();
      }
   }

   /// <summary>
   /// Gets the value in an async friendly manner.
   /// </summary>
   /// <returns>A <see cref="Task{T}"/> containing the retrieved value.</returns>
   /// <example>
   /// <code>
   /// var sv = new SingleWriterMultipleReaderValue&lt;int&gt;(15);
   /// 
   /// // get the value
   /// await setValue = swmr.GetValueAsync(20);
   /// 
   /// </code>
   /// </example>
   [MethodImpl(MethodImplOptions.AggressiveInlining)]
   public Task<T> GetValueAsync()
   {
      try
      {
         mutex.Wait();
         var result = val;

         return Task.FromResult(result);
      }
      finally
      {
         mutex.Release();
      }
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
      try
      {
         mutex.Wait();
         var result = val = value;

         return result;
      }
      finally
      {
         mutex.Release();
      }
   }

   /// <summary>
   /// Sets the current value to the provided value.
   /// </summary>
   /// <param name="value">The provided value.</param>
   /// <returns>A <see cref="Task{T}"/> containing the provided value.</returns>
   /// <example>
   /// <code>
   /// var sv = new SingleWriterMultipleReaderValue&lt;int&gt;();
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
   public Task<T> SetValueAsync(T value)
   {
      try
      {
         mutex.Wait();
         var result = val = value;

         return Task.FromResult(result);
      }
      finally
      {
         mutex.Release();
      }
   }

  
   
   #endregion
}