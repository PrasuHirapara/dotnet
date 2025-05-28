using System;

// Top-most class in the hierarchy
public class GrandParent
{
    private string privateNote = "Private GrandParent Data";         // accessible only within GrandParent
    protected string legacy = "Protected Legacy";                    // accessible to derived classes
    internal string familyRule = "Internal Rule for Family";         // accessible within the same assembly
    public string surname = "Hirpara";                               // accessible from anywhere

    public GrandParent()
    {
        Console.WriteLine("GrandParent constructor called");
    }

    public void ShowGrandParent()
    {
        Console.WriteLine("Public Method: GrandParent");
    }

    protected void ShowProtected()
    {
        Console.WriteLine("Protected Method: GrandParent");
    }

    private void ShowPrivate()
    {
        Console.WriteLine("Private Method: GrandParent");
    }

    internal void ShowInternal()
    {
        Console.WriteLine("Internal Method: GrandParent");
    }
}
