using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class WordCount
{
    static void Main(string[] args)
    {
        var wordsReader = new StreamReader("../../../../words.txt");
        var textReader = new StreamReader("../../../../text.txt");
        var writer = new StreamWriter("../../../../result.txt");
        var wordsCounts = new Dictionary<string, int>();
        string text = string.Empty;

        using (wordsReader)
        {
            string word;
            while ((word = wordsReader.ReadLine()) != null)
            {
                if (wordsCounts.ContainsKey(word.ToLower()) == false)
                {
                    wordsCounts.Add(word.ToLower(), 0);
                }
            }
        }

        using (textReader)
        {
            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                text += line.ToLower();
            }
        }

        string[] words = text.Split("-,.!? ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (wordsCounts.ContainsKey(word))
            {
                wordsCounts[word]++;
            }
        }

        using (writer)
        {
            foreach (var pair in wordsCounts.OrderByDescending(x => x.Value))
            {
                writer.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}