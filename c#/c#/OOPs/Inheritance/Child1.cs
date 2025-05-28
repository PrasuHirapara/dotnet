// Multilevel Inheritance: Child1 → Parent → GrandParent
public class Child1 : Parent
{
    internal string childToy = "Remote Car";

    public Child1() : base() // Parent constructor must be called
    {
        Console.WriteLine("Child1 constructor called");
    }

    public void ShowChild1()
    {
        Console.WriteLine("Public Method: Child1");
        Console.WriteLine("Accessing inherited protected: " + advice);       // accessible
        Console.WriteLine("Accessing inherited internal: " + familyRule);    // accessible
        Console.WriteLine("Accessing inherited public: " + surname);         // accessible
    }
}
