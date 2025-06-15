using System;
using System.Threading.Tasks;

// Async and await are used to write asynchronous, non-blocking code.
// An async method allows the use of the await keyword, which pauses execution until the awaited task completes.
// This helps keep the application responsive and avoids blocking threads.

// Task represents an asynchronous operation and is part of the Task Parallel Library (TPL).
// Tasks can be used to run code in the background, wait for completion, or return results.
// Common Task-related methods and features include:
// - Task.Run(): Runs code on a separate thread from the thread pool.
// - Task.Delay(): Introduces a non-blocking delay.
// - Task.WhenAll(): Waits for all provided tasks to complete.
// - Task.WhenAny(): Continues when any one of the tasks completes.
// - Task.Result: Gets the result of a completed Task<T>.
// - task.Wait(): Blocks the calling thread until the task finishes.
// - task.IsCompleted: Checks whether the task has completed.
// - task.Start(): Starts a manually created Task.

public class AsyncAwait
{
    public static async Task Run()
    {
        Console.WriteLine("Main method started");

        Task t1 = Task.Run(() => PrintData("Task1", 1000));
        await Task.Delay(500);
        Console.WriteLine("After Task.Delay(500)");
        t1.Wait();

        Task<int> t2 = Task.Run(() => CalculateSum(10));
        int result = await t2;
        Console.WriteLine($"Sum result from Task<int>: {result}");

        Task taskA = Task.Run(() => PrintData("A", 600));
        Task taskB = Task.Run(() => PrintData("B", 400));
        await Task.WhenAll(taskA, taskB);
        Console.WriteLine("Both tasks A and B completed");

        Task taskC = Task.Run(() => PrintData("C", 1000));
        Task taskD = Task.Run(() => PrintData("D", 300));
        Task firstFinished = await Task.WhenAny(taskC, taskD);
        Console.WriteLine("One of the tasks (C or D) completed");

        Task<int> t3 = Task.Run(() => CalculateSum(5));
        Console.WriteLine($"IsCompleted: {t3.IsCompleted}");
        t3.Wait();
        Console.WriteLine($"IsCompleted after Wait: {t3.IsCompleted}");
        Console.WriteLine($"Result of t3: {t3.Result}");

        Task t4 = new Task(() => Console.WriteLine("Manual task started"));
        t4.Start();
        t4.Wait();

        Console.WriteLine("Main method completed");
    }

    public static void PrintData(string name, int delay)
    {
        Console.WriteLine($"{name} started");
        Task.Delay(delay).Wait();
        Console.WriteLine($"{name} completed");
    }

    public static int CalculateSum(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i++) sum += i;
        return sum;
    }
}
