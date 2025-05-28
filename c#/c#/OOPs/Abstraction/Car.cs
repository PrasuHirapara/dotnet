using System;

public class Car : Vehicle
{
    public Car(string modelName) : base(modelName) { }

    public override int Wheels => 4;

    public override void StartEngine()
    {
        Console.WriteLine($"{model} car engine started.");
    }

    public override void Honk()
    {
        Console.WriteLine($"{model} car horn: Beep beep!");
    }
}