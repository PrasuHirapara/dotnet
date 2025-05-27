using System;

public class Methods
{
    public static void run()
    {
        // 1. Basic Method Call
        GreetUser(); // Output: Hello, User!

        // 2. Method with Parameters
        PrintSum(10, 20); // Output: Sum: 30

        // 3. Method with Return Type
        int squared = Square(5);
        Console.WriteLine("Square: " + squared); // Output: 25

        // 4. Method Overloading
        Console.WriteLine("Multiply int: " + Multiply(4, 5));           // Output: 20
        Console.WriteLine("Multiply double: " + Multiply(2.5, 3.5));    // Output: 8.75

        // 5. Optional and Named Parameters
        DisplayUser("Alice");                         // Output: Name: Alice, Age: 18
        DisplayUser("Bob", 25);                       // Output: Name: Bob, Age: 25
        DisplayUser(age: 30, name: "Charlie");        // Output: Name: Charlie, Age: 30

        // 6. Ref and Out
        /*
         * ref:
         * - Variable must be initialized before passing.
         * - Changes affect the original variable.
         *
         * out:
         * - Variable doesn't need to be initialized.
         * - Method must assign it before returning.
         */
        int a = 5;
        int b;
        DoubleIt(ref a);
        SetValue(out b);
        Console.WriteLine("After ref: " + a); // 10
        Console.WriteLine("After out: " + b); // 100

        // 7. Params (Variable Number of Arguments)
        /*
         * params:
         * - Accepts zero or more arguments.
         * - Must be the last parameter.
         */
        PrintNumbers();                     // Output: (blank line)
        PrintNumbers(1, 2, 3);              // Output: 1 2 3
        PrintNumbers(10, 20, 30, 40, 50);   // Output: 10 20 30 40 50

        // 8. Recursive Method
        Console.WriteLine("Factorial of 5: " + Factorial(5)); // Output: 120

        // 9. Expression-bodied Method
        Console.WriteLine("Cube: " + Cube(3)); // Output: 27
    }

    // Method Definitions:

    public static void GreetUser()
    {
        Console.WriteLine("Hello, User!");
    }

    public static void PrintSum(int x, int y)
    {
        Console.WriteLine("Sum: " + (x + y));
    }

    public static int Square(int num)
    {
        return num * num;
    }

    // Method Overloading
    public static int Multiply(int x, int y)
    {
        return x * y;
    }

    public static double Multiply(double x, double y)
    {
        return x * y;
    }

    // Optional + Named Parameters
    public static void DisplayUser(string name, int age = 18)
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }

    // Ref: variable passed by reference, must be initialized
    public static void DoubleIt(ref int value)
    {
        value *= 2;
    }

    // Out: variable passed by reference, must be assigned inside method
    public static void SetValue(out int value)
    {
        value = 100;
    }

    // Params: accepts variable number of arguments
    public static void PrintNumbers(params int[] numbers)
    {
        foreach (int num in numbers)
            Console.Write(num + " ");
        Console.WriteLine();
    }

    // Recursive Method
    public static int Factorial(int n)
    {
        if (n == 0 || n == 1) return 1;
        return n * Factorial(n - 1);
    }

    // Expression-bodied method
    public static int Cube(int x) => x * x * x;
}
