using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split();

            var numbersToPush = int.Parse(elements[0]);
            var numbersToPop = int.Parse(elements[1]);
            var containsNumber = int.Parse(elements[2]);


            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> numberQueue = new Queue<int>();

            for (int i = 0; i < numbersToPush; i++)
            {
                numberQueue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < numbersToPop; i++)
            {
                numberQueue.Dequeue();
            }
            if (numberQueue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (numberQueue.Contains(containsNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                var minValue = numberQueue.Min();
                Console.WriteLine(minValue);
            }
        }
    }
}
