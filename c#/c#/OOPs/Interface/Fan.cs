
// Concrete class implementing IAppliance
public class Fan : IAppliance
{
    private int _voltage;

    public Fan(int voltage)
    {
        _voltage = voltage;
    }

    // Implementing the abstract method
    public void TurnOn()
    {
        Console.WriteLine($"Fan turned on with voltage: {_voltage}V");
    }

    // Implementing the abstract property
    public int Voltage => _voltage;

    // Optionally overriding the default method
    public void Status()
    {
        Console.WriteLine("Fan is spinning at normal speed.");
    }

    // Custom method
    public void Oscillate()
    {
        Console.WriteLine("Fan is oscillating.");
    }
}