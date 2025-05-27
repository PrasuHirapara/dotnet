using System;

public class Randoms
{
    public static void run()
    {
        Random rand = new Random();

        // Generate a random integer between 0 (inclusive) and Int32.MaxValue (exclusive)
        int defaultRandom = rand.Next();
        Console.WriteLine("Default random int: " + defaultRandom);

        // Generate a random integer between 1 (inclusive) and 100 (exclusive)
        int randomInRange = rand.Next(1, 100);
        Console.WriteLine("Random number between 1 and 99: " + randomInRange);

        // Generate a random double between 0.0 and 1.0
        double randomDouble = rand.NextDouble();
        Console.WriteLine("Random double between 0.0 and 1.0: " + randomDouble);

        // Fill a byte array with random bytes
        byte[] buffer = new byte[5];
        rand.NextBytes(buffer);
        Console.WriteLine("Random bytes: " + BitConverter.ToString(buffer));

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
