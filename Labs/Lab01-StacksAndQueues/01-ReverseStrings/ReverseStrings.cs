using System;
using System.Collections.Generic;

class ReverseStrings
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        Stack<char> stack = new Stack<char>(input);

        Console.WriteLine(string.Join("", stack));
    }
}