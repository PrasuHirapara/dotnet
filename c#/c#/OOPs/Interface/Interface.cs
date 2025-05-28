using System;

/*
 * - Interfaces CAN contain:
 *    Abstract methods (must be implemented by implementing class)
 *    Properties (get-only, set-only, or both)
 *    Static methods (can be called via interface name)
 *    Default methods (have body, can be optionally overridden)
 *    Private methods (can be used only by default/static methods inside interface)
 * 
 * - Interfaces CANNOT contain:
 *    Fields (variables)
 *    Constructors
 *    Access modifiers like private/protected/internal for members (except private methods)
 */

public class Interface
{
    public static void run()
    {
        // Call static method directly using interface name
        IAppliance.ShowCategory();

        // Interface reference to a concrete class object
        IAppliance appliance = new Fan(220);

        /*
         * At this point:
         * - Object is of type Fan
         * - Reference is of type IAppliance
         * - Can only access methods and properties defined in IAppliance
         */

        appliance.TurnOn();     // Calls Fan.TurnOn()
        appliance.Status();     // Calls Fan.Status()
        Console.WriteLine($"Voltage: {appliance.Voltage}");

        // Casting to access methods specific to Fan
        if (appliance is Fan fan)
        {
            fan.Oscillate();   // Fan-specific method
        }

        // Invalid: Cannot instantiate interface
        // IAppliance obj = new IAppliance(); // Error
    }
}
