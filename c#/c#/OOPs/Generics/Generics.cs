using Generic;
using System;

public class Generics
{
    public static void Run()
    {
        CustomLinkedList<int> intList = new CustomLinkedList<int>();
        intList.Add(10);
        intList.Add(20);
        intList.Add(30);

        Console.WriteLine("Integer Linked List:");
        intList.Print();

        CustomLinkedList<string> stringList = new CustomLinkedList<string>();
        stringList.Add("Apple");
        stringList.Add("Banana");
        stringList.Add("Cherry");

        Console.WriteLine("\nString Linked List:");
        stringList.Print();
    }
}
