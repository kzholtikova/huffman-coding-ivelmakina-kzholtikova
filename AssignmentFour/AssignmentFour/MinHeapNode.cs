namespace Assignment4;

public class MinHeapNode
{
    private char _data;
    public int Freq;
    public MinHeapNode? Left;
    public MinHeapNode? Right;
    
    public MinHeapNode(char data, int freq, MinHeapNode? left, MinHeapNode? right)
    {
        _data = data;
        Freq = freq;
        Left = left;
        Right = right;
    }
}
