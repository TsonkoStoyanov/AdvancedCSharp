using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace P05_Calculate_Sequence_with_Queue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();
            List<long> list = new List<long>();
            list.Add(input);
            queue.Enqueue(input);

            for (int i = 0; i < 17; i++)
            {
                long first = queue.Dequeue();

                long second = first + 1;

                long third = 2 * first + 1;

                long fourth = first + 2;

                queue.Enqueue(second);
                queue.Enqueue(third);
                queue.Enqueue(fourth);

                list.Add(second);
                list.Add(third);
                list.Add(fourth);

            }

            Console.WriteLine(string.Join(" ", list.Take(50)));
        }
    }
}
