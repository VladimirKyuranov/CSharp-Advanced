using System;
using System.Collections.Generic;

class BallancedParenthesis
{
    static void Main(string[] args)
    {
        char[] parantheses = Console.ReadLine().ToCharArray();

        string openingBrackets = "({[";
        string closingBrackets = ")}]";
        Stack<char> stack = new Stack<char>();
        var brackets = new Dictionary<char, char>();

        brackets.Add(')', '(');
        brackets.Add('}', '{');
        brackets.Add(']', '[');

        if (closingBrackets.Contains(parantheses[0].ToString()) || parantheses.Length % 2 != 0)
        {
            Console.WriteLine("NO");
            Environment.Exit(0);
        }

        foreach (char bracket in parantheses)
        {
            if (openingBrackets.Contains(bracket.ToString()))
            {
                stack.Push(bracket);
            }
            else
            {
                if (stack.Count > 0 && brackets[bracket] == stack.Peek())
                {
                    stack.Pop();
                }
                else
                {
                    Console.WriteLine("NO");
                    Environment.Exit(0);
                }
            }
        }

        if (stack.Count == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}