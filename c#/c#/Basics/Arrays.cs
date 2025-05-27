using System;

public class Arrays
{
    public static void run()
    {
        // 1. Declaration and Initialization
        int[] numbers1 = new int[5]; // default values (0, 0, 0, 0, 0)
        int[] numbers2 = new int[] { 1, 2, 3, 4, 5 };
        int[] numbers3 = { 10, 20, 30, 40, 50 };

        Console.WriteLine("Accessing Elements:");
        Console.WriteLine(numbers3[2]); // Output: 30

        // 2. Iteration
        Console.WriteLine("For Loop:");
        for (int i = 0; i < numbers3.Length; i++)
            Console.Write(numbers3[i] + " ");
        Console.WriteLine(); // Output: 10 20 30 40 50

        Console.WriteLine("Foreach Loop:");
        foreach (int num in numbers3)
            Console.Write(num + " ");
        Console.WriteLine(); // Output: 10 20 30 40 50

        // 3. Properties
        Console.WriteLine("Length: " + numbers3.Length); // Output: 5
        Console.WriteLine("Rank (dimensions): " + numbers3.Rank); // Output: 1

        // 4. Array Methods
        Array.Sort(numbers3); // Sorts in ascending order
        Console.WriteLine("Sorted Array:");
        PrintArray(numbers3); // Output: 10 20 30 40 50

        Array.Reverse(numbers3); // Reverses order
        Console.WriteLine("Reversed Array:");
        PrintArray(numbers3); // Output: 50 40 30 20 10

        int index = Array.IndexOf(numbers3, 30); // (arr, value)
        Console.WriteLine("Index of 30: " + index); // Output: 2

        int[] copied = new int[5];
        Array.Copy(numbers3, copied, 5); // (sourceArray, destinationArray, length)
        Console.WriteLine("Copied Array:");
        PrintArray(copied); // Output: 50 40 30 20 10

        // 5. Multidimensional Arrays
        int[,] multiArray = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
        Console.WriteLine("Multidimensional Array:");
        for (int i = 0; i < multiArray.GetLength(0); i++)
        {
            for (int j = 0; j < multiArray.GetLength(1); j++)
                Console.Write(multiArray[i, j] + " ");
            Console.WriteLine();
        }
        // Output:
        // 1 2 3 
        // 4 5 6

        // 6. Jagged Arrays: array of arrays
        int[][] jagged = new int[2][];
        jagged[0] = new int[] { 1, 2, 3 };
        jagged[1] = new int[] { 4, 5 };

        Console.WriteLine("Jagged Array:");
        for (int i = 0; i < jagged.Length; i++)
        {
            foreach (int val in jagged[i])
                Console.Write(val + " ");
            Console.WriteLine();
        }
        // Output:
        // 1 2 3 
        // 4 5

        // 7. Passing and Returning Arrays
        int[] data = GenerateArray(5); // (size)
        Console.WriteLine("Returned Array from Method:");
        PrintArray(data); // Output: 1 2 3 4 5

        Console.WriteLine("Sum of Array: " + SumArray(data)); // Output: 15
    }

    public static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
    }

    public static int[] GenerateArray(int size)
    {
        int[] result = new int[size];
        for (int i = 0; i < size; i++)
            result[i] = i + 1;
        return result;
    }

    public static int SumArray(int[] arr)
    {
        int sum = 0;
        foreach (int num in arr)
            sum += num;
        return sum;
    }
}
