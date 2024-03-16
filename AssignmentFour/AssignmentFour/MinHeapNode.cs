namespace Assignment4;

public class MinHeapNode
{
    public char Data;
    public int Freq;
    public MinHeapNode? Left;
    public MinHeapNode? Right;
    
    public MinHeapNode(char data, int freq, MinHeapNode? left, MinHeapNode? right)
    {
        Data = data;
        Freq = freq;
        Left = left;
        Right = right;
    }
}
