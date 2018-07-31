using System;
using System.Collections.Generic;
using System.Text;

class SimpleTextEditor
{
    static void Main(string[] args)
    {
        int commandsCount = int.Parse(Console.ReadLine());

        string text = string.Empty;
        Stack<string> undo = new Stack<string>();

        for (int currendCommand = 0; currendCommand < commandsCount; currendCommand++)
        {
            string[] commandInfo = Console.ReadLine().Split();

            switch (commandInfo[0])
            {
                case "1":
                    undo.Push(text);
                    string textToAdd = commandInfo[1];
                    text += textToAdd;
                    break;
                case "2":
                    undo.Push(text);
                    int startIndex = text.Length - int.Parse(commandInfo[1]);
                    text = text.Remove(startIndex);
                    break;
                case "3":
                    int index = int.Parse(commandInfo[1]);
                    Console.WriteLine(text[index - 1]);
                    break;
                case "4":
                    text = undo.Pop();
                    break;
            }
        }
    }
}