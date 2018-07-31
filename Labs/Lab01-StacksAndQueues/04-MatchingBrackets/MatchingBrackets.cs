using System;
using System.Collections.Generic;

class MatchingBrackets
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        Stack<int> openBracketsIndexes = new Stack<int>();

        for (int index = 0; index < input.Length; index++)
        {
            if (input[index] == '(')
            {
                openBracketsIndexes.Push(index);
            }

            if (input[index] == ')')
            {
                int startIndex = openBracketsIndexes.Pop();
                int length = index - startIndex + 1;

                Console.WriteLine(input.Substring(startIndex, length));
            }
        }
    }
}