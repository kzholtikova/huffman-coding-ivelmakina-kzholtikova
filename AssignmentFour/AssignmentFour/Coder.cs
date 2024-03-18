namespace Assignment4;

public class Coder
{
    private const string ToEncode = "sherlock.txt";
    
    public static void Encode()
    {
        string content = File.ReadAllText(GetValidFilepath());
        
        HuffmanTree huffmanTree = new HuffmanTree(content);
        huffmanTree.BuildTree();
        Dictionary<char, string> codeTable = huffmanTree.BuildCodeTableRecursive();
        Program.PrintDict(codeTable);
    }
    
    public static void Decode()
    {
        string[] content = File.ReadAllLines(GetValidFilepath());
        string code = content[1];
        
        string encodedCodeTable = content[0];
    }

    private static string GetValidFilepath()
    {
        Console.WriteLine("Specify path to the file: ");
        string? filepath = Console.ReadLine();

        while (!File.Exists(filepath))
        {
            Console.WriteLine("Invalid path. Try again: ");
            filepath = Console.ReadLine();
        }
        return filepath;
    }
}