namespace Assignment4;

static class Program
{
    public static void Main()
    {
        string filePath = "sherlock.txt";

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
        } else { Console.WriteLine("File was not found."); }
    }

    static void CountSymbolFrequency(string text, Dictionary<char, int> frequency)
    {
        foreach (char symbol in text)
        {
            if (frequency.ContainsKey(symbol))
            {
                frequency[symbol]++;
            } else { frequency[symbol] = 1; }
        }

    }

    private static void PrintSymbolFrequency(Dictionary<char, int> symbolFrequency)
    {
        Console.WriteLine("Symbol frequency:");
        foreach (KeyValuePair<char, int> entry in symbolFrequency)
        {
            Console.WriteLine($"Symbol: {entry.Key}, Quantity: {entry.Value}");
        }
    }
    
}