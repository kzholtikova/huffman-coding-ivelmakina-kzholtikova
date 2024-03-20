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
        Program.PrintDict(codeTable);
        
        using (FileStream stream = new FileStream("e-" + filepath, FileMode.Create))
        {
            foreach (KeyValuePair<char, string> charCode in codeTable)
            {
                stream.WriteByte(Convert.ToByte(charCode.Key));
                byte[] byteCode = BinaryStringToByte(charCode.Value);
                stream.Write(byteCode, 0, byteCode.Length);
                stream.WriteByte(Convert.ToByte('\t'));
            }
            
            stream.WriteByte(Convert.ToByte('|'));

            foreach (char symbol in content)
            {
                byte[] symbolByteCode = BinaryStringToByte(codeTable[symbol]);
                stream.Write(symbolByteCode, 0, symbolByteCode.Length);
            }
        }
        
        Console.WriteLine($"{filename} file successfully encoded into e-{filename}");
    }
    
    public static void Decode()
    {
        string filepath = GetValidFilepath();
        string filename = Path.GetFileName(filepath);
        byte[] allBytes = File.ReadAllBytes(filepath);
        
        int delimiterIndex = Array.IndexOf(allBytes, (byte)'|');
        byte[] codeTableBytes = allBytes.Take(delimiterIndex).ToArray();
        byte[] encodedBytes = allBytes.Skip(delimiterIndex + 1).ToArray();

        Dictionary<string, char> codeTable = DecodeCodeTable(codeTableBytes);
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

    private static byte[] BinaryStringToByte(string code)
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

    private static Dictionary<string, char> DecodeCodeTable(byte[] codeTableBytes)
    {
        Dictionary<string, char> codeTable = new();
        char currentChar = (char)codeTableBytes[0];
        string currentCode = "";
        
        for (int i = 1; i < codeTableBytes.Length - 1; i++)
        {
            currentCode += Convert.ToString(codeTableBytes[i], 2).PadLeft(8, '0');
            
            if (codeTableBytes[i + 1] == (byte)'\t')
            {
                codeTable[currentCode] = currentChar;
                
                i += 2;
                if (i < codeTableBytes.Length)
                {
                    currentChar = (char)codeTableBytes[i];
                    currentCode = "";
                }
            }
        }

        return codeTable;
    }
}