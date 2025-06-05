# Delegate in C\#

## Introduction

A **delegate** in C# is a type that represents references to methods with a specific parameter list and return type. Delegates are used to pass methods as arguments to other methods, allowing for flexible and extensible program designs.

Delegates are the foundation of events and callback methods in C#. They enable the implementation of **event-driven** and **asynchronous** programming.

---

## How It Works

* A delegate is **type-safe**, meaning only methods matching the delegate signature can be assigned.
* Delegates can **reference static or instance methods**.
* They can be combined using **multicast** to call multiple methods in sequence.
* Delegates are commonly used with **events**, **LINQ**, and **anonymous methods/lambdas**.

### Characteristics:

* Reference type derived from `System.Delegate`
* Supports multicast
* Immutable once created (though invocation list can be changed using `+=`, `-=`)
* Can be chained using `Combine` and `Remove`

---

## Method Table

| Return Type  | Method Name     | Parameters                          | Description                                               |
| ------------ | --------------- | ----------------------------------- | --------------------------------------------------------- |
| `Delegate`   | `Combine`       | `(Delegate a, Delegate b)`          | Combines delegates into a multicast delegate.             |
| `Delegate`   | `Remove`        | `(Delegate source, Delegate value)` | Removes the last occurrence of the delegate from source.  |
| `object`     | `DynamicInvoke` | `(params object[] args)`            | Invokes the delegate dynamically at runtime.              |
| `MethodInfo` | `Method`        | *Property*                          | Gets method represented by the delegate.                  |
| `object`     | `Target`        | *Property*                          | Gets the object on which the delegate invokes the method. |

---

## Code Example

```csharp
using System;

// Step 1: Declare a delegate
delegate void Notify(string message);

class Program
{
    // Step 2: Create methods that match the delegate signature
    static void Email(string msg) => Console.WriteLine($"Email: {msg}");
    static void SMS(string msg) => Console.WriteLine($"SMS: {msg}");

    static void Main()
    {
        // Step 3: Instantiate delegate
        Notify notifier = Email;

        // Step 4: Add another method to the delegate (multicast)
        notifier += SMS;

        // Step 5: Call delegate
        notifier("Hello Delegates!");

        // Step 6: Remove a method
        notifier -= Email;
        notifier("Only SMS this time");

        // Step 7: Using Delegate methods
        Delegate combined = Delegate.Combine(notifier, new Notify(Email));
        combined.DynamicInvoke("Combined with Email again");

        Console.WriteLine("Method Name: " + notifier.Method.Name);
        Console.WriteLine("Target Object: " + notifier.Target);
    }
}
```

---

## Advantages

* **Type-Safe Function Pointers**: Prevents errors by ensuring method signature compatibility.
* **Flexible Design**: Enables callback and plugin-style patterns.
* **Event Handling**: Core component of event-driven architectures.
* **Multicasting**: Supports invoking multiple methods via a single delegate.
* **Supports Lambdas**: Integrates seamlessly with lambda expressions and anonymous methods.

---

## Use Cases

* Event handling (e.g., UI actions, .NET events)
* Callback implementations (e.g., async APIs)
* LINQ and functional programming
* Strategy pattern implementations
* Encapsulating method calls for deferred execution

---