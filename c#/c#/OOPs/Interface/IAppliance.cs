using System;

public interface IAppliance
{
    // Abstract method: must be implemented in the class
    void TurnOn();

    // Abstract property: must be implemented in the class
    int Voltage { get; }

    // Default method: provides default implementation, can be overridden
    void Status()
    {
        Console.WriteLine("Appliance is running.");
        LogInternal();  // Calling private helper
    }

    // Private method: used only by this interface internally
    private void LogInternal()
    {
        Console.WriteLine("Internal log from IAppliance.");
    }

    // Static method: not related to any object, can be called via interface name
    static void ShowCategory()
    {
        Console.WriteLine("This is a household appliance.");
    }
}