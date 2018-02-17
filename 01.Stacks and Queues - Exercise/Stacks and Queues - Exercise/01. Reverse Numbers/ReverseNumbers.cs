using System;
using System.Collections.Generic;

namespace _01._Reverse_Numbers
{
    class ReverseNumbers
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine().Split();
            Stack<string> numbersStack = new Stack<string>(numbers);

            while (numbersStack.Count > 0)
            {
                Console.Write(numbersStack.Pop());
                Console.Write(" ");
            }
            Console.WriteLine();
            
        }
    }
}
