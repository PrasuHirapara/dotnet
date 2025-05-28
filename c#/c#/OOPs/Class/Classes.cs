using System;
public class Classes
{
    public static void run()
    {
        A obj1 = new A();
        A obj2 = new A(2, "custom");

        obj1.Show();
        obj2.Show();

        A.ShowCounter();

        obj1.SetText("updated");
        obj1.SetAmount(100.0);
        obj1.SetGrade('Z');

        Console.WriteLine("After Updates:");
        obj1.Show();
    }
}
