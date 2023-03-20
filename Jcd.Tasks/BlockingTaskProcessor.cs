using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global

namespace Jcd.Tasks;

/// <summary>
/// Represents a high level object that enqueues and executes actions, functions, and unstarted tasks,
/// waiting for each to complete before executing the next.
/// </summary>
/// <remarks>
/// <para>
/// You must ensure all shared resources for the enqueued tasks have their access synchronized
/// appropriately.
/// </para>
/// <para>
/// NOTE: This was really just a thought experiment. There are probably legitimately better ways of
/// doing this built in to .Net. I had trouble finding them. If you find them, please let me know!
/// </para>
/// </remarks>
public class BlockingTaskProcessor : IDisposable
{
    private CancellationTokenSource _taskProcessingCancellationSource = new();

    private BlockingCollection<Task> _taskQueue = new();

    private Task _taskProcessor;

    private readonly SemaphoreSlim _queueManagementSemaphore = new(1, 1);

    private readonly SynchronizedValue<bool> _paused = new();

    /// <summary>
    /// The number of pending commands.
    /// </summary>
    public int QueueLength => _taskQueue.Count;

    /// <summary>
    /// Constructs a <see cref="BlockingTaskProcessor"/>
    /// </summary>
    /// <param name="autoStart"></param>
    public BlockingTaskProcessor(bool autoStart = true)
    {
        _taskProcessor = UnstartedTask.Create(TaskExecutionLoop, _taskProcessingCancellationSource.Token);
        if (autoStart) StartProcessing();
    }

    #region Command and Task Queuing

    /// <summary>
    /// Enqueues an action. This is a "fire and forget" method. Control is immediately
    /// returned to the caller.
    /// </summary>
    /// <param name="command">The action to enqueue.</param>
    public void Enqueue(Action command) =>
        TryEnqueueTask(UnstartedTask.Create(command, _taskProcessingCancellationSource.Token), out _);

    /// <summary>
    /// Enqueues an async action. This is a "fire and forget" method.
    /// Control is returned to the caller immediately.
    /// </summary>
    /// <param name="command">The asynchronous action to enqueue.</param>
    public void Enqueue(Func<Task> command) =>
        TryEnqueueTask(UnstartedTask.Create(command, _taskProcessingCancellationSource.Token), out _);

    /// <summary>
    /// Enqueues a function. This is a "fire and forget" method.
    /// The function result will not be available and control is immediately returned to the caller.
    /// </summary>
    /// <param name="command">The command to enqueue.</param>
    public void Enqueue<TResult>(Func<TResult> command) =>
        TryEnqueueTask(UnstartedTask.Create(command, _taskProcessingCancellationSource.Token), out _);

    /// <summary>
    /// Enqueues an async function. This is a "fire and forget" method.
    /// The function result will not be available and control is immediately returned to the caller.
    /// </summary>
    /// <param name="command">The async function to enqueue.</param>
    public void Enqueue<TResult>(Func<Task<TResult>> command) =>
        TryEnqueueTask(UnstartedTask.Create(command, _taskProcessingCancellationSource.Token), out _);

    /// <summary>
    /// Enqueues an action and returns a proxy task that will execute the action.
    /// Awaiting the returned proxy <see cref="Task"/> waits for the enqueued action to finish executing.
    /// </summary>
    /// <param name="command">The action to execute.</param>
    /// <returns>The <see cref="Task"/> that will execute the enqueued action.</returns>
    /// <remarks>
    /// Awaiting this task before <see cref="StartProcessing"/> is called will cause the calling
    /// thread of execution to block until <see cref="StartProcessing"/> is called. Ensure that
    /// either <see cref="StartProcessing"/> has already been called, or that your program has
    /// a mechanism in another thread to call <see cref="StartProcessing"/>. You really need to
    /// call <see cref="StartProcessing"/> for awaiting the result to work.
    /// </remarks>
    public Task EnqueueAndGetProxy(Action command) =>
        TryEnqueueTask(UnstartedTask.Create(command, _taskProcessingCancellationSource.Token), out _);

