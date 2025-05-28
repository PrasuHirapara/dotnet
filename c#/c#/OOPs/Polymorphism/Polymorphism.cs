using System;
using System.Drawing;

public class Polymorphism
{
    public static void run()
    {
        // Case 1: Base reference to derived object (Triangle)
        Shape s = new Triangle();

        /*
        Object: Triangle
        Reference: Shape
        What happens:
        - Only methods/properties in Shape can be accessed and called.
        - But overridden versions in Triangle will run, if not overrded then Reference methods will be called.
        - This is runtime polymorphism
        */

        s.Describe();      // Triangle's Describe
        s.WhoAmI();        // Triangle's WhoAmI
        s.BasicInfo();     // Triangle's overridden Material → "Wood"
        s.OnlyInShapeMethod(); //Not overriden in Triangle
        // s.area();          // area() is in trianlge but does not in Shape class so it won't run


        Console.WriteLine("\n");

        // Case 2: Triangle object and reference
        Triangle t = new Triangle();

        /*
        Object: Triangle
        Reference: Triangle
        What happens:
        - All methods in Triangle are accessible
        */

        t.Describe();      // Triangle Describe
        t.WhoAmI();        // Triangle WhoAmI
        t.BasicInfo();     // "Wood"
        t.Area();          // Triangle specific method

        // Invalid: can't assign base object to derived reference
        // Triangle wrong = new Shape(); // Compile-time error
    }
}
