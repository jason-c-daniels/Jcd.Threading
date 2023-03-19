// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.BoxingAllocation
namespace Jcd.Tasks.Examples;

public static class UnstartedTaskExample
{
    /// <summary>
    /// Runs the example code. Returns 0 if successful. Throws an exception otherwise.
    /// </summary>
    /// <returns>0</returns>
    public static async Task<int> Run()
    {
        //--------------------------------------------
        // create an unstarted task from an action.
        //--------------------------------------------
        var ctA = UnstartedTask.Create(() => Console.WriteLine("I'm an unstarted task from an action."));
        Console.WriteLine($"ctA.Status = {ctA.Status} | Is it an unstarted task? {ctA.IsUnstarted()}");

        // start the unstarted task.
        ctA.Start();
        Console.WriteLine($"Is ctA an unstarted task? {ctA.IsUnstarted()}");
        await ctA; // wait for it to finish. Should do the output between ctA.Start() and here.
        // don't do this though, starting it a second time gives an exception.
        Console.Write("Try starting it again! (it won't work); ");
        try {ctA.Start(); } catch(Exception ex){Console.WriteLine($"Bad Programmer Error: {ex.Message}");}
        Console.WriteLine();

        //--------------------------------------------
        // create an unstarted task from an async action.
        //--------------------------------------------
        var ctaA = UnstartedTask.Create(async () =>
        {
            await Task.Delay(1000);
            Console.WriteLine("I'm an unstarted task from an async action.");
        });

        // start the unstarted task.
        ctaA.Start();
        Console.WriteLine($"Is ctaA an unstarted task? {ctaA.IsUnstarted()}");
        await ctaA; // wait for it to finish. Should do the output between ctaA.Start() and here.

        Console.WriteLine();

        //--------------------------------------------
        // create an unstarted task from a function
        //--------------------------------------------
        var ctF = UnstartedTask.Create(() => TimesTen(10));
        Console.WriteLine($"ctF.Status = {ctF.Status} | Is it an unstarted task? {ctF.IsUnstarted()}");

        // start the task.
        ctF.Start();
        Console.WriteLine($"Is ctF an unstarted task? {ctF.IsUnstarted()}");
        Console.WriteLine($"The result of the task is {await ctF}");

        Console.WriteLine();

        //--------------------------------------------
        // create an unstarted task from an async function
        //--------------------------------------------
        var ctaF = UnstartedTask.Create(async ()=>await TimesTenAsync(12));

        Console.WriteLine($"ctaF.Status = {ctaF.Status} | Is it an unstarted task? {ctaF.IsUnstarted()}");

        // start the task.
        ctaF.Start();
        Console.WriteLine($"Is ctaF an unstarted task? {ctaF.IsUnstarted()}");
        Console.WriteLine($"The result of the task is {await ctaF}");

        Console.WriteLine();


        // another no-no, saved for the end. It'll hang the app.
        var unstarted = UnstartedTask.Create(() => { /* This part is unimportant. */ });
        Console.WriteLine($"unstarted.Status = {unstarted.Status} | Is it an unstarted task? {unstarted.IsUnstarted()}");
        Console.WriteLine("Now we await the unstarted task and wait forever. (Press CTRL-C to end)");
        await unstarted;

        int TimesTen(int input) => input * 10;

        async Task<int> TimesTenAsync(int input)
        {
            await Task.Delay(1000);
            return input * 10;
        }

        return 0;

    }
}