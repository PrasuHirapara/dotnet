# Math Class in C\#

## Introduction

The `Math` class in C# is a built-in utility class provided by the .NET Framework under the `System` namespace. It provides a collection of static methods and constants that perform mathematical operations such as trigonometric, logarithmic, and arithmetic calculations. This class is designed to simplify complex mathematical tasks and is widely used in scientific, engineering, and general-purpose programming applications.

## How it Works

* The `Math` class is **static**, which means it cannot be instantiated.
* All methods and properties are accessed directly through the class name (e.g., `Math.Sqrt(16)`).
* The class includes methods for basic arithmetic, powers and roots, logarithmic functions, trigonometry, rounding, and more.
* Constants like `Math.PI` and `Math.E` are provided for common mathematical values.

## Method Table

| Return Type | Method Name | Parameters         | Description                                                     |
| ----------- | ----------- | ------------------ | --------------------------------------------------------------- |
| double      | Abs         | double x           | Returns the absolute value of a number.                         |
| double      | Sqrt        | double x           | Returns the square root of a number.                            |
| double      | Pow         | double x, double y | Returns x raised to the power of y.                             |
| double      | Sin         | double angle       | Returns the sine of an angle (in radians).                      |
| double      | Cos         | double angle       | Returns the cosine of an angle (in radians).                    |
| double      | Tan         | double angle       | Returns the tangent of an angle (in radians).                   |
| double      | Log         | double x           | Returns the natural logarithm (base e).                         |
| double      | Log10       | double x           | Returns the base-10 logarithm.                                  |
| double      | Ceiling     | double x           | Returns the smallest integral value greater than or equal to x. |
| double      | Floor       | double x           | Returns the largest integral value less than or equal to x.     |
| double      | Round       | double x           | Rounds a value to the nearest integer.                          |
| int         | Max         | int x, int y       | Returns the larger of two integers.                             |
| int         | Min         | int x, int y       | Returns the smaller of two integers.                            |
| double      | Truncate    | double x           | Calculates the integral part of a specified number.             |
| double      | Exp         | double x           | Returns e raised to the specified power.                        |

## Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        double number = -9.7;
        double angle = Math.PI / 4; // 45 degrees in radians

        Console.WriteLine($"Absolute value: {Math.Abs(number)}");
        Console.WriteLine($"Square root of 16: {Math.Sqrt(16)}");
        Console.WriteLine($"2 raised to power 3: {Math.Pow(2, 3)}");
        Console.WriteLine($"Sine of 45 degrees: {Math.Sin(angle)}");
        Console.WriteLine($"Cosine of 45 degrees: {Math.Cos(angle)}");
        Console.WriteLine($"Tangent of 45 degrees: {Math.Tan(angle)}");
        Console.WriteLine($"Natural log of 10: {Math.Log(10)}");
        Console.WriteLine($"Base-10 log of 1000: {Math.Log10(1000)}");
        Console.WriteLine($"Ceiling of 5.3: {Math.Ceiling(5.3)}");
        Console.WriteLine($"Floor of 5.7: {Math.Floor(5.7)}");
        Console.WriteLine($"Round 4.6: {Math.Round(4.6)}");
        Console.WriteLine($"Max of 10 and 20: {Math.Max(10, 20)}");
        Console.WriteLine($"Min of 10 and 20: {Math.Min(10, 20)}");
        Console.WriteLine($"Truncate 9.87: {Math.Truncate(9.87)}");
        Console.WriteLine($"e^2: {Math.Exp(2)}");
    }
}
```

## Advantages

* **Performance**: Offers fast, optimized operations for mathematical computations.
* **Convenience**: Provides ready-to-use mathematical methods without requiring external libraries.
* **Precision**: Ensures high-precision results using IEEE floating-point standards.
* **Readability**: Improves code readability and maintainability by abstracting complex math logic.

## Use Cases

* **Scientific Calculations**: Useful in physics, chemistry, and engineering for trigonometric and logarithmic operations.
* **Game Development**: Frequently used in vector math, rotations, and graphics computations.
* **Finance**: Rounding methods, logarithmic calculations for compound interest.
* **Machine Learning/AI**: Computations of exponential/logarithmic functions, distance metrics, etc.
* **General Utility**: Everyday programming tasks like calculating averages, ranges, and normalizations.
