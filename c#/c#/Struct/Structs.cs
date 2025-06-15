using System;

namespace StructDemo
{
    struct Employee
    {
        // Fields
        public int Id;
        public string Name;

        // Auto-implemented property
        public double Salary { get; set; }

        // Read-only property
        public string Role => "Developer";

        // Constructor
        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        // Method
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Role: {Role}");
        }

        // Override ToString
        public override string ToString()
        {
            return $"[Employee] {Id} - {Name} - {Salary}";
        }
    }
}
