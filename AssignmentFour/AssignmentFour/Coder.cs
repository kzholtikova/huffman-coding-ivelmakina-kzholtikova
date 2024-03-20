using System.Security.AccessControl;
using System.Text;

namespace Assignment4;

public class Coder
{
    public static void Encode()
    {
        string filepath = GetValidFilepath();
        string filename = Path.GetFileName(filepath);
        string content = File.ReadAllText(filepath);
        
        HuffmanTree huffmanTree = new HuffmanTree(content);
        huffmanTree.BuildTree();
        Dictionary<char, string> codeTable = huffmanTree.BuildCodeTableRecursive();
    }
    
    public static void Decode()
    {
        string filepath = GetValidFilepath();
        string filename = Path.GetFileName(filepath);
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

    private static byte[] BinaryStringtoByte(string code)
    {
        int padLength = (8 - (code.Length % 8)) % 8;
        code = code.PadRight(code.Length + padLength, '0');
        
        byte[] bytecode = new byte[code.Length / 8];
        for (int i = 0; i < code.Length / 8; i++)
        {
            string substr = code.Substring(i * 8, 8);
            bytecode[i] = Convert.ToByte(substr, 2);
        }

        return bytecode;
    }
}