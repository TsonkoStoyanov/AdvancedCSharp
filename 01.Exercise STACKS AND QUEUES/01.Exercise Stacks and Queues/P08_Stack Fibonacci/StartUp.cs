using System;
using System.Collections.Generic;

namespace P08_Stack_Fibonacci
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();
            
            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < n-1; i++)
            {
                long first = stack.Pop();
                long second = stack.Peek();

                stack.Push(first);

                stack.Push(first+second);

            }

            Console.WriteLine(stack.Peek());
        }
    }
}
