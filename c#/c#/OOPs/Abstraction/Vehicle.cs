using System;

/*
 * - An abstract class represents an incomplete concept or entity.
 * - An abstract class cannot be instantiated.
 * - An abstract class can have both abstract and non-abstract (concrete) methods.
 * - Subclasses must implement all abstract methods or be declared abstract themselves.
 * - Abstract classes can have constructors and member variables and can be accessed by base() keyword.
 * - Abstract classes can implement interfaces.
 * - Cannot create abstract static methods because abstract methods must be overridden and static methods cannot be overridden.
 * - Instead, you can create static methods in abstract classes as they do not depend on objects.
 * - Useful for defining a common base with shared behavior while leaving some details to derived classes.
 * - Static methods can exist but cannot be abstract.
 */

public abstract class Vehicle
{
    protected string model;

    // Constructor in abstract class, accessible by derived classes via base()
    public Vehicle(string modelName)
    {
        model = modelName;
    }

    // Public property to access model name
    public string Model => model;

    // Abstract property - must be implemented in subclass
    public abstract int Wheels { get; }

    // Abstract method - must be implemented in subclass
    public abstract void StartEngine();

    // Concrete method - shared behavior for all vehicles
    public void StopEngine()
    {
        Console.WriteLine("Engine stopped.");
    }

    // Virtual method - can be overridden but not mandatory
    public virtual void Honk()
    {
        Console.WriteLine("Default horn sound.");
    }

    // Static method - cannot be abstract, shared by all Vehicles
    public static void ShowVehicleInfo()
    {
        Console.WriteLine("Vehicles are used for transportation.");
    }
}
