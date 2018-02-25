//solve problem: extract all sub-expressions in brackets
using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";
            Stack<int> stack = new Stack<int>();
            List<string> results = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                    continue;
                }
                
                if (input[i] == ')')
                {
                    int bracketStartIndex = stack.Pop();
                    int stringLenght = i - bracketStartIndex;
                    string stringBetweenBrackets = input.Substring(bracketStartIndex, stringLenght+1);
                    results.Add(stringBetweenBrackets);
                    Console.WriteLine(stringBetweenBrackets);
                }
            }    
            
        }
    }
}