    /// <summary>
    /// Enqueues an async action and returns a proxy task that will execute the action.
    /// Awaiting the returned proxy <see cref="Task"/> waits for the enqueued action to finish executing.
    /// </summary>
    /// <param name="command">The async action to enqueue.</param>
    /// <returns>The <see cref="Task{T}"/> that will execute the enqueued action.</returns>
    /// <remarks>
    /// Awaiting this task before <see cref="StartProcessing"/> is called will cause the calling
    /// thread of execution to block until <see cref="StartProcessing"/> is called. Ensure that
    /// either <see cref="StartProcessing"/> has already been called, or that your program has
    /// a mechanism in another thread to call <see cref="StartProcessing"/>. You really need to
    /// call <see cref="StartProcessing"/> for awaiting the result to work.
    /// </remarks>
    public Task EnqueueAndGetProxy(Func<Task> command) =>
        TryEnqueueTask(UnstartedTask.Create(command, _taskProcessingCancellationSource.Token), out _);

    /// <summary>
    /// Enqueues a function and returns a proxy task that will execute the function.
    /// Awaiting the returned <see cref="Task"/> waits for the enqueued function to finish executing
    /// and returns the result.
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
    public Task<TResult> EnqueueAndGetProxy<TResult>(Func<TResult> command) =>
        TryEnqueueTask(UnstartedTask.Create(command, _taskProcessingCancellationSource.Token), out _);

    /// <summary>
    /// Enqueues an async function and returns a proxy task that will execute the function.
    /// Awaiting the returned <see cref="Task"/> waits for the enqueued function to finish executing
    /// and returns the result.
    /// </summary>
    /// <param name="command">The async function to enqueue.</param>
    /// <typeparam name="TResult">The data type returned by the function.</typeparam>
    /// <returns>The <see cref="Task{T}"/> that will execute the enqueued action.</returns>
    /// <remarks>
    /// Awaiting this task before <see cref="StartProcessing"/> is called will cause the calling
    /// thread of execution to block until <see cref="StartProcessing"/> is called. Ensure that
    /// either <see cref="StartProcessing"/> has already been called, or that your program has
    /// a mechanism in another thread to call <see cref="StartProcessing"/>. You really need to
    /// call <see cref="StartProcessing"/> for awaiting the result to work.
    /// </remarks>
    public Task<TResult> EnqueueAndGetProxy<TResult>(Func<Task<TResult>> command) =>
        TryEnqueueTask(UnstartedTask.Create(command, _taskProcessingCancellationSource.Token), out _);

    /// <summary>
    /// Tries to enqueues a task for later execution. If the passed in task is not unstarted,
    /// it's not enqueued.
    /// </summary>
    /// <param name="task">the unstarted task</param>
    /// <param name="enqueued">a flag indicating if the task was actually enqueued</param>
    /// <typeparam name="TResult">The result type of the task.</typeparam>
    /// <returns>The passed in task.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="task"/> is <see langword="null"/> </exception>
    /// <remarks>
    /// <para>
    /// When passing in a previously started task the task is returned so that you can still await
    /// the result of the associated action. This is to support framework builders who may not control
    /// if a task is started or not.
    /// </para>
    /// <para>
    /// The reason for not enqueuing is to prevent such tasks, which can't be started, from
    /// occupying a position in the execution queue. This allows the processor to get to actual
    /// unstarted tasks sooner.
    /// </para>
    /// </remarks>
    public Task<TResult> TryEnqueueTask<TResult>(Task<TResult> task, out bool enqueued)
    {
        if (task == null) throw new ArgumentNullException(nameof(task));
        enqueued = false;
        TryEnqueueTask(task as Task, out enqueued);
        return task;
    }

