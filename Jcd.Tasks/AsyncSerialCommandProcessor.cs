using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Jcd.Tasks;

/// <summary>
/// In a background task, this class executes arbitrary tasks in the order they were enqueued,
/// waiting for each to complete before executing the next.
/// </summary>
/// <remarks>
/// Ensure all shared resources for the enqueued actions/functions have their access synchronized
/// appropriately.
/// </remarks>
public class AsyncSerialCommandProcessor : IDisposable
{
    private CancellationTokenSource _commandProcessingCancellationSource = new ();

    private BlockingCollection<Task> _commandQueue = new ();

    private Task _commandProcessor;

    private readonly SemaphoreSlim _queueManagementSemaphore = new (1,1);
    
    private readonly SynchronizedValue<bool> _paused= new ();

    /// <summary>
    /// Constructs a <see cref="AsyncSerialCommandProcessor"/>
    /// </summary>
    /// <param name="autoStart"></param>
    public AsyncSerialCommandProcessor(bool autoStart=true)
    {
        _commandProcessor = ColdTask.From(TaskExecutionLoop);
        if (autoStart) StartProcessing();
    }

    /// <summary>
    /// The number of pending commands.
    /// </summary>
    public int QueueLength => _commandQueue.Count;
    
    #region Command Queuing
    
    /// <summary>
    /// Enqueues a command for sequential execution. This is a "fire and forget" method.
    /// Control is returned to the caller immediately.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    public void Enqueue(Action command) =>
        EnqueueTask(ColdTask.From(command, _commandProcessingCancellationSource.Token));
    
    /// <summary>
    /// Enqueues an async command for sequential execution. This is a "fire and forget" method.
    /// Control is returned to the caller immediately.
    /// </summary>
    /// <param name="command">The asynchronous command to execute.</param>
    public void Enqueue(Func<Task> command) =>
        EnqueueTask(ColdTask.FromAsync(command,_commandProcessingCancellationSource.Token));

    /// <summary>
    /// Enqueues a command for sequential execution. Awaiting the returned <see cref="Task"/>
    /// waits for the command to finish executing.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <returns>The <see cref="Task"/> that will execute the enqueued action.</returns>
    /// <remarks>
    /// Awaiting this task before <see cref="StartProcessing"/> is called will cause the calling
    /// thread of execution to block until <see cref="StartProcessing"/> is called. Ensure that
    /// either <see cref="StartProcessing"/> has already been called, or that your program has
    /// a mechanism in another thread to call <see cref="StartProcessing"/>. You really need to
    /// call <see cref="StartProcessing"/> for awaiting the result to work.
    /// </remarks>
    public Task EnqueueAsync(Action command) =>
        EnqueueTask(ColdTask.From(command,_commandProcessingCancellationSource.Token));

    /// <summary>
    /// Asynchronously enqueues an async command for sequential execution. Awaiting the
    /// returned <see cref="Task"/> waits for the command to finish executing.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <returns>The <see cref="Task{T}"/> that will execute the enqueued action.</returns>
    /// <remarks>
    /// Awaiting this task before <see cref="StartProcessing"/> is called will cause the calling
    /// thread of execution to block until <see cref="StartProcessing"/> is called. Ensure that
    /// either <see cref="StartProcessing"/> has already been called, or that your program has
    /// a mechanism in another thread to call <see cref="StartProcessing"/>. You really need to
    /// call <see cref="StartProcessing"/> for awaiting the result to work.
    /// </remarks>
    public Task EnqueueAsync(Func<Task> command) =>
        EnqueueTask(ColdTask.FromAsync(command,_commandProcessingCancellationSource.Token));

    /// <summary>
    /// Enqueues a command for sequential execution. This is a "fire and forget" method.
    /// The command result will not be available and control is returned to the caller immediately.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    public void Enqueue<TResult>(Func<TResult> command) =>
        EnqueueTask(ColdTask.From(command,_commandProcessingCancellationSource.Token));
 
    /// <summary>
    /// Enqueues an async command for sequential execution. This is a "fire and forget" method.
    /// The function call result will not be available and control is returned to the caller immediately.
    /// </summary>
    /// <param name="command">The async command to execute.</param>
    public void Enqueue<TResult>(Func<Task<TResult>> command) =>
        EnqueueTask(ColdTask.FromAsync(command,_commandProcessingCancellationSource.Token));

    /// <summary>
    /// Asynchronously enqueues a command for sequential execution. The result of the function
    /// execution is available by awaiting the returned <see cref="Task{T}"/>
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <typeparam name="TResult">The data type returned by the function</typeparam>
    /// <returns>The <see cref="Task{T}"/> that will execute the enqueued action, once dequeued.</returns>
    /// <remarks>
    /// Awaiting this task before <see cref="StartProcessing"/> is called will cause the calling
    /// thread of execution to block until <see cref="StartProcessing"/> is called. Ensure that
    /// either <see cref="StartProcessing"/> has already been called, or that your program has
    /// a mechanism in another thread to call <see cref="StartProcessing"/>. You really need to
    /// call <see cref="StartProcessing"/> for awaiting the result to work.
    /// </remarks>
    public Task<TResult> EnqueueAsync<TResult>(Func<TResult> command) =>
        EnqueueTask(ColdTask.From(command,_commandProcessingCancellationSource.Token));
    
