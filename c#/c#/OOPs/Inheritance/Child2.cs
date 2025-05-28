// Hierarchical Inheritance: Child2 also inherits from Parent
public class Child2 : Parent
{
    private string petName = "Buddy";

    public Child2()
    {
        Console.WriteLine("Child2 constructor called");
    }

    public void ShowChild2()
    {
        Console.WriteLine("Public Method: Child2");
        Console.WriteLine("Accessing inherited protected: " + advice);       // accessible
        Console.WriteLine("Accessing inherited internal: " + familyRule);    // accessible
        Console.WriteLine("Accessing inherited public: " + surname);         // accessible
    }
}
