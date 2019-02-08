using System;
using System.Collections.Generic;

namespace P03_MaximumElement
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();


            for (int i = 0; i < queries; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                switch (input[0])
                {
                    case "1":
                        stack.Push(int.Parse(input[1]));
                        break;
                    case "2":
                        stack.Pop();
                        break;
                    case "3":
                        Console.WriteLine(GetMaxNumer(stack.ToArray()));
                        break;
                }

            }
        }

        private static int GetMaxNumer(int[] stack)
        {
            int maxNumber = Int32.MinValue;

            for (int i = 0; i < stack.Length; i++)
            {
                int temp = stack[i];

                if (temp > maxNumber)
                {
                    maxNumber = temp;
                }
            }

            return maxNumber;
        }
    }
}
