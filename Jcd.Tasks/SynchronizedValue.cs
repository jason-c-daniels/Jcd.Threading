using System;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global

namespace Jcd.Tasks;

/// <summary>
/// Provides a simple async-safe method of setting, getting, and altering values intended
/// to be shared among tasks and threads.
/// </summary>
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
/// time. See the documentation for <see cref="ChangeValue"/> and <see cref="ChangeValueAsync"/>
/// for recursive reentrancy considerations. <i>(don't try it)</i>
/// </para>
/// </remarks>
public class SynchronizedValue<T> : IDisposable
{
    private readonly SemaphoreSlim _lock;
    private T _value;

    /// <summary>
    /// Constructs an <see cref="SimpleInterlockedValue{T}"/> instance.
    /// </summary>
    /// <param name="initialValue">The starting value.</param>
    public SynchronizedValue(T initialValue = default)
    {
        _lock = new SemaphoreSlim(1, 1);
        _value = initialValue;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _lock.Dispose();
    }

    #region properties and accessors

    /// <summary>
    /// Get the synchronized value.
    /// </summary>
    /// <example>
    /// <code>
    /// var sv = new SimpleInterlockedValue&lt;int&gt;(15);
    /// 
    /// // get the value
    /// setValue = sv.Value;
    /// 
    /// </code>
    /// </example>
    public T Value => GetValue();

    /// <summary>
    /// Gets the value in an async friendly manner.
    /// </summary>
    /// <returns>A <see cref="Task{T}"/> containing the retrieved value.</returns>
    /// <example>
    /// <code>
    /// var sv = new SimpleInterlockedValue&lt;int&gt;(15);
    /// 
    /// // get the value
    /// await setValue = sv.GetValueAsync(20);
    /// 
    /// </code>
    /// </example>
    public Task<T> GetValueAsync()
    {
        return InternalExecuteAsync(null);
    }

    /// <summary>
    /// Sets the current value to the provided value.
    /// </summary>
    /// <param name="value">The provided value.</param>
    /// <returns>A <see cref="Task{T}"/> containing the provided value.</returns>
    /// <example>
    /// <code>
    /// var sv = new SimpleInterlockedValue&lt;int&gt;();
    /// 
    /// // set the value to 10.
    /// await setValue = sv.SetValueAsync(10);
    /// 
    /// // set the value to 20.
    /// await setValue = sv.SetValueAsync(20);
    /// 
    /// </code>
    /// </example>
    public Task<T> SetValueAsync(T value)
    {
        return InternalExecuteAsync((_)=>Task.FromResult(value));
    }

    /// <summary>
    /// Retrieves the current value. If another thread edits the value, moment later a subsequent
    /// call will yield a different result. 
    /// </summary>
    /// <returns>The current value as of establishing the lock.</returns>
    /// <example>
    /// <code>
    /// var sv = new SimpleInterlockedValue&lt;int&gt;(15);
    /// 
    /// // get the value
    /// setValue = sv.GetValue(20);
    /// 
    /// </code>
    /// </example>
    public T GetValue()
    {
        return InternalExecute(null);
    }

    /// <summary>
    /// Sets the current value to the provided value.
    /// </summary>
    /// <param name="value">The provided value.</param>
    /// <returns>The provided value.</returns>
    /// <example>
    /// <code>
    /// var sv = new SimpleInterlockedValue&lt;int&gt;();
    /// 
    /// // set the value to 10.
    /// setValue = sv.SetValue(10);
    /// 
    /// // set the value to 20.
    /// setValue = sv.SetValue(20);
    /// 
    /// </code>
    /// </example>
    public T SetValue(T value)
    {
        return InternalExecute(_ => value);
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
    /// var sv = new SimpleInterlockedValue&lt;int&gt;();
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
    /// var sv=new SimpleInterlockedValue&lt;int&gt;(10);
    ///
    /// // deadlock yourself in a single line of code!
    /// var changedValue = sv.Do(x=>sv.Value+10);
    /// </code>
    /// </remarks>
    public T ChangeValue(Func<T, T> func) { return InternalExecute(func); }

    private T InternalExecute(Func<T, T> func)
    {
        _lock.Wait();
        var result = _value;
        if (func != null)
            result = _value = func(_value);
        _lock.Release();
        return result;
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
    /// var sv = new SimpleInterlockedValue&lt;int&gt;();
    /// 
    /// // increment the value by one.
    /// var changedValue = await sv.DoAsync(x => x + 1);
    /// 
    /// // increment the value by two.
    /// changedValue = await sv.DoAsync(x => x + 2);
    /// 
    /// // Perform some operation that requires the value to remain unchanged during the operation.
    /// var sameValue = await sv.DoAsync(x => { DoSomething(x); return x;});
    /// </code>
    /// </example>
    /// <remarks>
    /// <para>
    /// <b>WARNING:</b>This is <b>not</b> a recursively reentrant method. Never write code like
    /// the following.
    /// </para>
    /// <code>
    /// var sv=new SimpleInterlockedValue&lt;int&gt;(10);
    ///
    /// // deadlock yourself in a single line of code!
    /// var changedValue = await sv.ChangeValueAsync(x=>sv.Value+10);
    /// </code>
    /// </remarks>
    public Task<T> ChangeValueAsync(Func<T, Task<T>> func) { return InternalExecuteAsync(func); }

    private async Task<T> InternalExecuteAsync(Func<T, Task<T>> func)
    {
        await _lock.WaitAsync();
        var result = _value;
        if (func != null)
            result = _value = await func(_value);
        _lock.Release();
        return result;
    }

    public void Do(Action<T> action)
    {
        if (action != null)
        {
            InternalExecute(t => { action(t); return t; });
        }
    }

    public Task DoAsync(Func<T, Task> asyncAction)
    {
        return asyncAction == null 
                   ? Task.CompletedTask 
                   : InternalExecuteAsync(t => { asyncAction(t); return Task.FromResult(t); });
    }

    #endregion
}