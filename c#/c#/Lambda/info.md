# Lambda Expressions in C\#

## Introduction

A **lambda expression** in C# is a concise way to represent an anonymous method using special syntax. It enables functional-style programming by allowing developers to write inline functions that can be passed as arguments, returned from methods, or assigned to delegates or variables.

Lambda expressions are especially powerful when working with LINQ, event handling, or any scenario that benefits from compact, reusable function definitions.

---

## How It Works

* A lambda expression uses the `=>` operator, read as "goes to".
* Syntax: `(parameters) => expression` or `(parameters) => { statement block }`
* Can be assigned to delegates, `Func<>`, `Action<>`, or used inline in LINQ.
* Captures variables from the outer scope (closures).

### Characteristics

* Anonymous (no need to define a method name)
* Type-inferred (compiler infers types if possible)
* Can return values (expression-bodied) or execute statements (statement-bodied)

---

| Syntax Type         | Example                             | Description                      |
| ------------------- | ----------------------------------- | -------------------------------- |
| No parameter        | `() => Console.WriteLine("Hi")`     | Lambda with no input.            |
| Single parameter    | `x => x * x`                        | Single input, expression-bodied. |
| Multiple parameters | `(x, y) => x + y`                   | Adds two numbers.                |
| Statement lambda    | `x => { int y = x * x; return y; }` | Block of statements with return. |

---

## Code Example

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        // Filter even numbers using lambda
        var evens = numbers.Where(x => x % 2 == 0).ToList();

        Console.WriteLine("Even Numbers:");
        evens.ForEach(n => Console.WriteLine(n));

        // Calculate square using lambda assigned to Func
        Func<int, int> square = x => x * x;
        Console.WriteLine($"Square of 5: {square(5)}");

        // Use Action lambda
        Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
        greet("Lambda");

        // Lambda with multiple parameters
        Func<int, int, bool> isGreater = (a, b) => a > b;
        Console.WriteLine($"Is 10 > 5? {isGreater(10, 5)}");
    }
}
```

---

## Advantages

* **Concise Syntax**: Replaces boilerplate method declarations.
* **Improved Readability**: Easier to read in functional-style chains (e.g., LINQ).
* **Scope Capturing**: Lambdas can access variables from the enclosing scope.
* **Flexible Use**: Assignable to delegates, `Func<>`, `Action<>`.
* **Ideal for LINQ**: Core to LINQ query expressions.

---

## Use Cases

* LINQ queries and projections
* Event handlers and callbacks
* Passing short logic to methods
* Declarative programming in UI frameworks (e.g., WPF, WinForms)
* Replacing anonymous delegate syntax

---

> **Namespace:** `System`

> **Related Types:** `Func<>`, `Action<>`, `Predicate<>`
