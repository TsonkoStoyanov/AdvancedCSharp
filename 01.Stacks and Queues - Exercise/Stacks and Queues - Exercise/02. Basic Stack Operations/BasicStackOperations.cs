using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace _02._Basic_Stack_Operations
{
    class BasicStackOperations
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split();

            var numbersToPush = int.Parse(elements[0]);
            var numbersToPop = int.Parse(elements[1]);
            var containsNumber = int.Parse(elements[2]);
            

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbersStack = new Stack<int>();

            for (int i = 0; i < numbersToPush; i++)
            {
                numbersStack.Push(numbers[i]);
            }
            for (int i = 0; i < numbersToPop; i++)
            {
                numbersStack.Pop();
            }
            if (numbersStack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (numbersStack.Contains(containsNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
               var minValue = numbersStack.Min();
                Console.WriteLine(minValue);
            }
        }
    }
}
