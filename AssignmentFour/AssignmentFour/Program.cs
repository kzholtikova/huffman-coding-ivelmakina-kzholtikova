namespace Assignment4;

static class Program
{
    public static void Main()
    {
        Console.Write("Choose mode (Encode e / Decode d): ");
        string? mode = Console.ReadLine();

        while (mode != "e" && mode != "d")
        {
            Console.Write("Choose mode (Encode e / Decode d): ");
            mode = Console.ReadLine();
        }

        if (mode == "e")
        {
           Coder.Encode(); 
        } else if (mode == "d") { Coder.Decode(); }
    }

    public static void PrintDict<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : notnull
    {
        foreach (KeyValuePair<TKey, TValue> entry in dictionary)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }

}
