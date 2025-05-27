using System;

public class Strings
{
    public static void run()
    {
        string str1 = "Hello";
        string str2 = "World";
        string str3 = "hello world";

        string concat = str1 + " " + str2;
        Console.WriteLine(concat);                  // Hello World
        Console.WriteLine(concat.ToUpper());        // HELLO WORLD
        Console.WriteLine(concat.ToLower());        // hello world
        Console.WriteLine(str1.Length);              // 5
        Console.WriteLine(concat.Contains("World")); // True
        Console.WriteLine(concat.StartsWith("He"));  // True
        Console.WriteLine(concat.EndsWith("ld"));    // True
        Console.WriteLine(str1.IndexOf('o'));        // 4
        Console.WriteLine("   padded string   ".Trim()); // padded string
        Console.WriteLine(string.Compare(str1, str3));   // non-zero number (diff)
        Console.WriteLine(str1.Equals(str3, StringComparison.OrdinalIgnoreCase)); // False

        Console.WriteLine(str3.Insert(0, "inserint")); // (startIdx, String) // inserinthello world
        Console.WriteLine(concat.Substring(6, 5));   //(startInd, Length)   // World
        Console.WriteLine(concat.Replace("World", "C#")); // Hello C#

        Console.ReadKey();
    }
}
