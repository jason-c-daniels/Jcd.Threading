namespace Jcd.Tasks.Examples;

public class ColdTaskExample
{
    /// <summary>
    /// Runs the example code. Returns 0 if successful. Throws an exception otherwise.
    /// </summary>
    /// <returns>0</returns>
    public static async Task<int> Run()
    {
        //--------------------------------------------
        // create a cold task from an action.
        //--------------------------------------------
        var ctA = ColdTask.FromAction(() => Console.WriteLine("I'm a cold task from an action."));
        Console.WriteLine($"ctA.Status = {ctA.Status} | Is it a cold task? {ctA.IsCold()}");

        // start the cold task.
        ctA.Start();
        Console.WriteLine($"Is ctA a cold task? {ctA.IsCold()}");
        await ctA; // wait for it to finish. Should do the output between ctA.Start() and here.
        // don't do this though, starting it a second time gives an exception.
        Console.Write("Try starting it again! (it won't work); ");
        try {ctA.Start(); } catch(Exception ex){Console.WriteLine($"Bad Programmer Error: {ex.Message}");}
        Console.WriteLine();

        //--------------------------------------------
        // create a cold task from an async action.
        //--------------------------------------------
        var ctaA = ColdTask.FromAsyncAction(async () =>
        {
            await Task.Delay(1000);
            Console.WriteLine("I'm a cold task from an async action.");
        });

        // start the cold task.
        ctaA.Start();
        Console.WriteLine($"Is ctaA a cold task? {ctaA.IsCold()}");
        await ctaA; // wait for it to finish. Should do the output between ctaA.Start() and here.

        Console.WriteLine();

        //--------------------------------------------
        // create a cold task from a function
        //--------------------------------------------
        var ctF = ColdTask.FromFunc(() => TimesTen(10));
        Console.WriteLine($"ctF.Status = {ctF.Status} | Is it a cold task? {ctF.IsCold()}");

        // start the cold task.
        ctF.Start();
        Console.WriteLine($"Is ctF a cold task? {ctF.IsCold()}");
        Console.WriteLine($"The result of the cold task is {await ctF}");

        Console.WriteLine();

        //--------------------------------------------
        // create a cold task from an async function
        //--------------------------------------------
        var ctaF = ColdTask.FromAsyncFunc(async ()=>await TimesTenAsync(12));

        Console.WriteLine($"ctaF.Status = {ctaF.Status} | Is it a cold task? {ctaF.IsCold()}");

        // start the cold task.
        ctaF.Start();
        Console.WriteLine($"Is ctaF a cold task? {ctaF.IsCold()}");
        Console.WriteLine($"The result of the cold task is {await ctaF}");

        Console.WriteLine();


        // another no-no, saved for the end. It'll hang the app.
        var unstarted = ColdTask.FromAction(() => { /* This part is unimportant. */ });
        Console.WriteLine($"unstarted.Status = {unstarted.Status} | Is it a cold task? {unstarted.IsCold()}");
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