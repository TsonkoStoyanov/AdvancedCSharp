using System;
using System.Collections.Generic;

namespace _10._Simple_Text_Editor
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> previousCommands = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] commArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (commArgs[0])
                {
                    case "1":
                        previousCommands.Push(text);
                        text += commArgs[1];
                        break;
                    case "2":
                        previousCommands.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(commArgs[1]));
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(commArgs[1]) - 1]);
                        break;
                    case "4":
                        text = previousCommands.Pop();  
                        break;
                }
            }
        }
    }
}
