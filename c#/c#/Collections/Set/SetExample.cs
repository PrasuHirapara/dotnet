using System;
using System.Collections.Generic;

public class SetExample
{
    public static void run()
    {
        // Create a new HashSet of integers
        HashSet<int> set = new HashSet<int>();

        // Add elements
        // Add(value)
        set.Add(10);
        set.Add(20);
        set.Add(30);
        set.Add(20);  // Duplicate ignored

        // Check if contains element
        // Contains(value)
        bool contains20 = set.Contains(20);
        Console.WriteLine($"Contains 20: {contains20}");

        // Remove element
        // Remove(value)
        set.Remove(10);

        // Count elements
        // Count property
        Console.WriteLine($"Count: {set.Count}");

        // Clear all elements
        // Clear()
        set.Clear();
        Console.WriteLine($"Count after Clear: {set.Count}");

        // Add elements again for set operations
        set.UnionWith(new int[] { 1, 2, 3, 4, 5 });
        HashSet<int> otherSet = new HashSet<int>() { 4, 5, 6, 7 };

        // Union
        // UnionWith(IEnumerable<T>)
        set.UnionWith(otherSet);
        Console.WriteLine("After Union:");
        PrintSet(set);

        // Intersection
        // IntersectWith(IEnumerable<T>)
        set.IntersectWith(new int[] { 2, 3, 4, 8 });
        Console.WriteLine("After Intersection:");
        PrintSet(set);

        // Except
        // ExceptWith(IEnumerable<T>)
        set.ExceptWith(new int[] { 3 });
        Console.WriteLine("After Except:");
        PrintSet(set);

        // SymmetricExceptWith (elements in either but not both)
        // SymmetricExceptWith(IEnumerable<T>)
        set.SymmetricExceptWith(new int[] { 2, 9 });
        Console.WriteLine("After Symmetric Except:");
        PrintSet(set);
    }

    private static void PrintSet(HashSet<int> set)
    {
        foreach (var item in set)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
