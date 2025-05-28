using System;
using System.Collections.Generic;

public class ListExample
{
    public static void run()
    {
        // Create a new list of integers
        List<int> numbers = new List<int>();

        // Add elements
        // Add(value)
        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);
        numbers.Add(40);

        // Add a range of elements
        // AddRange(IEnumerable<T>)
        numbers.AddRange(new int[] { 50, 60 });

        // Insert element at specific index
        // Insert(idx, val)
        numbers.Insert(2, 25);

        // Remove an element by value
        // Remove(value)
        numbers.Remove(40);

        // Remove element by index
        // RemoveAt(idx)
        numbers.RemoveAt(0);

        // Remove all elements matching predicate
        // RemoveAll(Predicate<T>)
        numbers.RemoveAll(x => x > 55);

        // Check if element exists
        // Contains(value)
        bool has30 = numbers.Contains(30);

        // Find index of an element
        // IndexOf(value)
        int indexOf25 = numbers.IndexOf(25);

        // Find last index matching predicate
        // FindLastIndex(Predicate<T>)
        int lastIndexLessThan30 = numbers.FindLastIndex(x => x < 30);

        // Find first element matching predicate
        // Find(Predicate<T>)
        int firstOver20 = numbers.Find(x => x > 20);

        // Find all elements matching predicate
        // FindAll(Predicate<T>)
        List<int> allOver20 = numbers.FindAll(x => x > 20);

        // Get range of elements
        // GetRange(startIdx, count)
        List<int> subList = numbers.GetRange(1, 3);

        // Sort the list
        // Sort()
        numbers.Sort();

        // Reverse the list
        // Reverse()
        numbers.Reverse();

        // Convert list to array
        // ToArray()
        int[] array = numbers.ToArray();

        // Convert all elements using converter
        // ConvertAll(Converter<TInput,TOutput>)
        List<string> stringList = numbers.ConvertAll(x => x.ToString());

        // Iterate over list and print elements
        Console.WriteLine("List elements:");
        foreach (int num in numbers) // foreach
        {
            Console.WriteLine(num);
        }

        // Get count of elements
        // Count property
        Console.WriteLine($"Count: {numbers.Count}");

        // Clear all elements
        // Clear()
        numbers.Clear();
        Console.WriteLine($"Count after Clear: {numbers.Count}");
    }
}
