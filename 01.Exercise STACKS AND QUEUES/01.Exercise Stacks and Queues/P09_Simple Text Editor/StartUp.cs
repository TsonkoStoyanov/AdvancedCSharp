using System;
using System.Collections.Generic;

namespace P09_Simple_Text_Editor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());

            string text = String.Empty;

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < operations; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];

                if (command == "1")
                {
                    string currentText = input[1];
                    stack.Push(text);

                    text += currentText;
                }
                else if (command == "2")
                {
                    int count = int.Parse(input[1]);

                    stack.Push(text);

                    text = text.Substring(0, text.Length - count);
                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]);

                    Console.WriteLine(text[index - 1]);
                }
                else if (command == "4")
                {
                    text = stack.Pop();
                }
            }
        }
    }
}
