using System;

public class TimeSpanExample
{
    public static void run()
    {
        // Create TimeSpan of 1 hour, 30 minutes, 45 seconds
        // TimeSpan(hours, minutes, seconds)
        TimeSpan time1 = new TimeSpan(1, 30, 45);
        Console.WriteLine($"Time1: {time1}");

        // Create TimeSpan from days, hours, minutes, seconds, milliseconds
        // TimeSpan(days, hours, minutes, seconds, milliseconds)
        TimeSpan time2 = new TimeSpan(0, 2, 15, 30, 500);
        Console.WriteLine($"Time2: {time2}");

        // Create TimeSpan from ticks (100 nanoseconds each)
        // TimeSpan(ticks)
        long ticks = 10000000; // 1 second
        TimeSpan timeFromTicks = new TimeSpan(ticks);
        Console.WriteLine($"Time from ticks: {timeFromTicks}");

        // Create TimeSpan from specific units using static methods
        // FromDays(value), FromHours(value), FromMinutes(value), FromSeconds(value), FromMilliseconds(value), FromTicks(value)
        TimeSpan fromMinutes = TimeSpan.FromMinutes(90); // 1 hour 30 minutes
        Console.WriteLine($"FromMinutes: {fromMinutes}");

        // Add two TimeSpan values
        // Add(TimeSpan)
        TimeSpan sum = time1.Add(time2);
        Console.WriteLine($"Sum: {sum}");

        // Subtract one TimeSpan from another
        // Subtract(TimeSpan)
        TimeSpan diff = time2.Subtract(time1);
        Console.WriteLine($"Difference: {diff}");

        // Multiply TimeSpan by a double factor
        // Multiply(factor)
        TimeSpan multiplied = time1.Multiply(2.5);
        Console.WriteLine($"Multiplied: {multiplied}");

        // Divide TimeSpan by a double factor
        // Divide(divisor)
        TimeSpan divided = time2.Divide(3);
        Console.WriteLine($"Divided: {divided}");

        // Get total days as double (including fractional)
        // TotalDays property
        Console.WriteLine($"TotalDays of time2: {time2.TotalDays}");

        // Get total hours as double (including fractional)
        // TotalHours property
        Console.WriteLine($"TotalHours of time1: {time1.TotalHours}");

        // Get total minutes as double (including fractional)
        // TotalMinutes property
        Console.WriteLine($"TotalMinutes of time1: {time1.TotalMinutes}");

        // Get total seconds as double (including fractional)
        // TotalSeconds property
        Console.WriteLine($"TotalSeconds of timeFromTicks: {timeFromTicks.TotalSeconds}");

        // Get total milliseconds as double (including fractional)
        // TotalMilliseconds property
        Console.WriteLine($"TotalMilliseconds of time2: {time2.TotalMilliseconds}");

        // Get individual components
        // Days, Hours, Minutes, Seconds, Milliseconds properties
        Console.WriteLine($"Days: {time2.Days}, Hours: {time2.Hours}, Minutes: {time2.Minutes}, Seconds: {time2.Seconds}, Milliseconds: {time2.Milliseconds}");

        // Negate the TimeSpan (reverse sign)
        // Negate()
        TimeSpan negated = time1.Negate();
        Console.WriteLine($"Negated time1: {negated}");

        // Compare two TimeSpans
        // CompareTo(TimeSpan)
        int comparison = time1.CompareTo(time2);
        Console.WriteLine($"Compare time1 to time2: {comparison}"); // -1 if less, 0 if equal, 1 if greater

        // Check if two TimeSpans are equal
        // Equals(TimeSpan)
        bool isEqual = time1.Equals(time2);
        Console.WriteLine($"time1 equals time2: {isEqual}");

        // Parse string to TimeSpan
        // TimeSpan.Parse(string)
        TimeSpan parsedTime = TimeSpan.Parse("02:45:30");
        Console.WriteLine($"Parsed TimeSpan: {parsedTime}");

        // TryParse string to TimeSpan safely
        // TimeSpan.TryParse(string, out TimeSpan)
        if (TimeSpan.TryParse("01:15:10", out TimeSpan tryParsed))
        {
            Console.WriteLine($"TryParsed TimeSpan: {tryParsed}");
        }

        // Format TimeSpan to string
        // ToString() and ToString(format)
        Console.WriteLine($"Default ToString: {time1.ToString()}");
        Console.WriteLine($"Custom format (c): {time1.ToString("c")}"); // constant ("c") format
        Console.WriteLine($"Custom format (g): {time1.ToString("g")}"); // general short format
        Console.WriteLine($"Custom format (G): {time1.ToString("G")}"); // general long format

        // Zero TimeSpan
        // TimeSpan.Zero static property
        Console.WriteLine($"Zero TimeSpan: {TimeSpan.Zero}");

        // Max and Min values
        // TimeSpan.MaxValue, TimeSpan.MinValue static properties
        Console.WriteLine($"Max TimeSpan: {TimeSpan.MaxValue}");
        Console.WriteLine($"Min TimeSpan: {TimeSpan.MinValue}");
    }
}
