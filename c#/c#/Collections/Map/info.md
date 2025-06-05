# Dictionary\<TKey, TValue> Class in C\#

## Introduction

The `Dictionary<TKey, TValue>` class in C# is a generic collection that stores key-value pairs. It belongs to the `System.Collections.Generic` namespace and allows fast lookup, insertion, and deletion based on keys. It functions similarly to a map or associative array found in other programming languages.

## How it Works

* `Dictionary<TKey, TValue>` is a **generic** and **hash-based** collection.
* Keys must be unique and cannot be null (for reference types).
* Values can be duplicated and can be null (for reference types).
* Implements `IDictionary<TKey, TValue>`, `IEnumerable<KeyValuePair<TKey, TValue>>`, `ICollection`, and other interfaces.

## Constructor Table

| Constructor Signature                                 | Description                                              |
| ----------------------------------------------------- | -------------------------------------------------------- |
| Dictionary\<TKey, TValue>()                           | Initializes an empty dictionary.                         |
| Dictionary\<TKey, TValue>(int capacity)               | Initializes with a specified initial capacity.           |
| Dictionary\<TKey, TValue>(IEqualityComparer<TKey>)    | Initializes with a custom key comparer.                  |
| Dictionary\<TKey, TValue>(IDictionary\<TKey, TValue>) | Initializes by copying elements from another dictionary. |

## Method Table

| Return Type         | Method Name     | Parameters                 | Description                                               |
| ------------------- | --------------- | -------------------------- | --------------------------------------------------------- |
| void                | Add             | TKey key, TValue value     | Adds an element with the specified key and value.         |
| bool                | ContainsKey     | TKey key                   | Determines if the key exists in the dictionary.           |
| bool                | TryGetValue     | TKey key, out TValue value | Tries to get the value associated with the specified key. |
| bool                | Remove          | TKey key                   | Removes the element with the specified key.               |
| void                | Clear           | -                          | Removes all elements from the dictionary.                 |
| int                 | Count           | -                          | Gets the number of key-value pairs.                       |
| ICollection<TKey>   | Keys            | -                          | Gets a collection containing the keys.                    |
| ICollection<TValue> | Values          | -                          | Gets a collection containing the values.                  |
| TValue              | this\[TKey key] | TKey key                   | Gets or sets the value associated with the specified key. |

## Code Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, string> studentMap = new Dictionary<int, string>();

        studentMap.Add(101, "Alice");
        studentMap.Add(102, "Bob");
        studentMap[103] = "Charlie"; // Alternative way to add

        Console.WriteLine("Student List:");
        foreach (var kvp in studentMap)
        {
            Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
        }

        if (studentMap.ContainsKey(102))
        {
            Console.WriteLine($"ID 102 belongs to: {studentMap[102]}");
        }

        studentMap.Remove(101);

        if (studentMap.TryGetValue(103, out string name))
        {
            Console.WriteLine($"ID 103 belongs to: {name}");
        }

        Console.WriteLine("All Student IDs:");
        foreach (var id in studentMap.Keys)
        {
            Console.WriteLine(id);
        }
    }
}
```

## Advantages

* **Fast Lookup**: Constant-time complexity for lookups in average cases.
* **Type-Safe**: Strong typing with generics ensures compile-time checking.
* **Flexible Access**: Retrieve, insert, update, and delete by key.
* **Extensible**: Can use custom comparers for complex key logic.

## Use Cases

* **Indexing Data**: Storing and quickly retrieving data based on a key.
* **Configurations**: Storing application settings or parameters.
* **Mapping Relationships**: Representing mappings like user ID to name, product ID to description, etc.
* **Lookup Tables**: When fast access to data via a key is needed.
* **Counting Frequencies**: Counting elements or events with keys and numeric values.