    /// <summary>
    /// Asynchronously enqueues an async function for sequential execution. The result of the function execution
    /// is available by awaiting the returned <see cref="Task{T}"/>
    /// </summary>
    /// <param name="asyncFunction">The async function to execute.</param>
    /// <typeparam name="TResult">The data type returned by the function</typeparam>
    /// <returns>The <see cref="Task{T}"/> that will execute the enqueued action.</returns>
    /// <remarks>
    /// Awaiting this task before <see cref="StartProcessing"/> is called will cause the calling
    /// thread of execution to block until <see cref="StartProcessing"/> is called. Ensure that
    /// either <see cref="StartProcessing"/> has already been called, or that your program has
    /// a mechanism in another thread to call <see cref="StartProcessing"/>. You really need to
    /// call <see cref="StartProcessing"/> for awaiting the result to work.
    /// </remarks>
    public Task<TResult> EnqueueAsync<TResult>(Func<Task<TResult>> asyncFunction) =>
        EnqueueTask(ColdTask.FromAsync(asyncFunction,_commandProcessingCancellationSource.Token));

    private Task<T> EnqueueTask<T>(Task<T> task)
    {
        EnqueueTask((Task)task);
        return task;
    }

    private Task EnqueueTask(Task task)
    {
        Debug.WriteLine($"{nameof(EnqueueTask)} called from Thread {Environment.CurrentManagedThreadId}");
        Debug.Flush();
        try
        {
            _queueManagementSemaphore.Wait();
            _commandQueue.Add(task);
            return task;
        }
        finally
        {
            _queueManagementSemaphore.Release();
        }
    }
    
    #endregion
        
    #region Command Processing

    /// <summary>
    /// Gets a flag indicating if there are any pending tasks.
    /// </summary>
    public bool HasTasks => _commandQueue.Count > 0;
        
    /// <summary>
    /// Signals the task executor to halt all processing immediately. This also cancels all tasks created
    /// by this task executor instance. This is mostly intended to be called during application shutdown.
    /// </summary>
    public void Cancel()
    {
        Debug.WriteLine($"{nameof(Cancel)} called from Thread {Environment.CurrentManagedThreadId}");
        Debug.Flush();
        _commandProcessingCancellationSource.Cancel();
        _commandProcessor.Wait();
        _commandProcessingCancellationSource.Dispose();
        _commandProcessor = null;
        _commandProcessingCancellationSource = new CancellationTokenSource();
        RemoveAllTasks();
    }
        
    /// <summary>
    /// Gets a flag indicating if the command processing has started. (it might be paused though).
    /// </summary>
    public bool IsStarted => _commandProcessor != null;
        
    /// <summary>
    /// Gets a flag indicating if the command processing is currently paused.
    /// </summary>
    public bool IsPaused => _paused.Value;

    /// <summary>
    /// Pauses the retrieval and execution of queued tasks. If a task is in the middle of being started when this is
    /// called it will still get started.
    /// </summary>
    public void Pause() =>
        _paused.SetValue(true);

    /// <summary>
    /// Resumes command processing.
    /// </summary>
    public void Resume() =>
        _paused.SetValue(false);

    /// <summary>
    /// Pauses the retrieval and execution of queued tasks. If a task is in the middle of being started
    /// when this is called it will still get started.
    /// </summary>
    public async Task PauseAsync() =>
        await _paused.SetValueAsync(true);

    /// <summary>
    /// Resumes command processing.
    /// </summary>
    public async Task ResumeAsync() =>
        await _paused.SetValueAsync(false);

    /// <summary>
    /// Starts the processing of queued commands.
    /// </summary>
    public void StartProcessing()
    {
        if (_commandProcessor?.Status == TaskStatus.Running)
        {
            return;
        }

        _commandProcessor = ColdTask.From(TaskExecutionLoop);
        _commandProcessor.Start();
    }
    
    private void RemoveAllTasks()
    {
        Debug.WriteLine(nameof(RemoveAllTasks));
        try
        {
            _queueManagementSemaphore.Wait();
            _commandQueue.Dispose();
            _commandQueue = new BlockingCollection<Task>();
        }
        finally
        {
            _queueManagementSemaphore.Release();
        }
    }
        
    private void TaskExecutionLoop()
    {
        try
        {
            Debug.WriteLine($"{nameof(TaskExecutionLoop)} starting in Thread {Environment.CurrentManagedThreadId}");

            var cancellationSource = _commandProcessingCancellationSource;
            while (!cancellationSource.IsCancellationRequested)
            {
                if (IsPaused)
                {
                    Task.Yield(); // yield some CPU time.
                    continue;
                }

                if (!TryGetTask(cancellationSource, out var task) || !task.IsCold())
                {
                    if (task != null)
                    {
                        Debug.WriteLineIf(!task.IsCold(),
                            $"{nameof(TaskExecutionLoop)} : invalid task status {task.Status}.");
                    }

                    continue;
                }

                TryExecuteAndWait(task, cancellationSource);
            }
        }
        finally
        {
            Debug.WriteLine($"Exiting {nameof(TaskExecutionLoop)}");
            Debug.Flush();
        }
    }

    private static void TryExecuteAndWait(Task task, CancellationTokenSource cancellationSource)
    {
        if (cancellationSource.IsCancellationRequested)
        {
            return;
        }

        try
        {
            task.StartThenWait(cancellationSource.Token);
        }
        catch (OperationCanceledException)
        {
            // do nothing. This is expected if lots of tasks are pending and Stop has been called.
        }
    }

    private bool TryGetTask(CancellationTokenSource cancellationSource, out Task item)
    {
        try
        {
            _queueManagementSemaphore.Wait();
            if (!cancellationSource.IsCancellationRequested)
            {
                var result= _commandQueue.TryTake(out item);
                return result;
            }
        }
        finally
        {
            _queueManagementSemaphore.Release();
        }
        item = default;
        return false;
    }

    #endregion


    /// <inheritdoc />
    public void Dispose()
    {
        Cancel();
        _paused.Dispose();
        _commandQueue?.Dispose();
        _commandProcessingCancellationSource?.Dispose();
        _queueManagementSemaphore.Dispose();
    }
}