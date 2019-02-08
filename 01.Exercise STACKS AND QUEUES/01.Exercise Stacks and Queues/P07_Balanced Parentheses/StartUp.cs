using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_Balanced_Parentheses
{
    class StartUp
    {
        static void Main()
        {
            string parentheses = Console.ReadLine();

            char[] open = new char[] { '(', '[', '{' };

            bool isValid = true;

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                char currentBraket = parentheses[i];

                if (open.Contains(currentBraket))
                {
                    stack.Push(currentBraket);
                    continue;
                }

                if (stack.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stack.Peek() == '(' && currentBraket == ')')
                {
                    stack.Pop();
                }

                else if (stack.Peek() == '{' && currentBraket == '}')
                {
                    stack.Pop();
                }

                else if (stack.Peek() == '[' && currentBraket == ']')
                {
                    stack.Pop();
                }
            }

            if (isValid && stack.Count==0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
