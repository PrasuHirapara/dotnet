using System.Data;

internal class LINQ
{
    public static void Run()
    {
        int[] num = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 324, 4, 534,-5345, -5 };
        List<string> list = new List<string> { "csharp", "java", "science", "IT", "LINQ", "123" };

        // select
        var select = from word in list
                     select word;

        // where
        var where = from i in num
                    where i > 5
                    select i;

        // order 
        // sorting
        var sort = from i in num
                   orderby i
                   select i;
        
    }
}