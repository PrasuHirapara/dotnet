1\. C# Fundamentals
-----------------------------

This section revisits the core fundamentals of C#, providing a solid foundation for more advanced topics.

### 1.1. Data Types

C# is a strongly-typed language, meaning that every variable must have a declared data type. Understanding these types is crucial.

*   **Value Types:** These types directly contain their data. Assigning a value type variable copies the value. Examples include:
    
    *   `int`: Represents integers (e.g., `int age = 30;`).
    *   `float`: Represents single-precision floating-point numbers (e.g., `float price = 19.99f;`). The `f` suffix is important to denote a float literal.
    *   `double`: Represents double-precision floating-point numbers (e.g., `double pi = 3.14159;`).
    *   `bool`: Represents boolean values (true or false) (e.g., `bool isEnabled = true;`).
    *   `char`: Represents a single Unicode character (e.g., `char initial = 'J';`).
    *   `struct`: A user-defined value type that can contain fields, methods, and properties.
    
        struct Point
        {
            public int X;
            public int Y;
        }
        
        Point p = new Point();
        p.X = 10;
        p.Y = 20;
        
    
*   **Reference Types:** These types store a reference (memory address) to the data. Assigning a reference type variable copies the reference, not the data itself. Examples include:
    
    *   `string`: Represents a sequence of characters (e.g., `string name = "John Doe";`).
    *   `object`: The base class for all other types in C#.
    *   `dynamic`: Allows type checking to be bypassed at compile time. Use with caution.
    *   `class`: A user-defined reference type that can contain fields, methods, and properties.
    *   `interface`: Defines a contract that classes can implement.
    *   `delegate`: Represents a method that can be passed as an argument.
    *   Arrays: Collections of elements of the same type (e.g., `int[] numbers = { 1, 2, 3 };`).
    
        class Person
        {
            public string Name { get; set; }
        }
        
        Person person1 = new Person();
        person1.Name = "Alice";
        Person person2 = person1; // person2 now references the same object as person1
        person2.Name = "Bob"; // This will also change person1.Name
        
    

### 1.2. Variables and Operators

*   **Variable Declaration:** Variables must be declared before they can be used. The syntax is `dataType variableName;` or `dataType variableName = initialValue;`.
*   **Operators:** C# provides a rich set of operators for performing various operations:
    *   **Arithmetic Operators:** `+`, `-`, `*`, `/`, `%` (modulus).
    *   **Assignment Operators:** `=`, `+=`, `-=`, `*=`, `/=`, `%=`.
    *   **Comparison Operators:** `==`, `!=`, `>`, `<`, `>=`, `<=`.
    *   **Logical Operators:** `&&` (AND), `||` (OR), `!` (NOT).
    *   **Bitwise Operators:** `&`, `|`, `^`, `~`, `<<`, `>>`.
    *   **Null-coalescing operator:** `??` (e.g., `string name = potentiallyNullName ?? "Default Name";`).

### 1.3. Control Flow

Control flow statements determine the order in which code is executed.

*   **`if`, `else if`, `else`:** Conditional statements.
    
        int age = 20;
        if (age >= 18)
        {
            Console.WriteLine("Adult");
        }
        else
        {
            Console.WriteLine("Minor");
        }
        
    
*   **`switch`:** Multi-way branching.
    
        string day = "Monday";
        switch (day)
        {
            case "Monday":
                Console.WriteLine("Start of the week");
                break;
            case "Friday":
                Console.WriteLine("End of the week");
                break;
            default:
                Console.WriteLine("Mid-week");
                break;
        }
        
    
*   **`for` loop:** Iterates a specific number of times.
    
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
        
    
*   **`while` loop:** Iterates as long as a condition is true.
    
        int count = 0;
        while (count < 5)
        {
            Console.WriteLine(count);
            count++;
        }
        
    
*   **`do-while` loop:** Similar to `while`, but the loop body is executed at least once.
    
        int number = 0;
        do
        {
            Console.WriteLine(number);
            number++;
        } while (number < 3);
        
    
*   **`foreach` loop:** Iterates over elements in a collection.
    
        int[] numbers = { 1, 2, 3, 4, 5 };
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        
    

### 1.4. Methods

Methods are blocks of code that perform a specific task.

*   **Method Declaration:** `accessModifier returnType MethodName(parameters) { // method body }`
    
*   **Parameters:** Values passed into a method.
    
