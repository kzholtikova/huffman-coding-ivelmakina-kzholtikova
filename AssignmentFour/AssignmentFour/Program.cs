namespace Assignment4;

static class Program
{
    public static void Main()
    {
        string filePath = "sherlock.txt";

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);

            Dictionary<char, int> symbolFrequency = new Dictionary<char, int>();
            CountSymbolFrequency(content, symbolFrequency);
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
}