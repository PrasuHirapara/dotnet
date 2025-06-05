# Exception Handling in C\#

## Introduction

**Exception handling** in C# is a structured mechanism to detect and respond to runtime errors (exceptions). It helps developers maintain program stability by catching errors and taking appropriate action without abruptly crashing the application.

C# provides a set of keywords (`try`, `catch`, `finally`, `throw`) to implement exception handling in a clean and readable way.

---

## How It Works

* The `try` block contains code that might throw an exception.
* The `catch` block defines how to handle specific or general exceptions.
* The `finally` block contains code that will run regardless of whether an exception occurred or not.
* The `throw` statement is used to manually raise an exception.

### Characteristics:

* Object-oriented and type-safe
* Built-in support for both system and user-defined exceptions
* Exceptions are derived from `System.Exception`

---

| Keyword   | Usage                                   | Description                                                         |
| --------- | --------------------------------------- | ------------------------------------------------------------------- |
| `try`     | `try { /* code */ }`                    | Defines the block of code to monitor for exceptions.                |
| `catch`   | `catch (Exception ex) { /* handle */ }` | Handles the exception. Can use multiple blocks for different types. |
| `finally` | `finally { /* clean up */ }`            | Optional. Executes code after try/catch regardless of result.       |
| `throw`   | `throw ex;` or `throw;`                 | Rethrows or throws a new exception.                                 |

---

## Common Exception Types

| Exception Class                    | Description                                  |
| ---------------------------------- | -------------------------------------------- |
| `System.Exception`                 | Base class for all exceptions.               |
| `System.NullReferenceException`    | Thrown when attempting to use a null object. |
| `System.IndexOutOfRangeException`  | Array index is outside its bounds.           |
| `System.InvalidOperationException` | Invalid operation based on current state.    |
| `System.DivideByZeroException`     | Division by zero occurred.                   |
| `System.IO.IOException`            | I/O-related failures.                        |

---

## Code Example

```csharp
using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter numerator:");
            int numerator = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter denominator:");
            int denominator = Convert.ToInt32(Console.ReadLine());

            int result = numerator / denominator;
            Console.WriteLine($"Result: {result}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: Please enter valid integers.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Execution completed.");
        }
    }
}
```

---

## Advantages

* **Improves Program Stability**: Prevents application crashes.
* **Error Reporting**: Provides detailed stack trace and error message.
* **Centralized Error Handling**: Cleaner code via structured error blocks.
* **Resource Management**: Ensures resources (like files, connections) are properly closed.

---

## Use Cases

* Handling invalid user input
* Managing I/O operations (e.g., file access, network calls)
* Dealing with null references or out-of-bound errors
* Logging and diagnostics
* Validating business logic and constraints

---

> **Namespace:** `System`

> **Base Exception Class:** `System.Exception`