*   **Return Type:** The type of value returned by the method (or `void` if it doesn't return a value).
    
*   **Method Overloading:** Creating multiple methods with the same name but different parameters.
    
        public int Add(int a, int b)
        {
            return a + b;
        }
        
        public double Add(double a, double b) // Method overloading
        {
            return a + b;
        }
        
    

2\. Working with Strings and Collections
----------------------------------------

This section covers essential techniques for manipulating strings and working with collections of data.

### 2.1. String Manipulation

The `string` class provides numerous methods for working with text.

*   **Concatenation:** Combining strings using the `+` operator or `string.Concat()`.
    
*   **`string.Format()`:** Creating formatted strings.
    
        string name = "Alice";
        int age = 30;
        string message = string.Format("Name: {0}, Age: {1}", name, age);
        Console.WriteLine(message); // Output: Name: Alice, Age: 30
        
    
*   **`Substring()`:** Extracting a portion of a string.
    
        string text = "Hello World";
        string sub = text.Substring(6); // sub will be "World"
        string sub2 = text.Substring(0, 5); // sub2 will be "Hello"
        
    
*   **`IndexOf()` and `LastIndexOf()`:** Finding the position of a substring.
    
        string text = "Hello World";
        int index = text.IndexOf("World"); // index will be 6
        
    
*   **`Replace()`:** Replacing substrings.
    
        string text = "Hello World";
        string newText = text.Replace("World", "C#"); // newText will be "Hello C#"
        
    
*   **`ToUpper()` and `ToLower()`:** Changing the case of a string.
    
*   **`Trim()`:** Removing leading and trailing whitespace.
    
*   **`Split()`:** Splitting a string into an array of substrings based on a delimiter.
    
        string text = "apple,banana,orange";
        string[] fruits = text.Split(','); // fruits will be {"apple", "banana", "orange"}
        
    
*   **`string.IsNullOrEmpty()` and `string.IsNullOrWhiteSpace()`:** Checking if a string is null or empty.
    

### 2.2. Lists

`List<T>` is a dynamic array that can grow or shrink as needed.

*   **Creating a List:** `List<int> numbers = new List<int>();`
    
*   **Adding Elements:** `numbers.Add(10);`
    
*   **Inserting Elements:** `numbers.Insert(0, 5);` (inserts 5 at index 0)
    
*   **Removing Elements:** `numbers.Remove(10);` (removes the first occurrence of 10), `numbers.RemoveAt(0);` (removes the element at index 0)
    
*   **Accessing Elements:** `int firstNumber = numbers[0];`
    
*   **`Count` Property:** Gets the number of elements in the list.
    
*   **`Contains()`:** Checks if the list contains a specific element.
    
*   **`Clear()`:** Removes all elements from the list.
    
*   **Iterating through a List:**
    
        List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
        
    

### 2.3. Arrays

Arrays are fixed-size collections of elements of the same type.

*   **Array Declaration:** `int[] numbers = new int[5];` (creates an array of 5 integers) or `int[] numbers = { 1, 2, 3, 4, 5 };`
    
*   **Accessing Elements:** `int firstNumber = numbers[0];`
    
*   **`Length` Property:** Gets the number of elements in the array.
    
*   **Iterating through an Array:**
    
        int[] numbers = { 1, 2, 3, 4, 5 };
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
        
    

### 2.4. Dictionaries

`Dictionary<TKey, TValue>` stores key-value pairs. Keys must be unique.

*   **Creating a Dictionary:** `Dictionary<string, int> ages = new Dictionary<string, int>();`
    
*   **Adding Elements:** `ages.Add("Alice", 30);`
    
*   **Accessing Elements:** `int aliceAge = ages["Alice"];` (throws an exception if the key doesn't exist)
    
*   **`TryGetValue()`:** Safely retrieves a value without throwing an exception.
    
        int age;
        if (ages.TryGetValue("Bob", out age))
        {
            Console.WriteLine("Bob's age is: " + age);
        }
        else
        {
            Console.WriteLine("Bob's age is not found.");
        }
        
    
*   **`ContainsKey()`:** Checks if the dictionary contains a specific key.
    
*   **Iterating through a Dictionary:**
    
        Dictionary<string, string> countries = new Dictionary<string, string>()
        {
            {"USA", "United States"},
            {"IND", "India"},
            {"UK", "United Kingdom"}
        };
        
        foreach (KeyValuePair<string, string> country in countries)
        {
            Console.WriteLine($"Code: {country.Key}, Country: {country.Value}");
        }
        
    

3\. More Collection Types
-------------------------

This section explores additional collection types available in C#.

### 3.1. HashSet

`HashSet<T>` is a collection that contains no duplicate elements. It provides efficient set operations.

*   **Creating a HashSet:** `HashSet<int> numbers = new HashSet<int>();`
    
*   **Adding Elements:** `numbers.Add(10);` (returns `true` if the element was added, `false` if it already exists)
    
*   **Removing Elements:** `numbers.Remove(10);`
    
*   **`Contains()`:** Checks if the set contains a specific element.
    
*   **Set Operations:**
    
    *   `UnionWith()`: Adds all elements from another collection to the set.
    *   `IntersectWith()`: Modifies the set to contain only elements that are also in another collection.
    *   `ExceptWith()`: Removes all elements from the set that are also in another collection.
    *   `IsSubsetOf()`: Determines whether the current set is a subset of a specified collection.
    *   `IsSupersetOf()`: Determines whether the current set is a superset of a specified collection.
    
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };
        
        set1.UnionWith(set2); // set1 now contains { 1, 2, 3, 4, 5 }
        
    

### 3.2. Queue

`Queue<T>` represents a first-in, first-out (FIFO) collection.

*   **Creating a Queue:** `Queue<string> messages = new Queue<string>();`
    
*   **Enqueue:** Adds an element to the end of the queue. `messages.Enqueue("Hello");`
    
*   **Dequeue:** Removes and returns the element at the beginning of the queue. `string message = messages.Dequeue();`
    
*   **Peek:** Returns the element at the beginning of the queue without removing it. `string nextMessage = messages.Peek();`
    
*   **`Count` Property:** Gets the number of elements in the queue.
    
        Queue<string> myQ = new Queue<string>();
        myQ.Enqueue("Hello");
        myQ.Enqueue("World");
        myQ.Enqueue("!");
        
        while (myQ.Count > 0)
        {
            Console.WriteLine(myQ.Dequeue());
        }
        
    

### 3.3. Stack

`Stack<T>` represents a last-in, first-out (LIFO) collection.

*   **Creating a Stack:** `Stack<int> numbers = new Stack<int>();`
    
*   **Push:** Adds an element to the top of the stack. `numbers.Push(10);`
    
*   **Pop:** Removes and returns the element at the top of the stack. `int number = numbers.Pop();`
    
*   **Peek:** Returns the element at the top of the stack without removing it. `int topNumber = numbers.Peek();`
    
*   **`Count` Property:** Gets the number of elements in the stack.
    
        Stack<int> myStack = new Stack<int>();
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        
        while (myStack.Count > 0)
        {
            Console.WriteLine(myStack.Pop());
        }
        
    

### 3.4. LinkedList

`LinkedList<T>` represents a doubly linked list. Each element is a `LinkedListNode<T>` that contains a value and references to the next and previous nodes.

*   **Creating a LinkedList:** `LinkedList<string> names = new LinkedList<string>();`
    
*   **Adding Elements:**
    
    *   `AddFirst()`: Adds an element to the beginning of the list.
    *   `AddLast()`: Adds an element to the end of the list.
    *   `AddBefore()`: Adds an element before an existing node.
    *   `AddAfter()`: Adds an element after an existing node.
*   **Removing Elements:**
    
    *   `RemoveFirst()`: Removes the first element.
    *   `RemoveLast()`: Removes the last element.
    *   `Remove()`: Removes a specific element or a specific node.
*   **Finding Elements:** `Find()`: Finds the first node that contains a specific value. `FindLast()`: Finds the last node that contains a specific value.
    
*   **Iterating through a LinkedList:**
    
        LinkedList<string> linkedList = new LinkedList<string>();
        linkedList.AddLast("A");
        linkedList.AddLast("B");
        linkedList.AddLast("C");
        
        foreach (string item in linkedList)
        {
            Console.WriteLine(item);
        }
        
    

4\. Exception Handling and File I/O
-----------------------------------

This section covers how to handle errors gracefully and how to read and write files.

### 4.1. Exception Handling

Exception handling allows you to deal with runtime errors in a structured way.

*   **`try-catch` Blocks:** Enclose code that might throw an exception in a `try` block. Handle the exception in a `catch` block.
    
        try
        {
            int result = 10 / 0; // This will throw a DivideByZeroException
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Division by zero.");
            Console.WriteLine(ex.Message); // Access the exception message
        }
        catch (Exception ex) // Catch any other exception
        {
            Console.WriteLine("An error occurred.");
            Console.WriteLine(ex.Message);
        }
        
    
*   **`finally` Block:** Code in the `finally` block is always executed, regardless of whether an exception was thrown or caught. This is often used to release resources.
    
        System.IO.StreamReader file = null;
        try
        {
            file = new System.IO.StreamReader("NonExistentFile.txt");
            string line = file.ReadLine();
            Console.WriteLine(line);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }
        finally
        {
            if (file != null)
            {
                file.Close(); // Ensure the file is closed, even if an error occurred
            }
        }
        
    
*   **`throw` Statement:** Throws an exception. You can throw existing exceptions or create your own custom exceptions.
    
        public void ValidateAge(int age)
        {
            if (age < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }
        }
        
    
*   **Custom Exceptions:** Create your own exception classes by inheriting from the `Exception` class.
    
        public class InvalidNameException : Exception
        {
            public InvalidNameException(string message) : base(message) { }
        }
        
        public void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidNameException("Name cannot be empty.");
            }
        }
        
    

