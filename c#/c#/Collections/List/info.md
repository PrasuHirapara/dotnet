# List<T> Class in C\#

## Introduction

The `List<T>` class in C# is a part of the `System.Collections.Generic` namespace and represents a strongly typed list of objects that can be accessed by index. It provides dynamic array-like functionality with powerful methods for searching, sorting, inserting, and removing elements.

## How it Works

* `List<T>` is a **generic class**, meaning it can hold any data type specified at instantiation.
* Internally, it uses an array that automatically resizes as elements are added.
* Elements can be accessed via zero-based indexing.
* It implements `IEnumerable<T>`, `ICollection<T>`, `IList<T>`, and other interfaces.

## Constructor Table

| Constructor Signature   | Description                                                           |
| ----------------------- | --------------------------------------------------------------------- |
| List<T>()               | Initializes a new empty list.                                         |
| List<T>(int capacity)   | Initializes a list with a predefined capacity.                        |
| List<T>(IEnumerable<T>) | Initializes a list that contains elements copied from the collection. |

## Method Table

| Return Type | Method Name      | Parameters                      | Description                                           |
| ----------- | ---------------- | ------------------------------- | ----------------------------------------------------- |
| void        | Add              | T item                          | Adds an object to the end of the list.                |
| void        | AddRange         | IEnumerable<T> collection       | Adds the elements of the specified collection.        |
| void        | Insert           | int index, T item               | Inserts an element at the specified index.            |
| void        | Remove           | T item                          | Removes the first occurrence of a specific object.    |
| void        | RemoveAt         | int index                       | Removes the element at the specified index.           |
| void        | Clear            | -                               | Removes all elements from the list.                   |
| int         | IndexOf          | T item                          | Returns the zero-based index of the first occurrence. |
| bool        | Contains         | T item                          | Determines whether an element is in the list.         |
| int         | Count            | -                               | Gets the number of elements in the list.              |
| void        | Sort             | - or Comparison<T>/IComparer<T> | Sorts the elements in the list.                       |
| void        | Reverse          | - or int index, int count       | Reverses the order of elements.                       |
| T           | this\[int index] | int index                       | Gets or sets the element at the specified index.      |

## Code Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };
        fruits.Add("Date");
        fruits.Insert(1, "Blueberry");
        fruits.Remove("Banana");

        Console.WriteLine("Fruits List:");
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        Console.WriteLine($"Index of Cherry: {fruits.IndexOf("Cherry")}");
        Console.WriteLine($"Contains Apple: {fruits.Contains("Apple")}");

        fruits.Sort();
        fruits.Reverse();

        Console.WriteLine("Sorted and Reversed List:");
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
    }
}
```

## Advantages

* **Dynamic Sizing**: Automatically grows as needed.
* **Generic Support**: Type safety and no need for casting.
* **Rich API**: Provides a comprehensive set of methods for list manipulation.
* **Efficient Indexing**: Supports fast access by index.
* **Integration**: Works well with LINQ, lambda expressions, and other .NET features.

## Use Cases

* **Collections of Data**: Storing lists of items (e.g., names, products, scores).
* **Dynamic Arrays**: When the number of elements is unknown or changes over time.
* **UI Binding**: Used in data-binding for UI components like dropdowns and lists.
* **Filtering and Sorting**: Easy to apply filters, sorts, and search functionality.
* **Processing Sequences**: Looping through data to perform operations, analysis, or transformations.
