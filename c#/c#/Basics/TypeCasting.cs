using System;

public class TypeCasting
{
    public static void Run()
    {
        // IMPLICIT TYPE CASTING
        // Implicit: small → large data types (no data loss)

        // float to double (Implicit)
        float f1 = 12.34f;
        double d1 = f1;
        Console.WriteLine(d1 + " " + d1.GetType()); // Output: 12.34 System.Double

        // char to int (Implicit)
        // 'A' has ASCII value 65, which fits in int
        char ch = 'A';
        int ascii = ch;
        Console.WriteLine(ascii); // Output: 65

        // int to long (Implicit)
        int small = 1000;
        long large = small;
        Console.WriteLine(large + " " + large.GetType()); // Output: 1000 System.Int64

        // bool to string (using ToString, implicit)
        bool isActive = true;
        string activeStr = isActive.ToString();
        Console.WriteLine(activeStr + " " + activeStr.GetType()); // Output: True System.String

        // int to string (using ToString)
        int x = 100;
        string xStr = x.ToString();
        Console.WriteLine(xStr + " " + xStr.GetType()); // Output: 100 System.String



        // EXPLICIT TYPE CASTING
        // Explicit: large → small data types (possible data loss)

        // double to int (Explicit - using Convert)
        double a = 3.140934691;
        int b = Convert.ToInt32(a);
        Console.WriteLine(b); // Output: 3

        // string to char (Explicit - using Convert)
        String c = "@";
        char d = Convert.ToChar(c);
        Console.WriteLine(d); // Output: @
        Console.WriteLine(d.GetType()); // Output: System.Char

        // string to bool (Explicit - using Convert)
        String e = "true";
        bool f = Convert.ToBoolean(e);
        Console.WriteLine(f + " " + f.GetType()); // Output: True System.Boolean

        // double to float (Explicit - possible precision loss)
        double d2 = 56.789;
        float f2 = (float)d2;
        Console.WriteLine(f2 + " " + f2.GetType()); // Output: 56.789 System.Single

        // string to int (Explicit - using Convert)
        string numStr = "123";
        int num = Convert.ToInt32(numStr);
        Console.WriteLine(num + " " + num.GetType()); // Output: 123 System.Int32
    }
}
