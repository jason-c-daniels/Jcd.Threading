using System;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable MemberCanBePrivate.Global

namespace Jcd.Tasks;

/// <summary>
/// Provides a simple async-safe method of setting, getting, and altering values intended to be shared among tasks and threads.
/// </summary>
/// <remarks>
/// <para>
/// While this provides a method of easily ensuring any one shared value is appropriately
/// locked during setting or getting, you still need to thoroughly understand your
/// use case. For example, having two <see cref="SynchronizedValue{T}"/> instances accessed
/// by two different threads, in rapid succession, in different orders can cause
/// potentially unexpected results.
/// </para>
/// <para>
/// In cases where the pair/tuple must be consistent at all times across all threads,
/// consider creating a struct containing the necessary fields/properties and wrapping that
/// in a SynchronizedValue instead of each individual field/property.
/// </para>
/// <para>
/// As well this implementation uses <see cref="SemaphoreSlim"/> and requires Dispose to be called.
/// Either implement <see cref="IDisposable"/> or call it directly at the appropriate time.
/// </para>
/// </remarks>
/// <typeparam name="T">The data type to synchronize access to.</typeparam>
public class SynchronizedValue<T> : IDisposable
{
    private readonly SemaphoreSlim _lock;
    private T _value;
    
    /// <summary>
    /// Constructs an <see cref="SynchronizedValue{T}"/> instance.
    /// </summary>
    /// <param name="initialValue">The starting value.</param>
    public SynchronizedValue(T initialValue=default)
    {
        _lock = new SemaphoreSlim(1, 1);
        _value = initialValue;
    }
    
    #region properties and accessors
    
    /// <summary>
    /// The synchronized value.
    /// </summary>
    public T Value => GetValue();

    /// <summary>
    /// Gets the value in an async friendly manner.
    /// </summary>
    /// <returns>A <see cref="Task{T}"/> containing the retrieved value.</returns>
    public async Task<T> GetValueAsync()
    {
        await _lock.WaitAsync();
        var value = _value;
        _lock.Release();
        return value;
    }

    /// <summary>
    /// Sets the current value to the provided value.
    /// </summary>
    /// <param name="value">The provided value.</param>
    /// <returns>A <see cref="Task{T}"/> containing the provided value.</returns>
    public async Task<T> SetValueAsync(T value)
    {
        await _lock.WaitAsync();
        var result=_value = value;
        _lock.Release();
        return result;
    }

    /// <summary>
    /// Retrieves the current value. If another thread edits the value, moment later a subsequent
    /// call will yield a different result. 
    /// </summary>
    /// <returns>The current value as of establishing the lock.</returns>
    public T GetValue()
    {
        _lock.Wait();
        var value = _value;
        _lock.Release();
        return value;
    }
    
    /// <summary>
    /// Sets the current value to the provided value.
    /// </summary>
    /// <param name="value">The provided value.</param>
    /// <returns>The provided value.</returns>
    public T SetValue(T value)
    {
        _lock.Wait();
        var result= _value = value;
        _lock.Release();
        return result;
    }
    
    /// <summary>
    /// Calls the provided function, passing in the current value, and assigns the result of the
    /// function call, to the current value.
    /// </summary>
    /// <param name="func">The function to call.</param>
    /// <returns>The result of calling the function.</returns>
    public T ChangeValue(Func<T,T> func)
    {
        _lock.Wait();
        var result=_value = func(_value);
        _lock.Release();
        return result;
    }
 
    /// <summary>
    /// Calls the provided function, passing in the current value, and assigns the result of the
    /// function call, to the current value.
    /// </summary>
    /// <param name="func">The function to call.</param>
    /// <returns>A <see cref="Task{T}"/> containing the result of calling the function.</returns>
    public async Task<T> ChangeValueAsync(Func<T,T> func)
    {
        await _lock.WaitAsync();
        var result=_value = func(_value);
        _lock.Release();
        return result;
    }

    #endregion
    
    /// <inheritdoc />
    public void Dispose()
    {
        _lock.Dispose();
    }
}