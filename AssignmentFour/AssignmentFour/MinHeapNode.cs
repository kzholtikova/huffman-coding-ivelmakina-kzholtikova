namespace Assignment4;

public class MinHeapNode
{
    private char _data;
    public int _freq;
    private MinHeapNode? _left;
    private MinHeapNode? _right;
    
    public MinHeapNode(char data, int freq, MinHeapNode? left, MinHeapNode? right)
    {
        _data = data;
        _freq = freq;
        _left = left;
        _right = right;
    }
}