### 4.2. File I/O

File I/O allows you to read data from and write data to files.

*   **`StreamReader`:** Reads text from a file.
    
        try
        {
            using (StreamReader reader = new StreamReader("myFile.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }
        
    
*   **`StreamWriter`:** Writes text to a file.
    
        try
        {
            using (StreamWriter writer = new StreamWriter("myFile.txt"))
            {
                writer.WriteLine("Hello, world!");
                writer.WriteLine("This is a new line.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
        }
        
    
*   **`File` Class:** Provides static methods for working with files.
    
    *   `File.Exists()`: Checks if a file exists.
    *   `File.Create()`: Creates a new file.
    *   `File.Delete()`: Deletes a file.
    *   `File.Copy()`: Copies a file.
    *   `File.Move()`: Moves a file.
    *   `File.ReadAllText()`: Reads the entire content of a file into a string.
    *   `File.WriteAllText()`: Writes a string to a file.
    *   `File.ReadAllLines()`: Reads all lines from a file into a string array.
    *   `File.WriteAllLines()`: Writes an array of strings to a file.
    
        if (File.Exists("myFile.txt"))
        {
            string content = File.ReadAllText("myFile.txt");
            Console.WriteLine(content);
        }
        
    
*   **`Directory` Class:** Provides static methods for working with directories.
    
    *   `Directory.Exists()`: Checks if a directory exists.
    *   `Directory.CreateDirectory()`: Creates a new directory.
    *   `Directory.Delete()`: Deletes a directory.
    *   `Directory.GetFiles()`: Returns an array of file names in a directory.
    *   `Directory.GetDirectories()`: Returns an array of subdirectory names in a directory.
    
        if (!Directory.Exists("myDirectory"))
        {
            Directory.CreateDirectory("myDirectory");
        }
        
    

5\. OOPs Basics
---------------

This section covers the fundamental principles of Object-Oriented Programming (OOP) in C#.

### 5.1. Classes and Objects

*   **Class:** A blueprint for creating objects. It defines the properties (data) and methods (behavior) that objects of that class will have.
    
*   **Object:** An instance of a class.
    
        class Dog
        {
            public string Name { get; set; }
            public string Breed { get; set; }
        
            public void Bark()
            {
                Console.WriteLine("Woof!");
            }
        }
        
        // Creating an object of the Dog class
        Dog myDog = new Dog();
        myDog.Name = "Buddy";
        myDog.Breed = "Golden Retriever";
        myDog.Bark(); // Output: Woof!
        
    

### 5.2. Encapsulation

Encapsulation is the bundling of data (fields) and methods that operate on that data within a class, and restricting direct access to some of the object's components. This is achieved through access modifiers.

*   **Access Modifiers:**
    
    *   `public`: Accessible from anywhere.
    *   `private`: Accessible only within the class.
    *   `protected`: Accessible within the class and its derived classes.
    *   `internal`: Accessible within the same assembly.
    *   `protected internal`: Accessible within the same assembly or from derived classes in another assembly.
    *   `private protected`: Accessible within the declaring class or from derived classes within the same assembly.
    
        class BankAccount
        {
            private decimal balance; // Private field
        
            public void Deposit(decimal amount)
            {
                balance += amount;
            }
        
            public decimal GetBalance() // Public method to access the balance
            {
                return balance;
            }
        }
        
    

### 5.3. Inheritance

Inheritance allows you to create new classes (derived classes) based on existing classes (base classes). The derived class inherits the properties and methods of the base class and can add its own.

*   **Base Class:** The class being inherited from.
    
*   **Derived Class:** The class that inherits from the base class.
    
*   **`:` Operator:** Used to specify inheritance.
    
*   **`virtual` and `override` Keywords:** Used for method overriding (allowing a derived class to provide a specific implementation of a method defined in the base class).
    
        class Animal
        {
            public virtual void MakeSound()
            {
                Console.WriteLine("Generic animal sound");
            }
        }
        
        class Dog : Animal // Dog inherits from Animal
        {
            public override void MakeSound() // Overriding the MakeSound method
            {
                Console.WriteLine("Woof!");
            }
        }
        
        Animal animal = new Animal();
        animal.MakeSound(); // Output: Generic animal sound
        
        Dog dog = new Dog();
        dog.MakeSound(); // Output: Woof!
        
    

### 5.4. Polymorphism

Polymorphism means "many forms." It allows objects of different classes to be treated as objects of a common type.

*   **Method Overriding (Runtime Polymorphism):** Achieved through `virtual` and `override` keywords, as shown in the Inheritance example.
    
*   **Method Overloading (Compile-time Polymorphism):** Creating multiple methods with the same name but different parameters, as shown in the Methods section.
    
*   **Interface Implementation:** A class can implement multiple interfaces, allowing it to be treated as any of those interface types.
    
        interface ISpeak
        {
            void Speak();
        }
        
        class Cat : ISpeak
        {
            public void Speak()
            {
                Console.WriteLine("Meow!");
            }
        }
        
        class Person : ISpeak
        {
            public void Speak()
            {
                Console.WriteLine("Hello!");
            }
        }
        
        ISpeak[] speakers = { new Cat(), new Person() };
        foreach (ISpeak speaker in speakers)
        {
            speaker.Speak(); // Output: Meow!  Hello!
        }
        
    

### 5.5. Abstraction

Abstraction involves simplifying complex reality by modeling classes based on essential characteristics, ignoring non-essential details. Abstract classes and interfaces are used to achieve abstraction.

*   **Abstract Class:** A class that cannot be instantiated directly. It can contain abstract methods (methods without implementation) that must be implemented by derived classes.
    
        abstract class Shape
        {
            public abstract double GetArea(); // Abstract method
        
            public virtual void Display()
            {
                Console.WriteLine("This is a shape.");
            }
        }
        
        class Circle : Shape
        {
            public double Radius { get; set; }
        
            public override double GetArea() // Implementing the abstract method
            {
                return Math.PI * Radius * Radius;
            }
        }
        
    
*   **Interface:** A completely abstract type that defines a contract. It contains only method signatures, property declarations, and event declarations (no implementation). Classes that implement the interface must provide implementations for all its members.
    
        interface IPrintable
        {
            void Print();
        }
        
        class Document : IPrintable
        {
            public string Content { get; set; }
        
            public void Print() // Implementing the interface method
            {
                Console.WriteLine("Printing document: " + Content);
            }
        }
        
    

6\. Data Serialization and Deserialization
------------------------------------------

This section covers how to convert objects to a format that can be stored or transmitted (serialization) and how to convert that format back into objects (deserialization).

### 6.1. JSON Serialization

JSON (JavaScript Object Notation) is a lightweight data-interchange format.

*   **`System.Text.Json` Namespace:** Provides classes for JSON serialization and deserialization. This is the recommended library for .NET Core and later.
    
*   **`JsonSerializer.Serialize()`:** Serializes an object to a JSON string.
    
*   **`JsonSerializer.Deserialize()`:** Deserializes a JSON string to an object.
    
        using System.Text.Json;
        
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        
        // Serialization
        Person person = new Person { Name = "Alice", Age = 30 };
        string jsonString = JsonSerializer.Serialize(person);
        Console.WriteLine(jsonString); // Output: {"Name":"Alice","Age":30}
        
        // Deserialization
        Person deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
        Console.WriteLine(deserializedPerson.Name); // Output: Alice
        Console.WriteLine(deserializedPerson.Age); // Output: 30
        
    
*   **`JsonSerializerOptions`:** Allows you to customize the serialization and deserialization process (e.g., indentation, property naming policies).
    
        var options = new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };
        string jsonString = JsonSerializer.Serialize(person, options);
        Person deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString, options);
        
    

### 6.2. XML Serialization

XML (Extensible Markup Language) is another data-interchange format.

*   **`System.Xml.Serialization` Namespace:** Provides classes for XML serialization and deserialization.
    
*   **`XmlSerializer` Class:** Used to serialize and deserialize objects to and from XML.
    
*   **`[XmlRoot]` Attribute:** Specifies the root element name in the XML document.
    
*   **`[XmlElement]` Attribute:** Specifies the element name for a property.
    
*   **`[XmlAttribute]` Attribute:** Specifies that a property should be serialized as an attribute.
    
        using System.Xml.Serialization;
        using System.IO;
        
        [XmlRoot("Person")]
        public class Person
        {
            [XmlElement("Name")]
            public string Name { get; set; }
        
            [XmlAttribute("Age")]
            public int Age { get; set; }
        }
        
        // Serialization
        Person person = new Person { Name = "Alice", Age = 30 };
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        using (TextWriter writer = new StreamWriter("person.xml"))
        {
            serializer.Serialize(writer, person);
        }
        
        // Deserialization
        XmlSerializer deserializer = new XmlSerializer(typeof(Person));
        Person deserializedPerson;
        using (TextReader reader = new StreamReader("person.xml"))
        {
            deserializedPerson = (Person)deserializer.Deserialize(reader);
        }
        
        Console.WriteLine(deserializedPerson.Name); // Output: Alice
        Console.WriteLine(deserializedPerson.Age); // Output: 30
        
    

### 6.3. Binary Serialization

Binary serialization converts an object into a binary format. This is generally more compact and faster than JSON or XML serialization, but it's less human-readable and less portable.

*   **`System.Runtime.Serialization.Formatters.Binary` Namespace:** Provides classes for binary serialization and deserialization.
    
*   **`BinaryFormatter` Class:** Used to serialize and deserialize objects to and from binary format.
    
*   **`[Serializable]` Attribute:** Must be applied to a class to indicate that it can be serialized.
    
        using System;
        using System.IO;
        using System.Runtime.Serialization;
        using System.Runtime.Serialization.Formatters.Binary;
        
        [Serializable]
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        
        // Serialization
        Person person = new Person { Name = "Alice", Age = 30 };
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream("person.bin", FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, person);
        }
        
        // Deserialization
        Person deserializedPerson;
        using (Stream stream = new FileStream("person.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            deserializedPerson = (Person)formatter.Deserialize(stream);
        }
        
        Console.WriteLine(deserializedPerson.Name); // Output: Alice
        Console.WriteLine(deserializedPerson.Age); // Output: 30
        
    

**Important Considerations:**

*   **Security:** Be cautious when deserializing data from untrusted sources, as it can pose security risks (e.g., code injection).
*   **Versioning:** Changes to class definitions can break serialization/deserialization compatibility. Consider using versioning strategies to handle these changes.
*   **Performance:** Binary serialization is generally faster than JSON or XML serialization, but it's less portable. JSON is often a good choice for web APIs due to its widespread support.

## 7 C# Delegates and Events: A Complete Guide
=========================================

Understanding Delegates Basics
------------------------------

Delegates are type-safe function pointers. They allow you to treat methods as objects, passing them as arguments to other methods, storing them in data structures, and invoking them later. Think of a delegate as a placeholder for a method. It defines the signature (return type and parameters) of the method it can represent.

*   **Type Safety:** Delegates enforce type safety. You can only assign a method to a delegate if the method's signature matches the delegate's signature. This prevents runtime errors that can occur with traditional function pointers.
    
*   **Encapsulation:** Delegates encapsulate methods, allowing you to pass them around without exposing the underlying implementation.
    
*   **Flexibility:** Delegates enable flexible and dynamic code. You can change the method that a delegate points to at runtime, allowing you to customize behavior without modifying the calling code.
    

### Delegate Declaration

A delegate declaration defines the signature of the methods that the delegate can represent. The syntax is:

    delegate return_type delegate_name(parameter_list);
    

*   `return_type`: The return type of the methods that the delegate can represent.
*   `delegate_name`: The name of the delegate type.
*   `parameter_list`: The list of parameters that the methods must accept.

**Example:**

    delegate void MyDelegate(string message);
    

This declares a delegate named `MyDelegate` that can represent methods that take a string as input and return void.

Creating and Using Delegates
----------------------------

### Instantiating a Delegate

Once you've declared a delegate type, you can create instances of it. You can instantiate a delegate by passing a method that matches the delegate's signature to the delegate's constructor.

    MyDelegate myDelegate = new MyDelegate(MyMethod);
    

Here, `MyMethod` is a method that matches the signature of `MyDelegate` (takes a string and returns void).

### Invoking a Delegate

You can invoke a delegate just like you would invoke a method.

    myDelegate("Hello, world!");
    

This will execute the method that the delegate points to (`MyMethod` in this case), passing the string "Hello, world!" as an argument.

### Complete Example

    using System;
    
    public class DelegateExample
    {
        // Declare a delegate
        delegate void MyDelegate(string message);
    
        // A method that matches the delegate's signature
        static void MyMethod(string message)
        {
            Console.WriteLine("Message: " + message);
        }
    
        public static void Main(string[] args)
        {
            // Instantiate the delegate
            MyDelegate myDelegate = new MyDelegate(MyMethod);
    
            // Invoke the delegate
            myDelegate("Hello, Delegates!");
    
            // Another method that matches the delegate's signature
            static void AnotherMethod(string message)
            {
                Console.WriteLine("Another Message: " + message.ToUpper());
            }
    
            // Reassign the delegate to a different method
            myDelegate = new MyDelegate(AnotherMethod);
    
            // Invoke the delegate again
            myDelegate("Hello, Again!");
        }
    }
    

This example demonstrates how to declare, instantiate, and invoke a delegate. It also shows how you can reassign a delegate to point to a different method at runtime.

### Multicast Delegates

Delegates can also hold a list of methods, known as a multicast delegate. When you invoke a multicast delegate, it invokes all the methods in its list, in the order they were added.

*   **Combining Delegates:** You can combine delegates using the `+` or `+=` operators.
*   **Removing Delegates:** You can remove delegates using the `-` or `-=` operators.

    using System;
    
    public class MulticastDelegateExample
    {
        delegate void MyDelegate(string message);
    
        static void Method1(string message)
        {
            Console.WriteLine("Method1: " + message);
        }
    
        static void Method2(string message)
        {
            Console.WriteLine("Method2: " + message.ToUpper());
        }
    
        public static void Main(string[] args)
        {
            MyDelegate myDelegate = new MyDelegate(Method1);
            myDelegate += Method2; // Combine delegates
    
            myDelegate("Hello, Multicast!"); // Invokes both Method1 and Method2
    
            myDelegate -= Method1; // Remove Method1
    
            myDelegate("Hello, Again!"); // Invokes only Method2
        }
    }
    

In this example, `myDelegate` initially points to `Method1`. Then, `Method2` is added to the delegate's invocation list. When `myDelegate` is invoked, both `Method1` and `Method2` are executed. Finally, `Method1` is removed, and only `Method2` is executed.

Introduction to Events
----------------------

Events are a mechanism for objects to notify other objects when something interesting happens. They are based on delegates and provide a way to implement the observer pattern. Events help decouple objects, making your code more modular and maintainable.

*   **Publisher:** The object that raises the event.
*   **Subscriber:** The object that receives the notification when the event is raised.
*   **Event Handler:** The method that is executed when the event is raised.

Delegates and Events: The Relationship
--------------------------------------

Events are built on top of delegates. An event is essentially a delegate with restricted access. The class that declares the event can raise it (invoke the delegate), but other classes can only subscribe to the event (add methods to the delegate's invocation list). This prevents external classes from arbitrarily invoking the event, ensuring that the event is only raised when appropriate.

Declaring and Raising Events
----------------------------

### Declaring an Event

To declare an event, you use the `event` keyword, followed by the delegate type and the event name.

    public event MyDelegate MyEvent;
    

Here, `MyEvent` is an event of type `MyDelegate`.

### Raising an Event

To raise an event, you invoke the delegate associated with the event. Before raising the event, you should always check if the delegate is null (i.e., if there are any subscribers).

    if (MyEvent != null)
    {
        MyEvent("Event raised!");
    }
    

A more concise way to raise the event (C# 6.0 and later) is to use the null-conditional operator:

    MyEvent?.Invoke("Event raised!");
    

This is equivalent to the previous code, but it's more compact and readable.

### Complete Example

    using System;
    
    public class EventPublisher
    {
        // Declare a delegate
        public delegate void MyDelegate(string message);
    
        // Declare an event based on the delegate
        public event MyDelegate MyEvent;
    
        // Method to raise the event
        public void RaiseEvent(string message)
        {
            Console.WriteLine("Raising event...");
            MyEvent?.Invoke(message);
        }
    }
    
    public class EventSubscriber
    {
        // Event handler method
        public void HandleEvent(string message)
        {
            Console.WriteLine("Event received: " + message);
        }
    }
    
    public class EventExample
    {
        public static void Main(string[] args)
        {
            // Create publisher and subscriber objects
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();
    
            // Subscribe to the event
            publisher.MyEvent += subscriber.HandleEvent;
    
            // Raise the event
            publisher.RaiseEvent("Hello, Events!");
    
            // Unsubscribe from the event
            publisher.MyEvent -= subscriber.HandleEvent;
    
            // Raise the event again (no subscriber)
            publisher.RaiseEvent("Hello, Again!"); // No output from subscriber
        }
    }
    

In this example, `EventPublisher` declares and raises the event `MyEvent`. `EventSubscriber` subscribes to the event and provides an event handler method (`HandleEvent`). When the event is raised, the event handler is executed.

Event Handlers Basics
---------------------

Event handlers are methods that are executed when an event is raised. They must have a signature that matches the delegate type associated with the event.

### Standard Event Handler Pattern

The standard event handler pattern in .NET uses the `EventHandler` delegate and the `EventArgs` class.

*   `EventHandler`: A generic delegate that takes two parameters: the object that raised the event (the sender) and an `EventArgs` object that contains information about the event.
    
        public delegate void EventHandler(object sender, EventArgs e);
        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;
        
    
*   `EventArgs`: A base class for event data. You can create custom `EventArgs` classes to pass specific information about the event to the event handler.
    
        public class EventArgs
        {
            public static readonly EventArgs Empty; // Represents an event with no data.
        }
        
    

### Example Using the Standard Pattern

    using System;
    
    public class MyEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
    
    public class EventPublisher
    {
        public event EventHandler<MyEventArgs> MyEvent;
    
        public void RaiseEvent(string message)
        {
            Console.WriteLine("Raising event...");
            MyEvent?.Invoke(this, new MyEventArgs { Message = message });
        }
    }
    
    public class EventSubscriber
    {
        public void HandleEvent(object sender, MyEventArgs e)
        {
            Console.WriteLine("Event received: " + e.Message);
        }
    }
    
    public class EventExample
    {
        public static void Main(string[] args)
        {
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();
    
            publisher.MyEvent += subscriber.HandleEvent;
    
            publisher.RaiseEvent("Hello, Standard Events!");
        }
    }
    

In this example, `MyEventArgs` is a custom class that inherits from `EventArgs` and contains a `Message` property. The `MyEvent` event uses the `EventHandler<MyEventArgs>` delegate. The `HandleEvent` method is the event handler and takes the sender (the `EventPublisher` object) and a `MyEventArgs` object as parameters.

Anonymous Methods and Events
----------------------------

Anonymous methods (also known as lambda expressions) provide a concise way to define event handlers without creating separate named methods.

### Using Anonymous Methods with Events

You can use anonymous methods to subscribe to events directly, without defining a separate event handler method.

    using System;
    
    public class EventPublisher
    {
        public event EventHandler<EventArgs> MyEvent;
    
        public void RaiseEvent(string message)
        {
            Console.WriteLine("Raising event...");
            MyEvent?.Invoke(this, EventArgs.Empty);
        }
    }
    
    public class AnonymousMethodEventExample
    {
        public static void Main(string[] args)
        {
            EventPublisher publisher = new EventPublisher();
    
            // Subscribe to the event using an anonymous method
            publisher.MyEvent += delegate (object sender, EventArgs e)
            {
                Console.WriteLine("Event received (anonymous method)!");
            };
    
            publisher.RaiseEvent("Hello, Anonymous Methods!");
    
            // Using a lambda expression (more concise)
            publisher.MyEvent += (sender, e) =>
            {
                Console.WriteLine("Event received (lambda expression)!");
            };
    
            publisher.RaiseEvent("Hello, Lambdas!");
        }
    }
    

In this example, an anonymous method and a lambda expression are used to subscribe to the `MyEvent` event. Both achieve the same result: executing code when the event is raised, without the need for a separate named method. Lambda expressions are generally preferred for their conciseness.

### Benefits of Anonymous Methods

*   **Conciseness:** Anonymous methods reduce the amount of code required to define event handlers.
*   **Readability:** In simple cases, anonymous methods can improve code readability by keeping the event handler logic close to the event subscription.
*   **Context:** Anonymous methods can access variables from the surrounding scope, which can be useful in certain scenarios.

By understanding and utilizing delegates and events effectively, you can create more flexible, maintainable, and decoupled C# applications.
