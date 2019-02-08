using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_BasicQueueOperations
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

            Queue<int> queue = new Queue<int>(numbersToPush);

            for (int i = 0; i < numbersToPush; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numbersToPop; i++)
            {
                queue.Dequeue();
            }

            bool isContains = queue.Contains(containsNumber);

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (isContains)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(GetMinNumber(queue.ToArray()));
            }
        }

        private static int GetMinNumber(int[] queue)
        {
            int minNumber = Int32.MaxValue;

            for (int i = 0; i < queue.Length; i++)
            {
                int temp = queue[i];

                if (temp < minNumber)
                {
                    minNumber = temp;
                }
            }

            return minNumber;
        }
    }
}
