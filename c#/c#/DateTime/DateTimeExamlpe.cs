using System;
using System.Globalization;

public class DateTimeExamlpe
{
    public static void run()
    {
        DateTime now = DateTime.Now;
        Console.WriteLine("Now: " + now);

        // Date components
        Console.WriteLine("Year: " + now.Year);
        Console.WriteLine("Month: " + now.Month);
        Console.WriteLine("Day: " + now.Day);
        Console.WriteLine("Day of Week: " + now.DayOfWeek);
        Console.WriteLine("Day of Year: " + now.DayOfYear);

        // Adding time
        Console.WriteLine("Add 5 days: " + now.AddDays(5));
        Console.WriteLine("Add 3 hours: " + now.AddHours(3));
        Console.WriteLine("Add 30 minutes: " + now.AddMinutes(30));
        Console.WriteLine("Add 100 milliseconds: " + now.AddMilliseconds(100));

        // Subtracting time
        DateTime past = now.AddDays(-10);
        Console.WriteLine("10 days ago: " + past);

        // Difference between two dates (TimeSpan)
        DateTime birthDate = new DateTime(1990, 6, 15);
        TimeSpan ageSpan = now - birthDate;
        Console.WriteLine($"Age in days: {ageSpan.TotalDays:N0}");
        Console.WriteLine($"Age in years (approx): {ageSpan.TotalDays / 365:N2}");

        // Comparison
        Console.WriteLine("Is now > birthDate? " + (now > birthDate));
        Console.WriteLine("Is now < birthDate? " + (now < birthDate));

        // Formatting
        Console.WriteLine("Default format: " + now.ToString());
        Console.WriteLine("Custom format: " + now.ToString("dddd, MMMM dd yyyy"));
        Console.WriteLine("Short date: " + now.ToShortDateString());
        Console.WriteLine("Long time: " + now.ToLongTimeString());
        Console.WriteLine("Sortable format: " + now.ToString("s"));

        // Parsing with culture info
        string dateStr = "31/12/2025";
        DateTime parsedDate;
        if (DateTime.TryParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
        {
            Console.WriteLine("Parsed date (exact): " + parsedDate.ToShortDateString());
        }
        else
        {
            Console.WriteLine("Failed to parse date.");
        }

        // UTC and Local time
        Console.WriteLine("Current UTC time: " + DateTime.UtcNow);
        Console.WriteLine("Is now local time? " + (now.Kind == DateTimeKind.Local));
        Console.WriteLine("Is UTC time? " + (DateTime.UtcNow.Kind == DateTimeKind.Utc));

        // Creating DateTime from ticks
        long ticks = now.Ticks;
        DateTime fromTicks = new DateTime(ticks);
        Console.WriteLine("Date from ticks: " + fromTicks);

        // DateTime Min and Max values
        Console.WriteLine("Min DateTime: " + DateTime.MinValue);
        Console.WriteLine("Max DateTime: " + DateTime.MaxValue);
    }
}
