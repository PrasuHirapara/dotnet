# DateTime Class in C\#

## Introduction

The `DateTime` class in C# is part of the `System` namespace and is used to represent both dates and times. It encapsulates information like year, month, day, hour, minute, second, and millisecond. `DateTime` is fundamental for scheduling, logging, timestamps, and any application dealing with time or date operations.

## How it Works

* `DateTime` is a **struct**, so it is a value type.
* It represents a specific point in time, unlike `TimeSpan` which represents a duration.
* It includes a variety of static methods and properties for easy access to current time values and parsing.
* `DateTime` supports arithmetic operations and comparisons.

## Constructor Table

| Constructor Signature                                                                     | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| DateTime(int year, int month, int day)                                                    | Initializes a new instance to the specified year, month, and day.                         |
| DateTime(int year, int month, int day, int hour, int minute, int second)                  | Initializes with specific date and time values.                                           |
| DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond) | Initializes with full date and time precision.                                            |
| DateTime(long ticks)                                                                      | Initializes a DateTime to a date/time represented by ticks.                               |
| DateTime(long ticks, DateTimeKind kind)                                                   | Initializes a DateTime with ticks and specifies whether it is local, UTC, or unspecified. |

## Method Table

| Return Type | Method Name     | Parameters                               | Description                                                             |
| ----------- | --------------- | ---------------------------------------- | ----------------------------------------------------------------------- |
| DateTime    | Now             | -                                        | Gets the current local date and time.                                   |
| DateTime    | UtcNow          | -                                        | Gets the current date and time in UTC.                                  |
| DateTime    | Today           | -                                        | Gets the current date with time set to 00:00:00.                        |
| int         | Day             | -                                        | Gets the day component.                                                 |
| int         | Month           | -                                        | Gets the month component.                                               |
| int         | Year            | -                                        | Gets the year component.                                                |
| DateTime    | AddDays         | double value                             | Adds the specified number of days.                                      |
| DateTime    | AddHours        | double value                             | Adds the specified number of hours.                                     |
| DateTime    | AddMinutes      | double value                             | Adds the specified number of minutes.                                   |
| DateTime    | AddMilliseconds | double value                             | Adds the specified number of milliseconds.                              |
| string      | ToString        | - or string format                       | Converts the date/time to a string.                                     |
| bool        | Equals          | DateTime value                           | Checks if two DateTime values are equal.                                |
| int         | Compare         | DateTime t1, DateTime t2                 | Compares two DateTime values.                                           |
| DateTime    | Parse           | string s                                 | Converts the string representation of a date/time to a DateTime object. |
| DateTime    | ParseExact      | string s, string format, IFormatProvider | Converts a string in exact format to a DateTime.                        |

## Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        DateTime now = DateTime.Now;
        DateTime utcNow = DateTime.UtcNow;
        DateTime today = DateTime.Today;
        DateTime custom = new DateTime(2025, 6, 5, 14, 30, 0);

        DateTime future = now.AddDays(5).AddHours(3);
        DateTime parsed = DateTime.Parse("2025-12-25");
        DateTime exact = DateTime.ParseExact("06/05/2025", "MM/dd/yyyy", null);

        Console.WriteLine($"Now: {now}");
        Console.WriteLine($"UTC Now: {utcNow}");
        Console.WriteLine($"Today: {today.ToShortDateString()}");
        Console.WriteLine($"Custom DateTime: {custom}");
        Console.WriteLine($"Future: {future}");
        Console.WriteLine($"Parsed Date: {parsed.ToString("yyyy-MM-dd")}");
        Console.WriteLine($"Exact Date: {exact.ToShortDateString()}");

        int comparison = DateTime.Compare(now, future);
        Console.WriteLine(comparison < 0 ? "Now is before Future" : "Now is after Future");
    }
}
```

## Advantages

* **Wide Functionality**: Offers rich APIs for manipulation and comparison of dates and times.
* **Culture and Format Support**: Easily formats and parses using various cultures and formats.
* **Precision**: Supports high-resolution time down to milliseconds and ticks.
* **Integration**: Works seamlessly with `TimeSpan`, databases, UI components, and more.

## Use Cases

* **Timestamps and Logging**: Recording event times in logs and databases.
* **Scheduling and Deadlines**: Calculating future/past dates and enforcing deadlines.
* **Data Processing**: Sorting or filtering data based on dates.
* **User Interfaces**: Displaying localized date/time to users.
* **Date Math**: Adding or subtracting time for billing, expiry, or reminder features.
