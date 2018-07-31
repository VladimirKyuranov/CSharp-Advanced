using System;
using System.IO;

class OddLines
{
    static void Main(string[] args)
    {
        var reader = new StreamReader("../../../../text.txt");
        int lineNumber = 0;
        using (reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (lineNumber++ % 2 != 0)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}