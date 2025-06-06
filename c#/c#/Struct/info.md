# Struct in C\#

## Introduction

A `struct` in C# is a value type that is typically used to encapsulate small groups of related variables, such as the coordinates of a rectangle or the characteristics of an item in an inventory. Structs are useful for improving performance in scenarios where the overhead of classes (which are reference types) is unnecessary. Structs are defined using the `struct` keyword and are stored on the stack, making access faster and avoiding garbage collection overhead.

Structs in C# can contain fields, methods, properties, constructors, and even implement interfaces.

---

## How It Works

* **Value Type**: Structs are stored on the stack, unlike classes which are reference types and stored on the heap.
* **Instance-Based**: Structs are created as instances, not inherited.
* **No Inheritance**: A struct cannot inherit from another struct or class, but it can implement interfaces.
* **Parameterless Constructors**: C# 10 and later allows parameterless constructors.
* **Default Constructor**: Every struct has a default parameterless constructor that initializes all fields to default values.

---

## Difference Between Struct and Class

| Feature             | Struct                                                                             | Class                                           |
| ------------------- | ---------------------------------------------------------------------------------- | ----------------------------------------------- |
| Type                | Value type                                                                         | Reference type                                  |
| Memory Location     | Stack                                                                              | Heap                                            |
| Inheritance         | Cannot inherit (but can implement interfaces)                                      | Can inherit from other classes                  |
| Default Constructor | Provided by compiler; cannot define parameterless constructors (except from C# 10) | Can define any constructors                     |
| Performance         | Faster for small data and fewer allocations                                        | More flexible and better for complex structures |
| Null Assignment     | Cannot be null (unless nullable)                                                   | Can be null                                     |
| Copy Behavior       | Copies entire data                                                                 | Copies reference only                           |
| Use Case            | Lightweight objects, performance-critical code                                     | Complex behavior, polymorphism                  |

---

## Constructor Table

| Constructor              | Description                                                                                                    |
| ------------------------ | -------------------------------------------------------------------------------------------------------------- |
| `StructName(parameters)` | Creates a struct instance and allows initialization of fields. Custom constructors must initialize all fields. |

---

## Method Table

| Return Type       | Method Name     | Parameters | Description                                    |
| ----------------- | --------------- | ---------- | ---------------------------------------------- |
| `void`            | `Display()`     | None       | Displays struct information (example method).  |
| `override string` | `ToString()`    | None       | Returns a string representation of the struct. |
| `bool`            | `Equals()`      | object obj | Compares the struct with another for equality. |
| `int`             | `GetHashCode()` | None       | Returns a hash code for the struct.            |

---

## Code Example

```csharp
using System;

struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Display()
    {
        Console.WriteLine($"Point: X={X}, Y={Y}");
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(10, 20);
        p1.Display();

        Console.WriteLine(p1.ToString());
        Console.WriteLine($"Hash Code: {p1.GetHashCode()}");
        Console.WriteLine($"Equals: {p1.Equals(new Point(10, 20))}");
    }
}
```

---

## Advantages

* Better performance for small, short-lived objects.
* Avoids garbage collection overhead.
* Useful for representing lightweight data structures.
* Can improve memory allocation efficiency.

---

## Use Cases

* Representing geometric types like points, rectangles, or vectors.
* Small data containers passed frequently across methods.
* Data structures used in high-performance or real-time applications.
* Value types in game development, graphics, and math libraries.

---
