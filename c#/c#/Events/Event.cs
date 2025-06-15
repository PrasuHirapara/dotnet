using System;

/*
 * Events in C# are based on delegates and allow a class (publisher) to notify other classes or objects (subscribers) when something happens.
 * 
 * Key Characteristics:
 * - Declared using the `event` keyword.
 * - Only the declaring class can raise (invoke) the event.
 * - Other classes can subscribe (+=) or unsubscribe (-=) from the event.
 * - Multiple methods can be subscribed; all are invoked in order.
 * - Use `?.Invoke()` to safely trigger the event if there are subscribers.
 *
 * How Events Work Internally:
 * - An event is essentially a delegate with restricted access.
 * - The event keyword restricts external classes from invoking the delegate directly.
 * - Internally, the event maintains a list of subscribed methods.
 * - When the event is raised, all subscribed methods are called in order.
 *
 * You can subscribe multiple methods to an event. When invoked, all subscribed methods are called sequentially.
 */

internal class Event
{
    public delegate void NotifyDelegate(string message);

    private static event NotifyDelegate OnNotify;

    public static void TriggerEvent()
    {
        Console.WriteLine("Triggering Event...\n");
        OnNotify?.Invoke("Event has been triggered."); // parameter of delegate
    }

    public static void SubscriberA(string message)
    {
        Console.WriteLine("Event received: " + message);
    }

    internal static void Run()
    {
        OnNotify += SubscriberA;
        OnNotify += Listener.ExternalHandler;

        TriggerEvent();

        // Example: Using GetInvocationList to display subscribers count
        if (OnNotify != null)
        {
            var subscribers = OnNotify.GetInvocationList();
            Console.WriteLine($"\nNumber of subscribers: {subscribers.Length}");
        }
    }
}

internal class Listener
{
    public static void ExternalHandler(string message)
    {
        Console.WriteLine("Listener received: " + message);
    }
}
