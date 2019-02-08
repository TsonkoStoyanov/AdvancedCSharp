using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_ReverseNumberWithStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(input);

            //Console.WriteLine(string.Join(" ", stack));

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
                Console.Write(" ");
            }

            Console.WriteLine();

        }
    }
}
