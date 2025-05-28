using System;

public class Shape
{
    protected string name = "Generic Shape"; // accessible to derived classes

    public virtual string Material // virtual property that can be overridden
    {
        get { return "Plastic"; }
    }

    public virtual void Describe()
    {
        Console.WriteLine("I am a shape.");
    }

    public virtual void WhoAmI()
    {
        Console.WriteLine($"I am a {name}");
    }

    public void BasicInfo()
    {
        Console.WriteLine($"Material: {Material}");
    }

    public void OnlyInShapeMethod()
    {
        Console.WriteLine("Only shape class has this method");
    }
}
