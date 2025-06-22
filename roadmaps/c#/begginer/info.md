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

7\. Delegates and Events
------------------------

This section covers delegates and events, which are fundamental concepts for implementing event-driven programming in C#.

### 7.1. Delegates

A delegate is a type that represents a reference to a method. It's similar to a function pointer in C or C++. Delegates allow you to pass methods as arguments to other methods, store methods in data structures, and invoke methods dynamically.

*   **Delegate Declaration:** `delegate returnType DelegateName(parameters);`
    
        delegate int MathOperation(int x, int y);
        
        class Calculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
        
            public int Subtract(int a, int b)
            {
                return a - b;
            }
        
            public int PerformOperation(int x, int y, MathOperation operation)
            {
                return operation(x, y);
            }
        }
        
        Calculator calculator = new Calculator();
        MathOperation addOperation = new MathOperation(calculator.Add); // Create a delegate instance
        int result = calculator.PerformOperation(5, 3, addOperation); // Pass the delegate as an argument
        Console.WriteLine(result); // Output: 8
        
        MathOperation subtractOperation = new MathOperation(calculator.Subtract);
        result = calculator.PerformOperation(5, 3, subtractOperation);
        Console.WriteLine(result); // Output: 2
        
    
*   **Multicast Delegates:** A delegate can hold references to multiple methods. When the delegate is invoked, all the methods in its invocation list are executed.
    
        delegate void MyDelegate(string message);
        
        class Example
        {
            public static void Method1(string message)
            {
                Console.WriteLine("Method1: " + message);
            }
        
            public static void Method2(string message)
            {
                Console.WriteLine("Method2: " + message);
            }
        }
        
        MyDelegate myDelegate = new MyDelegate(Example.Method1);
        myDelegate += Example.Method2; // Add Method2 to the invocation list
        
        myDelegate("Hello"); // Output: Method1: Hello  Method2: Hello
        
    
*   **`Action` and `Func` Delegates:** C# provides generic delegate types `Action` and `Func` to simplify delegate declarations.
    
    *   `Action`: Represents a method that takes zero or more input parameters and does not return a value. `Action<T1, T2>` takes two parameters, etc.
    *   `Func`: Represents a method that takes zero or more input parameters and returns a value. `Func<T, TResult>` takes one parameter and returns a result, `Func<T1, T2, TResult>` takes two parameters and returns a result, etc.
    

Related Topics
--------------

Explore related concepts to expand your knowledge

[.NET Framework Overview](/ai/guide?term=I%20have%20covered%20the%20basics%20of%20C%23%20Complete%20Guide%20and%20want%20to%20learn%20more%20about%20.NET%20Framework%20Overview&depth=essentials&id=&format=guide)[Design Patterns in C#](/ai/guide?term=I%20have%20covered%20the%20basics%20of%20C%23%20Complete%20Guide%20and%20want%20to%20learn%20more%20about%20Design%20Patterns%20in%20C%23&depth=essentials&id=&format=guide)

Dive Deeper
-----------

Take a deeper dive into specific areas

[LINQ (Language Integrated Query) in Detail](/ai/guide?term=I%20have%20covered%20the%20basics%20of%20C%23%20Complete%20Guide%20and%20want%20to%20dive%20deeper%20into%20LINQ%20(Language%20Integrated%20Query)%20in%20Detail&depth=detailed&id=&format=guide)[Asynchronous Programming with Async/Await](/ai/guide?term=I%20have%20covered%20the%20basics%20of%20C%23%20Complete%20Guide%20and%20want%20to%20dive%20deeper%20into%20Asynchronous%20Programming%20with%20Async%2FAwait&depth=detailed&id=&format=guide)