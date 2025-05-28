using System;

public class Abstraction
{
    public static void run()
    {
        Vehicle.ShowVehicleInfo();  // Calling static method from abstract class

        Vehicle car = new Car("Honda");

        Console.WriteLine($"{car.Model} has {car.Wheels} wheels.");
        car.StartEngine();
        car.Honk();
        car.StopEngine();

        // Vehicle v = new Vehicle("Generic"); // Error: cannot instantiate abstract class
    }
}