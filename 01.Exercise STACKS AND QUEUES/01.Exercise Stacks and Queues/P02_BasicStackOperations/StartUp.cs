using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_BasicStackOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");

            int numbersToPush = int.Parse(input[0]);
            int numbersToPop = int.Parse(input[1]);
            int containsNumber = int.Parse(input[2]);

            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbersToPush);

            for (int i = 0; i < numbersToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numbersToPop; i++)
            {
                stack.Pop();
            }

            bool isContains = stack.Contains(containsNumber);

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (isContains)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(GetMinNumber(stack.ToArray()));
            }
        }

        private static int GetMinNumber(int[] stack)
        {
            int minNumber = Int32.MaxValue;

            for (int i = 0; i < stack.Length; i++)
            {
                int temp = stack[i];

                if (temp < minNumber)
                {
                    minNumber = temp;
                }
            }

            return minNumber;
        }
    }
}
