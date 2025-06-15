using System;

/*
 * A delegate is a type-safe function pointer.
 * It holds a reference to one or more methods that match its signature.
 * 
 * HOW DELEGATES WORK INTERNALLY:
 * - A delegate is an object that knows how to call a method (or methods).
 * - When you create a delegate instance, you're storing the address of the target method.
 * - Delegates are based on System.MulticastDelegate.
 * - You can attach multiple methods using += operator (multicast).
 * - When you invoke the delegate, it calls all the methods in the order they were added.
 * - You can remove a method using -=.
 *
 * DELEGATE METHODS:
 * - Invoke(): Calls the delegate synchronously.
 * - GetInvocationList(): Returns an array of delegates representing each method in the invocation list.
 * - Combine(Delegate, Delegate): Combines two delegates into one multicast delegate.
 * - Remove(Delegate, Delegate): Removes the last occurrence of a delegate from another delegate's invocation list.
 */

public delegate void MyDelegate(string message);

public class Delegates
{
    public static void Greet(string name)
    {
        Console.WriteLine("Greet : " + name);
    }

    public static void Farewell(string name)
    {
        Console.WriteLine("Goodbye, " + name);
    }

    public static void Welcome(string name)
    {
        Console.WriteLine("Welcome, " + name);
    }

    public static void Run()
    {
        Console.WriteLine("=== SINGLE-CAST DELEGATE ===");

        MyDelegate del = Greet;
        del("Prasu");

        Console.WriteLine("\n=== MULTICAST DELEGATE ===");
        del += Farewell;
        del += Welcome;

        del("Ashok");

        del -= Greet;

        Console.WriteLine("\n=== USING GetInvocationList() ===");

        // Get all methods attached to delegate
        Delegate[] invocationList = del.GetInvocationList();

        Console.WriteLine($"Number of methods attached: {invocationList.Length}");
        foreach (MyDelegate d in invocationList)
        {
            Console.WriteLine("Method name: " + d.Method.Name);
        }

        MyDelegate del1 = new MyDelegate(Greet);
        MyDelegate del2 = new MyDelegate(Farewell);

        // Combine delegates manually
        MyDelegate combined = (MyDelegate)Delegate.Combine(del1, del2);

        combined("Combined Delegate");

        // Remove Farewell from combined delegate
        combined = (MyDelegate)Delegate.Remove(combined, del2);

        Console.WriteLine("\nAfter removing Farewell:");
        combined("After Removal");
    }
}
