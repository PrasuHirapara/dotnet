using System;

public class Input
{
	public static void run()
	{
		Console.WriteLine("Enter name : ");

		// input will be String formate 
        string name = Console.ReadLine();
		Console.WriteLine("Hello " + name);

		Console.WriteLine("Enter age : ");
		int age = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Age = " + age);
	}
}
