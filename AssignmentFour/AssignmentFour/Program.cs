namespace Assignment4;

static class Program
{
    public static void Main()
    {
        string filePath = "sherlock.txt";

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);

            Dictionary<char, int> symbolFrequency = new Dictionary<char, int>();
        } else { Console.WriteLine("File was not found."); }
    }
    
}