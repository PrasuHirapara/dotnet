# Threading in C\#

## Introduction

Threading in C# enables the execution of multiple operations concurrently. It is an essential part of creating responsive and efficient applications, especially those involving I/O operations, UI responsiveness, or CPU-intensive tasks. The core class used for threading is `System.Threading.Thread`, which allows for manual thread creation and management.

The `Thread` class represents a separate path of execution and provides methods to create, start, and manage threads. It enables developers to perform multiple tasks at the same time within a single application.

---

## How It Works

The `Thread` class in C# is instance-based. To create a thread, a method (usually encapsulated in a delegate) is passed to the `Thread` constructor. This thread can then be started with the `Start()` method. The method can either have no parameters (using `ThreadStart`) or accept a single object parameter (using `ParameterizedThreadStart`).

Each thread runs independently and has its own execution path. Important characteristics include:

* **Instance-Based**: Each thread is a separate object.
* **Concurrency**: Threads allow multiple operations to run at the same time.
* **Control Methods**: Includes methods like `Start`, `Sleep`, `Join`, `Abort`.
* **Thread State Management**: Threads have states like Running, Suspended, Stopped, etc.

---

## Constructor Table

| Constructor                              | Description                                                         |
| ---------------------------------------- | ------------------------------------------------------------------- |
| `Thread(ThreadStart start)`              | Initializes a thread with a method that takes no parameters.        |
| `Thread(ParameterizedThreadStart start)` | Initializes a thread with a method that takes one object parameter. |

---

## Method Table

| Return Type      | Method Name    | Parameters       | Description                                            |
| ---------------- | -------------- | ---------------- | ------------------------------------------------------ |
| `void`           | `Start()`      | None / object    | Starts the execution of the thread.                    |
| `void`           | `Join()`       | None             | Blocks the calling thread until the thread terminates. |
| `void`           | `Sleep()`      | int milliseconds | Suspends the current thread for a specified time.      |
| `void`           | `Abort()`      | None             | Attempts to stop the thread (Obsolete in .NET Core).   |
| `bool`           | `IsAlive`      | Property         | Checks if the thread is still running.                 |
| `ThreadPriority` | `Priority`     | Property         | Gets or sets the thread's priority.                    |
| `bool`           | `IsBackground` | Property         | Indicates whether a thread is a background thread.     |
| `ThreadState`    | `ThreadState`  | Property         | Gets the current state of the thread.                  |

---

## Code Example

```csharp
using System;
using System.Threading;

class Program
{
    static void PrintNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Number: {i}");
            Thread.Sleep(500);
        }
    }

    static void PrintMessage(object msg)
    {
        Console.WriteLine($"Message: {msg}");
    }

    static void Main()
    {
        Thread t1 = new Thread(new ThreadStart(PrintNumbers));
        Thread t2 = new Thread(new ParameterizedThreadStart(PrintMessage));

        t1.Priority = ThreadPriority.AboveNormal;
        t2.IsBackground = true;

        t1.Start();
        t2.Start("Hello from thread");

        t1.Join();
        Console.WriteLine("Main thread finished.");
    }
}
```

---

## Advantages

* Enables parallel execution for improved performance.
* Increases responsiveness in UI applications.
* Allows multiple tasks to run independently.
* Provides low-level control over thread behavior.

---

## Use Cases

* Performing background tasks without blocking the main thread.
* Running long computations without freezing the UI.
* Handling multiple client requests in server applications.
* Implementing parallel processing in CPU-intensive applications.
* Managing asynchronous operations where high control is needed.

---
