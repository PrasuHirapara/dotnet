# Events in C\#

## Introduction

An **event** in C# is a messaging system that enables a class to notify other classes or objects when something of interest occurs. Events are built on top of **delegates** and are a core part of implementing the **observer pattern** in .NET.

Events are especially useful in GUI applications, system monitoring, and asynchronous programming to signal state changes or occurrences.

---

## How It Works

* An event is declared using the `event` keyword along with a delegate type.
* The publisher class **raises** the event.
* The subscriber class **registers event handlers** using `+=` syntax.
* Events can only be triggered by the declaring class (or derived types), ensuring encapsulation.

### Characteristics:

* Based on delegates
* Follows publisher-subscriber model
* Type-safe notification mechanism
* Encapsulated access for invoking

---

## Event Declaration and Usage

Events are not instantiated directly using constructors like objects. Instead, you declare them with a delegate type:

```csharp
public delegate void MyEventHandler(string message);
public event MyEventHandler OnNotify;
```

You typically use built-in delegates like `EventHandler` or `EventHandler<TEventArgs>`.

---

## Method Table (Typical Event-Related Members)

| Return Type | Member Name  | Parameters                     | Description                                                  |
| ----------- | ------------ | ------------------------------ | ------------------------------------------------------------ |
| `void`      | `add`        | `(EventHandler handler)`       | Adds a subscriber to the event. Usually done via `+=`.       |
| `void`      | `remove`     | `(EventHandler handler)`       | Removes a subscriber from the event. Usually done via `-=`.  |
| `void`      | `Invoke`     | `(object sender, EventArgs e)` | Raises the event. Can only be called inside declaring class. |
| `bool`      | `null check` | `OnEvent != null`              | Check if any subscribers exist before invoking the event.    |

---

## Code Example

```csharp
using System;

// Publisher class
class Alarm
{
    // Declare event using EventHandler
    public event EventHandler AlarmRang;

    public void Ring()
    {
        Console.WriteLine("Alarm ringing...");
        // Check if there are subscribers
        AlarmRang?.Invoke(this, EventArgs.Empty);
    }
}

// Subscriber class
class Listener
{
    public void OnAlarmRang(object sender, EventArgs e)
    {
        Console.WriteLine("Listener received: Alarm event!");
    }
}

class Program
{
    static void Main()
    {
        Alarm alarm = new Alarm();
        Listener listener = new Listener();

        // Subscribe to event
        alarm.AlarmRang += listener.OnAlarmRang;

        // Raise event
        alarm.Ring();
    }
}
```

---

## Advantages

* **Loose Coupling**: Publishers and subscribers don’t need direct references.
* **Encapsulation**: Events can only be triggered from the class that defines them.
* **Scalability**: Multiple listeners can subscribe to a single event.
* **Consistency**: Uses standard `EventHandler` and `EventArgs` pattern.

---

## Use Cases

* **UI Applications**: Button clicks, form inputs, menu selections.
* **System Monitoring**: Logging changes, system errors, performance thresholds.
* **Asynchronous Programming**: Background task completion, progress updates.
* **Custom Component Communication**: Reacting to internal state changes.

---