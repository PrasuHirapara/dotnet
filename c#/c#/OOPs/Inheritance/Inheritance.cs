using System;

public class Inheritance
{
    public static void run()
    {
        Console.WriteLine("=== Child1 (Multilevel) ===");
        Child1 c1 = new Child1();
        c1.ShowGrandParent();
        c1.ShowParent();
        c1.ShowChild1();

        Console.WriteLine("\n=== Child2 (Hierarchical) ===");
        Child2 c2 = new Child2();
        c2.ShowGrandParent();
        c2.ShowParent();
        c2.ShowChild2();
    }
}
