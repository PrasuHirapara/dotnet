using System;

public class Maths
{
    public static void run()
    {
        // Abs() returns absolute value
        Console.WriteLine(Math.Abs(-20)); // Output: 20

        // Sign() returns -1 for negative, 0 for zero, 1 for positive
        Console.WriteLine(Math.Sign(-7)); // Output: -1

        // Max() returns the maximum of two values
        Console.WriteLine(Math.Max(15, 30)); // Output: 30

        // Min() returns the minimum of two values
        Console.WriteLine(Math.Min(15, 30)); // Output: 15

        // Pow() returns base raised to the power
        Console.WriteLine(Math.Pow(2, 3)); // Output: 8

        // Sqrt() returns square root
        Console.WriteLine(Math.Sqrt(49)); // Output: 7

        // Floor() returns the largest integer less than or equal to the value
        Console.WriteLine(Math.Floor(7.9)); // Output: 7

        // Ceiling() returns the smallest integer greater than or equal to the value
        Console.WriteLine(Math.Ceiling(7.1)); // Output: 8

        // Round() rounds to the nearest whole number
        Console.WriteLine(Math.Round(5.6)); // Output: 6

        // Truncate() removes the fractional part
        Console.WriteLine(Math.Truncate(9.87)); // Output: 9

        // Exp() returns e raised to the given power
        Console.WriteLine(Math.Exp(1)); // Output: 2.718281828...

        // Log() returns natural logarithm (base e)
        Console.WriteLine(Math.Log(10)); // Output: 2.302585092...

        // Log10() returns base 10 logarithm
        Console.WriteLine(Math.Log10(1000)); // Output: 3

        // Sin() returns sine of angle in radians
        Console.WriteLine(Math.Sin(Math.PI / 2)); // Output: 1

        // Cos() returns cosine of angle in radians
        Console.WriteLine(Math.Cos(0)); // Output: 1

        // Tan() returns tangent of angle in radians
        Console.WriteLine(Math.Tan(Math.PI / 4)); // Output: 1

        // Asin() returns arc sine (radians)
        Console.WriteLine(Math.Asin(1)); // Output: 1.57079632679 (π/2)

        // Acos() returns arc cosine (radians)
        Console.WriteLine(Math.Acos(1)); // Output: 0

        // Atan() returns arc tangent (radians)
        Console.WriteLine(Math.Atan(1)); // Output: 0.78539816339 (π/4)

        // PI constant
        Console.WriteLine(Math.PI); // Output: 3.1415926535...

        // E constant (Euler's number)
        Console.WriteLine(Math.E); // Output: 2.718281828...

        Console.ReadKey(true);
    }
}
