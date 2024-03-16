namespace Assignment4;

public class HuffmanTree
{
    private PriorityQueue _minHeapPrQ = new();

    public void BuildTree(Dictionary<char, int> symbolFrequency)
    {
        foreach (KeyValuePair<char, int> entry in symbolFrequency)
        {
            MinHeapNode node = new MinHeapNode(entry.Key, entry.Value, null, null);
            _minHeapPrQ.Enqueue(node);
        }

        while (_minHeapPrQ.Count() > 1)
        {
            MinHeapNode left = _minHeapPrQ.Dequeue();
            MinHeapNode right = _minHeapPrQ.Dequeue();
            
            MinHeapNode top = new MinHeapNode('$', left.Freq + right.Freq, null, null);
            top.Left = left;
            top.Right = right;
            _minHeapPrQ.Enqueue(top);
        }
    }

    public void PrintCodes()
    {
        MinHeapNode root = _minHeapPrQ.Dequeue();
        PrintCodes(root, "");
    }

    private void PrintCodes(MinHeapNode root, string str)
    {
        if (root == null)
        {
            return;
        }

        if (root.Data != '$')
        {
            Console.WriteLine(root.Data + ": " + str);
        }
        
        PrintCodes(root.Left, str + "0");
        PrintCodes(root.Right, str + "1");
    }
}