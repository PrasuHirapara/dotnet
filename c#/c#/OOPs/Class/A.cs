using System;

public class A
{
    public int id; // Accessible from anywhere

    private string text; // Accessible only within this class

    protected double amount; // Accessible within this class and derived classes

    internal bool isAvailable; // Accessible within the same assembly

    protected internal char grade; // Accessible within the same assembly or from derived classes

    private protected float score; // Accessible within this class or derived classes in the same assembly

    public static int counter = 0; // Shared across all instances, keeps track of object count

    public const string tag = "CSharp"; // Constant value, cannot be changed after declaration

    public readonly DateTime createdAt; // Assigned only once, typically in constructor

    public int Number { get; set; } // Auto-implemented property

    public string Text //field
    {
        get => text; // Getter for private field
        set => text = value; // Setter for private field
    }

    public string Summary => $"ID: {id}, Text: {text}"; // Read-only property using expression body

    public A()
    {
        id = 1;
        text = "default";
        amount = 10.5;
        isAvailable = true;
        grade = 'A';
        score = 9.5f;
        Number = ++counter;
        createdAt = DateTime.Now;
    }

    public A(int i, string t)
    {
        id = i;
        text = t;
        amount = 99.9;
        isAvailable = false;
        grade = 'B';
        score = 7.0f;
        Number = ++counter;
        createdAt = DateTime.Now;
    }

    public void Show()
    {
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Text: " + text);
        Console.WriteLine("Amount: " + amount);
        Console.WriteLine("Available: " + isAvailable);
        Console.WriteLine("Grade: " + grade);
        Console.WriteLine("Score: " + score);
        Console.WriteLine("Tag: " + tag);
        Console.WriteLine("Created: " + createdAt);
        Console.WriteLine("Number: " + Number);
        Console.WriteLine("Summary: " + Summary);
    }

    public static void ShowCounter()
    {
        Console.WriteLine("Total Objects: " + counter);
    }

    public int GetId() => id;
    public void SetId(int value) => id = value;

    public string GetText() => text;
    public void SetText(string value) => text = value;

    public double GetAmount() => amount;
    public void SetAmount(double value) => amount = value;

    public bool GetAvailability() => isAvailable;
    public void SetAvailability(bool value) => isAvailable = value;

    public char GetGrade() => grade;
    public void SetGrade(char value) => grade = value;

    public float GetScore() => score;
    public void SetScore(float value) => score = value;

    public DateTime GetCreatedAt() => createdAt;
}
