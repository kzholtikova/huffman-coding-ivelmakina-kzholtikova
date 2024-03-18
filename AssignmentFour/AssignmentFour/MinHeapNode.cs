namespace Assignment4;

public class MinHeapNode(char data, int freq, MinHeapNode? left, MinHeapNode? right)
{
    public readonly char Data = data;
    public readonly int Freq = freq;
    public MinHeapNode? Left = left;
    public MinHeapNode? Right = right;
    public bool IsLeaf => Left == null && Right == null; // if !IsLeaf -> IsInternal
}
