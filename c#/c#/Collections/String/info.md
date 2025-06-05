# String Class in C\#

## Introduction

The `string` class in C# represents a sequence of Unicode characters. It is one of the most commonly used types in the .NET framework. Strings in C# are **immutable**, meaning any operation that appears to modify a string actually creates a new string object.

The `string` class is an alias for `System.String` and provides a wide range of methods for manipulating text.

---

## How It Works

* The `string` class is a **reference type** but behaves like a **value type** in some contexts due to immutability.
* Any operation that changes the string creates a new string in memory.
* It supports indexing, concatenation, searching, formatting, and more.
* Because strings are immutable, `StringBuilder` is often used for performance in heavy modification scenarios.

### Characteristics:

* Immutable
* Interned by CLR (common strings are stored in a pool)
* Unicode-based
* Part of the `System` namespace
* Supports operator overloading (`+`, `==`, `!=`)

---

## Constructor Table

| Constructor                                  | Description                                     |
| -------------------------------------------- | ----------------------------------------------- |
| `String(char[])`                             | Initializes a string from a character array.    |
| `String(char, int)`                          | Initializes a string with a repeated character. |
| `String(char[], int startIndex, int length)` | Creates a string from a subset of a char array. |
| `String(ReadOnlySpan<char>)`                 | Initializes a string from a span of characters. |

---

## Method Table

| Return Type | Method Name  | Parameters                                         | Description                                                         |
| ----------- | ------------ | -------------------------------------------------- | ------------------------------------------------------------------- |
| `int`       | `Length`     | *Property*                                         | Returns the number of characters in the string.                     |
| `string`    | `Substring`  | `(int startIndex)`, `(int startIndex, int length)` | Returns a substring.                                                |
| `bool`      | `Contains`   | `(string value)`                                   | Checks if the string contains a specified value.                    |
| `bool`      | `StartsWith` | `(string value)`                                   | Checks if the string starts with the specified value.               |
| `bool`      | `EndsWith`   | `(string value)`                                   | Checks if the string ends with the specified value.                 |
| `int`       | `IndexOf`    | `(char)` or `(string)`                             | Returns the index of the first occurrence of a character or string. |
| `string`    | `Replace`    | `(string oldValue, string newValue)`               | Replaces all occurrences of a specified string.                     |
| `string`    | `ToUpper`    | `()`                                               | Converts the string to uppercase.                                   |
| `string`    | `ToLower`    | `()`                                               | Converts the string to lowercase.                                   |
| `string[]`  | `Split`      | `(params char[] separator)`                        | Splits the string into an array of substrings.                      |
| `string`    | `Trim`       | `()`                                               | Removes leading and trailing whitespace.                            |

---

## Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        string message = "  Hello, World!  ";

        // Trim
        string trimmed = message.Trim();
        Console.WriteLine("Trimmed: " + trimmed);

        // ToUpper
        string upper = trimmed.ToUpper();
        Console.WriteLine("Upper: " + upper);

        // Contains
        bool containsWorld = upper.Contains("WORLD");
        Console.WriteLine("Contains 'WORLD': " + containsWorld);

        // Replace
        string replaced = upper.Replace("WORLD", "C#");
        Console.WriteLine("Replaced: " + replaced);

        // Substring
        string sub = replaced.Substring(0, 5);
        Console.WriteLine("Substring: " + sub);

        // Split
        string[] words = trimmed.Split(',');
        Console.WriteLine("Split Result:");
        foreach (var word in words)
        {
            Console.WriteLine(word.Trim());
        }
    }
}
```

---

## Advantages

* **Easy to Use**: Extensive built-in methods make text manipulation intuitive.
* **Immutability**: Prevents accidental modification and is thread-safe.
* **Rich Functionality**: Includes searching, replacing, formatting, and more.
* **Unicode Support**: Fully supports internationalization.
* **Interoperability**: Integrates seamlessly with .NET APIs and system calls.

---

## Use Cases

* Displaying and manipulating user input.
* Parsing and formatting data (e.g., CSV, JSON).
* Logging and diagnostics.
* URL or path handling.
* Configuration and template-based processing.

---

> **Namespace:** `System`

> **Assembly:** `mscorlib.dll`
