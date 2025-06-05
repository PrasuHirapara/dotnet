# HashSet<T> Class in C\#

## Introduction

The `HashSet<T>` class in C# represents a set of values that are **unordered and contain no duplicate elements**. It is part of the `System.Collections.Generic` namespace and implements a hash-based set collection for efficient storage and retrieval of unique elements.

## How it Works

`HashSet<T>` uses the concept of hashing to store its elements. Internally, it is implemented using a hash table that allows fast lookup, insertion, and deletion operations.

### Characteristics:

* Belongs to the `System.Collections.Generic` namespace.
* Cannot contain duplicate elements.
* Order of elements is **not guaranteed**.
* Provides set operations such as union, intersection, and difference.
* Implements `ISet<T>`, `ICollection<T>`, `IEnumerable<T>`.
* Is a **concrete**, **instance-based** class (not static or abstract).

---

## Constructor Table

| Constructor                                        | Description                                                                                 |
| -------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `HashSet<T>()`                                     | Initializes a new empty instance of the `HashSet<T>` class.                                 |
| `HashSet<T>(IEnumerable<T>)`                       | Initializes a new `HashSet<T>` that contains elements copied from the specified collection. |
| `HashSet<T>(IEqualityComparer<T>)`                 | Initializes a new empty `HashSet<T>` with a specified comparer.                             |
| `HashSet<T>(IEnumerable<T>, IEqualityComparer<T>)` | Initializes a new `HashSet<T>` with elements from a collection and a comparer.              |

---

## Method Table

| Return Type      | Method Name     | Parameters               | Description                                                      |
| ---------------- | --------------- | ------------------------ | ---------------------------------------------------------------- |
| `bool`           | `Add`           | `(T item)`               | Adds the specified element if it is not already present.         |
| `void`           | `Clear`         | `()`                     | Removes all elements from the set.                               |
| `bool`           | `Contains`      | `(T item)`               | Determines whether the set contains the specified element.       |
| `bool`           | `Remove`        | `(T item)`               | Removes the specified element if it is present.                  |
| `void`           | `UnionWith`     | `(IEnumerable<T> other)` | Modifies the current set to contain all elements from both sets. |
| `void`           | `IntersectWith` | `(IEnumerable<T> other)` | Modifies the set to contain only elements present in both sets.  |
| `void`           | `ExceptWith`    | `(IEnumerable<T> other)` | Removes all elements in the specified collection from the set.   |
| `int`            | `Count`         | *Property*               | Gets the number of elements in the set.                          |
| `IEnumerator<T>` | `GetEnumerator` | `()`                     | Returns an enumerator that iterates through the set.             |

---

## Code Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a HashSet and add elements
        HashSet<string> fruits = new HashSet<string>();
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Orange");
        fruits.Add("Apple"); // Duplicate - won't be added

        Console.WriteLine("Initial Set:");
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // Check for element
        Console.WriteLine($"Contains Banana? {fruits.Contains("Banana")}");

        // Remove an element
        fruits.Remove("Orange");

        // Create another set
        HashSet<string> tropical = new HashSet<string>() { "Mango", "Banana" };

        // Union
        fruits.UnionWith(tropical);

        Console.WriteLine("After Union:");
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // Intersection
        fruits.IntersectWith(new HashSet<string>() { "Mango", "Apple" });

        Console.WriteLine("After Intersection:");
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // Clear set
        fruits.Clear();
        Console.WriteLine($"Set Count After Clear: {fruits.Count}");
    }
}
```

---

## Advantages

* **Prevents Duplicates**: Automatically ensures element uniqueness.
* **Efficient Operations**: Fast performance for add, remove, and lookup.
* **Set Theory Support**: Includes built-in support for union, intersection, and difference operations.
* **Memory Efficient**: Suitable for collections where duplicates are not needed.

---

## Use Cases

* Maintaining a unique list of tags, keywords, or identifiers.
* Performing set-based logic, such as finding common elements between two groups.
* Efficiently tracking seen/processed elements in data processing.
* Avoiding duplicates in algorithms like graph traversals or pathfinding.
* Filtering and comparing large datasets.

---