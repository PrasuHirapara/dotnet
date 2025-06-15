using System;
using System.Threading;

public class Threading
{
    public static void Run()
    {
        // Creating a thread with a method
        Thread thread1 = new Thread(new ThreadStart(PrintNumbers));
        thread1.Name = "WorkerThread-1";
        thread1.Priority = ThreadPriority.Normal;

        // Creating a thread using lambda expression
        Thread thread2 = new Thread(() =>
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] Started.");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"[{Thread.CurrentThread.Name}] -> {i}");
                Thread.Sleep(300); // Demonstrate WaitSleepJoin state
            }
        });
        thread2.Name = "LambdaThread";
        thread2.IsBackground = true; // Set as background thread

        Console.WriteLine($"Thread1 state before start: {thread1.ThreadState}");
        Console.WriteLine($"Thread2 state before start: {thread2.ThreadState}");

        thread1.Start();
        thread2.Start();

        Console.WriteLine($"Thread1 ID: {thread1.ManagedThreadId}");
        Console.WriteLine($"Thread2 IsBackground: {thread2.IsBackground}");

        Thread.Sleep(1000); // Let threads run a bit

        // Interrupt thread1 (only affects if it’s sleeping or waiting)
        if (thread1.IsAlive)
        {
            Console.WriteLine("\nInterrupting thread1...");
            thread1.Interrupt();
        }

        // Join threads
        thread1.Join(); // Wait until thread1 finishes
        thread2.Join(); // Wait until thread2 finishes

        Console.WriteLine($"\nThread1 final state: {thread1.ThreadState}");
        Console.WriteLine($"Thread2 final state: {thread2.ThreadState}");

        Console.WriteLine("Main thread finished.");
    }

    public static void PrintNumbers()
    {
        try
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] Started.");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"[{Thread.CurrentThread.Name}] -> {i}");
                Thread.Sleep(500); // Will enter WaitSleepJoin state
            }
        }
        catch (ThreadInterruptedException)
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] was interrupted while sleeping.");
        }
    }
}
