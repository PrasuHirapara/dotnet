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

    class Program
    {
        static void Main()
        {
            // Using parameterized constructor
            Employee emp1 = new Employee(101, "Alice", 60000);

            // Using object initializer
            Employee emp2 = new Employee
            {
                Id = 102,
                Name = "Bob",
                Salary = 55000
            };

            // Access members
            emp1.DisplayInfo();
            Console.WriteLine(emp2.ToString());

            // Update property
            emp2.Salary += 5000;
            Console.WriteLine($"Updated Salary of Bob: {emp2.Salary}");
        }
    }
}
