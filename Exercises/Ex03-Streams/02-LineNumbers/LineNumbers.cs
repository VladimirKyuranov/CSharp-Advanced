using System;
using System.IO;

class LineNumbers
{
    static void Main(string[] args)
    {
        var reader = new StreamReader("../../../../text.txt");
        int lineNumber = 1;
        using (reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine($"Line {lineNumber++}: {line}");
            }
        }
    }
}