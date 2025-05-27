using System;

public class ExceptionHandling
{
    public static void run()
    {
        // 1. Basic try-catch
        try
        {
            int x = 10;
            int y = 0;
            int result = x / y; // Throws DivideByZeroException
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Caught Exception: " + ex.Message);
        }

        // 2. Multiple catch blocks
        try
        {
            string s = null;
            Console.WriteLine(s.Length); // Throws NullReferenceException
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Caught NullReferenceException: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught General Exception: " + ex.Message);
        }

        // 3. Finally block
        try
        {
            Console.WriteLine("Trying something risky...");
        }
        catch
        {
            Console.WriteLine("Something went wrong.");
        }
        finally
        {
            Console.WriteLine("Finally block always runs.");
        }

        // 4. Throwing custom exception
        try
        {
            ValidateAge(15); // Will throw
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Custom Throw: " + ex.Message);
        }
    }

    // Method that throws exception
    public static void ValidateAge(int age)
    {
        if (age < 18)
        {
            throw new ArgumentException("Age must be at least 18.");
        }
        Console.WriteLine("Age is valid.");
    }
}
