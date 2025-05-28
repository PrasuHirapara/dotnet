using System;
using System.Collections.Generic;
using System.Linq;

public class LambdaExample
{
    public static void run()
    {
        // 1. Simple lambda with one parameter (expression-bodied)
        Func<int, int> square = x => x * x;
        Console.WriteLine("Square of 5: " + square(5)); // 25

        // 2. Lambda with multiple parameters
        Func<int, int, int> add = (a, b) => a + b;
        Console.WriteLine("Add 3 + 4: " + add(3, 4)); // 7

        // 3. Lambda with statement block
        Func<int, int, int> multiplyAndAdd = (a, b) =>
        {
            int product = a * b;
            return product + 10;
        };
        Console.WriteLine("Multiply 3 * 4 + 10: " + multiplyAndAdd(3, 4)); // 22

        // 4. Lambda with no parameters
        Action greet = () => Console.WriteLine("Hello Lambda!");
        greet();

        // 5. Returning a lambda from a lambda (Higher-order function)
        Func<int, Func<int, int>> multiplier = factor => (x => x * factor);
        var multiplyBy3 = multiplier(3);
        Console.WriteLine("Multiply 10 by 3: " + multiplyBy3(10)); // 30

        // 6. Lambda capturing outer variable (closure)
        int factor = 5;
        Func<int, int> multiplyByFactor = x => x * factor;
        Console.WriteLine("Multiply 10 by captured factor (5): " + multiplyByFactor(10)); // 50

        factor = 10; // Changing captured variable affects lambda
        Console.WriteLine("Multiply 10 by changed factor (10): " + multiplyByFactor(10)); // 100

        // 7. Using lambda with LINQ to filter and project data
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        var evens = numbers.Where(n => n % 2 == 0);
        Console.WriteLine("Even numbers: " + string.Join(", ", evens));

        var squares = numbers.Select(n => n * n);
        Console.WriteLine("Squares: " + string.Join(", ", squares));

        // 8. Lambda with multiple statements and side effects
        Action<string> printWithPrefix = name =>
        {
            string prefix = "[Name]";
            Console.WriteLine($"{prefix} {name}");
        };
        printWithPrefix("Alice");

        // 9. Lambda returning another lambda with complex logic
        Func<int, Func<int, int>> power = exponent =>
        {
            return baseNum =>
            {
                int result = 1;
                for (int i = 0; i < exponent; i++)
                    result *= baseNum;
                return result;
            };
        };

        var squareFunc = power(2);
        var cubeFunc = power(3);
        Console.WriteLine("5 squared: " + squareFunc(5)); // 25
        Console.WriteLine("2 cubed: " + cubeFunc(2));     // 8
    }
}
