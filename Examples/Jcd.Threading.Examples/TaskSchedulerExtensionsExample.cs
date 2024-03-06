using Jcd.Threading.Tasks;

namespace Jcd.Threading.Examples;

public static class TaskSchedulerExtensionsExample
{
   public static async Task Run()
   {
      // create an instance of the custom TaskScheduler
      var scheduler = new MyTaskScheduler();

      // execute an action with the scheduler.
      await scheduler.Run(() => Log("Execute an action."));

      // execute a function with the scheduler and return the result.
      var result = await scheduler.Run(() => Log("Execute a function and return its result", 10));
      Console.WriteLine($"result: {result}");

      // execute an async action with the scheduler.
      await scheduler.Run(() => LogAsync("Execute an async action."));

      // execute an async function with the scheduler and return the result.
      result = await scheduler.Run(() => LogAsync("Execute an async function and return its result", 20));
      Console.WriteLine($"result: {result}");
   }

   private static void Log(string text) { Console.WriteLine($"[{TaskScheduler.Current.GetType().Name}] : {text}"); }

   private static Task LogAsync(string text)
   {
      Log(text);

      return Task.CompletedTask;
   }

   private static TResult Log<TResult>(string text, TResult result)
   {
      Log(text);

      return result;
   }

   private static Task<TResult> LogAsync<TResult>(string text, TResult result)
   {
      return Task.FromResult(Log(text, result));
   }

   // ---------------------------------------------------------------
   // The code for the custom scheduler.
   //

   /// <summary>
   /// A non-queuing TaskScheduler that immediately executes its queued work.
   /// </summary>
   public class MyTaskScheduler : TaskScheduler
   {
      protected override IEnumerable<Task> GetScheduledTasks() { return Array.Empty<Task>(); }

      protected override void QueueTask(Task task) { TryExecuteTask(task); }

      protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
      {
         return TryExecuteTask(task);
      }
   }
}