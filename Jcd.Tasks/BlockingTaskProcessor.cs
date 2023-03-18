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
public class BlockingTaskProcessor : IDisposable
{
    private CancellationTokenSource _commandProcessingCancellationSource = new ();

    private BlockingCollection<Task> _commandQueue = new ();

    private Task _commandProcessor;

    private readonly SemaphoreSlim _queueManagementSemaphore = new (1,1);
    
    private readonly SynchronizedValue<bool> _paused= new ();
    
    /// <summary>
    /// The number of pending commands.
    /// </summary>
    public int QueueLength => _commandQueue.Count;

    /// <summary>
    /// Constructs a <see cref="BlockingTaskProcessor"/>
    /// </summary>
    /// <param name="autoStart"></param>
    public BlockingTaskProcessor(bool autoStart=true)
    {
        _commandProcessor = ColdTask.FromAction(TaskExecutionLoop);
        if (autoStart) StartProcessing();
    }
    
    #region Command and Task Queuing
    
    /// <summary>
    /// Enqueues a command for sequential execution. This is a "fire and forget" method.
    /// Control is returned to the caller immediately.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    public void EnqueueAction(Action command) =>
        EnqueueTask(ColdTask.FromAction(command, _commandProcessingCancellationSource.Token));
    
    /// <summary>
    /// Enqueues an async command for sequential execution. This is a "fire and forget" method.
    /// Control is returned to the caller immediately.
    /// </summary>
    /// <param name="command">The asynchronous command to execute.</param>
    public void EnqueueAsyncAction(Func<Task> command) =>
        EnqueueTask(ColdTask.FromAsyncAction(command,_commandProcessingCancellationSource.Token));

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
    public Task EnqueueActionAsync(Action command) =>
        EnqueueTask(ColdTask.FromAction(command,_commandProcessingCancellationSource.Token));

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
    public Task EnqueueAsyncActionAsync(Func<Task> command) =>
        EnqueueTask(ColdTask.FromAsyncAction(command,_commandProcessingCancellationSource.Token));

    /// <summary>
    /// Enqueues a command for sequential execution. This is a "fire and forget" method.
    /// The command result will not be available and control is returned to the caller immediately.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    public void EnqueueFunc<TResult>(Func<TResult> command) =>
        EnqueueTask(ColdTask.FromFunc(command,_commandProcessingCancellationSource.Token));
 
    /// <summary>
    /// Enqueues an async command for sequential execution. This is a "fire and forget" method.
    /// The function call result will not be available and control is returned to the caller immediately.
    /// </summary>
    /// <param name="command">The async command to execute.</param>
    public void EnqueueAsyncFunc<TResult>(Func<Task<TResult>> command) =>
        EnqueueTask(ColdTask.FromAsyncFunc(command,_commandProcessingCancellationSource.Token));

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
    public Task<TResult> EnqueueFuncAsync<TResult>(Func<TResult> command) =>
        EnqueueTask(ColdTask.FromFunc(command,_commandProcessingCancellationSource.Token));
    
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
    public Task<TResult> EnqueueAsyncFuncAsync<TResult>(Func<Task<TResult>> asyncFunction) =>
        EnqueueTask(ColdTask.FromAsyncFunc(asyncFunction,_commandProcessingCancellationSource.Token));

    /// <summary>
    /// Enqueues a cold task for later execution. If the passed in task is not cold, it's not enqueued.
    /// </summary>
    /// <param name="task">the cold task</param>
    /// <typeparam name="T">The result type of the task.</typeparam>
    /// <returns>The passed in task.</returns>
    /// <exception cref="ArgumentNullException">When the task is null</exception>
    /// <remarks>
    /// <para>
    /// When passing in a non-cold task the task is returned so that you can still await the result
    /// of the associated action. This is to support framework builders who may not control
    /// if a task is hot or cold.
    /// </para>
    /// <para>
    /// The reason for not enqueuing is to prevent such tasks, which can't be started, from
    /// occupying a position in the execution queue. This allows the processor to 
    /// </para>
    /// </remarks>
    public Task<T> EnqueueTask<T>(Task<T> task)
    {
        EnqueueTask((Task)task);
        return task;
    }

    /// <summary>
    /// Enqueues a cold task for later execution. If the passed in task is not cold, it's not enqueued.
    /// </summary>
    /// <param name="task">the cold task</param>
    /// <returns>The passed in task.</returns>
    /// <exception cref="ArgumentNullException">When the task is null</exception>
    /// <remarks>
    /// When passing in a non-cold task the task is returned so that you can still await the result
    /// of the associated action. This is to support framework builders who may not control
    /// if a task is hot or cold.
    /// </remarks>
    public Task EnqueueTask(Task task)
    {
        Debug.WriteLine($"{nameof(EnqueueTask)} called from Thread {Environment.CurrentManagedThreadId}");
        Debug.Flush();
        if (task == null) throw new ArgumentNullException(nameof(task));
        if (!task.IsCold()) return task;
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
    
    #region Task Queue Management and Processing

    /// <summary>
    /// Gets a flag indicating if there are any pending tasks.
    /// </summary>
    public bool HasTasks => _commandQueue.Count > 0;
        
    /// <summary>
    /// Signals the command processor to halt all processing immediately. This also cancels all tasks created
    /// by this task command processor. This is mostly intended to be called during application shutdown.
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

        _commandProcessor = ColdTask.FromAction(TaskExecutionLoop);
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
            task
                .StartEx()
                .Wait(cancellationSource.Token);
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