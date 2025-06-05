# TimeSpan Class in C\#

## Introduction

The `TimeSpan` class in C# is a part of the `System` namespace and represents a time interval, such as hours, minutes, and seconds. Unlike the `DateTime` class, which represents specific points in time, `TimeSpan` is used to define durations. It is commonly used for measuring elapsed time, adding or subtracting time intervals, or scheduling delays.

## How it Works

* `TimeSpan` is a **struct**, so it is a value type.
* It can represent both positive and negative intervals.
* The class provides various constructors and factory methods to create time intervals based on days, hours, minutes, seconds, and milliseconds.
* Arithmetic and comparison operators are supported (e.g., addition, subtraction, equality).

## Constructor Table

| Constructor Signature                                                     | Description                                                    |
| ------------------------------------------------------------------------- | -------------------------------------------------------------- |
| TimeSpan(int ticks)                                                       | Initializes a new TimeSpan to the specified number of ticks.   |
| TimeSpan(int hours, int minutes, int seconds)                             | Initializes a new TimeSpan to a specified time.                |
| TimeSpan(int days, int hours, int minutes, int seconds)                   | Initializes a TimeSpan based on days, hours, minutes, seconds. |
| TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds) | Initializes a TimeSpan with full time components.              |

## Method Table

| Return Type | Method/Property Name | Parameters               | Description                                                    |
| ----------- | -------------------- | ------------------------ | -------------------------------------------------------------- |
| TimeSpan    | FromDays             | double value             | Returns a TimeSpan that represents a specified number of days. |
| TimeSpan    | FromHours            | double value             | Returns a TimeSpan for a specified number of hours.            |
| TimeSpan    | FromMinutes          | double value             | Returns a TimeSpan for a specified number of minutes.          |
| TimeSpan    | FromSeconds          | double value             | Returns a TimeSpan for a specified number of seconds.          |
| TimeSpan    | FromMilliseconds     | double value             | Returns a TimeSpan for a specified number of milliseconds.     |
| double      | TotalDays            | -                        | Gets the total number of days represented.                     |
| double      | TotalHours           | -                        | Gets the total number of hours represented.                    |
| double      | TotalMinutes         | -                        | Gets the total number of minutes represented.                  |
| int         | Days                 | -                        | Gets the day component of the TimeSpan.                        |
| int         | Hours                | -                        | Gets the hour component.                                       |
| TimeSpan    | Add                  | TimeSpan value           | Returns a new TimeSpan with the value added.                   |
| TimeSpan    | Subtract             | TimeSpan value           | Returns a new TimeSpan with the value subtracted.              |
| TimeSpan    | Duration             | -                        | Returns a TimeSpan with absolute value.                        |
| int         | Compare              | TimeSpan t1, TimeSpan t2 | Compares two TimeSpan values.                                  |

## Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        TimeSpan span1 = TimeSpan.FromHours(1.5); // 1 hour 30 minutes
        TimeSpan span2 = TimeSpan.FromMinutes(45);

        Console.WriteLine($"Span1: {span1}");
        Console.WriteLine($"Span2: {span2}");

        TimeSpan sum = span1.Add(span2);
        TimeSpan diff = span1.Subtract(span2);

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {diff}");

        Console.WriteLine($"Total Hours in Sum: {sum.TotalHours}");
        Console.WriteLine($"Minutes in Difference: {diff.Minutes}");

        Console.WriteLine($"Duration of -45 minutes: {TimeSpan.FromMinutes(-45).Duration()}");

        int comparison = TimeSpan.Compare(span1, span2);
        Console.WriteLine(comparison > 0 ? "Span1 > Span2" : comparison < 0 ? "Span1 < Span2" : "Span1 == Span2");
    }
}
```

## Advantages

* **Precise Interval Representation**: Useful for representing durations rather than points in time.
* **Ease of Arithmetic**: Supports easy addition, subtraction, and comparison of time intervals.
* **Built-in Parsing and Formatting**: Supports converting to/from string formats.
* **High Resolution**: Can represent very small intervals (up to ticks: 100-nanosecond units).

## Use Cases

* **Measuring Elapsed Time**: Tracking time taken to complete an operation.
* **Scheduling and Delays**: Representing delay or wait durations.
* **Time-Based Calculations**: Calculating time differences between `DateTime` instances.
* **Logging and Monitoring**: Capturing durations for performance analysis.
* **Alarms and Timers**: Creating countdowns or repeated interval actions.
