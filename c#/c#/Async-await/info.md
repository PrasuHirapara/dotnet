# Task, async, and await in C\#

## Introduction

In C#, the `Task` class, along with the `async` and `await` keywords, provides a robust framework for asynchronous programming. This model helps developers write non-blocking code that performs operations like I/O or network access efficiently.

* `Task`: Represents an asynchronous operation that can return a value.
* `async`: Modifier that allows a method to contain `await` expressions and run asynchronously.
* `await`: Pauses execution of an `async` method until the awaited `Task` completes.

These constructs help in building responsive UI applications, scalable web services, and parallel workflows.

---

## How It Works

* **`Task`** is a class from `System.Threading.Tasks` that represents an asynchronous operation.
* The **`async`** keyword is applied to a method to indicate that it contains asynchronous operations.
* **`await`** is used before a `Task` to asynchronously wait for its completion without blocking the calling thread.

Characteristics:

* `Task` is **instance-based** and can return `void`, `Task`, or `Task<T>`.
* Execution is asynchronous and continuation-based.
* Exception handling is integrated using try/catch inside `async` methods.

---

## Task Constructor Table

| Constructor                         | Description                                               |
| ----------------------------------- | --------------------------------------------------------- |
| `Task(Action action)`               | Initializes a task with an action (no return value).      |
| `Task<TResult>(Func<TResult> func)` | Initializes a task with a function that returns a result. |
| `Task(Action, CancellationToken)`   | Initializes a task with cancellation support.             |

---

## Method Table

| Return Type    | Method Name   | Parameters                       | Description                                                |
| -------------- | ------------- | -------------------------------- | ---------------------------------------------------------- |
| `void`         | `Start`       | `()`                             | Starts a task that was created but not started.            |
| `Task`         | `Run`         | `(Action)` or `(Func<Task>)`     | Queues a task to run asynchronously.                       |
| `Task<T>`      | `Run`         | `(Func<T>)` or `(Func<Task<T>>)` | Queues a task with a return value.                         |
| `Task`         | `Delay`       | `(int milliseconds)`             | Creates a task that completes after a delay.               |
| `Task.WhenAll` | `WhenAll`     | `(params Task[] tasks)`          | Waits for all tasks to complete.                           |
| `Task.WhenAny` | `WhenAny`     | `(params Task[] tasks)`          | Completes when any one of the tasks has completed.         |
| `bool`         | `IsCompleted` | *Property*                       | Indicates whether the task has completed.                  |
| `TResult`      | `Result`      | *Property* (for `Task<T>`)       | Gets the result of the task (blocks if not yet completed). |

---

## Code Example

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting async work...");

        // Await an async method
        string result = await DoWorkAsync();
        Console.WriteLine(result);

        // Run multiple tasks in parallel
        Task t1 = Task.Delay(1000);
        Task t2 = Task.Delay(1500);
        await Task.WhenAll(t1, t2);
        Console.WriteLine("Both tasks completed.");
    }

    static async Task<string> DoWorkAsync()
    {
        await Task.Delay(2000); // simulate delay
        return "Work completed.";
    }
}
```

---

## Advantages

* **Non-blocking**: Keeps UI responsive and server threads free.
* **Scalable**: Ideal for I/O-bound and CPU-bound operations.
* **Readable**: Code looks synchronous but executes asynchronously.
* **Exception Handling**: Supports try/catch/finally blocks within async code.
* **Composability**: Tasks can be chained and combined easily.

---

## Use Cases

* Performing network I/O (e.g., web requests, database calls).
* Reading/writing large files without blocking.
* Creating scalable web APIs.
* Delaying operations or implementing retry logic.
* Parallelizing CPU-intensive computations.

---

> **Namespace:** `System.Threading.Tasks`

> **Assemblies:** `System.Runtime.dll`, `mscorlib.dll`
