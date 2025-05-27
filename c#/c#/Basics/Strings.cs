using System.Text;

public class Strings
{
    public static void run()
    {
        // 1. Declaration and Initialization
        string s1 = "Hello";
        string s2 = "World";
        string combined = s1 + " " + s2; // Concatenation
        Console.WriteLine("Concatenated: " + combined); // Output: Hello World

        // 2. String Interpolation
        string name = "Prasu";
        int age = 21;
        Console.WriteLine($"Name: {name}, Age: {age}"); // Output: Name: Prasu, Age: 21

        // 3. Verbatim Strings
        string path = @"C:\Users\Prasu\Documents";
        Console.WriteLine("Path: " + path); // Output: C:\Users\Prasu\Documents

        // 4. String Methods
        string str = "  CSharp Programming ";
        Console.WriteLine("Trim: " + str.Trim()); // removes leading/trailing spaces
        Console.WriteLine("ToUpper: " + str.ToUpper()); // CSHARP PROGRAMMING
        Console.WriteLine("ToLower: " + str.ToLower()); // csharp programming
        Console.WriteLine("Contains 'Sharp': " + str.Contains("Sharp")); // true
        Console.WriteLine("StartsWith 'C': " + str.Trim().StartsWith("C")); // true
        Console.WriteLine("EndsWith 'ing': " + str.Trim().EndsWith("ing")); // true
        Console.WriteLine("IndexOf 'a': " + str.IndexOf('a')); // (str, char) → 9

        // 5. Substring and Replace
        string sub = str.Substring(2, 5); // (startIndex, length)
        Console.WriteLine("Substring: " + sub); // Output: CShar
        Console.WriteLine("Replace: " + str.Replace("CSharp", "DotNet")); // DotNet Programming

        // 6. Split and Join
        string sentence = "CSharp is fun to learn";
        string[] words = sentence.Split(' '); // (delimiter)
        Console.WriteLine("Split words:");
        foreach (var word in words) Console.WriteLine(word); // CSharp \n is \n fun ...

        string joined = string.Join("-", words); // (delimiter, array)
        Console.WriteLine("Joined with - : " + joined); // CSharp-is-fun-to-learn

        // 7. StringBuilder for performance
        StringBuilder sb = new StringBuilder();
        sb.Append("Smart ");
        sb.Append("Coding ");
        sb.Append("With Prasu");
        Console.WriteLine("StringBuilder: " + sb.ToString()); // Smart Coding With Prasu

        // 8. Formatting
        string formatted = string.Format("Total: {0:C}", 1234.56); // Currency format
        Console.WriteLine("Formatted: " + formatted); // Output: Total: ₹1,234.56 (based on locale)

        // 9. Equality
        string a = "Test";
        string b = "test";
        Console.WriteLine("Equals: " + a.Equals(b)); // false
        Console.WriteLine("Equals Ignore Case: " + a.Equals(b, StringComparison.OrdinalIgnoreCase)); // true

        // 10. Null or Empty or WhiteSpace
        string empty = "";
        string whitespace = "   ";
        string nullStr = null;

        Console.WriteLine("IsNullOrEmpty(empty): " + string.IsNullOrEmpty(empty)); // true
        Console.WriteLine("IsNullOrWhiteSpace(whitespace): " + string.IsNullOrWhiteSpace(whitespace)); // true
    }
}
