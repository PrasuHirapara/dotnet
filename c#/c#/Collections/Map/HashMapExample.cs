using System;
using System.Collections.Generic;

public class HashMapExample
{
    public static void Run()
    {
        Dictionary<int, string> map = new Dictionary<int, string>();

        // Add(key, value)
        map.Add(1, "One");
        map.Add(2, "Two");
        map.Add(3, "Three");

        // indexer[key] = value
        map[2] = "Two Updated";
        map[4] = "Four";

        // ContainsKey(key)
        bool hasKey3 = map.ContainsKey(3);

        // ContainsValue(value)
        bool hasValueFive = map.ContainsValue("Five");

        // TryGetValue(key, out value)
        if (map.TryGetValue(1, out string val1))
        {
            Console.WriteLine($"Key 1 has value: {val1}");
        }

        // Remove(key)
        map.Remove(4);

        // Count property
        Console.WriteLine($"Count: {map.Count}");

        // Keys property
        foreach (int key in map.Keys)
        {
            Console.WriteLine(key);
        }

        // Values property
        foreach (string value in map.Values)
        {
            Console.WriteLine(value);
        }

        // Iterate key-value pairs
        foreach (KeyValuePair<int, string> entry in map)
        {
            Console.WriteLine($"{entry.Key} = {entry.Value}");
        }

        // Clear()
        map.Clear();
        Console.WriteLine($"Count after Clear: {map.Count}");

        // GetEnumerator() to iterate dictionary explicitly
        var enumerator = map.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            Console.WriteLine($"[Enumerator] {current.Key} = {current.Value}");
        }

        // Count property used with LINQ to find keys or values count
        int countGreaterThanOne = 0;
        foreach (var kvp in map)
        {
            if (kvp.Key > 1) countGreaterThanOne++;
        }
        Console.WriteLine($"Keys > 1 count: {countGreaterThanOne}");

        // TryAdd(key, value) - adds key-value pair only if key does not exist
        bool added = map.TryAdd(5, "Five");
        Console.WriteLine($"TryAdd key 5 success: {added}");

        added = map.TryAdd(1, "One New");
        Console.WriteLine($"TryAdd key 1 success: {added}"); // false, key exists

        // GetValueOrDefault(key) - returns value if exists, or default(TValue) otherwise
        string valOrDefault = map.GetValueOrDefault(10);
        Console.WriteLine($"Value for key 10: {(valOrDefault == null ? "null" : valOrDefault)}");
    }
}
