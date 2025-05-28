using System;

public class Triangle : Shape
{
    private double baseLength = 4;
    private double height = 5;

    public override void Describe() // overriding base Describe()
    {
        name = "Triangle";
        Console.WriteLine("A triangle has 3 sides.");
    }

    public override void WhoAmI() // overriding base WhoAmI()
    {
        Console.WriteLine($"I am a specific shape: {name}");
    }

    public void Area()
    {
        double area = 0.5 * baseLength * height;
        Console.WriteLine($"Area: {area}");
    }
}
