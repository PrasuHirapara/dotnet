// Inherits from GrandParent (Single Inheritance)
public class Parent : GrandParent
{
    private string privateStuff = "Private Parent Notes";
    protected string advice = "Protected Parent Advice";
    public string house = "Owns a House";

    public Parent() : base()  // Rule: GrandParent constructor must be called first
    {
        Console.WriteLine("Parent constructor called");
    }

    public void ShowParent()
    {
        Console.WriteLine("Public Method: Parent");
        Console.WriteLine("Accessing base protected: " + legacy);       // accessible
        Console.WriteLine("Accessing base internal: " + familyRule);    // accessible
        Console.WriteLine("Accessing base public: " + surname);         // accessible
        // privateNote and ShowPrivate() are not accessible here
    }
}
