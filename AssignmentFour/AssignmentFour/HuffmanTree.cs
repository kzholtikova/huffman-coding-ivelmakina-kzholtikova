namespace Assignment4;

public class HuffmanTree(string text)
{
    private readonly MinHeap _minHeap = new();

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

    public void BuildTree()
    {
        Dictionary<char, int> symbolFrequencies = new Dictionary<char, int>();
        CountSymbolFrequency(text, symbolFrequencies);
        
        foreach (KeyValuePair<char, int> entry in symbolFrequencies)
        {
            MinHeapNode node = new MinHeapNode(entry.Key, entry.Value, null, null);
            _minHeap.Enqueue(node);
        }

        while (_minHeap.Count() > 1)
        {
            MinHeapNode? left = _minHeap.Dequeue();
            MinHeapNode? right = _minHeap.Dequeue();
            
            MinHeapNode top = new MinHeapNode('$', left.Freq + right.Freq, null, null)
            {
                Left = left,
                Right = right
            };
            _minHeap.Enqueue(top);
        }
    }

    public Dictionary<char, string> BuildCodeTableRecursive()
    {
        Dictionary<char, string> codeTable = new();
        MinHeapNode? root = _minHeap.Dequeue();
        BuildCodeTableRecursive(root, "", ref codeTable);
        return codeTable;
    }

    private void BuildCodeTableRecursive(MinHeapNode? node, string code, ref Dictionary<char, string> codeTable)
    {
        if (node == null)
        {
            return;
        }

        if (node.IsLeaf)
        {
            codeTable[node.Data] = code;
        }
        
        BuildCodeTableRecursive(node.Left, code + "0", ref codeTable);
        BuildCodeTableRecursive(node.Right, code + "1", ref codeTable); 
    }

}