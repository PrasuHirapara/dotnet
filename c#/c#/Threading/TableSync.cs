using System;
using System.Threading;

public class TableSync
{
    public void PrintTable(int n)
    {
        lock (this) // Locking on current instance
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{n} x {i} = {n * i}");
                try
                {
                    Thread.Sleep(400);
                }
                catch (ThreadInterruptedException ex)
                {
                    Console.WriteLine("Thread interrupted: " + ex.Message);
                }
            }
        }
    }

    public static void run()
    {
        Console.WriteLine("Main thread started");

        TableSync table = new TableSync();

        Thread t1 = new Thread(() => table.PrintTable(5));
        Thread t2 = new Thread(() => table.PrintTable(100));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Main thread finished");
    }
}