    /// <summary>
    /// Tries to enqueues a task for later execution. If the passed in task is already
    /// started, it's not enqueued.
    /// </summary>
    /// <param name="task">the unstarted task</param>
    /// <param name="enqueued">a flag indicating if the task was actually enqueued.</param>
    /// <returns>The passed in task.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="task"/> is <see langword="null"/> </exception>
    /// <remarks>
    /// <para>
    /// When passing in a previously started task the task is still returned so that you can still await the result
    /// of the associated action. This is to support framework builders who may not control
    /// if a task is unstarted or not.
    /// </para>
    /// <para>
    /// The reason for not enqueuing is to prevent such tasks, which can't be started, from
    /// occupying a position in the execution queue. This allows the processor to get to actual
    /// unstarted tasks sooner.
    /// </para>
    /// </remarks>
    public Task TryEnqueueTask(Task task, out bool enqueued)
    {
        Debug.WriteLine($"{nameof(TryEnqueueTask)} called from Thread {Environment.CurrentManagedThreadId}");
        Debug.Flush();
        enqueued = false;
        if (task == null) throw new ArgumentNullException(nameof(task));
        if (!task.IsUnstarted()) return task;
        try
        {
            _queueManagementSemaphore.Wait();
            _taskQueue.Add(task);
            enqueued = true;
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
    public bool HasTasks => _taskQueue.Count > 0;

    /// <summary>
    /// Signals the task processor to halt all processing immediately. This also cancels all
    /// tasks created by this task task processor. This is mostly intended to be called
    /// during application shutdown.
    /// </summary>
    public void Cancel()
    {
        Debug.WriteLine($"{nameof(Cancel)} called from Thread {Environment.CurrentManagedThreadId}");
        Debug.Flush();
        _taskProcessingCancellationSource.Cancel();
        if (_taskProcessor.Status == TaskStatus.Running ||
            _taskProcessor.Status == TaskStatus.WaitingForChildrenToComplete)
            _taskProcessor.Wait();
        _queueManagementSemaphore.Wait();
        _taskProcessor = UnstartedTask.Create(TaskExecutionLoop, _taskProcessingCancellationSource.Token);
        _taskProcessingCancellationSource.Dispose();
        _taskProcessingCancellationSource = new CancellationTokenSource();
        _queueManagementSemaphore.Release();
        RemoveAllTasks();
    }

    /// <summary>
    /// Gets a flag indicating if the task processing has started. (it might be paused though).
    /// </summary>
    public bool IsStarted => !_taskProcessor.IsUnstarted();

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
    /// Resumes task processing.
    /// </summary>
    public async Task ResumeAsync() =>
        await _paused.SetValueAsync(false);

    /// <summary>
    /// Starts the processing of queued tasks.
    /// </summary>
    public void StartProcessing()
    {
        if (_taskProcessor?.Status == TaskStatus.Running)
        {
            return;
        }

        if (_taskProcessor != null && _taskProcessor.IsUnstarted())
        {
            _taskProcessor.Start();
        }
        else
        {
            _taskProcessor = UnstartedTask.Create(TaskExecutionLoop, _taskProcessingCancellationSource.Token);
            _taskProcessor.Start();
        }
    }

    private void RemoveAllTasks()
    {
        Debug.WriteLine(nameof(RemoveAllTasks));
        try
        {
            _queueManagementSemaphore.Wait();
            _taskQueue.Dispose();
            _taskQueue = new BlockingCollection<Task>();
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

            var cancellationSource = _taskProcessingCancellationSource;
            while (!cancellationSource.IsCancellationRequested)
            {
                if (IsPaused)
                {
                    Task.Yield(); // yield some CPU time.
                    continue;
                }

                if (!TryGetTask(cancellationSource, out var task) || !task.IsUnstarted())
                {
                    if (task != null)
                    {
                        Debug.WriteLineIf(!task.IsUnstarted(),
                            $"{nameof(TaskExecutionLoop)} : invalid task status {task.Status}.");
                    }

                    continue;
                }

                TryRunAndWait(task, cancellationSource);
                Task.Yield(); // yield some CPU time.
            }
        }
        finally
        {
            Debug.WriteLine($"Exiting {nameof(TaskExecutionLoop)}");
            Debug.Flush();
        }
    }

    private static void TryRunAndWait(Task task, CancellationTokenSource cancellationSource)
    {
        if (cancellationSource.IsCancellationRequested)
        {
            return;
        }

        try
        {
            task
                .Run()
                .Wait(cancellationSource.Token);
        }
        catch (OperationCanceledException)
        {
            // do nothing. This is expected if lots of tasks are pending and Cancel has been called.
        }
    }

    private bool TryGetTask(CancellationTokenSource cancellationSource, out Task item)
    {
        try
        {
            _queueManagementSemaphore.Wait();
            if (!cancellationSource.IsCancellationRequested)
            {
                var result = _taskQueue.TryTake(out item);
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
        _taskQueue?.Dispose();
        _taskProcessingCancellationSource?.Dispose();
        _queueManagementSemaphore.Dispose();
    }
}