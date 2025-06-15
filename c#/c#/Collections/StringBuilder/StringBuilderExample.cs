using System;
using System.Text;

public class StringBuilderExample
{
    public static void Run()
    {
        StringBuilder sb = new StringBuilder();

        // Append string to StringBuilder
        // Append(value)
        sb.Append("Hello");

        // Append string with newline
        // AppendLine(value)
        sb.AppendLine(" World!");

        // Insert string at given index
        // Insert(idx, value)
        sb.Insert(5, ",");

        // Replace substring with new value
        // Replace(oldValue, newValue)
        sb.Replace("World", "C#");

        // Remove substring from start index with given length
        // Remove(startIdx, length)
        sb.Remove(0, 1);

        // Get current length of StringBuilder content
        // Length property
        Console.WriteLine($"Length: {sb.Length}");

        // Convert StringBuilder content to string
        // ToString()
        Console.WriteLine(sb.ToString());

        // Clear all content of StringBuilder
        // Clear()
        sb.Clear();

        Console.WriteLine($"Length after Clear: {sb.Length}");

        // Append formatted string
        // AppendFormat(format, params)
        sb.AppendFormat("Number: {0}, String: {1}", 42, "test");
        Console.WriteLine(sb.ToString());

        // Ensure capacity of StringBuilder buffer
        // EnsureCapacity(capacity)
        sb.EnsureCapacity(100);
        Console.WriteLine($"Capacity after EnsureCapacity: {sb.Capacity}");

        // Get or set the capacity of StringBuilder
        // Capacity property
        Console.WriteLine($"Current Capacity: {sb.Capacity}");
        sb.Capacity = 200;
        Console.WriteLine($"Capacity after set: {sb.Capacity}");

        // Get max capacity allowed by StringBuilder
        // MaxCapacity property
        Console.WriteLine($"MaxCapacity: {sb.MaxCapacity}");

        // Replace characters in StringBuilder content
        // Replace(oldChar, newChar)
        sb.Replace('t', 'T');
        Console.WriteLine(sb.ToString());

        // Append single character
        // Append(charValue)
        sb.Append('!');
        Console.WriteLine(sb.ToString());

        // Append part of character array from start index and length
        // Append(charArray, startIdx, length)
        char[] chars = { ' ', 'A', 'B', 'C' };
        sb.Append(chars, 1, 3);
        Console.WriteLine(sb.ToString());

        // Get substring from StringBuilder content
        // ToString(startIdx, length)
        string subStr = sb.ToString(7, 6);
        Console.WriteLine($"Substring (7,6): {subStr}");
    }
}
