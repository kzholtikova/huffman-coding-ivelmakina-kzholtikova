namespace Assignment4;

static class Program
{
    public static void Main()
    {
            const string filePath = "sherlock.txt";
        
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);

                Dictionary<char, int> symbolFrequencies = new Dictionary<char, int>();
                CountSymbolFrequency(content, symbolFrequencies);
                
                HuffmanTree huffmanTree = new HuffmanTree();
                huffmanTree.BuildTree(symbolFrequencies);
                
                Dictionary<char, string> codeTable = huffmanTree.BuildCodeTableRecursive();
                PrintDict(codeTable);
            } else { Console.WriteLine("File was not found."); }
    }
        
        private static void CountSymbolFrequency(string text, Dictionary<char, int> frequency)
        {
            foreach (char symbol in text)
            {
                if (frequency.TryGetValue(symbol, out int value))
                {
                    frequency[symbol] = ++value;
                } else { frequency[symbol] = 1; }
            }
        
        }

        private static void PrintDict<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : notnull
        {
            foreach (KeyValuePair<TKey, TValue> entry in dictionary)
            {
                Console.WriteLine($"{entry.Key}, {entry.Value}");
            }
        }

    }
